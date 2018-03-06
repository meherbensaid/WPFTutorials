using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input; //for the 

namespace Part3_Using_Our_Own_Commands
{

    /// <summary>
    /// Declare a new <see cref="RoutedCommand">RoutedCommand</see> that
    /// is used by the <see cref="Window1">Window1</see> class where the 
    /// Command bindings and Command Sink events are declared. The Actual
    /// Comman is used on a Button within the <see cref="UserControlThatUsesCustomCommand">
    /// UserControlThatUsesCustomCommand</see> UserControl
    /// </summary>
    public class CustomCommands
    {
        #region Instance Fields
        public static readonly RoutedCommand simpleCommand = new RoutedCommand("simpleCommand",typeof(CustomCommands));
        #endregion
    }
}
