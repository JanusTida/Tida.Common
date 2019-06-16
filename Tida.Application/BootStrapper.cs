using Tida.Application.Common;
using Tida.Application.Contracts.App;
using Tida.Application.Contracts.App.Events;
using Tida.Application.Contracts.Common;
using Tida.Application.Contracts.Controls;
using Tida.Application.Contracts.Setting;
using Tida.Application.Contracts.Splash;
using Tida.Application.Controls;
using Microsoft.Practices.ServiceLocation;
using Prism.Mef;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Tida.Application {
    /// <summary>
    /// 启动"精灵",本类在程序初始化时进行全局公共服务(ServiceProvider,语言及其他)的初始化;
    /// </summary>
    public static class BootStrapper {
        private static readonly BootStrapperInternal _bootStrapper = new BootStrapperInternal();
        /// <summary>
        /// 通过指定类型的集合,向容器中添加这些类型所在的程序集模块;
        /// </summary>
        /// <param name="moduleTypes"></param>
        public static void AddAssemblyModules(IEnumerable<Type> moduleTypes) {

            if (moduleTypes == null) {
                throw new ArgumentNullException(nameof(moduleTypes));
            }

            _bootStrapper.AddAssemblyModules(moduleTypes);
        }

        /// <summary>
        /// 根据给定的模块,进行框架的初始化操作;
        /// </summary>
        /// <param name="moduleTypes">在需要被加载的Assembly中的类型</param>
        public static void Run() {

            _bootStrapper.Run();

        }

        /// <summary>
        /// 模块正在初始化事件;
        /// </summary>
        public static event EventHandler ModulesInitializing {
            add { _bootStrapper.ModulesInitializing += value; }
            remove { _bootStrapper.ModulesInitializing -= value; }
        }

        /// <summary>
        /// 模块初始化完毕事件;
        /// </summary>
        public static event EventHandler ModulesInitialized {
            add => _bootStrapper.ModulesInitialized += value;
            remove => _bootStrapper.ModulesInitialized -= value;
        }
    }

    class BootStrapperInternal : MefBootstrapper {
        /// <summary>
        /// 初始化所有模块;
        /// </summary>
        /// <param name="moduleTypes">在需要被加载的Assembly中的类型集合</param>
        public void AddAssemblyModules(IEnumerable<Type> moduleTypes) {
            if (moduleTypes == null) {
                throw new ArgumentNullException(nameof(moduleTypes));
            }
            
            this._assemblies = moduleTypes.Select(p => p.Assembly).Distinct().ToArray();
        }

        /// <summary>
        /// 模块正在初始化事件;
        /// </summary>
        public event EventHandler ModulesInitializing;

        /// <summary>
        /// 模块初始化完毕事件;
        /// </summary>
        public event EventHandler ModulesInitialized;

        private Assembly[] _assemblies;
        
        protected override void ConfigureAggregateCatalog() {
            base.ConfigureAggregateCatalog();

            //主框架模块;
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Dummy).Assembly));
            //附加模块;
            if(_assemblies != null) {
                foreach (var asm in _assemblies) {
                    this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(asm));
                }
            }
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType => {
                var viewSpace = viewType.Namespace;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly;
                var viewName = viewType.Name;
                try {
                    var lowerSpace = viewSpace.Substring(0, viewSpace.LastIndexOf("Views"));
                    var viewModelName = $"{lowerSpace}ViewModels.{viewName}ViewModel,{viewAssemblyName}";
                    return Type.GetType(viewModelName);
                }
                catch {
                    return null;
                }
            });
        }

        protected override IModuleCatalog CreateModuleCatalog() {
            return new ConfigurationModuleCatalog();
        }

        protected override void InitializeModules() {
            ServiceProvider.SetServiceProvider(new ServiceProviderWrapper(ServiceLocator.Current));
            ViewProvider.SetViewProvider(new ViewProviderImpl(ServiceProvider.Current));
            
            //应用程序域服务初始化;
            AppDomainService.Current.Initialize();
            //因为各个模块都可能用到语言服务,必须先初始化语言服务;
            LanguageService.Current.Initialize();

            

            //初始化设定服务;
            SettingsService.Current.Initialize();

            base.InitializeModules();
            ModulesInitializing?.Invoke(this, EventArgs.Empty);

            CommonEventHelper.GetEvent<ApplicationStartUpEvent>().Publish();
            CommonEventHelper.PublishEventToHandlers<IApplicationStartUpEventHandler>();


        }


    }
}
