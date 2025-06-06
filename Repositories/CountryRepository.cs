using DatabaseContext;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CountryRepository : BaseRepository<CountryModel>
    {
        public CountryRepository(SsoDbContext context) : base(context)
        {
        }

        // Obtém um país pelo nome
        public CountryModel? GetCountryByName(string countryName)
        {
            return _context.CountryModels.FirstOrDefault(c => c.Name == countryName);
        }

        // Obtém um país pelo código
        public CountryModel? GetCountryByCode(string codigo)
        {
            return _context.CountryModels.FirstOrDefault(c => c.Codigo == codigo);
        }

        // Adiciona um novo país
        public void AddCountry(CountryModel country)
        {
            _context.CountryModels.Add(country);
            _context.SaveChanges();
        }

        // Atualiza um país existente
        public bool UpdateCountry(CountryModel countryToUpdate)
        {
            var country = _context.CountryModels.Find(countryToUpdate.CountryId);
            if (country != null)
            {
                country.Name = countryToUpdate.Name;
                country.Codigo = countryToUpdate.Codigo;
                country.Fone = countryToUpdate.Fone;
                country.Iso = countryToUpdate.Iso;
                country.Iso3 = countryToUpdate.Iso3;
                country.NomeFormal = countryToUpdate.NomeFormal;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Exclui um país pelo ID
        public bool DeleteCountry(long countryId)
        {
            var country = _context.CountryModels.Find(countryId);
            if (country != null)
            {
                _context.CountryModels.Remove(country);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para CountryModel podem ser adicionados aqui...)
    }
}
