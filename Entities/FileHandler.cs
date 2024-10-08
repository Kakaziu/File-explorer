using System.Text;
using Entities.Exceptions;

namespace Entities {
  class FileHandler {
    public string path {get; set;} = string.Empty;
    public void WriteFile(string fileName, string content) {
      using(StreamWriter sw = File.AppendText(path + @"\" + fileName)) {
        sw.Write(content);
      }
    }

    public string ReadFile(string fileName) {
      StringBuilder sb = new StringBuilder();
      using(StreamReader sr = File.OpenText(path + @"\" + fileName)) {
        while(!sr.EndOfStream) {
          sb.Append(sr.ReadLine());
          sb.AppendLine();
        }
      }

      return sb.ToString();
    }

    public void DeleteFile(string fileName) {
      string filePath = path + @"\" + fileName;

      if (File.Exists(filePath)) File.Delete(filePath);
      else throw new FileException("O arquivo não existe.");
    }

    public List<string> GetFilesName() {
      IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
      var filesName = new List<string>();
    
      foreach(var file in files) {
        filesName.Add(Path.GetFileName(file));
      }

      return filesName;
    }
  }
}