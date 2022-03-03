using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetIntSum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    /// <summary>
    /// Questo è un esempio di commento per il controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IntSumCalculatorController : ControllerBase
    {
        private readonly IQueryHandler<GetIntSumQuery, int> handler;

        public IntSumCalculatorController(IQueryHandler<GetIntSumQuery, int> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        /// <summary>
        /// Questo è un esempio di commento per un servizio
        /// </summary>
        /// <remarks>
        /// Se necessario, si possono specificare ulteriori dettagli
        /// </remarks>
        /// <param name="query"></param>

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public ActionResult<int> Get([FromQuery] GetIntSumQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}