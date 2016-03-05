using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuditedRepository.Parser.Json;
using AuditedRepository.Interfaces.Models;
using AuditedRepository.Interfaces.Parsers;
using AuditedRepository.Models;

namespace Tests.Parser.Json
{
    [TestClass]
    public class ParserTests
    {
        private IEntity EMPTY_ENTITY = new Entity();
        private IEntity BASIC_ENTITY = new Entity()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            IsArchived = false
        };

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
            var jsonResult = parser.Parse(EMPTY_ENTITY);

            // Assert
        }

        [TestMethod]
        public void ParseEntity_Basic()
        {
            // Assign
            IParser<IEntity> parser = new JsonParser<IEntity>();
            string jsonExpected = string.Format(
                "\"Id\":\"{0}\",\"IsArchived\":{1},\"ModifiedDate\":\"{2}\",\"CreatedDate\":\"{3}\"",
                BASIC_ENTITY.Id,
                BASIC_ENTITY.IsArchived.ToString().ToLower(),
                BASIC_ENTITY.ModifiedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff+00:00"),
                BASIC_ENTITY.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff+00:00")
            );
            jsonExpected = "{" + jsonExpected + "}";

            // Act
            var jsonResult = parser.Parse(BASIC_ENTITY);

            // Assert
            Assert.AreEqual(jsonExpected, jsonResult);
        }
    }
}
