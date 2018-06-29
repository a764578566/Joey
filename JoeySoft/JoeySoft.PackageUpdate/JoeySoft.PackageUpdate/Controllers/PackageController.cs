using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoeySoft.PackageUpdate.Controllers
{
    [Produces("application/json")]
    [Route("api/Package")]
    public class PackageController : Controller
    {
        // GET api/values
        /// <summary>
        /// 获取所有包信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 获取指定所有包信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{packageName}")]
        public IActionResult Get(string packageName)
        {
            string ext = Path.GetExtension(packageName);

            byte[] by = System.IO.File.ReadAllBytes(Path.Combine("Package", packageName));

            return File(by, "application/octet-stream", Guid.NewGuid().ToString() + ext);
        }
        
        // POST: api/Package
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Package/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
