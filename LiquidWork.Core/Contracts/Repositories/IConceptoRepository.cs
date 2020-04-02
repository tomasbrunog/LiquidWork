using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Core.Contracts.Repositories
{
    public interface IConceptoRepository
    {
        public Task<IEnumerable<Concepto>> GetAll();
        public Task<Concepto> GetById(int id);
        public Task Create(Concepto concepto);
        public Task Update(int id);
        public Task Delete(int id);
    }

}
