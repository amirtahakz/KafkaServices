//using KafkaServices.Api.Consumers.Models;
//using KafkaServices.Kafka.Producer;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace KafkaServices.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class HomeController : ControllerBase
//    {
//        private readonly IKafkaMessageBus<string, User> _bus;

//        public HomeController(IKafkaMessageBus<string, User> bus)
//        {
//            _bus = bus;
//        }

//        // GET api/<HomeController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<HomeController>
//        [HttpPost]
//        public void Publish([FromBody] User model)
//        {
//            _bus.PublishAsync(model.Email, model);
//        }
//    }
//}
