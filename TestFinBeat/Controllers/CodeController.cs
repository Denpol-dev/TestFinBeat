using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestFinBeat.Services.Code;

namespace TestFinBeat.Controllers
{
    public class CodeController : Controller
    {
        private readonly ICodeService _codeService;
        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        /// <summary>
        /// Добавление кодов
        /// </summary>
        /// <param name="codeModels"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        [HttpPost]
        [Route("api/code")]
        public async Task<IActionResult> AddCodesAsync([FromBody] List<Dictionary<string, string>> codes)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException(string.Join(" ,", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }

            var count = await _codeService.AddCodesAsync(codes, HttpContext.RequestAborted);

            if (count > 0)
            {
                return Ok(count);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/code")]
        public async Task<IActionResult> GetCodesAsync(int? id, int? code, string? value)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException(string.Join(" ,", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }

            var codes = await _codeService.GetCodesAsync(id, code, value, HttpContext.RequestAborted);
            return Ok(codes);
        }
    }
}
