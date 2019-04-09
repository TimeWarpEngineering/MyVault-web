namespace Herc.Pwa.Server.Entities
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// This the MetaData of an Asset.
  /// Many Assets reference a single AssetDefintion
  /// AssetDefinition "1" *-- "*" Asset 
  /// </summary>
  [Table(nameof(AssetDefinition))]
  public class AssetDefinition : IEntity
  {
    public int AssetDefinitionId { get; set; }
    public IList<MetricDefinition> MetricDefinitions { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public byte[] Logo { get; set; }

    public int Id => AssetDefinitionId;
  }
}