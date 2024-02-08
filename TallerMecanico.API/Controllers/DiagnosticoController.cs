using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Business.Desperfectos;
using TallerMecanico.Business.Vehiculos;
using TallerMecanico.Entities.DataTransferObjects;

namespace TallerMecanico.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class DiagnosticoController : Controller
    {
        private readonly IVehiculoBusiness vehiculoBusiness;
        private readonly IDesperfectoBusiness desperfectoBusiness;
        public DiagnosticoController(IVehiculoBusiness vehiculoBusiness, IDesperfectoBusiness desperfectoBusiness)
        {
            this.vehiculoBusiness = vehiculoBusiness;
            this.desperfectoBusiness = desperfectoBusiness;
        }

        [Route("diagnosticar")]
        [HttpPost]
        public async Task<ActionResult<bool>> Diagnosticar([FromBody] DiagnosticarDTO model)
        {
            var res = desperfectoBusiness.CargarDefectos(model.IdPresupuesto, model.Desperfectos);
            return Ok(res);

        }

    }
}
