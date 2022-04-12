namespace contracted.Models
{
  public class Company
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
  public class CompanyViewModel : Company
  {
    public int? JobId { get; set; }
  }
}