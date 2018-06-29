using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoeySoft.Common;
using JoeySoft.PackageUpdate.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JoeySoft.PackageUpdate.Controllers
{
    /// <summary>
    /// 版本Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/Version")]
    public class VersionController : Controller
    {
        private List<JoeySoftVersion> joeySoftVersions;
        /// <summary>
        /// 版本Controller初始化
        /// </summary>
        /// <param name="joeySoftVersions"></param>
        public VersionController(List<JoeySoftVersion> joeySoftVersions)
        {
            this.joeySoftVersions = joeySoftVersions;
        }

        // GET: api/Version
        /// <summary>
        /// 获取所有软件信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<JoeySoftVersion> Get()
        {
            return this.joeySoftVersions;
        }

        // GET: api/Version/5
        /// <summary>
        /// 获取软件最新版本
        /// </summary>
        /// <param name="name">软件名称</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public JoeySoftVersion Get(string name)
        {
            return this.joeySoftVersions.FirstOrDefault(n => n.JoeySoftName == name);
        }

        // POST: api/Version
        /// <summary>
        /// 添加软件版本
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody]JoeySoftVersion value)
        {
            var joeySoft = this.joeySoftVersions.FirstOrDefault(n => n.JoeySoftName == value.JoeySoftName);
            if (joeySoft == null)
            {
                this.joeySoftVersions.Add(value);
                JsonHelper.WriteJson(this.joeySoftVersions, "VersionJson/Version.json");
                return Ok();
            }
            else
            {
                return BadRequest("当前软件已存在不可以新增！");
            }
        }

        // PUT: api/Version/5
        /// <summary>
        /// 修改软件版本信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [HttpPut("{name}")]
        public void Put(string name, [FromBody]JoeySoftVersion value)
        {
            var joeySoft = this.joeySoftVersions.FirstOrDefault(n => n.JoeySoftName == name);
            if (joeySoft != null)
            {
                joeySoft.Version = value.Version;
            }

            //todo 保存到json中
            JsonHelper.WriteJson(this.joeySoftVersions, "VersionJson/Version.json");
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// 删除软件版本
        /// </summary>
        /// <param name="name"></param>
        [HttpDelete("{name}")]
        public void Delete(string name)
        {

        }
    }
}
