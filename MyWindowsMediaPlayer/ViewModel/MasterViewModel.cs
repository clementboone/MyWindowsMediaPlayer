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
        private readonly Library _library;
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
            get { return this.audioCollectionView.CurrentItem as AudioViewModel; }
        }
        public ObservableCollection<AudioViewModel> MusicList
        {
            get { return this._musicList; }
        }
        private string test;
        public string Test
        {
            get
            {
                return this.test;
            }
            set
            {
                this.test = value;
                onProprietyChanged("Test");
            }
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
            this.filterCollectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);
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
            this.audioCollectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);
        }
        public MasterViewModel(Window parent)
        {
            this._parent = parent;
            this._library = new Library();
            this._musicList = null;
            this.Test = "Cacao";
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
                    this.newFilterCommand = new RelayCommand(() => this.NewFilter(), () => this.IsCategoryFolder());

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
                    this.renameCommand = new RelayCommand(() => this.Rename());

                return this.renameCommand;
            }
        }

        private void Rename()
        {
            Console.WriteLine("Rename");
            if (this.Test == "Cacao")
                this.Test = "Chocola";
            else
                this.Test = "Cacao";
        }


        private void LoadMediaList()
        {
            this._musicLibrary = new MediaList<Audio>(@"C:\Users\Admin\Desktop\projets\Visual\Src\MyWindowsMediaPlayer\MyWindowsMediaPlayer\Conf\Library.Musics.xml", this.SelectedFilter.Filter);
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
            MediaList<Audio> tempList = new MediaList<Audio>(@"C:\Users\Admin\Desktop\projets\Visual\Src\MyWindowsMediaPlayer\MyWindowsMediaPlayer\Conf\Library.Musics.xml", this.SelectedFilter.Filter);
            if (dialog.SelectedPath != "")
               tempList.loadFolder(dialog.SelectedPath);
        }

        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            onProprietyChanged("SelectedPerson");
        }
    }
}
