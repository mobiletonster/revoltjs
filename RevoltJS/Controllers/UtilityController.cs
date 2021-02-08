using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using System.IO;

namespace RevoltJS.Controllers
{
    public class UtilityController : Controller
    {
        [HttpGet("utilities")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("utilities/base64urldecoder")]
        public IActionResult Base64UrlDecoder()
        {
            return View();
        }

        [HttpGet("utilities/base64urlencoder")]
        public IActionResult Base64UrlEncoder()
        {
            return View();
        }

        [HttpPost("api/utilities/base64urldecode")]
        public IActionResult Base64UrlDecode([FromForm] string input)
        {
            string text = input.Trim('\n','\r').Trim();
            var output = WebEncoders.Base64UrlDecode(text);
            try
            {
                var str = System.Text.Encoding.Default.GetString(output);
                return Ok(str);
            }
            catch
            {
                return Ok("Error converting string");
            }
        }

        [HttpPost("api/utilities/base64urlencode")]
        public IActionResult Base64UrlEncode([FromForm] string input)
        {
            try
            {
                var text = System.Text.Encoding.ASCII.GetBytes(input.Trim());
                var output = WebEncoders.Base64UrlEncode(text);
                return Ok(output);
            }
            catch
            {
                return Ok("Error converting string to base64");
            }
        }
    }
}
