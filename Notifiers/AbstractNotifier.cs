using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooSimulatorLibrary.Notifiers
{
    public abstract class AbstractNotifier : INotifier
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void UpdateProperty<M>(ref M value, ref M backProp, [CallerMemberName] string propName = "") 
        {
            backProp = value;
            RaisePropertyChanged(propName);
        }

        public void RaisePropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}