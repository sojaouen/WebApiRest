using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    public class ModulesController : ApiController
    {
        private StagiairesDBContext db = new StagiairesDBContext();

        // Action qui liste les modules
        [HttpGet]
        [Route("module/all")]
        public List<Module> GetModules()
        {
            return db.Modules.ToList();
        }

        // ajouter un module

        [HttpPost]
        [Route("modules/add")]
        //public bool AddModule(Module module)
        public HttpStatusCode AddModule(Module module)
        {
            try
            {
                if (module == null)
                {
                    return HttpStatusCode.BadRequest;
                }
                db.Modules.Add(module);
                int i = db.SaveChanges();
                // if (i > 0)
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

    }
}
