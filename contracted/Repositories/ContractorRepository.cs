using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ContractorRepository
  {

    private readonly IDbConnection _db;

    public ContractorRepository(IDbConnection db)
    {
      _db = db;
    }

    internal ContractorViewModel GetViewModelById(int id)
    {
      string sql = @"
        SELECT * FROM contractors WHERE id=@Id;
      
      ";
      return _db.Query<ContractorViewModel>(sql, new { id }).FirstOrDefault();
    }
  }
}