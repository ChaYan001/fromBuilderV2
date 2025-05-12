using System.Text.Json;
using fromBuilder2.Models;

namespace fromBuilder2.Services
{
    public interface IFormSchemaService
    {
        FormSchema ParseSchema(string jsonSchema);
        FormElement CreateElementFromType(string elementType);
        string GenerateSchemaFromElements(List<FormElement> elements);
    }

    public class FormSchemaService : IFormSchemaService
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public FormSchema ParseSchema(string jsonSchema)
        {
            try
            {
                var schema = JsonSerializer.Deserialize<FormSchema>(jsonSchema, _jsonOptions);
                return schema ?? new FormSchema();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing schema: {ex.Message}");
                return new FormSchema();
            }
        }

        public FormElement CreateElementFromType(string elementType)
        {
            return elementType switch
            {
                "TextBox" => new TextBoxElement(),
                "DropDown" => new DropDownElement(),
                "DatePicker" => new DatePickerElement(),
                _ => new FormElement { Type = elementType }
            };
        }

        public string GenerateSchemaFromElements(List<FormElement> elements)
        {
            var schema = new FormSchema
            {
                Elements = elements
            };

            return JsonSerializer.Serialize(schema, _jsonOptions);
        }
    }
}