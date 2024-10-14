///The AbstractModel class is a foundational component in your application's architecture, 
///facilitating efficient and consistent property change notification across all data models.
///By inheriting from AbstractNotifier, it streamlines the implementation of data binding in 
///WPF applications, adhering to best practices in the MVVM pattern.
using ZooSimulatorLibrary.Notifiers;

namespace ZooSimulatorLibrary.Models
{
    /// <summary>
    /// An abstract base class for data models in the application, providing property change notification functionality.
    /// Inherits from <see cref="AbstractNotifier"/> to support data binding in WPF applications.
    /// </summary>
    public abstract class AbstractModel : AbstractNotifier
    {
    }
}