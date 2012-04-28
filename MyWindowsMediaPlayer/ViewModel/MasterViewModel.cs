using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MasterViewModel : ViewModelBase
    {
        private readonly Library _library;
        private readonly ObservableCollection<FilterViewModel> _filterList;
        private ICollectionView collectionView;
        private ICommand infoCommand;
        private ICommand loadCommand;
        public FilterViewModel SelectedFilter
        {
            get { return this.collectionView.CurrentItem as FilterViewModel; }
        }

        public MasterViewModel()
        {
            this._library = new Library();
            this._filterList = new ObservableCollection<FilterViewModel>();
            foreach (Filter category in this._library.Categories)
            {
                this._filterList.Add(new FilterViewModel(category));
                if (category.Filters != null)
                {
                    foreach (Filter filter in category.Filters)
                    {
                        this._filterList.Add(new FilterViewModel(filter));
                    }
                }
            }
            this.collectionView = CollectionViewSource.GetDefaultView(this._filterList);
            if(this.collectionView == null)
                throw new NullReferenceException("collectionView");
            this.collectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);
        }

        public ObservableCollection<FilterViewModel> FilterList
        {
            get { return this._filterList; }
        }
        public ICommand LoadFolderCommand
        {
            get
            {
                if (this.loadCommand == null)
                    this.loadCommand = new RelayCommand(() => this.LoadFolder(), () => this.CanLoadFolder());

                return this.loadCommand;
            }
        }
        public ICommand InfoCommand
        {
            get
            {
                if (this.infoCommand == null)
                    this.infoCommand = new RelayCommand(() => this.InfoFilter());

                return this.infoCommand;
            }
        }

        private void InfoFilter()
        {
            this.FilterList.Add(new FilterViewModel(new Filter("Toto", null)));
        }


        private void LoadFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();

            Console.WriteLine(dialog.SelectedPath);
        }
        private bool CanLoadFolder()
        {
            if (this.SelectedFilter.Parent == null)
                return true;
            return false;
        }
        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            onProprietyChanged("SelectedPerson");
        }
    }
}
