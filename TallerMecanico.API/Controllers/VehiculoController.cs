using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Business.Vehiculos;
using TallerMecanico.Entities.DataTransferObjects;
using TallerMecanico.Entities.Models;

namespace TallerMecanico.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class VehiculoController : Controller
    {
        private readonly IVehiculoBusiness vehiculoBusiness;
        public VehiculoController(IVehiculoBusiness vehiculoBusiness)
        {
            this.vehiculoBusiness = vehiculoBusiness;
        }

        [Route("ingresar")]
        [HttpPut]
        public async Task<ActionResult<long>> Ingresar([FromBody] VehiculoDTO model)
        {
            var res = await vehiculoBusiness.Ingresar(model);
            return Ok(res);
        }

        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<Vehiculo>> GetVehiculosADiagnosticar()
        {
            var res = await vehiculoBusiness.GetVehiculosADiagnosticar();
            return Ok(res);
        }
    }
}
