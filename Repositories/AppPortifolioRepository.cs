using DatabaseContext;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class AppPortifolioRepository : BaseRepository<AppPortifolio>
    {
        public AppPortifolioRepository(SsoDbContext context) : base(context)
        {
        }

        // Obter um aplicativo pelo nome
        public AppPortifolio? GetAppByName(string applicationName)
        {
            return _context.AppPortifolios.FirstOrDefault(app => app.ApplicationName == applicationName);
        }

        // Obter todos os aplicativos ativos
        public IEnumerable<AppPortifolio> GetActiveApps()
        {
            return _context.AppPortifolios.Where(app => app.IsActive == true).ToList();
        }

        // Adicionar um novo aplicativo
        public void AddApp(AppPortifolio appPortifolio)
        {
            _context.AppPortifolios.Add(appPortifolio);
            _context.SaveChanges();
        }

        // Atualizar um aplicativo existente
        public bool UpdateApp(AppPortifolio appToUpdate)
        {
            var app = _context.AppPortifolios.Find(appToUpdate.AppId);
            if (app != null)
            {
                app.ApplicationName = appToUpdate.ApplicationName;
                app.IsActive = appToUpdate.IsActive;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Excluir um aplicativo pelo ID
        public bool DeleteApp(long appId)
        {
            var app = _context.AppPortifolios.Find(appId);
            if (app != null)
            {
                _context.AppPortifolios.Remove(app);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para AppPortifolio podem ser adicionados aqui...)
    }
}

