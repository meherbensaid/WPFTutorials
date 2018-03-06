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

namespace Part3_RoutedEventsExample
{

    //the event handler delegate
    public delegate void CustomClickWithCustomArgsEventHandler(object sender, CustomEventArgs e);

    /// <summary>
    /// This is a very simple class that simply uses a Button click
    /// event to raise a custom (bubbling) routed event, which can
    /// be subscribed to.
    /// </summary>
    public partial class UserControlThatCreatesEvent : UserControl
    {
        #region Instance Fields
        public int clickedCount { get; private set; }
        #endregion

        #region Our Custom Routed Event Declarations


        #region Using Standard Event Args

        //The actual event routing
        public static readonly RoutedEvent CustomClickEvent = 
            EventManager.RegisterRoutedEvent(
            "CustomClick", RoutingStrategy.Bubble, 
            typeof(RoutedEventHandler), 
            typeof(UserControlThatCreatesEvent));

        //add remove handlers
        public event RoutedEventHandler CustomClick
        {
            add { AddHandler(CustomClickEvent, value); }
            remove { RemoveHandler(CustomClickEvent, value); }
        }
        #endregion


        #region Using Custom Event Args


        //The actual event routing
        public static readonly RoutedEvent CustomClickWithCustomArgsEvent = 
            EventManager.RegisterRoutedEvent(
            "CustomClickWithCustomArgs", RoutingStrategy.Bubble, 
            typeof(CustomClickWithCustomArgsEventHandler), 
            typeof(UserControlThatCreatesEvent));

        //add remove handlers
        public event CustomClickWithCustomArgsEventHandler CustomClickWithCustomArgs
        {
            add { AddHandler(CustomClickWithCustomArgsEvent, value); }
            remove { RemoveHandler(CustomClickWithCustomArgsEvent, value); }
        }
        #endregion 


        #endregion

        #region Ctor
        /// <summary>
        /// Constructs a new UserControlThatCreatesEvent object and ensures that each
        /// of the contained Button object raises the appropraite inyernal 
        /// <see cref="RoutedEvent">RoutedEvent</see>
        /// </summary>
        public UserControlThatCreatesEvent()
        {
            InitializeComponent();
            this.btnRaiseEvent.Click += new RoutedEventHandler(btnRaiseEvent_Click);
            this.btnRaiseEventCustomArgs.Click += new RoutedEventHandler(btnRaiseEventCustomArgs_Click);
           
        }
        #endregion

        #region Private Helpers (to raise the 2 RoutedEvents)
        /// <summary>
        /// The btnRaiseEventCustomArgs button was clicked, so raise the
        /// <see cref="CustomClickWithCustomArgsEvent">CustomClickWithCustomArgsEvent
        /// </see> RoutedEvent
        /// </summary>
        private void btnRaiseEventCustomArgs_Click(object sender, RoutedEventArgs e)
        {
            //raise our custom CustomClickWithCustomArgs event
            CustomEventArgs args = new CustomEventArgs(CustomClickWithCustomArgsEvent, ++clickedCount);
            RaiseEvent(args);            
        }

        /// <summary>
        /// The btnRaiseEvent button was clicked, so raise the
        /// <see cref="CustomClickEvent">CustomClickEvent
        /// </see> RoutedEvent
        /// </summary>
        private void btnRaiseEvent_Click(object sender, RoutedEventArgs e)
        {
            //raise our custom CustomClickEvent event
            RoutedEventArgs args = new RoutedEventArgs(CustomClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
