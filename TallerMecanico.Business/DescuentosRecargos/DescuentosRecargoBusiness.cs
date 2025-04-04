﻿using TallerMecanico.DAL.DescuentosRecargos;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.Business.DescuentosRecargos
{
    public class DescuentosRecargoBusiness: IDescuentosRecargoBusiness
    {
        private readonly IDescuentosRecargosDAL descuentosRecargosDAL;
        public DescuentosRecargoBusiness(IDescuentosRecargosDAL descuentosRecargosDAL)
        {
            this.descuentosRecargosDAL = descuentosRecargosDAL;
        }

        public async Task<List<DescuentosRecargo>> GetAll(bool soloActivos = false)
        {
            return await descuentosRecargosDAL.GetAll(soloActivos);
        }
        public async Task<DescuentosRecargo>Get(long id)
        {
            return await descuentosRecargosDAL.Get(id);
        }
        public async Task<long> SaveOrUpdate(DescuentosRecargo item)
        {
            return await descuentosRecargosDAL.SaveOrUpdate(item);
        }
    }
}
