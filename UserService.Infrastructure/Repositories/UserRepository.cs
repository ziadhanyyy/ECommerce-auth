using Dapper;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Context;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository( DapperContext context) { 
        
           _context = context;
        }
        public async Task<int> CreateAsync(User user)
        {
            const string qurey = """
                INSERT INTO 
                USERS (id,name,email,passwordhash) 
                VALUES(@id,@name,@email,@passwordhash);
                """;
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(qurey, user);
            return 1;
        }

        public async Task<User?> GetByEmailAsync(string email)

        { 
            const string query = "SELECT * From users Where email=@email";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User?>(query, new { email });

        }
    }
    }

