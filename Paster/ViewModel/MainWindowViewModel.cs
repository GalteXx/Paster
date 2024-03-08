using Paster.Model;
using Paster.Service;
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
            PhrasesService phrasesService = new();
            IEnumerable<Phrase> P = phrasesService.ParsePhrases();
            phrases = new ObservableCollection<Phrase>(P);

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
