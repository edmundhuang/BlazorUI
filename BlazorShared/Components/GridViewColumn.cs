using System.Reflection;

namespace BlazorShared.Components
{
    internal class GridViewColumn
    {
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public PropertyInfo Property { get; set; }

        public bool Sortable { get; set; }

        public bool isExtra { get; set; } = false;
        public string CellValue { get; set; }

    }
}