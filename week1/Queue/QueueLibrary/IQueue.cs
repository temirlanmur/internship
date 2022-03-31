namespace QueueLibrary
{
    /// <summary>
    /// Defines methods for working with generic queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Retrieves the number of items in queue
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds item to the back of the queue
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);

        /// <summary>
        /// Removes item from the front of the queue.
        /// Throws exception, if the queue is empty
        /// </summary>
        /// <returns>Removed item</returns>
        /// <exception cref="InvalidOperationException"></exception>
        T Dequeue();

        /// <summary>
        /// Returns item from the front of the queue, without removing it
        /// </summary>
        /// <returns>Item at the front, or null, if queue is empty</returns>
        T? Peek();        
    }
}
