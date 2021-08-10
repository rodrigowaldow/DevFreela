using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillRepository(DevFreelaDbContext dbContext, IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("DevFreelaCs");
            _dbContext = dbContext;
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            // Using Dapper
            // using (var sqlConnection = new SqlConnection(_connectionString))
            // {
            //     sqlConnection.Open();

            //     var script = "SELECT Id, Description FROM Skills";

            //     var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

            //     return skills.ToList();
            // }

            // Using EF Core
            // If Database in memory use EF Core not dapper.
            var skillsViewModel = await _dbContext.Skills
               .Select(s => new SkillDTO(s.Id, s.Description))
               .ToListAsync();

            return skillsViewModel;
        }
    }
}
