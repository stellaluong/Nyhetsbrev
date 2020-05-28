using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newsletter.Core.Domain.Model;

namespace Newsletter.Core.Domain.Service
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
