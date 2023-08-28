using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileApp
{
    /// <summary>
    /// 색상과 점들의 모임(선의 위치)가 저장되는 클래스
    /// </summary>
    internal class OzLine : ICloneable
    {
        /// <summary>
        /// Point
        /// </summary>
        [JsonPropertyName(nameof(Points))]
        [JsonConverter(typeof(PointListConverter))]
        public List<Point> Points { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [JsonPropertyName(nameof(Color))]
        [JsonConverter(typeof(ColorHexConverter))]
        public Color Color { get; set; }

        public object Clone()
        {
            return this.Clone();
        }
    }

    #region ColorHex Converter구현
    /// <summary>
    /// Json Color Converter (Color 구조체를 저장하고 불러올때 hex값을 사용하도록 한다.)
    /// </summary>
    public class ColorHexConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string hexValue = reader.GetString();
            return ColorTranslator.FromHtml(hexValue);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            string hexValue = ColorTranslator.ToHtml(Color.FromArgb(value.ToArgb()));
            writer.WriteStringValue(hexValue);
        }
    }
    #endregion

    #region Point List Converter 구현
    /// <summary>
    /// Json List Point Conveter List Point 제네릭 리스트를 저장할때 X,Y값을 입력토록한다.
    /// </summary>
    public class PointListConverter : JsonConverter<List<Point>>
    {
        public override List<Point> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<Point> pointList = new List<Point>();

            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                foreach (JsonElement element in root.EnumerateArray())
                {
                    int x = element.GetProperty("X").GetInt32();
                    int y = element.GetProperty("Y").GetInt32();
                    pointList.Add(new Point(x, y));
                }
            }

            return pointList;
        }

        public override void Write(Utf8JsonWriter writer, List<Point> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (Point point in value)
            {
                writer.WriteStartObject();
                writer.WriteNumber("X", point.X);
                writer.WriteNumber("Y", point.Y);
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
        }
    }
    #endregion

}
