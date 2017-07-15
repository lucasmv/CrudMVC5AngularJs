using CrudMVC5AngularJs.Context;
using CrudMVC5AngularJs.Models;
using System.Linq;
using System.Web.Http;

namespace CrudMVC5AngularJs.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class OperadoraController : ApiController
    {
        private readonly EFContext _db = new EFContext();

        [HttpGet]
        [Route("Operadoras")]
        public IQueryable<Operadora> ObteOperadoras()
        {
            return _db.Operadoras;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
