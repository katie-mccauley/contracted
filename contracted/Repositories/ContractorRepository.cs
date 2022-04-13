using System;
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

    internal string Remove(int contractId)
    {
      string sql = @"
      DELETE FROM contractors WHERE id = @contractId LIMIT 1;
      ";
      int removedRow = _db.Execute(sql, new { contractId });
      if (removedRow > 0)
      {
        return "DELETED";
      }
      throw new Exception("could not deletes this recipe");
    }

    internal void Update(Contractor contractorData)
    {
      string sql = @"
      UPDATE contractors 
        SET 
        name = @Name
        WHERE id = @Id;
      ";
      _db.Execute(sql, contractorData);
    }

    internal Contractor Create(Contractor contractorData)
    {
      string sql = @"
      INSERT INTO contractors
      (name)
      VALUES 
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, contractorData);
      contractorData.Id = id;
      return contractorData;
    }

    internal Contractor GetById(int contractId)
    {
      string sql = @"
      SELECT * FROM contractors WHERE id = @contractId;
      ";
      return _db.Query<Contractor>(sql, new { contractId }).FirstOrDefault();
    }

    internal List<Contractor> GetAll()
    {
      string sql = @"
      SELECT 
      * FROM contractors;
      ";
      return _db.Query<Contractor>(sql).ToList();
    }
  }
}