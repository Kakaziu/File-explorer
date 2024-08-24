using System.Text;

namespace Entities {
  class TextEditor {
    public string Text {get; private set;} = string.Empty;

    public void ToWrite() {
      Text += Console.ReadLine();
      Text += Environment.NewLine;
    }
  }
}