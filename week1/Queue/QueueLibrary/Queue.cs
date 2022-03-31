namespace QueueLibrary
{
    /// <summary>
    /// Custom generic Queue implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IQueue<T>
    {
        private readonly LinkedList<T> _queue;
        public int Count => _queue.Count;

        public Queue()
        {
            _queue = new LinkedList<T>();
        }        

        public void Enqueue(T item)
        {
            _queue.AddLast(item);
        }

        public T Dequeue()
        {
            if (_queue.First == null)
                throw new InvalidOperationException("Queue is empty");

            var item = _queue.First.Value;

            _queue.RemoveFirst();

            return item;

        }

        public T? Peek()
        {
            if (_queue.First == null)
                return default;

            return _queue.First.Value;
        }
    }
}