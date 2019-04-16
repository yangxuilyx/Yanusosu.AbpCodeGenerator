using System.Net.Mime;
using System.Windows.Controls;
using System.Windows.Forms;
using EnvDTE;

namespace Yanusosu.AbpCodeGenerator.Models
{
    public enum MetaColumnControlType
    {
        Text,
        Textarea,
        TextEditor,
        Hidden,
        DatePicker,
        DateTimePicker,
        DropdownList,
        Checkbox
    }
}