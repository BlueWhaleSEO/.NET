using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DonatasSimpleUniversal_MVVM_App.MVVMFramework.MVVMHelpers
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        // Eleminates the need for the null check and eliminates the potential race conditions in multi-threaded code
        // Source: http://www.vicesoftware.com/c/simplified-event-raising-pattern-in-c/ 
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        internal void RaisePropertyChanged(string propertyName)
        {
            // No need for null check because of empty delegate
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
