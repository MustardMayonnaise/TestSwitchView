using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Message
{
    public class ChangeViewMessage
    {
        public string ViewModelName { get; }
        public string ViewKey { get; }

        public ChangeViewMessage(string viewModelName, string viewKey)
        {
            ViewModelName = viewModelName;
            ViewKey = viewKey;
        }
    }
}