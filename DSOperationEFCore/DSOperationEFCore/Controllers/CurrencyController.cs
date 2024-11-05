using DSOperationEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace DSOperationEFCore.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        
        public CurrencyController(AppDBContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }

        [HttpGet("GetAllCurrencyOne")]
        public IActionResult GetAllCurrencyOne()
        {

            //var result = _appDBContext.CurrencyTypes.ToList();

            var result = (from currency in _appDBContext.CurrencyTypes
                          select currency).ToList();

            return Ok(result);
        }

        [HttpGet("GetAllCurrencTwo")]
        public async Task<IActionResult> GetAllCurrencTwo()
        {

            //var result = await _appDBContext.CurrencyTypes.ToListAsync();
            var result = await _appDBContext.CurrencyTypes.ToListAsync();

            return Ok(result);
        }

        [HttpGet("GetAllCurrencyThree")]
        public IActionResult GetAllCurrencyThree()
        {

            //var result = (from currency in _appDBContext.CurrencyTypes
            //              select currency).Select(x => new CurrencyType()
            //              {
            //                  Id = x.Id,
            //                  Title = x.Title
            //              }).ToList();

            //var result = (from currency in _appDBContext.CurrencyTypes
            //              select new CurrencyType() {
            //                  Id = currency.Id,
            //                  Title = currency.Title
            //              }).ToList();

            var result = (from currency in _appDBContext.CurrencyTypes
                          select new 
                          {
                              CurrencyId = currency.Id,
                              CurrencyTitle = currency.Title
                          }).ToList();

            return Ok(result);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int Id)
        {

            var result = await _appDBContext.CurrencyTypes.FindAsync(Id);
            if (result == null)
            {
               string  results = "No Data Found";
                return Ok(results);
              
            }

            return Ok(result);
        }

        [HttpGet("GetCurrencyByTitleAsync {name}")]
        public async Task<IActionResult> GetCurrencyByTitleAsync([FromRoute] string name)
        {

            var result = await _appDBContext.CurrencyTypes.FirstOrDefaultAsync(x => x.Title == name);
            if (result == null)
            {
                string results = "No Data Found";
                return Ok(results);

            }

            return Ok(result);
        }

        [HttpGet("{name}/{desc}")]
        public async Task<IActionResult> GetCurrencyByParamAsync([FromRoute] string name, [FromRoute] string desc)
        {

            var result = await _appDBContext.CurrencyTypes.FirstOrDefaultAsync(x => x.Title == name && x.Description == desc);
            if (result == null)
            {
                string results = "No Data Found";
                return Ok(results);

            }

            return Ok(result);
        }

        [HttpGet("GetCurrencyByParamQueryStringAsync {name}")]
        public async Task<IActionResult> GetCurrencyByParamQueryStringAsync([FromRoute] string name, [FromQuery] string? desc)
        {

            var result = await _appDBContext.CurrencyTypes.FirstOrDefaultAsync(x => x.Title == name || 
            (String.IsNullOrEmpty(desc) || x.Description == desc));
            //if (result == null)
            //{
            //    string results = "No Data Found";
            //    return Ok(results);
            //}

            return Ok(result);
        }

        [HttpGet("GetCurrencyDuplicateAsync{crname}")]
        public async Task<IActionResult> GetCurrencyDuplicateAsync([FromRoute] string crname)
        { 
            var result = await _appDBContext.CurrencyTypes.Where(x => x.Title == crname).ToListAsync();

            //if (result == null)
            //{
            //    string results = "No Data Found";
            //    return Ok(results);

            //}

            return Ok(result);
        }

        //[HttpGet("GetSelectedRecord")]
        //public async Task<IActionResult> GetSelectedRecordAsync()
        //{
        //    var ids = new List<int>{ 1,2,5};
        //    var result = await _appDBContext.CurrencyTypes.Where(x=> ids.Contains(x.Id)).ToListAsync();


        //    return Ok(result);
        //}

        //[HttpPost("GetSelectedRecord")]
        //public async Task<IActionResult> GetSelectedRecordAsync([FromBody] List<int> ids)
        //{

        //    var result = await _appDBContext.CurrencyTypes.Where(x => ids.Contains(x.Id)).ToListAsync();


        //    return Ok(result);
        //}


        [HttpPost("GetSelectedRecord")]
        public async Task<IActionResult> GetSelectedRecordAsync([FromBody] List<int> ids)
        {

            var result = await _appDBContext.CurrencyTypes.Where(x => ids.Contains(x.Id))
                .Select(x=> new CurrencyType()
                {
                    Id=x.Id,
                    Title=x.Title
                })
                .ToListAsync();


            return Ok(result);
        }
    }
}
