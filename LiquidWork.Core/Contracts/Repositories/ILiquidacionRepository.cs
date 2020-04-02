using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Core.Contracts.Repositories
{
    public interface ILiquidacionRepository
    {
        public Task<IEnumerable<Liquidacion>> GetAll();
        public Task<Liquidacion> GetById(int id);
        public Task Create(Liquidacion liquidacion);
        public Task Update(int id);
        public Task Delete(int id);
    }

}
