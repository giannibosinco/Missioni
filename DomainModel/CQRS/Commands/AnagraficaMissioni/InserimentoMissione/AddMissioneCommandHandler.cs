using CQRS.Commands;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione
{

    public class AddMissioneCommandHandler : ICommandHandler<AddMissioneCommand>
    {
        private readonly IDbMethods serviziPersistenza;

        public AddMissioneCommandHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza;
        }

        public void Handle(AddMissioneCommand command)
        {
            serviziPersistenza.NuovaMissione(command);

            // Here the user should be added.
            //
            // A good strategy consists in injecting the class
            // providing the service, e.g. a class encapsulating
            // the database query, located in the persistence
            // layer and implemented by a class library explicitely
            // aimed at providing the persistence services against
            // the chosen database technology (e.g. relational
            // database, document database, etc.).
            //
            // In this fake implementation we simply do nothing.
        }
    }
}
