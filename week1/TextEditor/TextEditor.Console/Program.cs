using TextEditorLogic;

var app = new Application();

app.InsertChar('a');
app.MoveCursor(0, 1);
app.InsertChar('b');
app.MoveCursor(1, 2);
app.DeleteChar();
app.InsertChar('c');
app.Undo();
app.InsertChar('z');
app.Redo();

app.PrintText();