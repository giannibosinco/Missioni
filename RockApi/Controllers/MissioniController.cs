using CQRS.Commands;
using CQRS.Queries;
using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using DomainModel.CQRS.Queries.Missioni;
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
{  /// <summary>
   /// Servizi per la la tabella Missioni
   /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]

    public class MissioniController : ControllerBase
    {
        private readonly ICommandHandler<AddMissioneCommand> handlerInsertMissione;
        private readonly IQueryHandler<GetMissioniQuery, List<GetMissioniQueryResult>> handler;

        public MissioniController(ICommandHandler<AddMissioneCommand> handlerInsertMissione, IQueryHandler<GetMissioniQuery, List<GetMissioniQueryResult>> handler)
        {
            this.handlerInsertMissione = handlerInsertMissione;
            this.handler = handler;
        }

        //public MissioneController(ICommandHandler<AddMissioneCommand> handlerInsertMissione)
        //{
        //    this.handlerInsertMissione = handlerInsertMissione ?? throw new ArgumentNullException(nameof(handlerInsertMissione));
        //}




        /// <summary>
        /// Servizio per il recupero delle missioni
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMissioneResult_DTO), (int)HttpStatusCode.OK)]
        public ActionResult<GetMissioneResult_DTO> Get()
        {
            try
            {
                Log.Information("Chiamato Get di MissioniController");
                return Ok(handler.Handle(new GetMissioniQuery()));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MissioniController");
                return BadRequest("Errore nel recupero delle  missioni");
            }
        }

        // POST api/<MissioneController1>
        /// <summary>
        /// Servizio per la scrittura delle Missioni
        /// </summary>
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
                    CodSedeMissione = nuovaMissione.CodSedeMissione,
                    DataOraInizioMissione = nuovaMissione.DataOraInizioMissione,
                    DataOraFineMissione = nuovaMissione.DataOraFineMissione,
                    LocalitaPartenza = nuovaMissione.LocalitaPartenza,
                    LocalitaDestinazione = nuovaMissione.LocalitaDestinazione,
                    MotivoMissione = nuovaMissione.MotivoMissione,
                    MezziTrasporto = nuovaMissione.MezziTrasporto,
                    EstremiAutorizzazione = nuovaMissione.EstremiAutorizzazione,
                    IdTipologiaMissione = nuovaMissione.IdTipologiaMissione,
                    CodEvento = nuovaMissione.CodEvento,
                    FlProv = nuovaMissione.FlProv,
                    FlSedeVvf = nuovaMissione.FlSedeVvf,
                    IdCausaliMissione = nuovaMissione.IdCausaliMissione,
                    DataInizioMissione = nuovaMissione.DataInizioMissione,
                    //miss.DtInizioValidita = .DateTime.Now;
                    //miss.DtFineValidita = null;
                    //miss.DtIns = DateTime.Now;
                    //miss.User = " ";
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
