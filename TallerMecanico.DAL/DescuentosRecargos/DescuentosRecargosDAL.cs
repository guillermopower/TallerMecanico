using Microsoft.EntityFrameworkCore;
using TallerMecanico.DAL.Models;

namespace TallerMecanico.DAL.DescuentosRecargos
{
    public class DescuentosRecargosDAL : IDescuentosRecargosDAL
    {
        public async Task<List<DescuentosRecargo>> GetAll(bool soloActivos = false)
        {
            using (var context = new TallerMecanicoContext())
            {
                if (soloActivos)
                    return await context.DescuentosRecargos.Where(x => x.Activo.Equals(true)).ToListAsync();
                else
                    return await context.DescuentosRecargos.ToListAsync();
            }
        }

        public async Task<DescuentosRecargo> Get(long id)
        {
            using (var context = new TallerMecanicoContext())
            {
                return await context.DescuentosRecargos.FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
        }

        public async Task<long> SaveOrUpdate(DescuentosRecargo item)
        {
            using (var context = new TallerMecanicoContext())
            {
                if (item.Id.Equals(0))
                    await context.DescuentosRecargos.AddAsync(item);
                else
                    context.DescuentosRecargos.Update(item);

                await context.SaveChangesAsync();
                return item.Id;
            }
        }
    }
}
