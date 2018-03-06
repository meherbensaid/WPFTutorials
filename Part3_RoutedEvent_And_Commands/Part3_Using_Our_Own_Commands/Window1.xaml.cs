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
    /// This class contains the Command binding for the simpleCommand RoutedCommand
    /// that is declared in the <see cref="CustomCommands">CustomCommands</see>class.
    /// This Window also declares the Command sink methods, and contains a 
    /// <see cref="UserControlThatUsesCustomCommand">
    /// UserControlThatUsesCustomCommand</see> UserControl which makes use of the
    /// simpleCommand RoutedCommand.
    /// </summary>
    public partial class Window1 : Window
    {
        #region Ctor
        public Window1()
        {
            InitializeComponent();
        }
        #endregion

        #region Command Sinks
        private void simpleCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(string.IsNullOrEmpty(txtCantBeEmpty.Text));
        }

        private void simpleCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(txtCantBeEmpty.Text);
        }
        #endregion
    }
}
