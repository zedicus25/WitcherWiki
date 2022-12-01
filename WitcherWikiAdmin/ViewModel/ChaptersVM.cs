using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WitcherWikiAdmin.ViewModel
{
    public class ChaptersVM : BaseVM
    {
		private string _chapterName;

		public string ChapterName
		{
			get { return _chapterName; }
			set 
			{ 
				_chapterName = value;
				OnPropertyChanged("ChapterName");
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


		private RelayCommand _addCommand;

		public RelayCommand AddCommand
		{
			get { return _addCommand ?? new RelayCommand(AddData); }
		}

        private RelayCommand _removeCommand;

        public RelayCommand RemoveCommand
        {
            get { return _removeCommand ?? new RelayCommand(RemoveData); }
        }

        public ChaptersVM()
		{
			Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
		}

		private void RemoveData()
		{
			if (SelectedChapter == null)
				return;
			var model = new WitcherModel();
			var chapter = model.Chapters.FirstOrDefault(x => x.Id == SelectedChapter.Id);
			model.Chapters.Remove(chapter);
			if (model.SaveChanges() > 0)
			{
                Chapters.Remove(SelectedChapter);
                SetMessage("Remove chapter");
			}
			else
			{
                SetMessage("Cannot save data to database");
            }
				
		}

		private  void AddData()
		{
			if (ChapterName.Equals(String.Empty))
				return;

			var model = new WitcherModel();
			Chapter chapter = new Chapter();
			chapter.Chapter_Name = ChapterName;
            var context = new ValidationContext(chapter);
            var resValid = new List<ValidationResult>();
            if (Validator.TryValidateObject(chapter, context, resValid, true))
            {
				model.Chapters.Add(chapter);
				if (model.SaveChanges() > 0)
				{
					SetMessage("Add new chapter");
                    ChapterName = String.Empty;
                    Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
                    OnPropertyChanged("Chapters");
				}
				else
				{
                    SetMessage("Cannot save data to database");
                }
			}
			else
			{
                SetMessage("Incorrect chapter name");
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
