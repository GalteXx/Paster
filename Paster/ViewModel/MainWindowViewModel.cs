using Paster.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Paster.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Phrase> phrases;

        public ObservableCollection<Phrase> Phrases
        {
            get
            {
                return phrases;
            }
            set
            {
                phrases = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            phrases = new()
            {
                new Phrase("Hello", "Halo"),
                new Phrase("World", "Welt")
            };

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
