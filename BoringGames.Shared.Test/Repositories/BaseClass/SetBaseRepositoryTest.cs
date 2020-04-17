using BoringGames.Shared.Contracts;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Repositories.BaseClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoringGames.Shared.Test.Repositories.BaseClass
{
    public class SetBaseRepositoryTest
    {
        private class MockClass : IIdentityModel, ICloneable
        {
            public long? Id { get; set; }

            public string Data { get; set; }

            public object Clone()
            {
                MockClass resp = new MockClass();
                resp.Id = this.Id;
                resp.Data = this.Data;

                return resp;
            }
        }

        private class MockRepository : SetBaseRepository<MockClass>
        {
            public override long? Add(MockClass data)
            {
                return base.Add(data);
            }

            public override void Update(MockClass data)
            {
                base.Update(data);
            }

            public override void Delete(long id)
            {
                base.Delete(id);
            }

            public override IEnumerable<MockClass> GetAll()
            {
                return base.GetAll();
            }

            public override MockClass Get(long id)
            {
                return base.Get(id);
            }
        }

        [Test]
        public void AddNullDataMustRaiseException()
        {
            // Given
            MockRepository rep = new MockRepository();

            // When / Then
            NotValidValueException exc = Assert.Throws<NotValidValueException>(() => rep.Add(null), "Adding null object must raise exception");
            Assert.AreEqual(exc.ErrorCode, ErrorCode.NULL_VALUE_NOT_ALLOWED);
        }

        [Test]
        public void AddDataWithIdMustRaiseException()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data = new MockClass();
            data.Id = 1;

            // When / Then
            ArgumentException exc = Assert.Throws<ArgumentException>(() => rep.Add(data), "Adding data with Id must raise exception");
        }

        [Test]
        public void FirstAddedDataMustReturnId1()
        {
            MockRepository rep = new MockRepository();
            MockClass data = new MockClass();

            // When
            long resp = (long)rep.Add(data);

            // Then
            Assert.AreEqual(resp, 1, "First added data must have ID 1");
        }

        [Test]
        public void SecondAddedDataMustReturnId2()
        {
            MockRepository rep = new MockRepository();
            MockClass data1 = new MockClass();
            MockClass data2 = new MockClass();

            // When
            long resp1 = (long)rep.Add(data1);
            long resp2 = (long)rep.Add(data2);

            // Then
            Assert.AreEqual(resp1, 1, "First added data must have ID 1");
            Assert.AreEqual(resp2, 2, "First added data must have ID 2");
        }

        [Test]
        public void UpdatingAnInexistentElementMustRaiseAnException()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data = new MockClass();

            // When
            long resp = (long)rep.Add(data);

            MockClass updatedData = new MockClass();
            updatedData.Id = resp + 1;

            // When / Then
            KeyNotFoundException exc = Assert.Throws<KeyNotFoundException>(() => rep.Update(updatedData), "Updating inexistent data must raise exception");
        }

        [Test]
        public void UpdatingDataMustChangeDataInSet()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass obj = new MockClass();
            string data = "Data";

            // When
            long resp = (long)rep.Add(obj);

            MockClass addedData = rep.Get(resp);
            addedData.Data = data;

            rep.Update(addedData);

            // Then
            Assert.AreEqual(rep.Get(resp).Data, data, "Object's data must be same as updated one");
        }

        [Test]
        public void DeletingANonExistingElementMustRaiseException()
        {
            // Given
            MockRepository rep = new MockRepository();

            // When / Then
            NotExistingValueException exc = Assert.Throws<NotExistingValueException>(() => rep.Delete(1), "Deleting inexistent data must raise exception");
            Assert.AreEqual(exc.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Raised exception code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void DeletingAnElementMustRaiseAnExceptionIdTryingToDeleteAgain()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data = new MockClass();
            long resp = (long)rep.Add(data);

            // When
            rep.Delete(resp);
            
            //Then
            NotExistingValueException exc = Assert.Throws<NotExistingValueException>(() => rep.Delete(resp), "Deleting already deleted data must raise exception");
            Assert.AreEqual(exc.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Raised exception code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void GetAllMustGetAllAddedItems()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data1 = new MockClass();
            MockClass data2 = new MockClass();
            MockClass data3 = new MockClass();

            // When
            rep.Add(data1);
            rep.Add(data2);
            rep.Add(data3);
            List<MockClass> resp = rep.GetAll().ToList();

            // Then
            Assert.AreEqual(resp.Count, 3, "Returned list must have same number of added objects");
        }

        [Test]
        public void GetAllMustReturnClonedObjects()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data1 = new MockClass();
            MockClass data2 = new MockClass();
            MockClass data3 = new MockClass();

            // When
            rep.Add(data1);
            rep.Add(data2);
            rep.Add(data3);
            List<MockClass> resp = rep.GetAll().ToList();

            // Then
            Assert.IsFalse(resp.Contains(data1), "Returned list must not contain the original objects");
            Assert.IsFalse(resp.Contains(data2), "Returned list must not contain the original objects");
            Assert.IsFalse(resp.Contains(data3), "Returned list must not contain the original objects");
        }

        [Test]
        public void GetElementMustReturnSameData()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data1 = new MockClass();
            string objectData = "ObjectData";
            data1.Data = objectData;

            // When
            long resp1 = (long)rep.Add(data1);
            MockClass resp = rep.Get(resp1);

            // Then
            Assert.AreEqual(resp.Data, objectData, "Returned object must have same data as added one");
        }

        [Test]
        public void GetElementMustBeDifferentAsOriginal()
        {
            // Given
            MockRepository rep = new MockRepository();
            MockClass data1 = new MockClass();
            string objectData = "ObjectData";
            data1.Data = objectData;

            // When
            long resp1 = (long)rep.Add(data1);
            MockClass resp = rep.Get(resp1);

            // Then
            Assert.AreNotEqual(resp, data1, "Returned object must be different from original one");
        }
    }
}
