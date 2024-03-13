using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Paster.Model;


namespace Paster.UserContols
{
    public partial class PhraseControl : UserControl, INotifyPropertyChanged
    {

        public ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(PhraseControl), null);

        public Phrase BoundPhrase
        {
            get { return (Phrase)GetValue(BoundPhraseProperty); }
            set { SetValue(BoundPhraseProperty, value); }
        }

        public static readonly DependencyProperty BoundPhraseProperty =
            DependencyProperty.Register("BoundPhrase", typeof(Phrase), typeof(PhraseControl), null);

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

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BoundPhrase.Output();
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
