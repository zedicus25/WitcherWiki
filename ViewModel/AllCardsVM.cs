using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WitcherWiki.Models;

namespace WitcherWiki.ViewModel
{
    public class AllCardsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Character> _characters;


        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        public AllCardsVM()
        {
            Characters = new ObservableCollection<Character>(new WitcherModel().Characters);
        }
        public AllCardsVM(int chapterId)
        {
            Characters = new ObservableCollection<Character>(new WitcherModel().Characters.Where(x => x.Chapert_Id == chapterId));
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
