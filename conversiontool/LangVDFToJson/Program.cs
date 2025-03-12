using System.Text;

namespace LangVDFToJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            if (string.IsNullOrWhiteSpace(path))
                return;

            string[] file = File.ReadAllLines(path);
            //clear out brackets in first and last line
            file[0] = "";
            file[file.Length - 1] = "";

            using (var s = File.Create(path.Replace(".json", ".txt")))
            {
                using (StreamWriter sw = new StreamWriter(s, new UnicodeEncoding(false, true)))
                {
                    foreach (string line in file)
                    {
                        sw.WriteLine(line.Replace("\":", "\"").Replace("\",", "\""));
                    }
                }
            }
        }
    }
}
