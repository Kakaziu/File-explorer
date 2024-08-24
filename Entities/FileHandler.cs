using System.Text;

namespace Entities {
  class FileHandler {
    public string Path {get; set;} = string.Empty;
    public void CreateFile(string fileName, string content) {
      using(StreamWriter sw = File.AppendText(Path + @"\" + fileName)) {
        sw.Write(content);
      }
    }

    public string ReadFile(string fileName) {
      StringBuilder sb = new StringBuilder();
      using(StreamReader sr = File.OpenText(Path + @"\" + fileName)) {
        while(!sr.EndOfStream) {
          sb.Append(sr.ReadLine());
          sb.AppendLine();
        }
      }

      return sb.ToString();
    }

    public List<string> GetFilesName() {
      IEnumerable<string> files = Directory.EnumerateDirectories(Path + "*.*" + SearchOption.AllDirectories);
      var filesName = new List<string>();
    
      foreach(var file in files) {
        string[] directoryElements = file.Split(@"\");
        filesName.Add(directoryElements[directoryElements.Length - 1]);
      }

      return filesName;
    }
  }
}