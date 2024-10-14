///The AbstractNotifier class provides a convenient base for view models and other classes 
///that require property change notification in WPF applications. 
///By abstracting the common pattern of updating properties and raising change notifications, 
///it reduces boilerplate code and simplifies maintenance.
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooSimulatorLibrary.Notifiers
{
    /// <summary>
    /// An abstract base class that implements the <see cref="INotifier"/> interface.
    /// Provides functionality for property change notification in WPF applications.
    /// </summary>
    public abstract class AbstractNotifier : INotifier
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Updates the property's backing field and raises the <see cref="PropertyChanged"/> event.
        /// Simplifies property setters in classes that implement data binding.
        /// </summary>
        /// <typeparam name="M">The type of the property.</typeparam>
        /// <param name="value">The new value to assign to the property.</param>
        /// <param name="backProp">The backing field that stores the property's current value.</param>
        /// <param name="propName">
        /// The name of the property. This parameter is optional and is automatically supplied by the compiler.
        /// </param>
        public void UpdateProperty<M>(ref M value, ref M backProp, [CallerMemberName] string propName = "")
        {
            backProp = value;
            RaisePropertyChanged(propName);
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the specified property.
        /// Notifies any listeners that the property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}