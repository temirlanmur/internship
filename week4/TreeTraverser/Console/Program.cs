using TreeTraverser;

var tree = new Tree<int>(3)
{
    Left = new Tree<int>(1),
    Right = new Tree<int>(10)
};

Action<int> writeToConsole = x => Console.WriteLine(x);

Traverser.TraverseTree(tree, writeToConsole);