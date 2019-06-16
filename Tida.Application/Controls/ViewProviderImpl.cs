using Tida.Application.Contracts.Common;
using Tida.Application.Contracts.Controls;
using System.Windows;


namespace Tida.Application.Controls {
    public class ViewProviderImpl : IViewProvider {
        public ViewProviderImpl(IServiceProvider serviceProvider) {
            this._serviceProvider = serviceProvider;
        }
        private IServiceProvider _serviceProvider;
        public object GetView(string viewName) => _serviceProvider.GetInstance<FrameworkElement>(viewName);
        
    }
}
