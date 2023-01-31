

namespace AdressbokVS.Services
{
    public class FileService
    {
        private string _filePath;
        public FileService(string filepath)
        {
            _filePath = filepath;
        }
        public void Save(string console) 
        { 
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(console);
        }

        public string Read() 
        {
            try
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
            catch { return null!; }
        }
    }
}
