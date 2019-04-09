namespace Shared.Features.AssetDefinition
{
  public class MetricDefinitionDto
  {
    public MetricDefinitionDto() { }

    /// <summary>
    /// The Id of the owning AssetDefinition
    /// </summary>
    public int AssetDefinitionId { get; set; }

    /// <summary>
    /// The Default value to be used for `Metric`'s
    /// associated to this MetricDefinition
    /// </summary>
    public string Default { get; set; }

    /// <summary>
    /// The Description of this Metric
    /// </summary>
    /// <example>TODO:</example>
    public string Description { get; set; }

    /// <summary>
    /// The id of this MetricDefinition
    /// </summary>
    public int MetricDefinitionId { get; set; }

    /// <summary>
    /// The Name of this MetricDefenition
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// a Regular Expression that values in a Metric associated to this MetricDefentiion
    /// have to match. 
    /// </summary>
    public string Regex { get; set; }

    /// <summary>
    /// A sample value that we can display to the user.
    /// </summary>
    public string SampleValue { get; set; }

    /// <summary>
    /// The units used for `Metric`s associated to this `MetricDefinition`
    /// </summary>
    /// <example>kilograms</example>
    /// <example>meters</example>
    /// <example>liters</example>
    public string UnitOfMeasure { get; set; }

    public object Clone() => (MetricDefinitionDto)MemberwiseClone(); // shallow clone is all we need
  }
}