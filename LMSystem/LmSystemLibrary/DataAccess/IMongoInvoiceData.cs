
namespace LmSystemLibrary.DataAccess
{
    public interface IMongoInvoiceData
    {
        Task CreateInvoice(InvoiceModel invoice);
        Task<List<InvoiceModel>> GetAllInvoices();
        Task<InvoiceModel> GetInvoiceAsync(string id);
        Task UpdateInvoice(InvoiceModel invoice);
        void DeleteInvoice(InvoiceModel invoice);
    }
}