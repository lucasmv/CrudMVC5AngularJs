using CrudMVC5AngularJs.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudMVC5AngularJs.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class CelularController : ApiController
    {
        private readonly CelularDbContext _db = new CelularDbContext();

        [HttpGet]
        [Route("Celulares")]
        public IQueryable<Celular> ObterCelulares()
        {
            return _db.Celulares;
        }

        [HttpGet]
        [Route("celular/{id:int}")]
        public HttpResponseMessage ObterPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var celular = _db.Celulares.Find(id);

            return Request.CreateResponse(HttpStatusCode.OK, celular);
        }

        [HttpPut]
        [Route("putCelular")]
        public HttpResponseMessage Alterar(Celular celular)
        {
            if (celular == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(celular).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("postCelular")]
        public HttpResponseMessage Incluir(Celular celular)
        {
            if (celular == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Celulares.Add(celular);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("deleteCelular/{id:int}")]
        public HttpResponseMessage Excluir(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var celular = _db.Celulares.Find(id);

            if (celular == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Celular não encontrado");

            _db.Celulares.Remove(celular);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
