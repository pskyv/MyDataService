using MyDataServiceAPI.Models;
using MyDataServiceAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace MyDataServiceAPI.Services
{
    public class MyDataService : IMyDataService
    {        
        public async Task<RequestedDoc> GetInvoices(QueryParameters queryParameters)
        {
            using (var client = new HttpClient())
            {
                // Request headers
                client.DefaultRequestHeaders.Add("aade-user-id", Consts.username);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Consts.subscriptionKey);
                
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["mark"] = queryParameters.Mark;
                if (queryParameters.ContinuationToken != null)
                {
                    queryString["nextPartitionKey"] = queryParameters.ContinuationToken.NextPartitionKey;
                    queryString["nextRowKey"] = queryParameters.ContinuationToken.NextRowKey;
                }
                var uri = Consts.baseUri + "/RequestTransmittedDocs?" + queryString;

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestedDoc));
                    return (RequestedDoc)xmlSerializer.Deserialize(responseStream);
                }
            }

            return null;
        }

        public async Task<ResponseDoc> SendInvoices()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                // Request headers
                client.DefaultRequestHeaders.Add("aade-user-id", Consts.username);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Consts.subscriptionKey);

                var uri = Consts.baseUri + "/SendInvoices";

                // Request body
                var xmlBody = await CreateInvoicesDoc();

                var content = new StringContent(xmlBody, Encoding.UTF8, "text/xml");
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseDoc));                    
                    return (ResponseDoc)xmlSerializer.Deserialize(responseStream);
                }
            }

            return null;
        }

        public async Task<ResponseDoc> CancelInvoice(string mark)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                // Request headers
                client.DefaultRequestHeaders.Add("aade-user-id", Consts.username);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Consts.subscriptionKey);

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["mark"] = mark;

                var uri = Consts.baseUri + "/CancelInvoice?" + queryString;

                response = await client.PostAsync(uri, null);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseDoc));
                    return (ResponseDoc)xmlSerializer.Deserialize(responseStream);
                }
            }

            return null;
        }

        private Task<string> CreateInvoicesDoc()
        {
            InvoicesDoc invoicesDoc = new InvoicesDoc();
            invoicesDoc.invoice = new AadeBookInvoiceType[1];
            invoicesDoc.invoice[0] = new AadeBookInvoiceType
            {                
                invoiceHeader = new InvoiceHeaderType
                {
                    series = "ΑΠΥ",
                    aa = "0001",
                    issueDate = DateTime.Now,
                    invoiceType = InvoiceType.Item11,
                    currency = CurrencyType.EUR,
                    currencySpecified = true
                },
                issuer = new PartyType
                {
                    vatNumber = "104702679",
                    country = CountryType.GR,
                    branch = 0
                },
                counterpart = new PartyType
                {
                    vatNumber = "122675042",
                    country = CountryType.GR,
                    branch = 0
                },
                paymentMethods = new PaymentMethodDetailType[]
                {
                    new PaymentMethodDetailType
                    {
                        type = 3,
                        amount = 124
                    }
                },
                invoiceDetails = new InvoiceRowType[]
                {
                    new InvoiceRowType
                    {
                        lineNumber = 1,
                        netValue = 100,
                        vatCategory = 1,
                        vatAmount = 24,
                        incomeClassification = new IncomeClassificationType[]
                        {
                            new IncomeClassificationType
                            {
                                classificationType = IncomeClassificationValueType.E3_561_007,
                                classificationCategory = IncomeClassificationCategoryType.category1_3,
                                amount = 100
                            }
                        }
                    }
                },
                invoiceSummary = new InvoiceSummaryType
                {
                    totalNetValue = 100,
                    totalVatAmount = 24,
                    totalWithheldAmount = 0,
                    totalFeesAmount = 0,
                    totalStampDutyAmount = 0,
                    totalOtherTaxesAmount = 0,
                    totalDeductionsAmount = 0,
                    totalGrossValue = 124,
                    incomeClassification = new IncomeClassificationType[]
                    {
                        new IncomeClassificationType
                        {
                            classificationType = IncomeClassificationValueType.E3_561_007,
                            classificationCategory = IncomeClassificationCategoryType.category1_3,
                            amount = 100
                        }
                    }
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(InvoicesDoc));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, invoicesDoc);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEndAsync();            
        }
    }
}
