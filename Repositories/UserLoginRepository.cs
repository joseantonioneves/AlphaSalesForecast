using DatabaseContext;
using Models;

namespace Repositories
{
    public class UserLoginRepository : BaseRepository<UserLogin>
    {
        public UserLoginRepository(SsoDbContext context) : base(context)
        {
        }

        // Adicionar um novo registro de login
        public void AddUserLogin(UserLogin userLogin)
        {
            _context.UserLogins.Add(userLogin);
            _context.SaveChanges();
        }

        // Atualizar um registro de login
        public bool UpdateUserLogin(UserLogin userLoginToUpdate)
        {
            var userLogin = _context.UserLogins.Find(userLoginToUpdate.UserLoginId);
            if (userLogin != null)
            {
                userLogin.CreateLogin = userLoginToUpdate.CreateLogin;
                userLogin.LogTime = userLoginToUpdate.LogTime;
                userLogin.AuthenticateResult = userLoginToUpdate.AuthenticateResult;
                userLogin.Log = userLoginToUpdate.Log;
                userLogin.UserModelUserId = userLoginToUpdate.UserModelUserId;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Obter um registro de login pelo ID
        public UserLogin? GetUserLoginById(long userLoginId)
        {
            return _context.UserLogins.FirstOrDefault(u => u.UserLoginId == userLoginId);
        }

        // Obter registros de login de um usuário específico
        public IEnumerable<UserLogin> GetUserLoginsByUserId(long userId)
        {
            return _context.UserLogins.Where(u => u.UserModelUserId == userId).ToList();
        }

        // Obter registros de login dentro de um intervalo de tempo
        public IEnumerable<UserLogin> GetUserLoginsByTimeRange(DateTime startTime, DateTime endTime)
        {
            return _context.UserLogins.Where(u => u.LogTime >= startTime && u.LogTime <= endTime).ToList();
        }

        // Excluir um registro de login
        public bool DeleteUserLogin(long userLoginId)
        {
            var userLogin = _context.UserLogins.Find(userLoginId);
            if (userLogin != null)
            {
                _context.UserLogins.Remove(userLogin);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para UserLogin podem ser adicionados aqui...)
    }
}
