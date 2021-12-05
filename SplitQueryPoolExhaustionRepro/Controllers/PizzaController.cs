using Microsoft.AspNetCore.Mvc;

namespace SplitQueryPoolExhaustionRepro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaAsync(int id)
        {
            return Ok(await pizzaService.GetPizzaAsync(id));
        }
    }
}