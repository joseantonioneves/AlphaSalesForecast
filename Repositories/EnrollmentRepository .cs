using DatabaseContext;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class EnrollmentRepository : BaseRepository<EnrollmentModel>
    {
        public EnrollmentRepository(SsoDbContext context) : base(context)
        {
        }

        // Obtém uma inscrição pelo ID do usuário
        public IEnumerable<EnrollmentModel> GetEnrollmentsByUserId(long userId)
        {
            return _context.EnrollmentModels.Where(e => e.UserModelUserId == userId).ToList();
        }

        // Obtém uma inscrição pelo ID do aplicativo
        public IEnumerable<EnrollmentModel> GetEnrollmentsByAppId(long appId)
        {
            return _context.EnrollmentModels.Where(e => e.AppPortifolioAppId == appId).ToList();
        }

        // Adiciona uma nova inscrição
        public void AddEnrollment(EnrollmentModel enrollment)
        {
            _context.EnrollmentModels.Add(enrollment);
            _context.SaveChanges();
        }

        // Atualiza uma inscrição existente
        public bool UpdateEnrollment(EnrollmentModel enrollmentToUpdate)
        {
            var enrollment = _context.EnrollmentModels.Find(enrollmentToUpdate.EnrollmentId);
            if (enrollment != null)
            {
                enrollment.AppPortifolioAppId = enrollmentToUpdate.AppPortifolioAppId;
                enrollment.SignatureModelSignatureId = enrollmentToUpdate.SignatureModelSignatureId;
                enrollment.UserModelUserId = enrollmentToUpdate.UserModelUserId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Exclui uma inscrição pelo ID
        public bool DeleteEnrollment(long enrollmentId)
        {
            var enrollment = _context.EnrollmentModels.Find(enrollmentId);
            if (enrollment != null)
            {
                _context.EnrollmentModels.Remove(enrollment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para EnrollmentModel podem ser adicionados aqui...)
    }
}
