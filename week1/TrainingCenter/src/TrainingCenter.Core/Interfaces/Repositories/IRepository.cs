using TrainingCenter.Core.Models;

namespace TrainingCenter.Core.Interfaces.Repositories
{
    /// <summary>
    /// Defines common persistence logic for models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Retrieves item from db by its id. Returns null, if not found
        /// </summary>
        /// <param name="id">Item's id</param>
        /// <returns></returns>        
        T Get(int id);

        /// <summary>
        /// Retrieves item from db by its id. If not found, throws exception
        /// </summary>
        /// <param name="id">Item's id</param>
        /// <returns></returns>
        /// <exeption cref="ArgumentException"></exeption>
        T GetOrThrowException(int id);

        /// <summary>
        /// Saves item in db
        /// </summary>
        /// <param name="item"></param>
        void Save(T item);
    }
}
