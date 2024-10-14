///The INotifier interface is a valuable tool for WPF applications, 
///simplifying the implementation of the INotifyPropertyChanged interface and reducing 
///boilerplate code in property setters. By using this interface, you can ensure 
///that the application's UI stays responsive and up-to-date with 
///changes in the underlying data model.
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooSimulatorLibrary.Notifiers
{
    /// <summary>
    /// Defines methods for notifying property changes and updating properties with change notification in WPF applications.
    /// Simplifies the implementation of <see cref="INotifyPropertyChanged"/> for data binding.
    /// </summary>
    public interface INotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Updates the property's backing field and raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event if the value has changed.
        /// This method simplifies property setters in WPF by handling value comparison, assignment, and notification.
        /// </summary>
        /// <typeparam name="M">The type of the property.</typeparam>
        /// <param name="value">The new value to set for the property.</param>
        /// <param name="backProp">The backing field that holds the property's current value.</param>
        /// <param name="propName">
        /// The name of the property. This parameter is optional and is automatically supplied by the compiler.
        /// </param>
        void UpdateProperty<M>(ref M value, ref M backProp, [CallerMemberName] string propName = "");

        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event for the specified property.
        /// This method is used to notify the UI of property changes, essential for data binding in WPF.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        void RaisePropertyChanged(string propertyName);
    }

}