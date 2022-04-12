using System.Data;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Job Create(Job jobData)
    {
      string sql = @"
      INSERT INTO jobs
      (companyId, contractorId)
      VALUES 
      (@CompanyId, @ContractorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, jobData);
      jobData.Id = id;
      return jobData;
    }
  }
}