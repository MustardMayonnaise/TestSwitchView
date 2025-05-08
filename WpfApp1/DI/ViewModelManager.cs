using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows;
using WpfApp1.Message;
using WpfApp1.ViewModel;

namespace WpfApp1.DI
{
    public class ViewModelManager : ObservableObject
    {
        private readonly ViewLocator _viewLocator;

        private object _currentViewModel;
        private object _currentView;
        private string _viewKey;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        // 현재 보여줄 View
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public string ViewKey
        {
            get => _viewKey;
            set => SetProperty(ref _viewKey, value);
        }

        public ViewModelManager(ViewLocator viewLocator)
        {
            _viewLocator = viewLocator;

            WeakReferenceMessenger.Default.Register<ChangeViewMessage>
                (this, (r, m) =>
                {
                    ChangeView(m.ViewModelName, m.ViewKey);
                });
        }

        private void UpdateView(string viewKey)
        {
            string key = CurrentViewModel.GetType().Name + "." + viewKey;
            var newView = _viewLocator.GetView(key);
            if (newView == null)
            {
                key = CurrentViewModel.GetType().Name + "." + ViewKey;
                newView = _viewLocator.GetView(key);
            }
            else
            {
                ViewKey = viewKey;
            }
            // View의 DataContext를 현재 ViewModel로 설정
            if (newView is FrameworkElement element)
            {
                element.DataContext = _currentViewModel;
            }
            CurrentView = newView;
        }

        public void ChangeView(string viewModelName, string viewKey)
        {
            if (CurrentViewModel == null)
            {
                var newViewModel = _viewLocator.GetViewModel(viewModelName);
                if (newViewModel != null)
                {
                    CurrentViewModel = newViewModel;
                    UpdateView(viewKey);
                }
            }

            if (CurrentViewModel.GetType().Name == viewModelName)
            {
                if (!string.IsNullOrEmpty(viewKey))
                {
                    UpdateView(viewKey);
                }
            }
            else
            {
                var newViewModel = _viewLocator.GetViewModel(viewModelName);
                if (newViewModel != null)
                {
                    CurrentViewModel = newViewModel;
                    UpdateView(viewKey);
                }
            }
        }
    }
}