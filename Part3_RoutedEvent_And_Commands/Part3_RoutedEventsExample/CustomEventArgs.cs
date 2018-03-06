using System;
using System.Windows;

namespace Part3_RoutedEventsExample
{
    /// <summary>
    /// CustomEventArgs : a custom event argument class
    /// which simply holds an int value representing 
    /// how many times the associated event has been fired
    /// </summary>
    public class CustomEventArgs : RoutedEventArgs
    {
        #region Instance fields
        public int SomeNumber { get; private set; }
        #endregion

        #region Ctor
        /// <summary>
        /// Constructs a new CustomEventArgs object
        /// using the parameters provided
        /// </summary>
        /// <param name="someNumber">the value for the events args</param>
        public CustomEventArgs(RoutedEvent routedEvent,
            int someNumber)
            : base(routedEvent)
        {
            this.SomeNumber = someNumber;
        }
        #endregion
    }
}

