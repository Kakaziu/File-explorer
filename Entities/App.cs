namespace Entities {
  class App {
    public FileHandler FileHandler {get; set;} = new FileHandler();
    public TextEditor TextEditor {get; set;} = new TextEditor();
  
    public void Init() {
      Console.WriteLine("File explorer");
      Console.WriteLine("1 - Create file");
      Console.WriteLine("2 - List all files");
      Console.WriteLine("3 - Find file");
      Console.WriteLine("0 - Exit");
      short option = short.Parse(Console.ReadLine());

      switch(option) {
        case 1: CreateFile(); break;
      }
    } 

    public void CreateFile() {
      Console.Write("\nEnter file path: ");
      string path = Console.ReadLine();
      FileHandler.Path = path;
      
      Console.Write("Enter the file name: ");
      string filename = Console.ReadLine();

      Console.WriteLine("Write your file (Press ESC to exit)");

      do{
        TextEditor.ToWrite();
      } while(Console.ReadKey().Key != ConsoleKey.Escape);

      Console.Write("\nWant to save de file? (y = yes / n = no): ");
      char option = char.Parse(Console.ReadLine());

      if (option == 'y') FileHandler.CreateFile(filename, TextEditor.Text);
    }
  }
}