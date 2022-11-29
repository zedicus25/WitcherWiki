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
using WitcherWiki.ViewModel;

namespace WitcherWiki.View
{
    /// <summary>
    /// Interaction logic for AllCards.xaml
    /// </summary>
    public partial class AllCards : Window
    {
        public AllCards()
        {
            InitializeComponent();
            this.DataContext = new AllCardsVM();
        }
        public AllCards(int chapterId)
        {
            InitializeComponent();
            this.DataContext = new AllCardsVM(chapterId);
        }
    }
}
