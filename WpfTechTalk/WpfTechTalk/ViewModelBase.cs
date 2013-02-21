﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfTechTalk.Annotations;

namespace WpfTechTalk
{
    public class ViewModelBase : INotifyPropertyChanged
    {               
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}