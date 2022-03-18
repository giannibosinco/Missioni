using CQRS.Commands;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.AnagraficaMissioniDipendenti
{
    public class AddMissioniDipendentiHandler : ICommandHandler<AddMissioniDipendentiCommand>
    {
        private readonly IDbMethods serviziPersistenza;

        public AddMissioniDipendentiHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza;
        }

        public void Handle(AddMissioniDipendentiCommand command)
        {
            serviziPersistenza.NuovaMissioniDipendenti(command);

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
