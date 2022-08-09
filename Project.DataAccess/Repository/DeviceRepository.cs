using Project.DataAccess.Entities;
using Project.DataAccess.Extension;
using Project.DataAccess.Mock;

namespace Project.DataAccess.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly List<Device> _devices;

        public DeviceRepository()
        {
            _devices = DeviceMock.GetDevices();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Device> GetAllDevice()
        {
            return _devices;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Device GetDevice(Guid id)
        {
            return _devices.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Device> SortedDeviceByColumn(string sortColumn, bool isAsc = true, List<Device>? devices = null)
        {
            var sourceData = GetSourceDevices(devices);

            return SortedDeviceByProperty(sortColumn, isAsc, sourceData);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Device> SelectDeviceByType(string selectType, List<Device>? devices = null)
        {
            var sourceData = GetSourceDevices(devices);

            return sourceData.Where(t => t.DeviceType == selectType).ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Device> SelectDeviceByStatus(string selectStatus, List<Device>? devices = null)
        {
            var sourceData = GetSourceDevices(devices);

            return sourceData.Where(t => t.Status == selectStatus).ToList();
        }

        /// <summary>
        /// Получение контейнера исходных/полученных данных
        /// </summary>
        private List<Device> GetSourceDevices(List<Device>? devices)
        {
            return devices == null ? _devices : devices;
        }

        /// <summary>
        /// Сортировка по полю и возрастанию/убыванию
        /// </summary>
        private List<Device> SortedDeviceByProperty(string sortColumn, bool isAsc, List<Device> sourceData)
        {
            switch (sortColumn)
            {
                case nameof(Device.DeviceType): return sourceData.OrderBy(t => t.DeviceType, isAsc).ToList();
                case nameof(Device.SerialNumber): return sourceData.OrderBy(t => t.SerialNumber, isAsc).ToList();
                case nameof(Device.Status): return sourceData.OrderBy(t => t.Status, isAsc).ToList();
                case nameof(Device.Address): return sourceData.OrderBy(t => t.Address, isAsc).ToList();
                case nameof(Device.LastActivity): return sourceData.OrderBy(t => t.LastActivity, isAsc).ToList();
                case nameof(Device.BufferSize): return sourceData.OrderBy(t => t.BufferSize, isAsc).ToList();
                case nameof(Device.Temperature): return sourceData.OrderBy(t => t.Temperature, isAsc).ToList();
            }

            return sourceData;
        }
    }
}
