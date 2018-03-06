using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Part3_RoutedEventViewer
{
    /// <summary>
    /// Demo application that displays some data about the events 
    /// that were recieved by a users actions. Which allows users
    /// to see the difference between tunneling/routed events
    /// </summary>
    public partial class Window1 : Window
    {
        #region Ctor
        /// <summary>
        /// Wires up several of the standard <see cref="FrameworkElement">
        /// FrameworkElement</see> Tunneling/Bubbling <see cref="RoutedEvent">RoutedEvents</see>.
        /// This demo also displays some data about the events that were recieved by
        /// a users actions.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            UIElement[] els = { this, gridMain, btnTop, lvResults };
            foreach (UIElement el in els)
            {
                //keyboard
                el.PreviewKeyDown += GenericHandler;
                el.PreviewKeyUp += GenericHandler;
                el.PreviewTextInput += GenericHandler;
                el.KeyDown += GenericHandler;
                el.KeyUp += GenericHandler;
                el.TextInput += GenericHandler;

                //Mouse
                el.MouseDown += GenericHandler;
                el.MouseUp += GenericHandler;
                el.PreviewMouseDown += GenericHandler;
                el.PreviewMouseUp += GenericHandler;

                //Stylus
                el.StylusDown += GenericHandler;
                el.StylusUp += GenericHandler;
                el.PreviewStylusDown += GenericHandler;
                el.PreviewStylusUp += GenericHandler;

                el.AddHandler(Button.ClickEvent, new RoutedEventHandler(GenericHandler));
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates a new <see cref="EventDemoClass">EventDemoClass</see>
        /// to represent the <see cref="RoutedEvent">RoutedEvent</see>.
        /// And adds this new EventDemoClass to the listbox
        /// </summary>
        private void GenericHandler(object sender, RoutedEventArgs e)
        {

            lvResults.Items.Add(new EventDemoClass()
            {
                RoutedEventName = e.RoutedEvent.Name,
                SenderName = typeWithoutNamespace(sender),
                ArgsSource = typeWithoutNamespace(e.Source),
                OriginalSource = typeWithoutNamespace(e.OriginalSource)
            });

        }
        /// <summary>
        /// Returns the type name without the namespace portion
        /// </summary>
        private string typeWithoutNamespace(object obj)
        {
            string[] astr = obj.GetType().ToString().Split('.');
            return astr[astr.Length - 1];
        }

        /// <summary>
        /// Clears the listbox of events
        /// </summary>
        private void btnClearItems_Click(object sender, RoutedEventArgs e)
        {
            lvResults.Items.Clear();
        }
        #endregion
    }

    #region EventDemoClass CLASS
    /// <summary>
    /// A simpy data class that is used to display event data
    /// </summary>
    public class EventDemoClass
    {
        public string RoutedEventName { get; set; }
        public string SenderName { get; set; }
        public string ArgsSource { get; set; }
        public string OriginalSource { get; set; }
    }
    #endregion
}
