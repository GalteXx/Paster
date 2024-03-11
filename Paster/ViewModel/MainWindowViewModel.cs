using Paster.Model;
using Paster.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Paster.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Phrase> phrases;
        PhrasesService phrasesService;
        private string inputName;
        private string inputText;

        public ICommand AddCommand { get; private set; }
        public string InputName
        {
            get
            {
                return inputName;
            }
            set
            {
                inputName = value;
                OnPropertyChanged();
            }
        }
        public string InputText 
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                OnPropertyChanged();
            }
        }
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

            AddCommand = new RelayCommand(AddPhrase);
        }

        public void SavePhrases()
        {
            phrasesService.SavePhrases(phrases);
        }

        private void AddPhrase()
        {
            Phrases.Add(new Phrase(inputName, inputText));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
