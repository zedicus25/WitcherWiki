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
    public class CharactersVM : BaseVM
    {
		private Chapter _selectedChapter;

		public Chapter SelectedChapter
		{
			get { return _selectedChapter; }
			set 
			{ 
				_selectedChapter = value;
				OnPropertyChanged("SelectedChapter");
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

		private Character _newCharacter;

		public Character NewCharacter
		{
			get { return _newCharacter; }
			set
			{ 
				_newCharacter = value;
				OnPropertyChanged("NewCharacter");
			}
		}

		private RelayCommand _addCharacter;

		public RelayCommand AddCharacterCommand
		{
			get { return _addCharacter ?? new RelayCommand(AddCharacter); }
		}



		public CharactersVM()
		{
			Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
			NewCharacter = new Character();
		}

		private void AddCharacter()
		{
			if (NewCharacter == null || SelectedChapter == null)
				return;
			NewCharacter.Chapert_Id = SelectedChapter.Id;
			var model = new WitcherModel();
            var context = new ValidationContext(NewCharacter);
            var resValid = new List<ValidationResult>();
			if (Validator.TryValidateObject(NewCharacter, context, resValid, true))
			{
				model.Characters.Add(NewCharacter);
				if (model.SaveChanges() > 0)
				{
					SetMessage("Add new character");
					NewCharacter = new Character();
					OnPropertyChanged("NewCharacter");
				}
				else
				{
					SetMessage("Cannot save data");
				}
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				resValid.ForEach(x => sb.Append(x.ErrorMessage + " "));
				SetMessage(sb.ToString());
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
