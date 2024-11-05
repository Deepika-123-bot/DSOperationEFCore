using DSOperationEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSOperationEFCore.Controllers
{
    [Route("api/Languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public LanguagesController( AppDBContext appDBContext )
        {
            this._appDBContext = appDBContext;
        }

        [HttpGet("GetAllLanguages")]
        public async Task<IActionResult> GetAllLanguages()
        {
            //var result = _appDBContext.Languages.ToList();
            //var result =(from language in _appDBContext.Languages
            //            select language).ToList();

            var result = await _appDBContext.Languages.ToListAsync();
            return Ok(result);
        }
    }
}
