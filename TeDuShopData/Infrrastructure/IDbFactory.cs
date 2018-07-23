using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.Infrrastructure
{
    public interface IDbFactory:IDisposable
    {
        TeDuShopDbContext Init();
    }
}
