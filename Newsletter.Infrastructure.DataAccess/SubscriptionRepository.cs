using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Service;

namespace Newsletter.Infrastructure.DataAccess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public async Task<bool> Create(Subscription subscription)
        {
            const string
                connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            await using var connection = new SqlConnection(connStr);
            const string insert = "INSERT INTO Registrations (Name, Email, Code, Status) VALUES (@Name, @Email, @Code, 'NOT Verified')";
            var rowsAffected = await connection.ExecuteAsync(insert);
            return rowsAffected == 1;
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
