namespace Project.Application.Params
{
    public class DeviceQueryParam
    {
        /// <summary>
        /// Возрастание/Убывание
        /// </summary>
        public string AscendingProperty { get; set; }

        /// <summary>
        /// Сортируемый слолбец
        /// </summary>
        public string SortableColumn { get; set; }

        /// <summary>
        /// Выбранные статус
        /// </summary>
        public string SelectedStatus { get; set; }

        /// <summary>
        /// Выбранные тип
        /// </summary>
        public string SelectedType { get; set; }
    }
}
