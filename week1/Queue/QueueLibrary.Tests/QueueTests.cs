using QueueLibrary;
using System;
using Xunit;

namespace QueueLibrary.Tests
{
    public class QueueTests
    {
        [Fact]
        public void Enqueue_Works_Correctly()
        {
            // Arrange
            IQueue<int> sut = new Queue<int>();

            // Act
            sut.Enqueue(10);
            sut.Enqueue(20);
            sut.Enqueue(30);

            // Assert
            Assert.Equal(3, sut.Count);
        }

        [Fact]
        public void Dequeue_Works_Correctly()
        {
            // Arrange
            IQueue<int> sut = new Queue<int>();
            sut.Enqueue(10);
            sut.Enqueue(20);
            sut.Enqueue(30);

            // Act
            var item = sut.Dequeue();

            // Assert
            Assert.Equal(2, sut.Count);
            Assert.Equal(10, item);
        }

        [Fact]
        public void Dequeue_Throws_Exception_If_Called_On_Empty_Queue()
        {
            // Arrange
            IQueue<int> sut1 = new Queue<int>();

            IQueue<int> sut2 = new Queue<int>();
            sut2.Enqueue(10);                        
            sut2.Dequeue();                        

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut1.Dequeue());
            Assert.Throws<InvalidOperationException>(() => sut2.Dequeue());
        }

        [Fact]
        public void Peek_Works_Correctly()
        {
            // Arrange
            IQueue<int> sut = new Queue<int>();
            sut.Enqueue(10);
            sut.Enqueue(20);
            sut.Enqueue(30);

            // Act
            var item = sut.Peek();

            // Assert
            Assert.Equal(3, sut.Count);
            Assert.Equal(10, item);
        }
    }
}