using BlogCoreAPI.Dependence.Reponsitorys.DetailOrderRepository;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public class DetailOrderService : IDetailOrderService
    {
        private IDetailOrderRepository _detailOrderRepository;
        public DetailOrderService(IDetailOrderRepository detailOrderRepository)
        {
            this._detailOrderRepository = detailOrderRepository;
        }
        /// <summary>
        /// ad datail after add order
        /// </summary>
        /// <param name="detailOrder"></param>
        public void CreateDetailOrd(DetailOrder detailOrder)
        {
            _detailOrderRepository.Inser(detailOrder);
        }

        /// <summary>
        /// Get Detail By Id form Order 
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        public IEnumerable<DetailOrder> GetDetailById(int detailID)
        {
            yield return _detailOrderRepository.GetByID(detailID);
        }
        public void Save()
        {
            _detailOrderRepository.Save();
        }
    }
}
