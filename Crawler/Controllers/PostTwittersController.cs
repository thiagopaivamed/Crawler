using Crawler.DAL;
using Crawler.Models;
using System;
using System.Web.Mvc;
using PagedList;

namespace Crawler.Controllers
{
    public class PostTwittersController : Controller
    {

        private PostTwitterRepository postTwitterRepository = new PostTwitterRepository();
        private const int tweetsPorPagina = 500;

        public PostTwittersController() { }
        public PostTwittersController(PostTwitterRepository postTwitterRepository)
        {
            this.postTwitterRepository = postTwitterRepository;
        }

        // GET: PostTwitters
        public ActionResult Index(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            ViewBag.EstadoId = new SelectList(postTwitterRepository.GetAllStates(), "EstadoId", "Nome");
            return View(postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));
        }
        
        public ActionResult Procurar(string termo, int? pagina)
        {
            PostTwitter postTwitter = new PostTwitter();
            Categoria categoria = new Categoria();
            int estadoId = Convert.ToInt32(Request["EstadoId"]);
            string estado = postTwitterRepository.GetStatebyId(estadoId);
            var service = postTwitterRepository.ConfigureService();
            int numeroPagina = pagina ?? 1;
            int categoriaId;

            ViewBag.EstadoId = new SelectList(postTwitterRepository.GetAllStates(), "EstadoId", "Nome");
           

            if (string.IsNullOrEmpty(termo))
            {
                if (Request.IsAjaxRequest())
                    return PartialView("Tweets", postTwitterRepository.GetAll());

                return View("Index", postTwitterRepository.GetAll());
            }

            if (postTwitterRepository.CheckIfExists(termo))
            {
                var tweets = postTwitterRepository.Search(service, termo + " " + estado);
                categoriaId = postTwitterRepository.GetId(termo);
                foreach (var tweet in tweets)
                {
                    postTwitter.NomeUsuario = tweet.User.ScreenName;
                    postTwitter.Texto = tweet.Text;
                    postTwitter.Data = tweet.CreatedDate.ToShortDateString();
                    postTwitter.CategoriaId = categoriaId;
                    postTwitter.EstadoId = Convert.ToInt32(estadoId);
                    postTwitterRepository.SaveTweets(postTwitter);
                }
            }

            else
            {
                var tweets = postTwitterRepository.Search(service, termo + " " + estado);
                categoria.Nome = termo;
                postTwitterRepository.SaveCategory(categoria);
                categoriaId = postTwitterRepository.GetId(termo);

                foreach (var tweet in tweets)
                {
                    postTwitter.NomeUsuario = tweet.User.ScreenName;
                    postTwitter.Texto = tweet.Text;
                    postTwitter.CategoriaId = categoriaId;
                    postTwitter.EstadoId = Convert.ToInt32(estadoId);
                    postTwitterRepository.SaveTweets(postTwitter);
                }
            }

            if (Request.IsAjaxRequest())
                return PartialView("Tweets", postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));

            return View("Index", postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));
        }

        [HttpGet]
        public ActionResult Graficos()
        {
            ViewBag.CategoriaId = new SelectList(postTwitterRepository.GetAllCategories(), "CategoriaId", "Nome");
            return View();
        }

        public ActionResult DadosGraficos(string categoria)
        {
            DadosGrafico dadosGraficos = new DadosGrafico();

            if (string.IsNullOrEmpty(categoria))
            {
                dadosGraficos.Quantidade = postTwitterRepository.GetTotalByCategory("Assalto");
                dadosGraficos.Siglas = postTwitterRepository.GetStatesAcronymsByCategory("Assalto");
            }
            else
            {
                dadosGraficos.Quantidade = postTwitterRepository.GetTotalByCategory(categoria);
                dadosGraficos.Siglas = postTwitterRepository.GetStatesAcronymsByCategory(categoria);
            }
            
            return Json(dadosGraficos, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult GetCategories()
        {

            return Json((postTwitterRepository.GetAllCategories()), JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                postTwitterRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}
