using WindowsInput;

namespace Paster.Model
{
    //I got stuck on this part, so singletone it is...
    static class OutputManager
    {
        private static InputSimulator inputSimulator;

        static OutputManager() 
        {
            inputSimulator = new InputSimulator();
        }

        public static void Type(string text)
        {
            inputSimulator.Keyboard.TextEntry(text);
        }
    }
}
