using System.ComponentModel;

namespace Project.Application.Enum
{
    /// <summary>
    /// Тип сортировки
    /// </summary>
    public enum SortableEnum
    {
        /// <summary>
        /// Возрастанию
        /// </summary>
        [Description("Возрастанию")]
        Ascending = 1,

        /// <summary>
        /// Убыванию
        /// </summary>
        [Description("Убыванию")]
        Descending = 2,
    }
}
