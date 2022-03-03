using DomainModel.Common;
using Persistenza.Models;
using System;
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
    }
}
