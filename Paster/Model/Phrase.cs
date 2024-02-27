using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paster.Model
{
    class Phrase
    {
        private readonly string name;
        private readonly string text;

        public Phrase(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        public string Name { get => name; }
        public string Text { get => text; }
    }
}
