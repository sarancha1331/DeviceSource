using Microsoft.AspNetCore.Mvc;
using Project.Application.Interfaces;
using Project.Application.Params;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceService _deviceService;

        public HomeController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public IActionResult Index()
        {
            ViewData["DeviceData"] = _deviceService.GetDevices();

            return View();
        }

        /// <summary>
        /// Выборка записей через фильтр
        /// </summary>
        [HttpGet]
        public IActionResult SortByProperty(DeviceQueryParam statusFilter)
        {
            ViewData["DeviceData"] = _deviceService.GetDeviceByProperty(statusFilter);

            return View("Index");
        }

        /// <summary>
        /// Выборка записей через фильтр
        /// </summary>
        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            ViewData["DeviceDataItem"] = _deviceService.GetDevice(id);

            return View("Item");
        }
    }
}