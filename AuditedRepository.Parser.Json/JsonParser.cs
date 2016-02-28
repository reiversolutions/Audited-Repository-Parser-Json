using AuditedRepository.Interfaces.Models;
using AuditedRepository.Interfaces.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditedRepository.Parser.Json
{
    public class JsonParser<T> : IParser<T> where T : class, IEntity
    {
        public string Parse(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
