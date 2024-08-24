using Entities.Exceptions;

namespace Entities {
  class App {
    public FileHandler FileHandler {get; set;} = new FileHandler();
    public TextEditor TextEditor {get; set;} = new TextEditor();
  
    public void Init() {
      Console.Clear();
      Console.WriteLine("File explorer");
      Console.WriteLine("1 - Create file");
      Console.WriteLine("2 - List all files");
      Console.WriteLine("3 - Find file");
      Console.WriteLine("0 - Exit");
      short option = short.Parse(Console.ReadLine());

      try {
        switch(option) {
          case 1: CreateFile(); break;
          case 2: ListFiles(); break;
        }
      } catch (FileException ex) {
        Console.WriteLine("Error: " + ex.Message);
        Console.ReadLine();
        Init();
      }
    } 

    public void CreateFile() {
      Console.Write("\nEnter file path: ");
      string path = Console.ReadLine();
      FileHandler.path = path;
      
      Console.Write("Enter the file name: ");
      string filename = Console.ReadLine();

      if(File.Exists(path + @"\" + filename)) throw new FileException("Este arquivo já existe na pasta.");

      Console.Clear();
      Console.WriteLine("Write your file (Press ESC to exit)");

      do{
        TextEditor.ToWrite();
      } while(Console.ReadKey().Key != ConsoleKey.Escape);

      Console.Write("\nWant to save de file? (y = yes / n = no): ");
      char option = char.Parse(Console.ReadLine());

      if (option == 'y') FileHandler.CreateFile(filename, TextEditor.Text.ToString());
      else Init();
    }

    public void ListFiles() {
      Console.Write("\nEnter file path: ");
      string path = Console.ReadLine();
      FileHandler.path = path;

      Console.WriteLine();
      var files = FileHandler.GetFilesName();

      for(int i = 0; i < files.Count; i++) {
        Console.WriteLine($"{i + 1} - {files[i]}");
      }
    }
  }
}