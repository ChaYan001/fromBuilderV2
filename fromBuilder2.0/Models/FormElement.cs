namespace fromBuilder2.Models
{
    public class FormElement
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Required { get; set; }
        public string Placeholder { get; set; } = string.Empty;
        public object? DefaultValue { get; set; }
        public List<ValidationRule> ValidationRules { get; set; } = new List<ValidationRule>();
        public Dictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

        // Added responsive layout properties
        public int ColSpanXS { get; set; } = 12;
        public int ColSpanSM { get; set; } = 6;
        public int ColSpanMD { get; set; } = 6;
        public int ColSpanLG { get; set; } = 4;
    }

    public class ValidationRule
    {
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public object? Value { get; set; }
    }

    public class TextBoxElement : FormElement
    {
        public TextBoxElement()
        {
            Type = "TextBox";
        }
        public bool Multiline { get; set; }
        public int? MaxLength { get; set; }
        public string InputMode { get; set; } = "text";
    }

    public class DropDownElement : FormElement
    {
        public DropDownElement()
        {
            Type = "DropDown";
        }
        public List<DropDownOption> Options { get; set; } = new List<DropDownOption>();
        public bool AllowMultiple { get; set; }
    }

    public class DropDownOption
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class DatePickerElement : FormElement
    {
        public DatePickerElement()
        {
            Type = "DatePicker";
        }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public string Format { get; set; } = "MM/dd/yyyy";
    }

    public class FormSchema
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<FormElement> Elements { get; set; } = new List<FormElement>();
    }
}