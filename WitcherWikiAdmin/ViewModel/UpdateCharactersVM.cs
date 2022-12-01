using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherWikiAdmin.ViewModel
{
    public class UpdateCharactersVM : BaseVM
    {
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

        private Chapter _selectedChapter;

        public Chapter SelectedChapter
        {
            get { return _selectedChapter; }
            set 
            { 
                _selectedChapter = value;
                OnPropertyChanged("SelectedChapter");
                GetChracters();
            }
        }
        private Chapter _newChapter;

        public Chapter NewChapter
        {
            get { return _newChapter; }
            set
            {
                _newChapter = value;
                OnPropertyChanged("NewChapter");
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


        private RelayCommand _updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return _updateCommand ?? new RelayCommand(UpdateData); }
        }

        public UpdateCharactersVM()
        {
            Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
            Characters = new ObservableCollection<Character>();
            NewChapter = new Chapter();
        }

        private void UpdateData()
        {
            if (SelectedCharacter == null || SelectedChapter == null || NewChapter == null)
                return;

            
            var context = new ValidationContext(SelectedCharacter);
            var resValid = new List<ValidationResult>();
            if (Validator.TryValidateObject(SelectedCharacter, context, resValid, true))
            {
                var model = new WitcherModel();
                var character = model.Characters.FirstOrDefault(x => x.Id == SelectedCharacter.Id);
                int oldChapter = character.Chapert_Id;
                character.Name = SelectedCharacter.Name;
                character.Sex = SelectedCharacter.Sex;
                character.Description = SelectedCharacter.Description;
                character.Occupation = SelectedCharacter.Occupation;
                character.Affiliation = SelectedCharacter.Affiliation;
                character.Race = SelectedCharacter.Race;
                character.Image_Url = SelectedCharacter.Image_Url;
                character.Chapert_Id = NewChapter.Id;
                if(model.SaveChanges() > 0)
                {
                    SetMessage("Update character");
                    if(oldChapter != character.Chapert_Id)
                        Characters.Remove(SelectedCharacter);
                    SelectedCharacter = null;
                    NewChapter = null;
                }
                else
                {
                    SetMessage("Cannot save data to database");
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                resValid.ForEach(x => sb.Append(x.ErrorMessage + " "));
                SetMessage(sb.ToString());
            }
        }

        private void GetChracters()
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
            await Task.Delay(5000);
            Message = String.Empty;
        }
    }
}
