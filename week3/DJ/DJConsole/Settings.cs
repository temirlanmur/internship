namespace DJConsole
{
    internal static class Settings
    {
        /// <summary>
        /// Defines song types & moves
        /// </summary>
        internal static readonly Dictionary<string, string> Moves = new()
        {
            { "hardbass", "elbow" },
            { "latino", "hips" },
            { "rock", "head" }
        };

        /// <summary>
        /// Defines number of threads used in the program
        /// </summary>
        internal static readonly int WorkersNumber = 4;

        /// <summary>
        /// Defines how many dancers are processed on each worker (thread)
        /// </summary>
        internal static readonly int DancersPerWorker = 4;

        /// <summary>
        /// Defines the duration of song in miliseconds
        /// </summary>
        internal static readonly int SongDuration = 5000;
    }
}
