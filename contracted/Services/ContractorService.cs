using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{



  public class ContractorService
  {
    private readonly ContractorRepository _repo;

    public ContractorService(ContractorRepository repo)
    {
      _repo = repo;
    }

    internal ContractorViewModel GetViewModelById(int id)
    {
      return _repo.GetViewModelById(id);
    }

    internal List<CompanyViewModel> GetCompaniesByContractorId(int contractId)
    {
      return _repo.GetCompaniesByContractorId(contractId);
    }

    internal List<Contractor> GetAll()
    {
      return _repo.GetAll();
    }

    internal Contractor GetById(int contractId)
    {
      Contractor contractor = _repo.GetById(contractId);
      if (contractor == null)
      {
        throw new Exception("this can't be found");
      }
      return contractor;
    }

    internal Contractor Create(Contractor contractorData)
    {
      return _repo.Create(contractorData);
    }

    internal string Remove(int contractId)
    {
      Contractor contractor = _repo.GetById(contractId);
      return _repo.Remove(contractId);
    }
  }
}