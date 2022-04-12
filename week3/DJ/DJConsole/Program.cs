using System.Collections.Concurrent;

namespace DJConsole
{
    internal class Program
    {
        static readonly ManualResetEvent _musicSwitchedEvent = new ManualResetEvent(false);
        static readonly CountdownEvent _dancersSwitchedEvent = new CountdownEvent(Settings.WorkersNumber);        
        static readonly Barrier _barrier = new(Settings.WorkersNumber + 1);

        static readonly Thread[] _threads = new Thread[Settings.WorkersNumber];

        static readonly List<string> _playlist = new();                      
        static string? _currentSong = null;

        static readonly object _locker = new object();

        static void Main()
        {
            Thread.CurrentThread.Name = "DJThread";

            SetupPlaylist();
            SetupThreadsWithDancers();

            StartWorkerThreads();
            PlaySongs();
        }

        /// <summary>
        /// Adds songs from settings to the playlist
        /// </summary>
        static void SetupPlaylist()
        {            
            foreach (var song in Settings.Moves.Keys)
                _playlist.Add(song);            
        }

        /// <summary>
        /// Sets up workers and dancers based on the settings
        /// </summary>
        static void SetupThreadsWithDancers()
        {            
            for (int i = 0; i < Settings.WorkersNumber; i++)
            {
                int dancerFirstId = i * Settings.DancersPerWorker + 1;
                int dancerLastId = (i + 1) * Settings.DancersPerWorker;
                _threads[i] = new Thread(() =>
                {
                    Dance(dancerFirstId, dancerLastId);
                });
            }            
        }

        /// <summary>
        /// Method used by workers to process dancers and sync with the main thread
        /// </summary>
        /// <param name="dancerFirstId"></param>
        /// <param name="dancerLastId"></param>
        static void Dance(int dancerFirstId, int dancerLastId)
        {
            while (true)
            {
                _musicSwitchedEvent.WaitOne();
                _dancersSwitchedEvent.Signal();
                if (_currentSong == null)
                    return;

                for (int i = dancerFirstId; i <= dancerLastId; i++)
                {
                    Console.WriteLine($"Dancer {i} now moves his/her {Settings.Moves[_currentSong]}");
                }
                _barrier.SignalAndWait();
            }                                    
        }

        /// <summary>
        /// Method used by the main thread to start playing songs
        /// </summary>
        static void PlaySongs()
        {
            int i = 0;            

            while (true)
            {                 
                
                lock (_locker)
                {
                    if (i < _playlist.Count)
                    {
                        _currentSong = _playlist[i++];
                        Console.WriteLine($"CURRENTLY PLAYING: {_currentSong}");
                    }
                    else
                    {
                        _currentSong = null;
                        _musicSwitchedEvent.Set();
                        Console.WriteLine("Disco stopped");
                        return;
                    }
                }                
                _musicSwitchedEvent.Set();               
                _dancersSwitchedEvent.Wait();
                _musicSwitchedEvent.Reset();
                _dancersSwitchedEvent.Reset();
                Thread.Sleep(Settings.SongDuration);
                _barrier.SignalAndWait();
            }                        
        }

        /// <summary>
        /// Method used by the main thread to start workers
        /// </summary>
        static void StartWorkerThreads()
        {
            foreach (var thread in _threads)
                thread.Start();
        }
    }
}