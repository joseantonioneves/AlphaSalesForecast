using DatabaseContext;
using Models;

namespace Repositories
{
    public class StateRepository : BaseRepository<StateModel>
    {
        public StateRepository(SsoDbContext context) : base(context)
        {
        }

        // Obtém um estado pelo nome
        public StateModel? GetStateByName(string stateName)
        {
            return _context.StateModels.FirstOrDefault(s => s.Name == stateName);
        }

        // Obtém todos os estados de um país específico
        public IEnumerable<StateModel> GetStatesByCountryId(long countryId)
        {
            return _context.StateModels.Where(s => s.CountryModelCountryId == countryId).ToList();
        }

        // Adiciona um novo estado
        public void AddState(StateModel state)
        {
            _context.StateModels.Add(state);
            _context.SaveChanges();
        }

        // Atualiza um estado existente
        public bool UpdateState(StateModel stateToUpdate)
        {
            var state = _context.StateModels.Find(stateToUpdate.StateId);
            if (state != null)
            {
                state.Name = stateToUpdate.Name;
                state.Uf = stateToUpdate.Uf;
                state.Ibgecode = stateToUpdate.Ibgecode;
                state.Ddd = stateToUpdate.Ddd;
                state.CountryModelCountryId = stateToUpdate.CountryModelCountryId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Exclui um estado pelo ID
        public bool DeleteState(long stateId)
        {
            var state = _context.StateModels.Find(stateId);
            if (state != null)
            {
                _context.StateModels.Remove(state);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para StateModel podem ser adicionados aqui...)
    }
}
