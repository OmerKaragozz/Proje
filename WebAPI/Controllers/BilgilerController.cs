using Application.Abstract;
using Application.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilgilerController : ControllerBase
    {
        private IBilgiService _bilgiservice;

        public BilgilerController()
        {
            _bilgiservice = new BilgiManager();
        }

        [HttpGet]
        public List<Bilgi> Get()
        {
            return _bilgiservice.GetAllBilgiler();
        }

        [HttpGet("{id}")]
        public Bilgi Get(int id)
        {
            return _bilgiservice.GetBilgiById(id);
        }
        
        [HttpPost]
        public Bilgi Post([FromBody]Bilgi bilgi)
        {
            return _bilgiservice.CreatedBilgi(bilgi);
        }
        
        [HttpPut]
        public Bilgi Put([FromBody] Bilgi bilgi)
        {
            return _bilgiservice.UpdateBilgi(bilgi);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bilgiservice.DeleteBilgi(id);
        }
        
        [HttpPost("addall")]
        public List<Bilgi> Post([FromBody] List<Bilgi> bilgi)
        {
            return _bilgiservice.BatchCreationBilgi(bilgi);
        }
        
    }
}
