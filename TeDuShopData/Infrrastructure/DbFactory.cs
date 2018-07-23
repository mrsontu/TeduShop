using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopData;
using TeduShopData.Infrrastructure;

namespace TeDuShopData.Infrrastructure
{
   public class DbFactory : Disposeable, IDbFactory
    {
        private TeDuShopDbContext dbContext;
        public TeDuShopDbContext Init()
        {
            return dbContext ?? (dbContext = new TeDuShopDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
