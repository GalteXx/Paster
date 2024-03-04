using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Paster.Model
{
    class Phrase
    {
        private readonly string name;
        private readonly string text;
        
        public ICommand InputSelf { get; }
        public string Name { get => name; }
        public string Text { get => text; }


        public Phrase(string _name, string _text)
        {
            name = _name;
            text = _text;
            InputSelf = new RoutedCommand("InputSelf", typeof(Phrase));
            
        }

        private void ExecuteTypeSelf()
        {
            OutputManager.Type(text);
        }


    }
}
