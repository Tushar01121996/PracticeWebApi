using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApi.Controllers
{

    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer iCustomer;
        // private readonly ILogger iLogger;
        public CustomerController(ICustomer _iCustomer)
        {
            iCustomer = _iCustomer;
            //iLogger = _iLogger;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //Test for build Jenkins
                //Test Again
                //Test Again 1
                //Test Again 2
                var result = await iCustomer.GetAll();
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                //iLogger.LogError(ex, "Something went wrong");
                return StatusCode(500, "Internal Server Error");
            }

        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await iCustomer.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet]
        [Route("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await iCustomer.Delete(id);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpPost]
        [Route("SaveUpdate")]
        public async Task<IActionResult> SaveUpdate(Customer customer)
        {
            var result = await iCustomer.SaveUpdate(customer);
            return result != null ? Ok(result) : NotFound();
        }
    }

}
