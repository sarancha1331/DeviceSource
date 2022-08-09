using Project.DataAccess.Entities;

namespace Project.DataAccess.Repository
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Все элементы
        /// </summary>
        List<Device> GetAllDevice();

        /// <summary>
        /// Получить элемент по Id
        /// </summary>
        /// <param name="id">Id</param>
        Device GetDevice(Guid id);

        /// <summary>
        /// Получение данных с применение сортировки по столбцу
        /// </summary>
        /// <param name="sortColumn">Столбец для сортировки</param>
        ///<param name="sortColumn">Внешний источник данных</param>
        List<Device> SortedDeviceByColumn(string sortColumn, bool isAsc = true, List<Device>? devices = null);

        /// <summary>
        /// Выборка данных по типу
        /// </summary>
        /// <param name="selectType">Тип</param>
        /// <param name="devices">Внешний источник данных</param>
        List<Device> SelectDeviceByType(string selectType, List<Device>? devices = null);

        /// <summary>
        /// Выборка данных по статусу
        /// </summary>
        /// <param name="selectStatus"></param>
        /// <param name="devices">Внешний источник данных</param>
        List<Device> SelectDeviceByStatus(string selectStatus, List<Device>? devices = null);
    }
}
