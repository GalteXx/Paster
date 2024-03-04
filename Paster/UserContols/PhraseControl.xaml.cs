using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
namespace Paster.UserContols
{
    public partial class PhraseControl : UserControl, INotifyPropertyChanged
    {
        

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PhraseControl), new PropertyMetadata(""));
        public PhraseControl()
        {
            InitializeComponent();
        }

        private bool mouseHovered;
        public bool MouseHovered
        {
            get => mouseHovered;
            set
            {
                mouseHovered = value;
                OnPropertyChanged();
            }
        }

        private void UserControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseHovered = true;
        }

        private void UserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseHovered = false;
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
