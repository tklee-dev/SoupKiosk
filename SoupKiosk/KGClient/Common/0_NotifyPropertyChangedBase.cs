using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class NotifyPropertyChangedBase : DisposeBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _PropertyChanged += value;
            remove => _PropertyChanged -= value;
        }

        private PropertyChangedEventHandler _PropertyChanged;

        protected void RaisePropertyChanged(string propertyName = "")
        {
        //    if (Anytek_Devices.RaisePropertyChangedEvent == false)
        //        return;

            //공백 또는 Null 전송시 전체 프로퍼티가 업데이트 된다.
            _PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected bool SetProperty<T>(ref T prop, T value, Action propertyChangedAction = null, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(prop, value))
                return false;

            prop = value;
            propertyChangedAction?.Invoke();

            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
