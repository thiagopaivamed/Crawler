using Crawler.BLL.Models;
using Crawler.DAL.Repositories;
using Crawler.ViewModels;
using PagedList;
using System;
using System.Web.Mvc;

namespace Crawler.Controllers
{
    public class PostTwittersController : Controller
    {
        private TwitterServiceRepository twitterServiceRepository = new TwitterServiceRepository();
        private PostTwitterRepository postTwitterRepository = new PostTwitterRepository();
        private CategoriaRepository categoriaRepository = new CategoriaRepository();
        private EstadoRepository estadoRepository = new EstadoRepository();
        private const int tweetsPorPagina = 500;

        public PostTwittersController() { }

        public PostTwittersController(PostTwitterRepository _postTwitterRepository,
                                      TwitterServiceRepository _twitterServiceRepository,
                                      CategoriaRepository _categoriaRepository,
                                      EstadoRepository _estadoRepository)
        {
            postTwitterRepository = _postTwitterRepository;
            twitterServiceRepository = _twitterServiceRepository;
            categoriaRepository = _categoriaRepository;
            estadoRepository = _estadoRepository;
        }

        public ActionResult Index(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            ViewBag.EstadoId = new SelectList(estadoRepository.GetAllStates(), "EstadoId", "Nome");
            return View(postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));
        }

        public ActionResult Procurar(string termo, int? pagina)
        {
            PostTwitter postTwitter = new PostTwitter();
            Categoria categoria = new Categoria();
            int estadoId = Convert.ToInt32(Request["EstadoId"]);
            string estado = estadoRepository.GetStatebyId(estadoId);
            var service = twitterServiceRepository.ConfigureService();
            int numeroPagina = pagina ?? 1;
            int categoriaId;

            ViewBag.EstadoId = new SelectList(estadoRepository.GetAllStates(), "EstadoId", "Nome");


            if (string.IsNullOrEmpty(termo))
            {
                if (Request.IsAjaxRequest())
                    return PartialView("Tweets", postTwitterRepository.GetAll());

                return View("Index", postTwitterRepository.GetAll());
            }

            if (categoriaRepository.CheckIfExists(termo))
            {
                var tweets = twitterServiceRepository.Search(service, termo + " " + estado);
                categoriaId = categoriaRepository.GetId(termo);
                foreach (var tweet in tweets)
                {
                    postTwitter.NomeUsuario = tweet.User.ScreenName;
                    postTwitter.Texto = tweet.Text;
                    postTwitter.Data = Convert.ToDateTime(tweet.CreatedDate.ToString("d"));
                    postTwitter.CategoriaId = categoriaId;
                    postTwitter.EstadoId = Convert.ToInt32(estadoId);
                    postTwitterRepository.SaveTweets(postTwitter);
                }
            }

            else
            {
                var tweets = twitterServiceRepository.Search(service, termo + " " + estado);
                categoria.Nome = termo;
                categoriaRepository.SaveCategory(categoria);
                categoriaId = categoriaRepository.GetId(termo);

                foreach (var tweet in tweets)
                {
                    postTwitter.NomeUsuario = tweet.User.ScreenName;
                    postTwitter.Texto = tweet.Text;
                    postTwitter.Data = Convert.ToDateTime(tweet.CreatedDate.ToString("d"));
                    postTwitter.CategoriaId = categoriaId;
                    postTwitter.EstadoId = Convert.ToInt32(estadoId);
                    postTwitterRepository.SaveTweets(postTwitter);
                }
            }

            if (Request.IsAjaxRequest())
                return PartialView("Tweets", postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));

            return View("Index", postTwitterRepository.GetAll().ToPagedList(numeroPagina, tweetsPorPagina));
        }

        public ActionResult Mapa()
        {
            ViewBag.CategoriasId = new SelectList(categoriaRepository.GetAllCategories(), "CategoriaId", "Nome");
            return View();

        }

        public JsonResult GetMapData(string categoria)
        {
            DadosMapa dadosMapa = new DadosMapa();

            if (string.IsNullOrEmpty(categoria))
            {
                dadosMapa.Quantidade = categoriaRepository.GetTotalByCategory("Assalto");
                dadosMapa.Codigos = estadoRepository.GetStatesCodesByCategory("Assalto");
                dadosMapa.QuantidadeTotal = categoriaRepository.GetTotal("Assalto");
            }

            else
            {
                dadosMapa.Quantidade = categoriaRepository.GetTotalByCategory(categoria);
                dadosMapa.Codigos = estadoRepository.GetStatesCodesByCategory(categoria);
                dadosMapa.QuantidadeTotal = categoriaRepository.GetTotal(categoria);
            }


            return Json(dadosMapa, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetViolenceData(int codigo)
        {
            DadosViolenciaGrafico dadosViolenciaGrafico = new DadosViolenciaGrafico();

            dadosViolenciaGrafico.Quantidade = estadoRepository.GetTotalByCode(codigo);
            dadosViolenciaGrafico.Categoria = estadoRepository.GetCategoryByCode(codigo);
            dadosViolenciaGrafico.Estado = estadoRepository.GetStatebyId(codigo);

            return Json(dadosViolenciaGrafico, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Grafico()
        {
            ViewBag.CategoriaId = new SelectList(categoriaRepository.GetAllCategories(), "CategoriaId", "Nome");
            return View();
        }

        public JsonResult GetGraphicData(string categoria)
        {
            DadosGrafico dadosGraficos = new DadosGrafico();

            if (string.IsNullOrEmpty(categoria))
            {
                dadosGraficos.Quantidade = categoriaRepository.GetTotalByCategory("Assalto");
                dadosGraficos.Siglas = estadoRepository.GetStatesAcronymsByCategory("Assalto");
            }
            else
            {
                dadosGraficos.Quantidade = categoriaRepository.GetTotalByCategory(categoria);
                dadosGraficos.Siglas = estadoRepository.GetStatesAcronymsByCategory(categoria);
            }

            return Json(dadosGraficos, JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult GraficoTemporal()
        {
            ViewBag.Categorias = new SelectList(categoriaRepository.GetAllCategories(), "CategoriaId", "Nome");
            ViewBag.EstadoId = new SelectList(estadoRepository.GetAllStates(), "EstadoId", "Nome");
            return View();

        }

        public JsonResult GetTemporalData(string categoria, string dataInicio, string dataFim, string estado)
        {
            DadosGraficoLinha dadosGraficoLinha = new DadosGraficoLinha();

            DateTime di = DateTime.ParseExact(dataInicio, "dd/MM/yyyy", null);
            DateTime df = DateTime.ParseExact(dataFim, "dd/MM/yyyy", null);

            dadosGraficoLinha.Datas = postTwitterRepository.GetDatesByRange(categoria, di, df, estado);
            dadosGraficoLinha.Quantidade = postTwitterRepository.GetTotalByDate(categoria, di, df, estado);

            return Json(dadosGraficoLinha, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            return Json((categoriaRepository.GetAllCategories()), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                postTwitterRepository = null;
                categoriaRepository = null;
                estadoRepository = null;
                twitterServiceRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}
