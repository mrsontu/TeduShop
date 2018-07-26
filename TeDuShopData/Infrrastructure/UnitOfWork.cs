using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopData;
using TeduShopData.Infrrastructure;

namespace TeDuShopData.Infrrastructure
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TeDuShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TeDuShopDbContext DbContext { get {return  dbContext ?? (dbContext=dbFactory.Init()); } }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
    
}
