using Paster.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Paster.UserContols.ViewModel
{
    class PhraseControlViewModel : INotifyPropertyChanged
    {
        Phrase phrase;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
