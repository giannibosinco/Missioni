using CQRS.Queries;
using DomainModel.CQRS.Queries.TipologieMissioni;
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
    /// Servizi per la tipologica TipologiaMissione
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class TipologiaMissioneController : ControllerBase
    {
        private readonly IQueryHandler<GetTipologieMissioniQuery, List<GetTipologieMissioniQueryResult>> handler;

        public TipologiaMissioneController(IQueryHandler<GetTipologieMissioniQuery, List<GetTipologieMissioniQueryResult>> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }


        // GET: api/<TipologiaMissioneController>

        /// <summary>
        /// Servizio per il recupero delle tipologie missione
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTipologiaMissioniResult_DTO), (int)HttpStatusCode.OK)]
        public ActionResult <GetTipologiaMissioniResult_DTO>  Get()
        {
            try
            {
                Log.Information("Chiamato Get di TipologiaMissioneController");
                return Ok(handler.Handle(new GetTipologieMissioniQuery()));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "TipologiaMissioneController");
                return BadRequest("Errore nel recupero delle tipologie missione");
            }
        }

      
    }
}
