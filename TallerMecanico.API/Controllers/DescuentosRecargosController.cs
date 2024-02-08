using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Business.DescuentosRecargos;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class DescuentosRecargosController : Controller
    {
        private readonly IDescuentosRecargoBusiness descuentosRecargosSVC;
        public DescuentosRecargosController(IDescuentosRecargoBusiness descuentosRecargosSVC)
        {
            this.descuentosRecargosSVC = descuentosRecargosSVC;
        }

        [Route("SaveOrUpdate")]
        [HttpPut]
        public async Task<ActionResult<long>> SaveOrUpdate([FromBody] DescuentosRecargo descuentosRecargo)
        {
            var res = await descuentosRecargosSVC.SaveOrUpdate(descuentosRecargo);
            return Ok(res);
        }

        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult<DescuentosRecargo>> GetAll()
        {
            var res = await descuentosRecargosSVC.GetAll(true);
            return Ok(res);
        }
    }
}
