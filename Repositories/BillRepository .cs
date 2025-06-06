using DatabaseContext;
using Models;

namespace Repositories
{
    public class BillRepository : BaseRepository<BillModel>
    {
        public BillRepository(SsoDbContext context) : base(context)
        {
        }

        // Obter uma fatura pelo tipo
        public BillModel? GetBillByType(string tipo)
        {
            return _context.BillModels.FirstOrDefault(bill => bill.Tipo == tipo);
        }

        // Obter todas as faturas que usam uma determinada URL API
        public IEnumerable<BillModel> GetBillsByUrlApi(string urlApi)
        {
            return _context.BillModels.Where(bill => bill.UrlApi == urlApi).ToList();
        }

        // Adicionar uma nova fatura
        public void AddBill(BillModel billModel)
        {
            _context.BillModels.Add(billModel);
            _context.SaveChanges();
        }

        // Atualizar uma fatura existente
        public bool UpdateBill(BillModel billToUpdate)
        {
            var bill = _context.BillModels.Find(billToUpdate.BillId);
            if (bill != null)
            {
                bill.Tipo = billToUpdate.Tipo;
                bill.UrlApi = billToUpdate.UrlApi;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Excluir uma fatura pelo ID
        public bool DeleteBill(long billId)
        {
            var bill = _context.BillModels.Find(billId);
            if (bill != null)
            {
                _context.BillModels.Remove(bill);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // (Outros métodos específicos para BillModel podem ser adicionados aqui...)
    }
}

