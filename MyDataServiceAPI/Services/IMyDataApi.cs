using MyDataServiceAPI.Models;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Services
{
    public interface IMyDataApi
    {
        [Get("/RequestTransmittedDocs?mark={mark}")]
        Task<RequestedDoc> GetInvoices(string mark);

        [Get("/RequestTransmittedDocs?mark={mark}&nextPartitionKey={nextPartitionKey}&nextRowKey={nextRowKey}")]
        Task<RequestedDoc> GetPagedInvoices(string mark, string nextPartitionKey, string nextRowKey);

        [Post("/SendInvoices")]
        Task<ResponseDoc> SendInvoices([Body] StringContent content);

        [Post("/CancelInvoice?mark={mark}")]
        Task<ResponseDoc> CancelInvoice(string mark);
    }
}
