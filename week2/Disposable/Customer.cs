namespace Disposable
{
    public class Customer : IDisposable
    {
        private StringReader? _reader;

        public Customer(string s)
        {
            _reader = new StringReader(s);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reader.Dispose();
            }
            _reader = null;
        }

        ~Customer() => Dispose(false);
    }
}