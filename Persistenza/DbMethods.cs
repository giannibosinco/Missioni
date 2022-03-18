using DomainModel.Common;
using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using DomainModel.CQRS.Queries.CausaliMissione;
using DomainModel.CQRS.Queries.Missioni;
using DomainModel.CQRS.Queries.TipologieMissioni;
using DomainModel.CQRS.Queries.MissioniDipendenti;
using Persistenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.CQRS.AnagraficaMissioniDipendenti;

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
            miss.CodSedeMissione = Guid.NewGuid();
            miss.DataOraInizioMissione = miss.DataOraInizioMissione;
            miss.DataOraFineMissione = miss.DataOraFineMissione;
            miss.LocalitaPartenza = missione.LocalitaPartenza;
            miss.LocalitaDestinazione = missione.LocalitaDestinazione;
            miss.MotivoMissione = missione.MotivoMissione;
            miss.MezziTrasporto = missione.MezziTrasporto;
            miss.EstremiAutorizzazione = missione.EstremiAutorizzazione;
            miss.IdTipologiaMissione = missione.IdTipologiaMissione;
            miss.CodEvento = missione.CodEvento;
            miss.FlProv = missione.FlProv;
            miss.FlSedeVvf = missione.FlSedeVvf;
            miss.IdCausaliMissione = missione.IdCausaliMissione;
            miss.DataInizioMissione = miss.DataInizioMissione;
            miss.DtInizioValidita = DateTime.Now;
            miss.DtFineValidita = null;
            miss.DtIns = DateTime.Now;
            miss.User = " ";

            _context.Missionis.Add(miss);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }

        public List<GetTipologieMissioniQueryResult> elencoTipologieMissioni()
        {
            return _context.TipologieMissiones.Select(s => new GetTipologieMissioniQueryResult
            {
                IdTipologiaMissione = s.IdTipologiaMissione,
                DescrTipMissione = s.DescrTipMissione,
                VistiConTransiti = s.VistiConTransiti
            }).ToList();
        }
        public List<GetMissioniQueryResult> elencoMissioni()
        {
            return _context.Missionis.Select(s => new GetMissioniQueryResult
            {
                //IdTipologiaMissione = s.IdTipologiaMissione,
                //DescrTipMissione = s.DescrTipMissione,
                //VistiConTransiti = s.VistiConTransiti
            }).ToList();
        }

       
        public List<GetMissioniDipendentiQueryResult> elencoMissioniDipendenti()
        {
            return _context.MissioniDipendentis.Select(s => new GetMissioniDipendentiQueryResult
            {
                //IdTipologiaMissione = s.IdTipologiaMissione,
                //DescrTipMissione = s.DescrTipMissione,
                //VistiConTransiti = s.VistiConTransiti
            }).ToList();
        }
       
        public void NuovaMissioniDipendenti(AddMissioniDipendentiCommand missioneDipendenti)
        {
            MissioniDipendenti missdip = new MissioniDipendenti();          
            missdip.IdMissioneDipendente = Guid.NewGuid();
            missdip.IdMissione = missioneDipendenti.IdMissione;
            missdip.IdDipendente = missioneDipendenti.IdDipendente;
            missdip.IdMansione = missioneDipendenti.IdMansione;
            missdip.CodFiscale = missioneDipendenti.CodFiscale;
            missdip.DataOraPartitoSede = missioneDipendenti.DataOraPartitoSede;
            missdip.DataOraArrivatoSede = missioneDipendenti.DataOraArrivatoSede;
            missdip.FLavorato = missioneDipendenti.FLavorato;
            missdip.DtInizioValidita = DateTime.Now;
            missdip.DtFineValidita = null;
            missdip.DtIns = DateTime.Now;
            missdip.User = " ";

            _context.MissioniDipendentis.Add(missdip);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }
    }
}
