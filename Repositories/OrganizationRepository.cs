using DatabaseContext;
using Models;

namespace Repositories
{
    public class OrganizationRepository : BaseRepository<OrganizationModel>
    {
        public OrganizationRepository(SsoDbContext context) : base(context)
        {
        }

        // Pesquisa organizações por nome
        public IEnumerable<OrganizationModel> SearchOrganizations(string keyword)
        {
            return _context.OrganizationModels.Where(o =>
                !string.IsNullOrEmpty(keyword) && (o.Razao != null && o.Razao.Contains(keyword)))
                .ToList();
        }

        // Pesquisa uma organização pelo CNPJ
        public OrganizationModel? GetOrganizationByCnpj(string cnpj)
        {
            return _context.OrganizationModels.FirstOrDefault(o => o.Cnpj == cnpj);
        }

        // Ativa uma organização
        public bool ActivateOrganization(long organizationId)
        {
            var organization = _context.OrganizationModels.Find(organizationId);
            if (organization != null)
            {
                organization.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Desativa uma organização
        public bool DeactivateOrganization(long organizationId)
        {
            var organization = _context.OrganizationModels.Find(organizationId);
            if (organization != null)
            {
                organization.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Obtém organizações por estado de ativação
        public IEnumerable<OrganizationModel> GetOrganizationsByState(bool isActive)
        {
            return _context.OrganizationModels.Where(o => o.IsActive == isActive).ToList();
        }

        // Exclui uma organização pelo ID
        public bool DeleteOrganization(long organizationId)
        {
            var organizacao = _context.OrganizationModels.Find(organizationId);
            if (organizacao != null)
            {
                organizacao.IsActive = false;
                _context.OrganizationModels.Remove(organizacao);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
