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

namespace Part3_Using_Our_Own_Commands
{

    /// <summary>
    /// This class contains a single button that uses the <see cref="RoutedCommand">
    /// RoutedCommand</see> thats is declared in the class <see cref="CustomCommands">
    /// CustomCommands</see>. The Command sinks for this command is specified in the
    /// <see cref="Window1">Window</see> that contains this control. 
    /// </summary>
    public partial class UserControlThatUsesCustomCommand : UserControl
    {
        #region Ctor
        public UserControlThatUsesCustomCommand()
        {
            InitializeComponent();
        }
        #endregion
    }
}
