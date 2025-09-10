using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class busqueda : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public busqueda(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
           string fecha_inicio = "",
           string fecha_fin = "",
           string categoria = "",
           string nombre = ""
            
        )
        {
            // URL de tu App Script
           
            string url = $"https://script.google.com/macros/s/AKfycbzhiLHI4GZjruRN-zkreV2gHLVCUIhgybW7OJwVB2l3kLbirJGqwg-kko74q7Doo3cYgA/exec?tipo=busqueda_api&fecha_inicio={fecha_inicio}&fecha_fin={fecha_fin}&categoria={categoria}&nombre={nombre}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error no se Econtro datos");
            }

            var json = await response.Content.ReadAsStringAsync();

            return Content(json, "application/json");
        }

    }
}
