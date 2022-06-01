using Microsoft.Extensions.Caching.Memory;

namespace LmSystemLibrary.DataAccess
{
    public class MongoInvoiceData : IMongoInvoiceData
    {
        private readonly IMemoryCache _cache;
        private readonly IMongoCollection<InvoiceModel> _invoices;
        private const string cacheName = "InvoicesData";

        public MongoInvoiceData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _invoices = db.InvoiceCollection;
        }

        public async Task<List<InvoiceModel>> GetAllInvoices()
        {
            var result = await _invoices.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<InvoiceModel> GetInvoiceAsync(string id)
        {
            var results = await _invoices.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateInvoice(InvoiceModel invoice)
        {
            return _invoices.InsertOneAsync(invoice);
        }

        public Task UpdateInvoice(InvoiceModel invoice)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq("Id", invoice.Id);
            return _invoices.ReplaceOneAsync(filter, invoice, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteInvoice(InvoiceModel invoice)
        {
            var filter = Builders<InvoiceModel>.Filter.Eq("Id", invoice.Id);
            _invoices.DeleteOne(filter);
        }
    }
}

