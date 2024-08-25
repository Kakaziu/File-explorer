using Entities.Exceptions;

namespace Entities {
  class App {
    public FileHandler FileHandler {get; set;} = new FileHandler();
    public TextEditor TextEditor {get; set;} = new TextEditor();

    public App(string basePath) {
      FileHandler.path = basePath;
    }
  
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
          case 3: FindFile(); break;
          case 0: System.Environment.Exit(0); break;
        }
      } catch (FileException ex) {
        Console.WriteLine("Error: " + ex.Message);
        Console.ReadLine();
        Init();
      }
    } 

    public void CreateFile() {
      Console.Write("Enter the file name: ");
      string filename = Console.ReadLine();

      if(File.Exists(GetPath(filename))) throw new FileException("Este arquivo já existe na pasta.");

      Console.Clear();
      Console.WriteLine("Write your file (Press ESC to exit)");

      do{
        TextEditor.ToWrite();
      } while(Console.ReadKey().Key != ConsoleKey.Escape);

      Console.Write("\nWant to save de file? (y = yes / n = no): ");
      char option = char.Parse(Console.ReadLine());

      if (option == 'y') FileHandler.WriteFile(filename, TextEditor.Text.ToString());
      else Init();
    }

    public void FindFile() {
      Console.WriteLine("Enter the file name: ");
      string filename = Console.ReadLine();

      if (!File.Exists(GetPath(filename))) throw new FileException("This file does not exist");

      Console.WriteLine("\nCaminho: " + GetPath(filename));
      Console.WriteLine("1 - Delete file");
      Console.WriteLine("2 - Edit file");
      Console.WriteLine("3 - Voltar ao menu");
      short option = short.Parse(Console.ReadLine());

      switch(option) {
        case 1: FileHandler.DeleteFile(filename); break;
        case 2: EditFile(filename); break;
      }
      
    }

    public void EditFile(string filename) {
      string actualContent = FileHandler.ReadFile(filename);
      
      Console.Clear();
      Console.Write(actualContent);
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("Edit your file (Press ESC to exit)");

      do{
        TextEditor.ToWrite();
      } while(Console.ReadKey().Key != ConsoleKey.Escape);

      Console.Write("\nWant to save de file? (y = yes / n = no): ");
      char option = char.Parse(Console.ReadLine());

      if (option == 'y') {
        FileHandler.DeleteFile(filename); 
        FileHandler.WriteFile(filename, TextEditor.Text.ToString());
      }
      else Init();
    }

    public void ListFiles() {
      Console.WriteLine();
      var files = FileHandler.GetFilesName();

      for(int i = 0; i < files.Count; i++) {
        Console.WriteLine($"{i + 1} - {files[i]}");
      }
    }

    private string GetPath(string fileName) {
      return FileHandler.path + @"\" + fileName;
    }
  }
}