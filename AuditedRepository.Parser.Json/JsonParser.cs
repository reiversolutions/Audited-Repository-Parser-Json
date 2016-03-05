using AuditedRepository.Interfaces.Models;
using AuditedRepository.Interfaces.Parsers;
using AuditedRepository.Parsers;
using AuditedRepository.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditedRepository.Parser.Json
{
    public class JsonParser<T> : ParserBase<T>, IParser<T> where T : IEntity
    {
        public override string Parse(T entity)
        {
            var validator = new EntityValidator<T>();
            validator.Validate(entity);

            return JsonConvert.SerializeObject(entity);
        }
    }
}