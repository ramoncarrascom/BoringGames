using BoringGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BoringGames.Core.Exceptions;
using BoringGames.Core.Enums;

namespace BoringGames.Core.Repositories.BaseClass
{
    /// <summary>
    /// Abstract repository to keep data in a dictionary
    /// </summary>
    /// <typeparam name="T">Elements data type</typeparam>
    public abstract class SetBaseRepository<T> : ICrudRepository<T> where T:IIdentityModel, ICloneable
    {
        protected readonly ISet<T> _set;

        /// <summary>
        /// Constructor
        /// </summary>
        public SetBaseRepository()
        {
            _set = new HashSet<T>();
        }

        /// <summary>
        /// Adds a new element to the set
        /// </summary>
        /// <param name="data">New data</param>
        /// <returns>Generated Id</returns>
        public virtual long? Add(T data)
        {
            if (data == null)
                throw new NotValidValueException("Null values are not allowed", ErrorCode.NULL_VALUE_NOT_ALLOWED);

            if (data.Id != null)
                throw new ArgumentException("GuidId must be null");

            data.Id = _set.Where(x => x.Id != null)
                            .Select(x => x.Id)
                            .DefaultIfEmpty(0)
                            .Max() + 1;
            _set.Add(data);

            return data.Id;
        }

        /// <summary>
        /// Updates an element of the set based on its GuidId
        /// </summary>
        /// <param name="data">Data to update</param>
        public virtual void Update(T data)
        {
            T currentElement = _set.Where(x => x.Id == data.Id).FirstOrDefault();
            if (currentElement == null)
                throw new KeyNotFoundException("Not existing element");

            _set.Remove(currentElement);
            _set.Add(data);
        }

        /// <summary>
        /// Deletes an element based on its Id
        /// </summary>
        /// <param name="id">Element's id</param>
        public virtual void Delete(long id)
        {
            T currentElement = _set.Where(x => x.Id == id).FirstOrDefault();
            if (currentElement == null)
                throw new NotExistingValueException("Not existing element", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);

            _set.Remove(currentElement);
        }

        /// <summary>
        /// Gets all the elements of the repository
        /// </summary>
        /// <returns>A list with all elements of the set</returns>
        public virtual IEnumerable<T> GetAll()
        {
            List<T> response = _set.ToList().Select(x => (T)x.Clone()).ToList();

            return response;
        }

        /// <summary>
        /// Gets an element from the repository
        /// </summary>
        /// <param name="id">Element's id</param>
        /// <returns>Requested element</returns>
        public virtual T Get(long id)
        {
            return _set.ToList().Select(x => (T)x.Clone()).Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
