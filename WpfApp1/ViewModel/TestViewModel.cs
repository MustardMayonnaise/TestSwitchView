using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        private int _count;

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public TestViewModel()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) =>
            {
                Count++;
            };
            timer.Start();
        }
    }
}