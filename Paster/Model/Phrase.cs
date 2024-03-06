using Paster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Paster.Model
{
    class Phrase
    {
        private readonly string name;
        private readonly string text;
        
        public ICommand OutputContent { get; }
        public string Name { get => name; }
        public string Text { get => text; }


        public Phrase(string _name, string _text)
        {
            name = _name;
            text = _text;
            OutputContent = new RelayCommand(Output);
            
        }

        private void Output()
        {
            Clipboard.SetText(text); 
        }


    }
}
