using MyDataServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Services
{
    public interface IMyDataService
    {
        Task<RequestedDoc> GetInvoices(QueryParameters queryParameters);
        Task<RequestedDoc> GetInvoicesWithRefit(QueryParameters queryParameters);
        Task<ResponseDoc> SendInvoices(InvoicesDoc invoicesDoc);
        Task<ResponseDoc> SendInvoicesWithRefit();
        Task<ResponseDoc> CancelInvoice(string mark);
        Task<ResponseDoc> CancelInvoiceWithRefit(string mark);
    }
}
