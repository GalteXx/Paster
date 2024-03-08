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
        PhrasesService phrasesService;


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
            phrasesService = new();
            phrases = new ObservableCollection<Phrase>(phrasesService.ParsePhrases());
        }

        public void SavePhrases()
        {
            phrasesService.SavePhrases(phrases);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
