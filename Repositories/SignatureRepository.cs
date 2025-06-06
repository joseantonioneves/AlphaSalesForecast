using DatabaseContext;
using Models;

namespace Repositories
{
    public class SignatureRepository : BaseRepository<SignatureModel>
    {
        public SignatureRepository(SsoDbContext context) : base(context)
        {
        }

        // Obter uma assinatura pela chave de assinatura
        public SignatureModel? GetSignatureByKey(string keySignature)
        {
            return _context.SignatureModels.FirstOrDefault(s => s.KeySignature == keySignature);
        }

        // Adicionar uma nova assinatura
        public void AddSignature(SignatureModel signatureModel)
        {
            _context.SignatureModels.Add(signatureModel);
            _context.SaveChanges();
        }

        // Atualizar uma assinatura existente
        public bool UpdateSignature(SignatureModel signatureToUpdate)
        {
            var signature = _context.SignatureModels.Find(signatureToUpdate.SignatureId);
            if (signature != null)
            {
                signature.KeySignature = signatureToUpdate.KeySignature;
                signature.IsActive = signatureToUpdate.IsActive;
                signature.OrganizationModelOrganizationId = signatureToUpdate.OrganizationModelOrganizationId;
                signature.BillModelBillId = signatureToUpdate.BillModelBillId;
                signature.AppId = signatureToUpdate.AppId;
                signature.OrganizationModelCnpj = signatureToUpdate.OrganizationModelCnpj;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Excluir uma assinatura pelo ID
        public bool DeleteSignature(long signatureId)
        {
            var signature = _context.SignatureModels.Find(signatureId);
            if (signature != null)
            {
                _context.SignatureModels.Remove(signature);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Obter todas as assinaturas que estão ativas
        public IEnumerable<SignatureModel> GetActiveSignatures()
        {
            return _context.SignatureModels.Where(s => s.IsActive == true).ToList();
        }

        // Obter todas as inscrições associadas a uma assinatura específica
        public IEnumerable<EnrollmentModel> GetEnrollmentsBySignature(long signatureId)
        {
            var signature = _context.SignatureModels.Find(signatureId);
            return signature?.EnrollmentModels ?? new List<EnrollmentModel>();
        }

        // (Outros métodos específicos para SignatureModel podem ser adicionados aqui...)
    }
}
