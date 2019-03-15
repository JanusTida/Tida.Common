using CDO.Common.Application.Contracts.Common;
using CDO.Common.Application.Contracts.Controls;
using System.Windows;


namespace CDO.Common.Application.Controls {
    public class ViewProviderImpl : IViewProvider {
        public ViewProviderImpl(IServiceProvider serviceProvider) {
            this._serviceProvider = serviceProvider;
        }
        private IServiceProvider _serviceProvider;
        public object GetView(string viewName) => _serviceProvider.GetInstance<FrameworkElement>(viewName);
        
    }
}
