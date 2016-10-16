using AuditedRepository.Interfaces.Models;
using AuditedRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Parser.Json.Models;

namespace Tests.Parser.Json.Constants
{
    public static class MockObject
    {
        public static IEntity EMPTY_ENTITY = new Entity();
        public static IEntity BASIC_ENTITY = new Entity()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedDate = DateTime.UtcNow.Date,
            ModifiedDate = DateTime.UtcNow.Date,
            IsArchived = false
        };
        public static IMockEntity BASIC_MOCKENTITY = new MockEntity()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedDate = DateTime.UtcNow.Date,
            ModifiedDate = DateTime.UtcNow.Date,
            IsArchived = false,
            Message = "Testing",
            IsTest = true
        };
    }
}
