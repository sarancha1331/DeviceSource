using Project.Application.Models;
using Project.Application.Params;

namespace Project.Application.Interfaces
{
    /// <summary>
    /// Сервис устройств
    /// </summary>
    public interface IDeviceService
    {
        /// <summary>
        /// Получение устройства по Шв
        /// </summary>
        /// <param name="id">Шв</param>
        DeviceModel GetDevice(Guid id);

        /// <summary>
        /// Получение всех устройств
        /// </summary>
        List<DeviceModel> GetDevices();

        /// <summary>
        /// Получение устройств по параметрам
        /// </summary>
        /// <param name="param">Параметры</param>
        List<DeviceModel> GetDeviceByProperty(DeviceQueryParam param);
    }
}
