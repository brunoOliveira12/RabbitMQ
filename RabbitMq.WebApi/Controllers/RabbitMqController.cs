using Microsoft.AspNetCore.Mvc;
using RabbitMq.Infra;

namespace RabbitMq.WebApi.Controllers
{
    public class RabbitMqController(RabbitMqProducer producer) : ControllerBase
    {
        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] string message)
        {
            producer.PublishMessage(message);
            return Ok("Mensagem enviada!");
        }
    }
}
