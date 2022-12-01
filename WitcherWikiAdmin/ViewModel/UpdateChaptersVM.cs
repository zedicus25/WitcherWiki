using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherWikiAdmin.ViewModel
{
    public class UpdateChaptersVM : BaseVM
    {
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

		private RelayCommand _updateCommand;

		public RelayCommand UpdateCommand
		{
			get { return _updateCommand ?? new RelayCommand(UpdateChapters); }
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

        public UpdateChaptersVM()
		{
			Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
		}

		private void UpdateChapters()
		{
			if (SelectedChapter == null)
				return;
            var model = new WitcherModel();
            var chapter = model.Chapters.FirstOrDefault(x => x.Id == SelectedChapter.Id);
            chapter.Chapter_Name = SelectedChapter.Chapter_Name;
            if (model.SaveChanges() > 0)
            {
                SetMessage("Update chapter");
                SelectedChapter = null;
            }
            else
            {
                SetMessage("Cannot save data to database");
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
