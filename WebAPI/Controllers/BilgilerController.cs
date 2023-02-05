using Application.Abstract;
using Application.Concrete;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Standart, Administrator")]
        public List<Bilgi> Get()
        {
            return _bilgiservice.GetAllBilgiler();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Standart, Administrator")]
        public Bilgi Get(int id)
        {
            return _bilgiservice.GetBilgiById(id);
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public Bilgi Post([FromBody]Bilgi bilgi)
        {
            return _bilgiservice.CreatedBilgi(bilgi);
        }
        
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public Bilgi Put([FromBody] Bilgi bilgi)
        {
            return _bilgiservice.UpdateBilgi(bilgi);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public void Delete(int id)
        {
            _bilgiservice.DeleteBilgi(id);
        }
        
        [HttpPost("addall")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public List<Bilgi> Post([FromBody] List<Bilgi> bilgi)
        {
            return _bilgiservice.BatchCreationBilgi(bilgi);
        }
        
    }
}
