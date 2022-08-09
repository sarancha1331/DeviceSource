using Project.Application.Enum;
using Project.Application.Helper;
using Project.Application.Interfaces;
using Project.Application.Mapping;
using Project.Application.Models;
using Project.Application.Params;
using Project.DataAccess.Entities;
using Project.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DeviceModel GetDevice(Guid id)
        {
            var device = _deviceRepository.GetDevice(id);

            if (device == null)
            {
                throw new ArgumentNullException("Ошибка");
            }

            return new DeviceModel()
            {
                Id = device.Id,
                Address = device.Address,
                BufferSize = device.BufferSize,
                DeviceType = device.DeviceType,
                LastActivity = device.LastActivity,
                SerialNumber = device.SerialNumber,
                Status = device.Status,
                Temperature = device.Temperature
            };
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<DeviceModel> GetDevices()
        {
            return _deviceRepository.GetAllDevice().Select(r => r.ToDeviceModel()).ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<DeviceModel> GetDeviceByProperty(DeviceQueryParam param)
        {
            if (param == null)
            {
                throw new ArgumentNullException("Ошибка");
            }

            var result = new List<Device>();
            var isDataChanged = false;

            //Выборка по типу
            result = GetDataByType(param.SelectedType, ref isDataChanged, result);

            //Выборка по статусу
            result = GetDeviceByStatus(param.SelectedStatus, ref isDataChanged, result);

            //Выборка по колонке с сортировкой
            result = GetDeviceByColumn(param.SortableColumn, param.AscendingProperty == SortableEnum.Ascending.GetEnumDescription(), ref isDataChanged, result);

            return result.Select(r => r.ToDeviceModel()).ToList();
        }

        /// <summary>
        /// Выборка по типу
        /// </summary>
        /// <param name="selectedType"></param>
        /// <param name="isDataChanged"></param>
        /// <param name="sourceData"></param>
        private List<Device> GetDataByType(string selectedType, ref bool isDataChanged, List<Device> sourceData)
        {
            if (selectedType != string.Empty && selectedType != null)
            {
                if (isDataChanged)
                {
                    return _deviceRepository.SelectDeviceByType(selectedType, sourceData);
                }

                isDataChanged = true;

                return _deviceRepository.SelectDeviceByType(selectedType);
            }

            return sourceData;
        }

        /// <summary>
        /// Выборка по статусу
        /// </summary>
        /// <param name="selectedStatus"></param>
        /// <param name="isDataChanged"></param>
        /// <param name="sourceData"></param>
        private List<Device> GetDeviceByStatus(string selectedStatus, ref bool isDataChanged, List<Device> sourceData)
        {
            if (selectedStatus != string.Empty && selectedStatus != null)
            {
                if (isDataChanged)
                {
                    return _deviceRepository.SelectDeviceByStatus(selectedStatus, sourceData);
                }

                isDataChanged = true;

                return _deviceRepository.SelectDeviceByStatus(selectedStatus);
            }

            return sourceData;
        }

        /// <summary>
        /// Выборка по колонке
        /// </summary>
        /// <param name="selectedColumn"></param>
        /// <param name="isAsc"></param>
        /// <param name="isDataChanged"></param>
        /// <param name="sourceData"></param>
        private List<Device> GetDeviceByColumn(string selectedColumn, bool isAsc, ref bool isDataChanged, List<Device> sourceData)
        {
            if (selectedColumn != string.Empty && selectedColumn != null)
            {
                if (isDataChanged)
                {
                    return _deviceRepository.SortedDeviceByColumn(selectedColumn, isAsc, sourceData);
                }

                isDataChanged = true;

                return _deviceRepository.SortedDeviceByColumn(selectedColumn, isAsc);
            }

            if (!isDataChanged)
            {
                return _deviceRepository.GetAllDevice();
            }

            return sourceData;
        }

    }
}
