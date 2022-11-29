using GalaSoft.MvvmLight.CommandWpf;
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
    public class ChaptersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Chapter> _chapters;


        public ObservableCollection<Chapter> Chapters
        {
            get { return _chapters; }
            set { _chapters = value; }
        }

        private Chapter _selectedChapter;

        public Chapter SelectedChapter
        {
            get { return _selectedChapter; }
            set { _selectedChapter = value; }
        }

        private RelayCommand _showCommand;

        public RelayCommand ShowCommand
        {
            get { return _showCommand ?? (_showCommand = new RelayCommand(ShowCharacters)); }
        }


        public ChaptersViewModel()
        {
            Chapters = new ObservableCollection<Chapter>(new WitcherModel().Chapters);
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ShowCharacters()
        {
            if (SelectedChapter == null)
                return;
            AllCards cards = new AllCards(SelectedChapter.Id);
            cards.ShowDialog();
        }
    }
}
