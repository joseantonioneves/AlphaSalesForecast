using DatabaseContext;
using Models;

namespace Repositories
{
    public class CityRepository : BaseRepository<CityModel>
    {
        public CityRepository(SsoDbContext context) : base(context)
        {
        }

        // Obtém uma cidade pelo nome
        public CityModel? GetCityByName(string cityName)
        {
            return _context.CityModels.FirstOrDefault(c => c.Name == cityName);
        }

        // Obtém todas as cidades em um estado específico
        public IEnumerable<CityModel> GetCitiesByStateId(long stateId)
        {
            return _context.CityModels.Where(c => c.StateModelStateId == stateId).ToList();
        }

        // Adiciona uma nova cidade
        public void AddCity(CityModel city)
        {
            _context.CityModels.Add(city);
            _context.SaveChanges();
        }

        // Atualiza uma cidade existente
        public bool UpdateCity(CityModel cityToUpdate)
        {
            var city = _context.CityModels.Find(cityToUpdate.CityId);
            if (city != null)
            {
                city.Name = cityToUpdate.Name;
                city.Ibge = cityToUpdate.Ibge;
                city.StateModelStateId = cityToUpdate.StateModelStateId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Exclui uma cidade pelo ID
        public bool DeleteCity(long cityId)
        {
            var city = _context.CityModels.Find(cityId);
            if (city != null)
            {
                _context.CityModels.Remove(city);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para CityModel podem ser adicionados aqui...)
    }
}

