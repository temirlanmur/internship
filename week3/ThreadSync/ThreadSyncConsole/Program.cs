namespace ThreadSyncConsole;

internal class Program
{
    static ManualResetEvent manEvent = new ManualResetEvent(false);
    static AutoResetEvent autoEvent = new AutoResetEvent(false);    
    static Barrier barrier1 = new Barrier(6);
    static Barrier barrier2 = new Barrier(6);
    static Barrier barrier3 = new Barrier(6);
    static Barrier barrier4 = new Barrier(6);
    static Barrier barrier5 = new Barrier(6);
    static Barrier barrier6 = new Barrier(6);
    static Barrier barrier7 = new Barrier(6);
    static Barrier barrier8 = new Barrier(6);
    static Barrier barrier9 = new Barrier(6);
    static Barrier barrier10 = new Barrier(6);
    static Barrier barrier11 = new Barrier(6);
    static Barrier barrier12 = new Barrier(6);
    static Barrier barrier13 = new Barrier(6);    

    static void Main()
    {
        // Test to check if the instance is already running
        if (
            System.Diagnostics.Process.GetProcessesByName(
                Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)
                )
                .Count() > 1
            )
        {
            Console.WriteLine("The app is already working");
            return;
        }            
        
        //Thread.Sleep(5000); - To test if running two instances is allowed

        Thread[] threads = new Thread[6];

        threads[2] = new Thread(() => 
        {
            barrier1.SignalAndWait();
            barrier2.SignalAndWait();
            Console.WriteLine("Thread 3 is waiting for a manual signal from Thread 1");
            barrier3.SignalAndWait();
            barrier4.SignalAndWait();
            barrier5.SignalAndWait();
            barrier6.SignalAndWait();
            barrier7.SignalAndWait();
            barrier8.SignalAndWait();
            barrier9.SignalAndWait();
            manEvent.WaitOne();
            Console.WriteLine("Thread 3 received a manual signal, continue working");
            barrier10.SignalAndWait();
            barrier11.SignalAndWait();
            barrier12.SignalAndWait();
            barrier13.SignalAndWait();
        });
        threads[3] = new Thread(() =>
        {
            barrier1.SignalAndWait();
            barrier2.SignalAndWait();
            barrier3.SignalAndWait();
            Console.WriteLine("Thread 4 is waiting for a manual signal from Thread 1");
            barrier4.SignalAndWait();
            barrier5.SignalAndWait();
            barrier6.SignalAndWait();
            barrier7.SignalAndWait();
            barrier8.SignalAndWait();
            barrier9.SignalAndWait();
            barrier10.SignalAndWait();
            manEvent.WaitOne();
            Console.WriteLine("Thread 4 received a manual signal, continue working");
            barrier11.SignalAndWait();
            barrier12.SignalAndWait();
            barrier13.SignalAndWait();
        });
        threads[4] = new Thread(() =>
        {
            barrier1.SignalAndWait();
            barrier2.SignalAndWait();
            barrier3.SignalAndWait();
            barrier4.SignalAndWait();
            Console.WriteLine("Thread 5 is waiting for an auto signal from Thread 2");
            barrier5.SignalAndWait();
            barrier6.SignalAndWait();
            barrier7.SignalAndWait();
            autoEvent.WaitOne();
            Console.WriteLine("Thread 5 received an auto signal, continue working");
            barrier8.SignalAndWait();
            barrier9.SignalAndWait();
            barrier10.SignalAndWait();
            barrier11.SignalAndWait();
            barrier12.SignalAndWait();
            barrier13.SignalAndWait();
        });
        threads[5] = new Thread(() =>
        {
            barrier1.SignalAndWait();
            barrier2.SignalAndWait();
            barrier3.SignalAndWait();
            barrier4.SignalAndWait();
            barrier5.SignalAndWait();
            Console.WriteLine("Thread 6 is waiting for an auto signal from Thread 2");
            barrier6.SignalAndWait();
            barrier7.SignalAndWait();
            barrier8.SignalAndWait();
            barrier9.SignalAndWait();
            barrier10.SignalAndWait();
            barrier11.SignalAndWait();
            barrier12.SignalAndWait();
            barrier13.SignalAndWait();
            autoEvent.WaitOne();
            Console.WriteLine("Thread 6 received an auto signal, continue working");
        });
        threads[0] = new Thread(() =>
        {
            Console.WriteLine("Thread 1 started");
            barrier1.SignalAndWait();
            barrier2.SignalAndWait();
            barrier3.SignalAndWait();
            barrier4.SignalAndWait();
            barrier5.SignalAndWait();
            barrier6.SignalAndWait();
            barrier7.SignalAndWait();
            barrier8.SignalAndWait();
            Console.WriteLine("Thread 1 set signal");
            manEvent.Set();
            barrier9.SignalAndWait();
            barrier10.SignalAndWait();
            barrier11.SignalAndWait();
            Console.WriteLine("Thread 1 reset signal");
            manEvent.Reset();
            barrier12.SignalAndWait();
            barrier13.SignalAndWait();
        });        
        threads[1] = new Thread(() =>
        {
            barrier1.SignalAndWait();
            Console.WriteLine("Thread 2 started");
            barrier2.SignalAndWait();
            barrier3.SignalAndWait();
            barrier4.SignalAndWait();
            barrier5.SignalAndWait();
            barrier6.SignalAndWait();
            Console.WriteLine("Thread 2 set signal");
            autoEvent.Set();
            barrier7.SignalAndWait();
            barrier8.SignalAndWait();
            barrier9.SignalAndWait();
            barrier10.SignalAndWait();
            barrier11.SignalAndWait();
            barrier12.SignalAndWait();
            Console.WriteLine("Thread 2 set signal");
            autoEvent.Set();
            barrier13.SignalAndWait();
        });        

        foreach (var thread in threads)
            thread.Start();
    }
}
