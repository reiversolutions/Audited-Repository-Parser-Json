using AuditedRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Parser.Json.Models
{
    public class MockEntity : Entity, IMockEntity
    {
        public string Message { get; set; }
        public bool IsTest { get; set; }
    }
}
