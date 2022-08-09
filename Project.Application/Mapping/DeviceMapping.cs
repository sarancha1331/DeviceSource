using Project.Application.Models;
using Project.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Mapping
{
    /// <summary>
    /// Маппинг для устройств
    /// </summary>
    public static class DeviceMapping
    {
        /// <summary>
        /// Преобразование Devise в DeviseModel
        /// </summary>
        public static DeviceModel ToDeviceModel(this Device item)
        {
            return new DeviceModel()
            {
                Id = item.Id,
                Address = item.Address,
                BufferSize = item.BufferSize,
                DeviceType = item.DeviceType,
                LastActivity = item.LastActivity,
                SerialNumber = item.SerialNumber,
                Status = item.Status,
                Temperature = item.Temperature
            };
        }
    }
}
