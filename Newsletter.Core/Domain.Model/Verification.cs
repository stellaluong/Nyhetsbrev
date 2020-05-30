using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model
{
    public class Verification
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
