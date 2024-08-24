namespace Entities {
  class FileHandler {
    public string Path {get; private set;}

    public void CreateFile(string folder) {
      using(StreamWriter sw = File.AppendText(Path + @"\" + folder)) {

      }
    }
  }
}