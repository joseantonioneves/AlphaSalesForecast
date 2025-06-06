using DatabaseContext;
using Models;

namespace Repositories
{
    public class RoleRepository : BaseRepository<RoleModel>
    {
        public RoleRepository(SsoDbContext context) : base(context)
        {
        }

        // Obter um papel pelo nome
        public RoleModel? GetRoleByName(string roleName)
        {
            return _context.RoleModels.FirstOrDefault(role => role.RoleName == roleName);
        }

        // Adicionar um novo papel
        public void AddRole(RoleModel roleModel)
        {
            _context.RoleModels.Add(roleModel);
            _context.SaveChanges();
        }

        // Atualizar um papel existente
        public bool UpdateRole(RoleModel roleToUpdate)
        {
            var role = _context.RoleModels.Find(roleToUpdate.RoleId);
            if (role != null)
            {
                role.RoleName = roleToUpdate.RoleName;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Excluir um papel pelo ID
        public bool DeleteRole(long roleId)
        {
            var role = _context.RoleModels.Find(roleId);
            if (role != null)
            {
                _context.RoleModels.Remove(role);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Obter todos os usuários associados a um determinado papel
        public IEnumerable<UserModel> GetUsersByRole(long roleId)
        {
            var role = _context.RoleModels.Find(roleId);
            return role?.UserModels ?? new List<UserModel>();
        }

        // (Outros métodos específicos para RoleModel podem ser adicionados aqui...)
    }
}
