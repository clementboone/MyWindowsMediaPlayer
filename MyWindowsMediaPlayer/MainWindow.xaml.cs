using System.Windows;
using MyWindowsMediaPlayer.Model;
using MyWindowsMediaPlayer.ViewModel;
using MyWindowsMediaPlayer.View;

namespace MyWindowsMediaPlayer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MasterViewModel(this);
        }
    }
}
