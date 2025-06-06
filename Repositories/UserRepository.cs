using DatabaseContext;
using Models;
using System.Security.Cryptography;
using System.Text;

namespace Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        private static string ComputeHash(string password, string salt)
        {
            // Concatena a senha e o salt
            var saltedPassword = password + salt;

            // Cria uma nova instância de SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string concatenada para um array de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);

                // Calcula o hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Converte o array de bytes do hash para uma string
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                return hash;
            }
        }
        public UserRepository(SsoDbContext context):base(context)
        {
            
        }
        public string EncrypitPassword(string password, string salt)
        {
            return ComputeHash(password, salt); 
        }
        public IEnumerable<UserModel> SearchUsers(string keyword, string role)
        {
            return _context.UserModels.Where(u =>
               (!string.IsNullOrEmpty(keyword) || (u.UserName != null && u.UserName.Contains(keyword))) &&
               (!string.IsNullOrEmpty(role) || u.Role == role))
           .ToList();
        }
        public bool UserExists(string username)
        {
            return _context.UserModels.Any(u => u.UserName == username);
        }
        public IEnumerable<UserModel> GetUsersByRole(string role)
        {
            return _context.UserModels.Where(u => u.Role == role).ToList();
        }
        public IEnumerable<UserModel> GetPagedUsers(int pageNumber, int pageSize)
        {
            return _context.UserModels
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }
        public async Task<UserModel> Authenticate(string username, string password)
        {
            var user = _context.UserModels.FirstOrDefault(u => u.UserName == username);

            if (user != null)
            {
                // Hash da senha fornecida
                var hashOfProvidedPassword = ComputeHash(password, user.Salt);

                // Comparação do hash
                if (hashOfProvidedPassword == user.PasswordHash)
                {
                    return user;
                }
            }

            return null;
        }
        public bool ChangePassword(int userId, string newPassword)
        {
            var user = _context.UserModels.Find(userId);
            if (user != null)
            {
                // Recupera o salt do usuário
                string salt = user.Salt;
                // Calcula o hash da nova senha com o salt
                string hashedPassword = ComputeHash(newPassword, salt);
                // Atualiza a senha do usuário com a senha "hasheada"
                user.Password = hashedPassword;
                // Salva as alterações no banco de dados
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
