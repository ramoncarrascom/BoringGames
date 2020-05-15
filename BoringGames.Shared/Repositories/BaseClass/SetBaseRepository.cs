using BoringGames.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Enums;
using System.Threading;

namespace BoringGames.Shared.Repositories.BaseClass
{
    /// <summary>
    /// Abstract repository to keep data in a dictionary
    /// </summary>
    /// <typeparam name="T">Elements data type</typeparam>
    public abstract class SetBaseRepository<T> : ICrudRepository<T> where T:IIdentityModel, ICloneable
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        protected readonly ISet<T> _set;

        /// <summary>
        /// Constructor
        /// </summary>
        protected SetBaseRepository()
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

            _lock.EnterWriteLock();
            try
            {
                data.Id = _set.Where(x => x.Id != null)
                                .Select(x => x.Id)
                                .DefaultIfEmpty(0)
                                .Max() + 1;
                _set.Add(data);
            } finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }


            return data.Id;
        }

        /// <summary>
        /// Updates an element of the set based on its GuidId
        /// </summary>
        /// <param name="data">Data to update</param>
        public virtual void Update(T data)
        {
            T currentElement;

            _lock.EnterReadLock();
            try
            {
                currentElement = _set.FirstOrDefault(x => x.Id == data.Id);
            } finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
            
            if (currentElement == null)
                throw new KeyNotFoundException("Not existing element");

            _lock.EnterWriteLock();
            try
            {
                _set.Remove(currentElement);
                _set.Add(data);
            } finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }

        }

        /// <summary>
        /// Deletes an element based on its Id
        /// </summary>
        /// <param name="id">Element's id</param>
        public virtual void Delete(long id)
        {
            T currentElement;

            _lock.EnterReadLock();
            try
            {
                currentElement = _set.FirstOrDefault(x => x.Id == id);
            } finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }

            if (currentElement == null)
                throw new NotExistingValueException("Not existing element", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);

            _lock.EnterWriteLock();
            try
            {
                _set.Remove(currentElement);
            } finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }

        }

        /// <summary>
        /// Gets all the elements of the repository
        /// </summary>
        /// <returns>A list with all elements of the set</returns>
        public virtual IEnumerable<T> GetAll()
        {
            List<T> response;

            _lock.EnterWriteLock();
            try
            {
                response = _set.AsEnumerable().Select(x => (T)x.Clone()).ToList();
            } finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }            

            return response;
        }

        /// <summary>
        /// Gets an element from the repository
        /// </summary>
        /// <param name="id">Element's id</param>
        /// <returns>Requested element</returns>
        public virtual T Get(long id)
        {
            T resp;

            _lock.EnterReadLock();
            try
            {
                resp = _set.AsEnumerable().Select(x => (T)x.Clone()).FirstOrDefault(x => x.Id == id);
            } finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }

            return resp;
        }

    }
}
