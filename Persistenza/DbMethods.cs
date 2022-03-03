using DomainModel.Common;
using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using DomainModel.CQRS.Queries.CausaliMissione;
using Persistenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistenza
{
    /// <summary>
    /// Questa classe contiene tutti i metodi per l'accesso al DB delle Missioni
    /// </summary>
    public class DbMethods: IDbMethods
    {
        private missioniDbContext _context;

        public DbMethods(missioniDbContext context)//sipecdbContext context)//postgresContext context)
        {
            this._context = context;
        }


        public int Count ()
        {
            return _context.Missionis.Select(s => s).ToList().Count;
        }

        public List<GetCausaleMissioneQueryResult> elencoCausaliMissione()
        {
            return _context.CausaliMissiones.Select(s => new GetCausaleMissioneQueryResult
            {
                IdCausaliMissione = s.IdCausaliMissione,
                DescCausaleMissione = s.DescCausaleMissione,
                TipoMissione = s.TipoMissione
            }).ToList();
        }

        public void NuovaMissione(AddMissioneCommand missione)
        {
            Missioni miss = new Missioni();
            miss.IdMissione = Guid.NewGuid();
            miss.DtIns = DateTime.Now;
            miss.DtInizioValidita = DateTime.Now;
            miss.CodEvento = missione.CodEvento;
            miss.CodSedeAmmDestinazione = missione.CodSedeAmmDestinazione;
            miss.IdCausaliMissione = missione.IdCausaliMissione;
            miss.IdTipologiaMissione = missione.IdTipologiaMissione;


//da completare





            _context.Missionis.Add(miss);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }
    }
}
