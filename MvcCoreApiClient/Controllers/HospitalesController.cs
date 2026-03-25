using Microsoft.AspNetCore.Mvc;
using MvcCoreApiClient.Models;
using MvcCoreApiClient.Services;

namespace MvcCoreApiClient.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospitales service;

        public HospitalesController(ServiceHospitales service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales =
                await this.service.GetHospitalesAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> ServidorDetails(int id)
        {
            Hospital h = await this.service.FindHospitalAsync(id);
            return View(h);
        }

    }
}
