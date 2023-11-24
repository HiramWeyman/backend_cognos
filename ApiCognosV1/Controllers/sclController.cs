using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct.Library.Settings;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sclController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public sclController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
           
        }

        [HttpGet]
        [Route("testSCL")]
        public IEnumerable<TestSCL> GetActividades()
        {
            return _context.TestSCL.ToList();
        }
        //public IActionResult watchSCL()
        //{
        //    TestSCL forum = new TestSCL();//this model is used to "join" various
        //                              //models

        //    //get the data from the different tables with the id sending from the MVC controller
        //    var appfile = _context.TestSCL.ToList();

        //    if (appfile == null)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {

        //        return Ok(forum);
        //    }
        //}
    }
}
