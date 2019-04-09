namespace Server.Entities
{
  using System.ComponentModel.DataAnnotations.Schema;

  [Table(nameof(MetricDefinition))]
  public class MetricDefinition : IEntity
  {
    /// <summary>
    /// Id of the Owning AssetDefinition
    /// </summary>
    public int AssetDefinitionId { get; set; }

    /// <summary>
    /// Default Value of a Metric using this MetricDefinition
    /// </summary>
    public string Default { get; set; }

    /// <summary>
    /// Brief Description of the Metric
    /// </summary>
    /// <remarks>Possibly good for tool-tip notification</remarks>
    public string Description { get; set; }

    public int MetricDefinitionId { get; set; }

    /// <summary>
    /// The Name of the metric
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A Regex expression that the input must match
    /// </summary>
    public string Regex { get; internal set; }

    /// <summary>
    /// Html PlaceHolder value, to show user an example of data
    /// </summary>
    public string SampleValue { get; set; }

    /// <summary>
    /// This probably becomes a class  See Quantity in Suite Model
    /// </summary>
    public string UnitOfMeasure { get; set; }

    public int Id => MetricDefinitionId;
  }
}