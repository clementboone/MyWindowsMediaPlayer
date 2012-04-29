using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MyWindowsMediaPlayer.View;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PopupTextViewModel
    {
        public string inputContent { get; set; }
        private PopupTextView view;
        private ICommand okCommand;

        public PopupTextViewModel(Window owner)
        {
            this.inputContent = "";
            view = new PopupTextView();
            view.Owner = owner;
            view.ShowDialog();
        }

        public ICommand ClickCommand
        {
            get
            {
                if (this.okCommand == null)
                    this.okCommand = new RelayCommand(() => this.Click());

                return this.okCommand;
            }
        }

        public void Click()
        {
            Console.WriteLine("Super " + this.inputContent);
        }

    }
}
