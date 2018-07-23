using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopData.Infrrastructure;
using TeDuShopData.Infrrastructure;
using TeduSopModel.Model;

namespace TeDuShopData.Repositories
{

    public interface IFeedbackRepository : IRepository<Feedback>
    {

    }
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
