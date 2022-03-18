using CQRS.Commands;
using CQRS.Queries;
using DomainModel.CQRS.AnagraficaMissioniDipendenti;
using DomainModel.CQRS.Queries.MissioniDipendenti;
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
    /// Servizi per la la tabella MissioniDipendenti
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class MissioniDipendentiController : ControllerBase
    {
        private readonly ICommandHandler<AddMissioniDipendentiCommand> handlerInsertMissioniDipendenti;
        private readonly IQueryHandler<GetMissioniDipendentiQuery, List<GetMissioniDipendentiQueryResult>> handler;

        public MissioniDipendentiController(ICommandHandler<AddMissioniDipendentiCommand> handlerInsertMissioniDipendenti, IQueryHandler<GetMissioniDipendentiQuery, List<GetMissioniDipendentiQueryResult>> handler)
        {
            this.handlerInsertMissioniDipendenti = handlerInsertMissioniDipendenti;
            this.handler = handler;
        }


        /// <summary>
        /// Servizio per il recupero delle missioniDipendenti
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMissioniDipendentiResult_DTO), (int)HttpStatusCode.OK)]
        public ActionResult<GetMissioniDipendentiResult_DTO> Get()
        {
            try
            {
                Log.Information("Chiamato Get di MissioniDipendentiController");
                return Ok(handler.Handle(new GetMissioniDipendentiQuery()));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MissioniDipendentiController");
                return BadRequest("Errore nel recupero delle  missioniDipendenti");
            }
        }
        /// <summary>
        /// Servizio per il recupero dei Dipendenti assegnati ad una missione specifica
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMissioniDipendentiResult_DTO), (int)HttpStatusCode.OK)]
        public ActionResult<GetMissioniDipendentiResult_DTO> GetDipendentiMissione(Guid idmissione)
        {
            try
            {
                Log.Information("Chiamato GetDipendentiMissione di MissioniDipendentiController");
                return Ok(handler.Handle(new GetMissioniDipendentiQuery())
                    .Where(i=>i.IdMissione == idmissione && i.DtFineValidita is null));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "MissioniDipendentiController");
                return BadRequest("Errore nel recupero dei dipendenti assegnati ad una missione");
            }
        }
        // POST api/<MissioniDipendentiController1>
        /// <summary>
        /// Servizio per la scrittura delle missioniDipendenti
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public ActionResult Post([FromBody] AddMissioniDipendentiCommand_DTO nuovaMissione)
        {
            try
            {
                handlerInsertMissioniDipendenti.Handle(new AddMissioniDipendentiCommand
                {
                    IdMissione = nuovaMissione.IdMissione,
                    IdDipendente = nuovaMissione.IdDipendente,
                    CodFiscale = nuovaMissione.CodFiscale,
                    IdMansione = nuovaMissione.IdMansione,
                    DataOraPartitoSede = nuovaMissione.DataOraPartitoSede,
                    DataOraArrivatoSede = nuovaMissione.DataOraArrivatoSede,
                    FLavorato = nuovaMissione.FLavorato,

                    //miss.DtInizioValidita = .DateTime.Now;
                    //miss.DtFineValidita = null;
                    //miss.DtIns = DateTime.Now;
                    //miss.User = " ";
                }); ;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        //// PUT api/<MissioniDipendentiController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MissioniDipendentiController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
