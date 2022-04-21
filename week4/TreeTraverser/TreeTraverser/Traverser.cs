namespace TreeTraverser
{
    public class Traverser
    {
        public static void TraverseTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null)
                return;

            var leftBranch = Task.Run(
                () => TraverseTree(tree.Left, action));            
            var rightBranch = Task.Run(
                () => TraverseTree(tree.Right, action));                       

            Task.WaitAll(leftBranch, rightBranch);

            action(tree.Data);
        }
    }
}