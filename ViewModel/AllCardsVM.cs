using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WitcherWiki.Models;
using WitcherWiki.View;

namespace WitcherWiki.ViewModel
{
    public class AllCardsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Character> _characters;

        private Character _selectedCharacter;

        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set 
            { 
                _selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
                ShowInformation();
            }
        }

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set 
            { 
                _characters = value; 
                OnPropertyChanged("Characters");
            }
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

        private void ShowInformation()
        {
            FullCardInformation fullCard = new FullCardInformation(SelectedCharacter);
            fullCard.Show();
        }
    }
}
