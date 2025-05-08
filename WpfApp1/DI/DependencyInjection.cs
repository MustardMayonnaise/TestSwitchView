using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;
using WpfApp1.View;

namespace WpfApp1.DI
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ViewLocator>();
            services.AddSingleton<ViewModelManager>();

            services.AddTransient<testview1>();
            services.AddTransient<testview2>();
            services.AddTransient<hiView>();
            services.AddTransient<hiView2>();

            services.AddTransient<HiViewModel>();
            services.AddTransient<TestViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}