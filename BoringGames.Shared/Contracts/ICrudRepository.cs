using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Shared.Contracts
{
    /// <summary>
    /// Contract for Crud Repository
    /// </summary>
    /// <typeparam name="T">Generic type for repository elements</typeparam>
    public interface ICrudRepository<T> where T:IIdentityModel
    {
        /// <summary>
        /// Adds an element to the repository and returns its id
        /// </summary>
        /// <param name="data">Data to add</param>
        /// <returns>New generated Id</returns>
        public long? Add(T data);

        /// <summary>
        /// Updates an element of the set based on its GuidId
        /// </summary>
        /// <param name="data">Data to update</param>
        public void Update(T data);

        /// <summary>
        /// Deletes an element based on its GuidId
        /// </summary>
        /// <param name="id">Element's id</param>
        public void Delete(long id);

        /// <summary>
        /// Gets all the elements
        /// </summary>
        /// <returns>Elements list</returns>
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Gets an element based on its id
        /// </summary>
        /// <param name="id">Element's id to return</param>
        /// <returns>Element</returns>
        public T Get(long id);
    }
}
