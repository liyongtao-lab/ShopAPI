using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class STUController : ControllerBase
    {
        StudentContext stucontext;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="stucontext"></param>
        public STUController(StudentContext stucontext)
        {
            this.stucontext = stucontext;
        }

        // GET: api/STU
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return stucontext.students.ToList();
        }

        // GET: api/STU/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/STU
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/STU/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
