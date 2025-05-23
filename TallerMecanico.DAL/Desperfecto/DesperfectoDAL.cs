﻿using TallerMecanico.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanico.DAL.Desperfecto
{
    public class DesperfectoDAL : IDesperfectoDAL
    {
        public long Add(Models.Desperfecto desperfecto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.Desperfectos.Add(desperfecto);
                context.SaveChanges();

                id = desperfecto.Id;
            }

            return id;
        }

        public long Update(Models.Desperfecto desperfecto)
        {
            long id = 0;
            using (var context = new TallerMecanicoContext())
            {
                context.Desperfectos.Update(desperfecto);
                context.SaveChanges();

                id = desperfecto.Id;
            }

            return id;
        }

        public List<Models.Desperfecto> GetAll()
        {
            var lista = new List<Models.Desperfecto>();
            using (var context = new TallerMecanicoContext())
            {
                lista = context.Desperfectos.ToList();
            }

            return lista;
        }

        public Models.Desperfecto GetById(long id)
        {
            var item = new Models.Desperfecto();
            using (var context = new TallerMecanicoContext())
            {
                item = context.Desperfectos.FirstOrDefault(x => x.Id.Equals(id));
            }

            return item;
        }

        public async Task<List<Models.Desperfecto>> GetByPresupuestoId(long idPresupuesto)
        {
            using (var context = new TallerMecanicoContext())
            {
                return await context.Desperfectos
                    .Where(x => x.IdPresupuesto.Equals(idPresupuesto))
                    .ToListAsync();
            }
        }
    }
}