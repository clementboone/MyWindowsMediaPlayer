using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

using MyWindowsMediaPlayer.View;
using MyWindowsMediaPlayer.Model;
using Player;
using Player.Video;
using Player.Audio;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MasterViewModel : ViewModelBase
    {
        private Window _parent;
        private Library _library;
        private readonly ObservableCollection<FilterViewModel> _filterList;
        private ICollectionView filterCollectionView;
        public FilterViewModel SelectedFilter
        {
            get { return this.filterCollectionView.CurrentItem as FilterViewModel; }
        }
        public ObservableCollection<FilterViewModel> FilterList
        {
            get { return this._filterList; }
        }

        private MediaList<Audio> _musicLibrary;
        private readonly ObservableCollection<AudioViewModel> _musicList;
        private ICollectionView audioCollectionView;
        public AudioViewModel SelectedTrack
        {
            get { return (this.audioCollectionView != null && this.audioCollectionView.CurrentItem != null) ? this.audioCollectionView.CurrentItem as AudioViewModel : null;  }
        }

        public ObservableCollection<AudioViewModel> MusicList
        {
            get { return this._musicList; }
        }

        private ICommand newFilterCommand;
        private ICommand loadCommand;
        private ICommand loadMediaListCommand;
        private ICommand renameCommand;

        public string NewName { get; set; }


        private void setFilterCollectionView()
        {
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
            this.filterCollectionView = CollectionViewSource.GetDefaultView(this._filterList);
            if (this.filterCollectionView == null)
                throw new NullReferenceException("filterCollectionView");
            this.filterCollectionView.CurrentChanged += new EventHandler(this.OnFilterCollectionViewCurrentChanged);
        }
        private void setMusicCollectionView()
        {
            foreach (Audio model in this._musicLibrary.MediasList)
            {
                this._musicList.Add(new AudioViewModel(model));
            }
            this.audioCollectionView = CollectionViewSource.GetDefaultView(this._musicList);
            if (this.audioCollectionView == null)
                throw new NullReferenceException("audioCollectionView");
            this.audioCollectionView.CurrentChanged += new EventHandler(this.OnMusicCollectionViewCurrentChanged);
        }
        public MasterViewModel(Window parent)
        {
            this._parent = parent;
            this._library = new Library();
            this._musicList = null;
            this._filterList = new ObservableCollection<FilterViewModel>();
            this._musicList = new ObservableCollection<AudioViewModel>();
            this.setFilterCollectionView();
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
                    this.newFilterCommand = new RelayCommand(() => this.NewFilter(), () => false);

                return this.newFilterCommand;
            }
        }
        public ICommand LoadMediaListCommand
        {
            get
            {
                if (this.loadMediaListCommand == null)
                    this.loadMediaListCommand = new RelayCommand(() => this.LoadMediaList(), () => this.IsCategoryFolder());

                return this.loadMediaListCommand;
            }
        }
        public ICommand RenameCommand
        {
            get
            {
                if (this.renameCommand == null)
                    this.renameCommand = new RelayCommand(() => this.LoadLib());

                return this.renameCommand;
            }
        }

        private void LoadLib()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.DefaultExt = "xml";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {

                this._filterList.Clear();
                this._library = new Library(dialog.FileName);
                this.setFilterCollectionView();
            }
        }

        private void LoadMediaList()
        {
            this._musicList.Clear();
            this._musicLibrary = new MediaList<Audio>(Properties.Settings.Default.MusicPath, this.SelectedFilter.Filter);
            this.setMusicCollectionView();
            onProprietyChanged("MusicList");
        }

        private bool IsCategoryFolder()
        {
            if (this.SelectedFilter != null && this.SelectedFilter.Parent == null)
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
            MediaList<Audio> tempList = new MediaList<Audio>(Properties.Settings.Default.MusicPath, this.SelectedFilter.Filter);
            if (dialog.SelectedPath != "")
                tempList.loadFolder(dialog.SelectedPath);
        }

        private void OnFilterCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            onProprietyChanged("SelectedFilter");
        }

        private void OnMusicCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            onProprietyChanged("SelectedTrack");
        }
    }
}
