using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.DataAccess.Models.Helpers.Extensions;

public static class CustomFieldExtensions
{
    public static void SetValue(this CustomField field, object value)
    {
        switch (field.Type)
        {
            case CustomFieldType.StringType:
                field.StringValue = value.ToString();
                break;
            case CustomFieldType.IntType:
                field.IntValue = (int)value;
                break;
            case CustomFieldType.DateTimeType:
                field.DateTimeValue = (DateTime)value;
                break;
            case CustomFieldType.BoolType:
                field.BoolValue = (bool)value;
                break;
            case CustomFieldType.TextType:
                field.TextValue = value.ToString();
                break;
            default:
                throw new InvalidOperationException("Unknown field type.");
        }
    }

    public static object? GetValue(this CustomField field)
    {
        return field.Type switch
        {
            CustomFieldType.StringType => field.StringValue,
            CustomFieldType.IntType => field.IntValue,
            CustomFieldType.DateTimeType => field.DateTimeValue,
            CustomFieldType.BoolType => field.BoolValue,
            CustomFieldType.TextType => field.TextValue,
            _ => throw new InvalidOperationException("Unknown field type."),
        };
    }
}