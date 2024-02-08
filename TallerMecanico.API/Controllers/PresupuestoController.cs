using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Business.Presupuesto;
using TallerMecanico.Entities.Models;

namespace TallerMecanico.API.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class PresupuestoController : Controller
    {
        private readonly IPresupuestoBusiness presupuestoBusiness;
        public PresupuestoController(IPresupuestoBusiness presupuestoBusiness)
        {
            this.presupuestoBusiness = presupuestoBusiness;
        }

        [Route("presupuestar")]
        [HttpPost]
        public async Task<ActionResult<bool>> ConfeccionarPresupuesto([FromBody] Presupuesto model)
        {
            var res = await presupuestoBusiness.AddOrUpdate(model);
            return Ok(res);
        }

        [Route("calculartotal/{idpresupuesto}")]
        [HttpGet]
        public async Task<ActionResult<decimal>> CalcularlTotal(long idpresupuesto)
        {
            var res = await presupuestoBusiness.CalcularTotal(idpresupuesto);
            return Ok(res);
        }
    }
}
