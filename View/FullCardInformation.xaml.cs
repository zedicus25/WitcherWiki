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
using System.Windows.Shapes;
using WitcherWiki.Models;

namespace WitcherWiki.View
{
    /// <summary>
    /// Interaction logic for FullCardInformation.xaml
    /// </summary>
    public partial class FullCardInformation : Window
    {
        public FullCardInformation()
        {
            InitializeComponent();
        }

        public FullCardInformation(Character selectedCharacter)
        {
            InitializeComponent();
            this.DataContext = selectedCharacter;
        }
    }
}
