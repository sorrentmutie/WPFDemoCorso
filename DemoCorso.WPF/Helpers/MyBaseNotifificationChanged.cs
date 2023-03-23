using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoCorso.Helpers
{
    public class MyBaseNotifificationChanged : INotifyPropertyChanged
    {
        public void SetProperty<T>(ref T member, T value, [CallerMemberName]string propertyName = "")
        {
            if(object.Equals(member, value)) return;
            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
