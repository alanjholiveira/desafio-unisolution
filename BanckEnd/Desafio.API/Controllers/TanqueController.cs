using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanqueController : ControllerBase
    {

        private readonly ITanqueServiceApplication _tanqueServiceApplication;

        public TanqueController(ITanqueServiceApplication TanqueServiceApplication)
        {
            _tanqueServiceApplication = TanqueServiceApplication;
        }


        // GET: api/Tanque
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_tanqueServiceApplication.GetAll());
        }

        // GET: api/Tanque/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_tanqueServiceApplication.GetById(id));
        }

        // POST: api/Tanque
        [HttpPost]
        public ActionResult Post([FromBody] TanqueDTO tanqueDTO)
        {
            try
            {
                if (tanqueDTO == null)
                {
                    return NotFound();
                }

                _tanqueServiceApplication.Add(tanqueDTO);
                return Ok(tanqueDTO);

            } catch (Exception e)
            {
                throw e;
            }
        }

        // PUT: api/Tanque/5
        [HttpPut]
        public ActionResult Put([FromBody] TanqueDTO tanqueDTO)
        {
            try
            {
                if (tanqueDTO == null)
                {
                    return NotFound();
                }

                _tanqueServiceApplication.Update(tanqueDTO);
                return Ok(tanqueDTO);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                TanqueDTO tanqueDTO = new TanqueDTO() { Id = id };

                if (tanqueDTO != null)
                {
                    _tanqueServiceApplication.Remove(tanqueDTO);
                }
                               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
