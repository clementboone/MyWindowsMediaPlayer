using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWindowsMediaPlayer.View
{
    /// <summary>
    /// Logique d'interaction pour PopupTextView.xaml
    /// </summary>
    public partial class PopupTextView : Window
    {
        public PopupTextView()
        {
            InitializeComponent();
        }
        public void ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
