using System.Collections.Generic;
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

    internal List<CompanyViewModel> GetCompaniesByContractorId(int contractId)
    {
      string sql = @"
        SELECT 
          contractor.*,
          job.*,
          company.*
        FROM jobs job
        JOIN contractors contractor ON contractor.id = job.contractorId
        JOIN companies company ON company.id = job.companyId
        WHERE job.contractorId = @contractId;";
      List<CompanyViewModel> company = _db.Query<Contractor, Job, CompanyViewModel, CompanyViewModel>(sql, (con, j, com) =>
      {
        com.JobId = j.Id;
        com.CompanyName = con.Name;
        return com;
      }, new { contractId }).ToList();
      return company;
    }
  }
}