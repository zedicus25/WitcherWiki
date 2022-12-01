using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitcherWikiAdmin.ViewModel
{
    public class MainVM :BaseVM
    {
        public BaseVM SelectedViewModel
        {
            get => _selectedVM;
            set
            {
                _selectedVM = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        private BaseVM _selectedVM;

        private RelayCommand _showChapters;

        public RelayCommand ShowChapters
        {
            get { return _showChapters ?? (_showChapters = new RelayCommand(() =>
            {
                SelectedViewModel = new ChaptersVM();
            })); }

        }

        private RelayCommand _showCharacters;

        public RelayCommand ShowCharacters
        {
            get { return _showCharacters ?? (_showChapters = new RelayCommand(() =>
            {
                SelectedViewModel = new CharactersVM();
            })); }
        }

        private RelayCommand _updateChapters;

        public RelayCommand UpdateChapters
        {
            get { return _updateChapters ?? new RelayCommand(() =>
            {
                SelectedViewModel = new UpdateChaptersVM();
            }); }
        }

        private RelayCommand _updateCharacters;

        public RelayCommand UpdateCharacters
        {
            get
            {
                return _updateCharacters ?? new RelayCommand(() =>
                {
                    SelectedViewModel = new UpdateCharactersVM();
                });
            }
        }

        private RelayCommand _removeCharacters;

        public RelayCommand RemoveCharacters
        {
            get
            {
                return _removeCharacters ?? new RelayCommand(() =>
                {
                    SelectedViewModel = new RemoveCharactersVM();
                });
            }
        }

    }
}
