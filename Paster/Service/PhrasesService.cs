using Paster.Model;
using System.IO;
using System.Xml.Linq;

namespace Paster.Service
{
    internal class PhrasesService
    {
        public PhrasesService() 
        {
            
        }

        public IEnumerable<Phrase> ParsePhrases()
        {
            string path = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Resources\\Phrases.xml";
            XDocument doc = XDocument.Load(path);
            return from element in doc.Descendants("Phrase")
                       select new Phrase(element.Attribute("name")!.Value, element.Attribute("text")!.Value);
        }


    }
}
