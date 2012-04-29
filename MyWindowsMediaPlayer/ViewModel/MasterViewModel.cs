using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

using MyWindowsMediaPlayer.View;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MasterViewModel : ViewModelBase
    {
        private readonly Library _library;
        private Window _parent;
        private readonly ObservableCollection<FilterViewModel> _filterList;
        private ICollectionView collectionView;
        private ICommand loadCommand;
        private ICommand newFilterCommand;
        public string NewName { get; set; }
        public FilterViewModel SelectedFilter
        {
            get { return this.collectionView.CurrentItem as FilterViewModel; }
        }

        public MasterViewModel(Window parent)
        {
            this._parent = parent;
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
                    this.loadCommand = new RelayCommand(() => this.LoadFolder(), () => this.IsCategoryFolder());

                return this.loadCommand;
            }
        }
        public ICommand NewFilterCommand
        {
            get
            {
                if (this.newFilterCommand == null)
                    this.newFilterCommand = new RelayCommand(() => this.NewFilter(), () => this.IsCategoryFolder());

                return this.newFilterCommand;
            }
        }
        private bool IsCategoryFolder()
        {
            if (this.SelectedFilter.Parent == null)
                return true;
            return false;
        }
        private void NewFilter()
        {
            PopupTextView popUp = new PopupTextView();


    
        }


        private void LoadFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();

            Console.WriteLine(this.NewName + " " + dialog.SelectedPath);
        }



        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            onProprietyChanged("SelectedPerson");
        }
    }
}
