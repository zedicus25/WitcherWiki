using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WitcherWikiAdmin.View
{
    /// <summary>
    /// Interaction logic for UpdateCharactersControl.xaml
    /// </summary>
    public partial class UpdateCharactersControl : UserControl
    {
        public UpdateCharactersControl()
        {
            InitializeComponent();
        }

        private void chracterLB_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Console.WriteLine("some");
        }
    }
}
