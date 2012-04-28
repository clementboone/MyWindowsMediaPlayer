using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

using MyWindowsMediaPlayer.Model;
using MyWindowsMediaPlayer.View;

namespace MyWindowsMediaPlayer.ViewModel
{
    class FilterViewModel : ViewModelBase
    {
        private Filter _filter;
        private ICommand infoCommand;
        private DialogBox _popup;

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
            this._popup = new PopupTextView();
            this._popup.ShowDialog();
        }
    }
}
