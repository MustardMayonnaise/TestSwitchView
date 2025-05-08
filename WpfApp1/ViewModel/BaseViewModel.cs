using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.DI;
using WpfApp1.Message;

namespace WpfApp1.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
        }

        public RelayCommand<string> ChangeViewCommand => new RelayCommand<string>(cmd =>
        {
            WeakReferenceMessenger.Default.Send(new ChangeViewMessage(cmd, ""));
        });
    }
}