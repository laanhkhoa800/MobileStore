using BlogCoreAPI.Dependence.Reponsitorys.UserRepository;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.DetailOrderRepository
{
    public class DetailOrderRepository : BaseRepository<DetailOrder>, IDetailOrderRepository
    {
        private ApContext _apContext;
        public DetailOrderRepository(ApContext context) : base(context)
        {
            _apContext = context;
        }
    }
}
