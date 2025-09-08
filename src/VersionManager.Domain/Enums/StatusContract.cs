using System.Text.Json;
using System.Text.Json.Serialization;
using VersionManager.Domain.Exceptions;

namespace VersionManager.Domain.Enums
{
    public enum StatusContract
    {
        active = 1,
        inactive = 2,
        canceled = 3
    }

    public static class StatusContractExtensions
    {
        public static string ToStringFast(this StatusContract status)
        {
            return status switch
            {
                StatusContract.active => "active",
                StatusContract.inactive => "inactive",
                StatusContract.canceled => "canceled",
                _ => throw new EnumParseException("Invalid status contract!")
            };
        }

        public static StatusContract StatusContractFromString(this string status)
        {
            return status.ToLower() switch
            {
                "active" => StatusContract.active,
                "inactive" => StatusContract.inactive,
                "canceled" => StatusContract.canceled,
                _ => throw new EnumParseException("Invalid status contract!")
            };
        }
    }

    public sealed class StatusContractJsonConverter : JsonConverter<StatusContract>
    {
        public override StatusContract Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader
               .GetString()?
               .StatusContractFromString() ??
                   throw new JsonException("Status contract cannot be null!");
        }

        public override void Write(
            Utf8JsonWriter writer,
            StatusContract value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToStringFast());
        }
    }
}
