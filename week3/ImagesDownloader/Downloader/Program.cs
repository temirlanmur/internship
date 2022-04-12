using Newtonsoft.Json.Linq;
using System.Net;

namespace Downloader
{
    internal class Program
    {
        /// <summary>
        /// Number of photos to be downloaded
        /// </summary>
        static readonly int imagesNumber = 100;

        /// <summary>
        /// Number of threads used in the download
        /// </summary>
        static readonly int threadsNumber = 4;

        /// <summary>
        /// Resource that contains json with information about images
        /// </summary>
        static readonly string url = "https://jsonplaceholder.typicode.com/photos";

        /// <summary>
        /// Project-level folder's name, which will store downloaded images
        /// </summary>
        static readonly string imagesFolderName = "Images";

        /// <summary>
        /// Absolute path to the project's root directory (needed for saving)
        /// </summary>
        static readonly string projectFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        /// <summary>
        /// Absolute path to the downloads folder
        /// </summary>
        static readonly string imagesFolderPath = Path.Combine(projectFolderPath, imagesFolderName);

        /// <summary>
        /// Locker object
        /// </summary>
        static readonly object _locker = new();
        
        /// <summary>
        /// Json array that stores information about images
        /// </summary>
        static JArray? ImagesJArray { get; set; }


        static void Main()
        {
            GetImagesArray();
            if (ImagesJArray == null) return;

            Thread[] threads = new Thread[threadsNumber];

            int batchSize = imagesNumber / threadsNumber;

            for (int i = 0; i < threadsNumber; i++)
            {
                int startIndex = i * batchSize;
                int endIndex = (i + 1) * batchSize;

                threads[i] = new Thread(() =>
                {                    
                    DownloadBatch(startIndex, endIndex);
                });

                threads[i].Name = $"Thread {i}";
            }

            foreach (var thread in threads)
            {
                Console.WriteLine($"{thread.Name} started");
                thread.Start();                
            }                            
        }


        /// <summary>
        /// Retrieves string as json from the url, parses as JArray, and sets to the static field
        /// </summary>
        static void GetImagesArray()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    Console.WriteLine($"Getting json from {url}...");
                    var json = client.DownloadString(url);
                    ImagesJArray = JArray.Parse(json);
                    Console.WriteLine("Got the json!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not retrieve json from the url. An error occured:\n" + ex.Message);                    
                }
            }
        }

        /// <summary>
        /// Downloads batch of photos from ImagesJArray, from and till specified indexes
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        static void DownloadBatch(int startIndex, int endIndex)
        {
            using WebClient client = new WebClient();
            for (int i = startIndex; i < endIndex; i++)
            {
                try
                {
                    var imageInfo = ImagesJArray[i];

                    var imageUrl = imageInfo["thumbnailUrl"].ToString();
                    var imageFileName = imageInfo["id"].ToString() + ".png";
                    var imageFileFullName = Path.Combine(imagesFolderPath, imageFileName);

                    lock (_locker)
                    {                        
                        client.DownloadFile(imageUrl, imageFileFullName);
                        Console.WriteLine($"Image {imageFileName} downloaded");
                    }                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ooops! Could not retrieve image. An error occured:\n" + ex.Message);
                }                
            }
        }
    }
}
