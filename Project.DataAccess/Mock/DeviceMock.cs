using Bogus;
using Project.DataAccess.Entities;

namespace Project.DataAccess.Mock
{
    public static class DeviceMock
    {
        /// <summary>
        /// Генерация тестовых данных устройств
        /// </summary>
        public static List<Device> GetDevices()
        {
            Faker<Device> generatorDevice = getGeneratorDevice();
            List<Device> devices = generatorDevice.Generate(100);

            return devices;
        }

        private static Faker<Device> getGeneratorDevice()
        {
            return new Faker<Device>("ru")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.DeviceType, f => f.Random.ListItem(new List<string> {
                            "TYPE1",
                            "TYPE2",
                            "TYPE3",
                        }))
                .RuleFor(x => x.Address, f => f.Address.StreetAddress())
                .RuleFor(x => x.SerialNumber, f => f.Random.Int(1000, 5000))
                .RuleFor(x => x.Status, f => f.Random.ListItem(new List<string> {
                            "Работает",
                            "На ремонте",
                            "Не работает",
                        }))
                .RuleFor(x => x.LastActivity, f => DateTime.Now.AddMinutes(f.Random.Int(-1000, -1)))
                .RuleFor(x => x.BufferSize, f => f.Random.Int(10, 1000))
                .RuleFor(x => x.Temperature, f => f.Random.Int(40, 60))
                ;
        }
    }
}
