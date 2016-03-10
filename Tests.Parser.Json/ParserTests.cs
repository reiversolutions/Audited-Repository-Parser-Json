using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuditedRepository.Parser.Json;
using AuditedRepository.Interfaces.Models;
using AuditedRepository.Interfaces.Parsers;
using AuditedRepository.Models;
using Tests.Parser.Json.Models;
using Tests.Parser.Json.Constants;

namespace Tests.Parser.Json
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ParseEntity_null()
        {
            // Assign
            IParser<IEntity> parser = new JsonParser<IEntity>();
            IEntity entity = null;

            // Act
            var result = parser.Parse(entity);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseEntity_Empty()
        {
            // Assign
            IParser<IEntity> parser = new JsonParser<IEntity>();

            // Act
            var jsonResult = parser.Parse(MockObject.EMPTY_ENTITY);

            // Assert
        }

        [TestMethod]
        public void ParseEntity_Basic()
        {
            // Assign
            IParser<IEntity> parser = new JsonParser<IEntity>();
            string jsonExpected = string.Format(
                "\"Id\":\"{0}\",\"IsArchived\":{1},\"ModifiedDate\":\"{2}\",\"CreatedDate\":\"{3}\"",
                MockObject.BASIC_ENTITY.Id,
                MockObject.BASIC_ENTITY.IsArchived.ToString().ToLower(),
                MockObject.BASIC_ENTITY.ModifiedDate.ToString("yyyy-MM-ddTHH:mm:ss+00:00"),
                MockObject.BASIC_ENTITY.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss+00:00")
            );
            jsonExpected = "{" + jsonExpected + "}";

            // Act
            var jsonResult = parser.Parse(MockObject.BASIC_ENTITY);

            // Assert
            Assert.AreEqual(jsonExpected, jsonResult);
        }

        [TestMethod]
        public void ParseEntity_BaseInherited()
        {
            // Assign
            IParser<IEntity> parser = new JsonParser<IEntity>();
            string jsonExpected = string.Format(
                "\"Message\":\"{4}\",\"IsTest\":{5},\"Id\":\"{0}\",\"IsArchived\":{1},\"ModifiedDate\":\"{2}\",\"CreatedDate\":\"{3}\"",
                MockObject.BASIC_MOCKENTITY.Id,
                MockObject.BASIC_MOCKENTITY.IsArchived.ToString().ToLower(),
                MockObject.BASIC_MOCKENTITY.ModifiedDate.ToString("yyyy-MM-ddTHH:mm:ss+00:00"),
                MockObject.BASIC_MOCKENTITY.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss+00:00"),
                MockObject.BASIC_MOCKENTITY.Message,
                MockObject.BASIC_MOCKENTITY.IsTest.ToString().ToLower()
            );
            jsonExpected = "{" + jsonExpected + "}";

            // Act
            var jsonResult = parser.Parse(MockObject.BASIC_MOCKENTITY);

            // Assert
            Assert.AreEqual(jsonExpected, jsonResult);
        }
    }
}
