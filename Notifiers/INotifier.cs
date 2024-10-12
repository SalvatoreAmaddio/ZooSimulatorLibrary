using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooSimulatorLibrary.Notifiers
{
    public interface INotifier : INotifyPropertyChanged
    {
        void UpdateProperty<M>(ref M value, ref M backProp, [CallerMemberName] string propName = "");
        void RaisePropertyChanged(string propertyName);
    }
}