namespace Server.Services.AnthemGold
{
  using System;
  using System.Buffers;
  using System.Buffers.Text;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Threading.Tasks;

  public class DecimalJsonConverter : JsonConverter<Decimal>
  {
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

      if (reader.TokenType == JsonTokenType.String)
      {
        ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
        if (Utf8Parser.TryParse(span, out decimal result, out int bytesConsumed) && span.Length == bytesConsumed)
          return result;

        if (decimal.TryParse(reader.GetString(), out result))
          return result;
      }

      return reader.GetDecimal();
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) => 
      writer.WriteStringValue(value.ToString());
  }  
}
