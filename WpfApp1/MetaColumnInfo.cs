using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Yanusosu.AbpCodeGenerator.Models
{
    public class MetaColumnInfo
    {
        public string StrDataType { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string CamelCaseName { get; set; }

        public bool IsSimpleProperty { get; set; }

        public bool IsRelation { get; set; }

        public bool IsCollection { get; set; }

        public List<string> AttributesList { get; set; }

        public string ControlType { get; set; }

        public bool IsDtoVisible { get; set; }

        public bool IsCreateVisible { get; set; }

        public bool IsUpdateVisible { get; set; }

        public bool Required { get; set; }

        public int? MaxLength { get; set; }
    }
}