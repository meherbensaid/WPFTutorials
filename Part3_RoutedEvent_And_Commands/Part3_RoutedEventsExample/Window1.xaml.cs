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
    /// <summary>
    /// Demo application that holds a single UserControl that has 2 Routed Events available.
    /// The UserControlThatCreatesEvent UserControl, exposes 2 events, one of which
    /// uses the standard <see cref="EventArgs">EventArgs</see> and another which uses
    /// a <see cref="CustomEventArgs">CustomEventArgs</see>
    /// </summary>
    public partial class Window1 : Window
    {
        #region Ctor
        /// <summary>
        /// Wires up the 2 UserControlThatCreatesEvent UserControl events
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            #region Event1
            //For the 1st UserControlThatCreatesEvent UserControl event, 
            //the one that doesn't create custom event args lets hook up 2 listeners

            //hook up event listeners on the actual UserControl instance
            this.ucCustomEvent1.CustomClick += new RoutedEventHandler(ucCustomEvent_CustomClick);
            //hook up event listeners on the main window (Window1)
            this.AddHandler(UserControlThatCreatesEvent.CustomClickEvent, new RoutedEventHandler(ucCustomEvent_CustomClick));
            #endregion

            #region Event2
            //For the 2nd UserControlThatCreatesEvent UserControl event, 
            //the one that creates custom event args lets hook up a single listener

            //hook up event listeners on the actual UserControl instance
            this.ucCustomEvent1.CustomClickWithCustomArgs += new CustomClickWithCustomArgsEventHandler(ucCustomEvent1_CustomClickWithCustomArgs);
            #endregion
        }
        #endregion

        #region Event handlers

        /// <summary>
        /// Fired when we see the 1st UserControlThatCreatesEvent UserControl event.
        /// The one with the standard <see cref="EventArgs">EventArgs</see>
        /// </summary>
        private void ucCustomEvent_CustomClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a routed event using standard event args\r\n\r\n" +
                            "________________________________________________\r\n\r\n" +
                            "e.Source : " + sender.ToString() + "\r\n\r\n\r\n" +
                            "e.OriginalSource : " + e.OriginalSource.ToString());
        }

        /// <summary>
        /// Fired when we see the 1st UserControlThatCreatesEvent UserControl event.
        /// The one with the custom <see cref="CustomEventArgs">CustomEventArgs</see>
        /// </summary>
        private void ucCustomEvent1_CustomClickWithCustomArgs(object sender, CustomEventArgs e)
        {
            MessageBox.Show("This is a routed event using custom event args\r\n\r\n" +
                            "That has been clicked " + e.SomeNumber.ToString() + " times\r\n\r\n" +
                            "_______________________________________________\r\n\r\n" +
                            "e.Source : " + sender.ToString() + "\r\n\r\n\r\n" +
                            "e.OriginalSource : " + e.OriginalSource.ToString());
        }


        #endregion

        private void UserControlThatCreatesEvent_CustomClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
        }
    }
}
