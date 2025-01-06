using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrbitelApi.DBContext;
using OrbitelApi.Models.Dtos;

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
}