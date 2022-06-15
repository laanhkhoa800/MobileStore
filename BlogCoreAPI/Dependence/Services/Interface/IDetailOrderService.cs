using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services.Interface
{
    public interface IDetailOrderService
    {
        void CreateDetailOrd(DetailOrder detailOrder);
        IEnumerable<DetailOrder> GetDetailById(int detailID);
        void Save();
    }
}
