using System;
using System.Collections.Generic;
using WpfApp1.ViewModel;
using WpfApp1.View;

namespace WpfApp1.DI
{
    public class ViewLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly Dictionary<string, Type> _viewModelMap = new Dictionary<string, Type>()
        {
            { "TestViewModel", typeof(TestViewModel) },
            { "HiViewModel", typeof(HiViewModel) }
            // 추가
        };

        private readonly Dictionary<string, Type> _viewMap = new Dictionary<string, Type>()
        {
            { "TestViewModel.Default", typeof(testview1)},
            { "TestViewModel.red", typeof(testview2) },
            { "HiViewModel.Default", typeof(hiView) },
            { "HiViewModel.red", typeof(hiView2) }
            // 추가
        };

        public object GetViewModel(string viewModelName)
        {
            if (_viewModelMap.TryGetValue(viewModelName, out var type))
                return _serviceProvider.GetService(type);

            return null;
        }

        public object GetView(string viewKey)
        {
            if (_viewMap.TryGetValue(viewKey, out var type))
                return _serviceProvider.GetService(type);
            return null;
        }
    }
}