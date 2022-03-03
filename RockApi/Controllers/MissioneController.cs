using CQRS.Commands;
using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using Microsoft.AspNetCore.Mvc;
using MissioniBE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissioniBE.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]

    public class MissioneController : ControllerBase
    {
        private readonly ICommandHandler<AddMissioneCommand> handlerInsertMissione;

        public MissioneController(ICommandHandler<AddMissioneCommand> handlerInsertMissione)
        {
            this.handlerInsertMissione = handlerInsertMissione ?? throw new ArgumentNullException(nameof(handlerInsertMissione));
        }



        //// GET: api/<MissioneController1>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<MissioneController1>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MissioneController1>
        [HttpPost]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public ActionResult Post([FromBody] AddMissioneCommand_DTO nuovaMissione)
        {
            try
            {
                handlerInsertMissione.Handle(new AddMissioneCommand
                {
                    CodEvento = nuovaMissione.CodEvento,
                    CodSedeAmmDestinazione = nuovaMissione.CodSedeAmmDestinazione,
                    IdCausaliMissione = nuovaMissione.IdCausaliMissione,
                    IdTipologiaMissione = nuovaMissione.IdTipologiaMissione
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<MissioneController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MissioneController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
