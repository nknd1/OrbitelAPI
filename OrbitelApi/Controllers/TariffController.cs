using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrbitelApi.DBContext;
using OrbitelApi.Models.Dtos;
using OrbitelApi.Models.Entities.Tariffs;

namespace OrbitelApi.Controllers;
[ApiController]
[Route("api/Tariff")]
public class TariffController(OrbitelContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TariffDto>>> GetTariff()
    {
        var result = await _context.Tariffs.ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("api/Tariff/{TariffId:long}")]
    public async Task<ActionResult<Tariff>> GetTariffById(long TariffId)
    {
        if (TariffId <= 0)
        {
            return BadRequest("tariffs not found");
        }
        
        var res = await _context
            .Tariffs
            .FindAsync(TariffId);

        return Ok(TariffId);
    }
}