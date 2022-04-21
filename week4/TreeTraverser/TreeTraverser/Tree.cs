namespace TreeTraverser
{
    public class Tree<T>
    {
        public Tree<T>? Left;
        public Tree<T>? Right;
        public T Data;
        
        public Tree(T data)
        {
            Data = data;
        }
    }
}
