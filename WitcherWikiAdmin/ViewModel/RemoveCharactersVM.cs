using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherWikiAdmin.ViewModel
{
    public class RemoveCharactersVM : BaseVM
    {
        private Chapter _selectedChapter;

        public Chapter SelectedChapter
        {
            get { return _selectedChapter; }
            set
            {
                _selectedChapter = value;
                OnPropertyChanged("SelectedChapter");
                UpdateCharacters();
            }
        }


        private ObservableCollection<Chapter> _chapters;

        public ObservableCollection<Chapter> Chapters
        {
            get { return _chapters; }
            set
            {
                _chapters = value;
                OnPropertyChanged("Chapters");
            }
        }
        private ObservableCollection<Character> _characters;

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged("Characters");
            }
        }

        private Character _selectedCharacter;

        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set 
            { 
                _selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private RelayCommand _removeCommand;

        public RelayCommand RemoveCommand
        {
            get { return _removeCommand ?? new RelayCommand(RemoveData); }
        }


        public RemoveCharactersVM()
        {
            Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
            Characters = new ObservableCollection<Character>();
        }

        private void RemoveData()
        {
            if (SelectedCharacter == null)
                return;

            var model = new WitcherModel();
            var character = model.Characters.FirstOrDefault(x => x.Id == SelectedCharacter.Id);
            model.Characters.Remove(character);
            if(model.SaveChanges() > 0)
            {
                SetMessage("Remove character");
                Characters.Remove(SelectedCharacter);
                SelectedCharacter = null;
            }
            else
            {
                SetMessage("Cannot save data");
            }

        }

        private void UpdateCharacters()
        {
            if (SelectedChapter == null)
                return;
            Characters.Clear();
            foreach (var item in new WitcherModel().Characters.Where(x => x.Chapert_Id == SelectedChapter.Id))
            {
                Characters.Add(item);
            }
        }

        private async void SetMessage(string msg)
        {
            Message = msg;
            await Task.Delay(3000);
            Message = String.Empty;
        }
    }
}
