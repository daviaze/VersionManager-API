using System.Text.Json;
using System.Text.Json.Serialization;
using VersionManager.Domain.Exceptions;

namespace VersionManager.Domain.Enums
{
    public enum AmbientVersion
    {
        approval = 0,
        release = 1,
    }

    public static class AmbientVersionExtensions
    {
        public static string ToStringFast(this AmbientVersion version)
        {
            return version switch
            {
                AmbientVersion.approval => "approval",
                AmbientVersion.release => "release",
                _ => throw new EnumParseException("Invalid version type!")
            };
        }

        public static AmbientVersion AmbientVersionFromString(this string status)
        {
            return status.ToLower() switch
            {
                "approval" => AmbientVersion.approval,
                "release" => AmbientVersion.release,
                _ => throw new EnumParseException("Invalid version type!")
            };
        }
    }

    public sealed class AmbientVersionJsonConverter : JsonConverter<AmbientVersion>
    {
        public override AmbientVersion Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader
               .GetString()?
               .AmbientVersionFromString() ??
                   throw new JsonException("Ambient version cannot be null!");
        }

        public override void Write(
            Utf8JsonWriter writer,
            AmbientVersion value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToStringFast());
        }
    }
}
