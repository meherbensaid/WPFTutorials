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

namespace Part3_Using_Built_In_Commands
{
    /// <summary>
    /// This Window simply uses some of the built in Application.Commands
    /// have a look at the following MSDN link for more details
    /// http://www.google.co.uk/search?hl=en&client=firefox-a&rls=org.mozilla%3Aen-GB%3Aofficial&hs=46Z&q=ApplicationCommands&btnG=Search&meta=
    /// </summary>
    public partial class Window1 : Window
    {
        #region Ctor
        public Window1()
        {
            InitializeComponent();
        }
        #endregion
    }
}
