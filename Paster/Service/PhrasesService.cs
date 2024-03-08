using Paster.Model;
using System.IO;
using System.Xml.Linq;

namespace Paster.Service
{
    internal class PhrasesService
    {
        private string path;
        public PhrasesService() 
        {
            path = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Resources\\Phrases.xml";
        }

        public IEnumerable<Phrase> ParsePhrases()
        {
            XDocument doc = XDocument.Load(path);
            return from element in doc.Descendants("Phrase")
                       select new Phrase(element.Attribute("name")!.Value, element.Attribute("text")!.Value);
        }

        public void SavePhrases(IEnumerable<Phrase> phrases)
        {
            new XDocument(new XElement("Phrases",
                from phrase in phrases select
                new XElement("Phrase",
                    new XAttribute("name", phrase.Name),
                    new XAttribute("text", phrase.Text)
                ))).Save(path);
        }
    }
}
