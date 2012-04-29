using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class FilterViewModel : ViewModelBase
    {
        private Filter _filter;
        private ICommand infoCommand;

        public Filter Filter { get { return this._filter;  } }
        public string Name
        {
            get
            {
                return this._filter.Name;
            }
        }
        public Filter Parent
        {
            get
            {
                return this._filter.Parent;
            }
        }
        public string Level
        {
            get
            {
                if (this.Parent == null)
                    return "";
                else
                    return " - ";
            }
        }
        public string Type
        {
            get
            {
                if (this.Parent == null)
                    return "Category";
                else
                    return "Filter";
            }
        }
        public FilterViewModel(Filter filter)
        {
            this._filter = filter;
        }

        public ICommand DoubleClickCommand
        {
            get
            {
                if (this.infoCommand == null)
                    this.infoCommand = new RelayCommand(() => this.DoubleClick());

                return this.infoCommand;
            }
        }

        public void DoubleClick()
        {
            Console.WriteLine("Super " + this.Name);
        }
    }
}
