using Microsoft.AspNetCore.Mvc;
using MyDataServiceAPI.Models;
using MyDataServiceAPI.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMyDataService _myDataService;

        public InvoicesController(IMyDataService myDataService)
        {
            _myDataService = myDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices([FromQuery]QueryParameters queryParameters)
        {
            try
            {
                if (!string.IsNullOrEmpty(queryParameters.Mark))
                {
                    var result = await _myDataService.GetInvoicesWithRefit(queryParameters);
                    if (result?.invoicesDoc != null && result.invoicesDoc.invoice.Any())
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest("Empty mark!");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendInvoices()
        {
            try
            {
                return Ok(await _myDataService.SendInvoicesWithRefit());

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw ex;
            }
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelInvoice(string mark)
        {
            try
            {
                return Ok(await _myDataService.CancelInvoiceWithRefit(mark));

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw ex;
            }
        }
    }
}
