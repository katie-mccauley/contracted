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


  }
}