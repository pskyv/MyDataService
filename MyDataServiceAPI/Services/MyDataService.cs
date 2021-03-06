using MyDataServiceAPI.Models;
using MyDataServiceAPI.Utils;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace MyDataServiceAPI.Services
{
    public class MyDataService : IMyDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IMyDataApi _myDataApi;

        public MyDataService(HttpClient httpClient, IMyDataApi myDataApi)
        {
            _httpClient = httpClient;
            _myDataApi = myDataApi;
        }

        public async Task<RequestedDoc> GetInvoices(QueryParameters queryParameters)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["mark"] = queryParameters.Mark;
            if (queryParameters.ContinuationToken != null)
            {
                queryString["nextPartitionKey"] = queryParameters.ContinuationToken.NextPartitionKey;
                queryString["nextRowKey"] = queryParameters.ContinuationToken.NextRowKey;
            }
            var uri = Consts.baseUri + "/RequestTransmittedDocs?" + queryString;

            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestedDoc));
                return (RequestedDoc)xmlSerializer.Deserialize(responseStream);
            }

            return null;
        }

        public async Task<RequestedDoc> GetInvoicesWithRefit(QueryParameters queryParameters)
        {
            if (queryParameters.ContinuationToken != null)
            {
                return await _myDataApi.GetPagedInvoices(queryParameters.Mark, queryParameters.ContinuationToken.NextPartitionKey, queryParameters.ContinuationToken.NextRowKey);
            }

            else
            {
                return await _myDataApi.GetInvoices(queryParameters.Mark);
            }
        }

        public async Task<ResponseDoc> SendInvoices(InvoicesDoc invoicesDoc)
        {
            HttpResponseMessage response;

            var uri = Consts.baseUri + "/SendInvoices";
            string xmlBody = string.Empty;

            // Request body
            if (invoicesDoc == null)
            {
                xmlBody = await CreateInvoicesDoc();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InvoicesDoc));
                MemoryStream stream = new MemoryStream();
                serializer.Serialize(stream, invoicesDoc);
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                xmlBody = await reader.ReadToEndAsync();
            }                        

            var content = new StringContent(xmlBody, Encoding.UTF8, "text/xml");
            response = await _httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseDoc));
                return (ResponseDoc)xmlSerializer.Deserialize(responseStream);
            }

            return null;
        }

        public async Task<ResponseDoc> SendInvoicesWithRefit()
        {
            var xmlBody = await CreateInvoicesDoc();
            var content = new StringContent(xmlBody, Encoding.UTF8, "text/xml");

            return await _myDataApi.SendInvoices(content);
        }

        public async Task<ResponseDoc> CancelInvoice(string mark)
        {
            HttpResponseMessage response;

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["mark"] = mark;

            var uri = Consts.baseUri + "/CancelInvoice?" + queryString;

            response = await _httpClient.PostAsync(uri, null);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseDoc));
                return (ResponseDoc)xmlSerializer.Deserialize(responseStream);
            }

            return null;
        }

        public async Task<ResponseDoc> CancelInvoiceWithRefit(string mark)
        {
            return await _myDataApi.CancelInvoice(mark);
        }

        private Task<string> CreateInvoicesDoc()
        {
            InvoicesDoc invoicesDoc = new InvoicesDoc();
            invoicesDoc.invoice = new AadeBookInvoiceType[2];
            invoicesDoc.invoice[0] = new AadeBookInvoiceType
            {
                invoiceHeader = new InvoiceHeaderType
                {
                    series = "ΑΠΥ",
                    aa = "0005",
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

            invoicesDoc.invoice[1] = new AadeBookInvoiceType
            {
                invoiceHeader = new InvoiceHeaderType
                {
                    series = "ΑΠΥ",
                    aa = "0006",
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
