using System.Text;

namespace Entities {
  class TextEditor {
    public StringBuilder Text {get; private set;} = new StringBuilder();
  
    public void ToWrite() {
      Text.AppendLine(Console.ReadLine());
    }
  }
}