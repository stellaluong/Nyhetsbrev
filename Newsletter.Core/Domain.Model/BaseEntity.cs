using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity(Guid id)
        {
            Id = Guid.NewGuid();
        }
    }
}
