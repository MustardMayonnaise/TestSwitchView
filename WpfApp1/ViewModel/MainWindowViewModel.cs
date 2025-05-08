using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DI;
using WpfApp1.Message;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly ViewModelManager _viewModelManager;
        private object _currentView;
        private object _currentViewModel;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MainWindowViewModel(ViewModelManager viewModelManager)
        {
            _viewModelManager = viewModelManager;
            _viewModelManager.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ViewModelManager.CurrentView))
                {
                    CurrentView = _viewModelManager.CurrentView;
                }
                if (e.PropertyName == nameof(ViewModelManager.CurrentViewModel))
                {
                    CurrentViewModel = _viewModelManager.CurrentViewModel;
                }
            };

            WeakReferenceMessenger.Default.Send(new ChangeViewMessage("TestViewModel", "Default"));
        }

        public RelayCommand<string> ChangeViewCommand => new RelayCommand<string>(cmd => ConvertChangeView());

        private bool test = false;

        private void ConvertChangeView()
        {
            string key = test ? "Default" : "red";
            test = !test;
            ChangeView(CurrentViewModel.GetType().Name, key);
        }

        private void ChangeView(string viewModelName, string key)
        {
            WeakReferenceMessenger.Default.Send(new ChangeViewMessage(viewModelName, key));
        }
    }
}