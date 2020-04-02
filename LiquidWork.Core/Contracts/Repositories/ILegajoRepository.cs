using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Core.Contracts.Repositories
{
    public interface ILegajoRepository
    {
        public Task<IEnumerable<Legajo>> GetAll();
        public Task<Legajo> GetById(int id);
        public Task Create(Legajo legajo);
        public Task Update(int id);
        public Task Delete(int id);
    }

}
