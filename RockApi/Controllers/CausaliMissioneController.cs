using CQRS.Queries;
using DomainModel.CQRS.Queries.CausaliMissione;
using Microsoft.AspNetCore.Mvc;
using MissioniBE.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissioniBE.Controllers
{



    /// <summary>
    /// Servizi per la tipologica CausaliMissione
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class CausaliMissioneController : ControllerBase
    {
        private readonly IQueryHandler<GetCausaleMissioneQuery, List<GetCausaleMissioneQueryResult>> handler;

        public CausaliMissioneController(IQueryHandler<GetCausaleMissioneQuery, List<GetCausaleMissioneQueryResult>> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }


        // GET: api/<CausaliMissioneController>

        /// <summary>
        /// Servizio per il recupero delle causali missione
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCausaleMissioniResult_DTO), (int)HttpStatusCode.OK)]
        public ActionResult<GetCausaleMissioniResult_DTO> Get()
        {
            try { 
                Log.Information("Chiamato Get di CausaliMissioneController");
                return Ok(handler.Handle(new GetCausaleMissioneQuery()));
            }
            catch(Exception ex)
            {
                Log.Error(ex, "CausaliMissioneController");
                return BadRequest("Errore nel recupero delle causali missione");
            }
        }
        
    }
}
