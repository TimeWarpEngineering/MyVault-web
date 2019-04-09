namespace Server.Entities
{
  using System.ComponentModel.DataAnnotations.Schema;

  [Table(nameof(Application))]
  public class Application: IEntity
  {
    
    public int ApplicationId { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }

    public int Id => ApplicationId;
  }
}
