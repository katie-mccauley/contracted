namespace contracted.Models
{
  public class Contractor
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class ContractorViewModel : Contractor
  {
    public int JobId { get; set; }
    public string CompanyName { get; set; }
  }
}