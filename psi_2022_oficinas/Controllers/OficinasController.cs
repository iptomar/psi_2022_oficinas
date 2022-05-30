using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using psi_2022_oficinas.Data;
using psi_2022_oficinas.Models;

namespace psi_2022_oficinas.Controllers
{
    public class OficinasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OficinasController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        //// GET: Oficinas
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Oficinas.Include(o => o.Gestor);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        /// <summary>
        /// Providencia a listagem das oficinas com optção de filtro por localidade e/ou nome
        /// </summary>
        /// <param name="local">Parametro de filtro para a localidade</param>
        /// <param name="nome">Parametro de filtro para o nome</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string local, string nome)
        {
            // define a query LINQ para obter todas as localidades
            IQueryable<string> localQuery = from m in _context.Oficinas
                                            orderby m.Localidade
                                            select m.Localidade;
            // define a query LINQ para selecionar as oficinas
            var oficinas = from m in _context.Oficinas
                           .Include(o => o.Gestor)
                           .Include(s => s.ListaServicos)
                           select m;
            // se a string nome for vazia ou nula
            if (!String.IsNullOrEmpty(nome))
            {
                // modificar a query para filtrar todas as oficinas cujo o Nome contem a string nome
                oficinas = oficinas.Where(s => s.Nome!.Contains(nome));
            }
            // se a string local é vazia ou nula 
            if (!string.IsNullOrEmpty(local))
            {
                // modificar a query para filtrar todas as oficinas cujo a Localidade é igual à string local
                oficinas = oficinas.Where(x => x.Localidade == local);
            }

            var oficinaLocalidadeVM = new OficinaLocalViewModel
            {
                // obter a lista das localidades sem duplicados
                Localidades = new SelectList(await localQuery.Distinct().ToListAsync()),
                // obter a lista de oficinas
                Oficinas = await oficinas.ToListAsync()
            };
            // retorna o resultado do filtro
            return View(oficinaLocalidadeVM);
        }

        // GET: Oficinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return NotFound();
            }

            var oficinas = await _context.Oficinas
                .Include(o => o.Gestor)
                .Include(s => s.ListaServicos)
                .FirstOrDefaultAsync(m => m.IdOficina == id);
            if (oficinas == null)
            {
                return NotFound();
            }

            return View(oficinas);
        }

        // GET: Oficinas/Create
        public IActionResult Create()
        {
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Nome");
            ViewData["defaultImg"] = "carservice64.png";
            ViewBag.ListaServicos = _context.Serviços.OrderBy(s => s.IdServ).ToList();

            return View();
        }

        // POST: Oficinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Ação para registar uma oficina
        /// </summary>
        /// <param name="oficinas">objeto do tipo Oficinas</param>
        /// <param name="oficinaImag">ficheiro envdiado (imagem)</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas oficina, IFormFile oficinaImag, int[] ServicoEscolhido)
        {

            // avalia se o array com a lista de serviços escolhidos associados à oficina está vazio ou não
            if (ServicoEscolhido.Length == 0)
            {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos um serviço.");
                // gerar a lista serviços que podem ser associados à oficina
                ViewBag.ListaServicos = _context.Serviços.OrderBy(s => s.IdServ).ToList();
                // devolver controlo à View
                return View(oficina);
            }

            // criar uma lista com os objetos escolhidos dos serviços
            List<Serviços> listaDeServicosEscolhidos = new List<Serviços>();
            // Para cada objeto escolhido..
            foreach (int item in ServicoEscolhido)
            {
                //procurar o serviço
                Serviços servicos = _context.Serviços.Find(item);
                // adicionar o serviço à lista
                listaDeServicosEscolhidos.Add(servicos);
            }

            // adicionar a lista ao objeto de "Oficinas"
            oficina.ListaServicos = listaDeServicosEscolhidos;

            //#########################################################################3

            // Se o utilizador não forneceu um ficheiro (imagem)
            if (oficinaImag == null)
            {

                // diretoria onde são armazenadas todas as imagens desta aplicação no servidor
                string imagStorage = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                // imagem por omissão, no caso de não ser indicada uma por o utilizador (esta imagem deve existir)
                //string defaultImagName = "carservice64.png";
                // caminho absoluto da imagem por omissão para as oficinas
                string defaultImagPath = Path.Combine(imagStorage, "carservice64.png");
                // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                string newImagName = "default_" + Guid.NewGuid().ToString() + ".png";
                // caminho absoluto da copia da imagem carservice64.png com o nome no formato especificado
                string newImagPath = Path.Combine(imagStorage, newImagName);

                try
                {
                    // efetuar a copia da imagem
                    System.IO.File.Copy(defaultImagPath, newImagPath);
                }
                catch (Exception)
                {
                    // mostrar mensagem de erro ao utilizador
                    ModelState.AddModelError("", "Erro ao guardar o registo. Imagem default não encontrada.");
                    return View(oficina);
                }

                // adicionar a imagem à oficina
                oficina.Imagem = newImagName;
            }
            else
            {
                // Se for detetado um ficheiro que não seja do tipo especificado
                if (!(oficinaImag.ContentType == "image/jpeg" || oficinaImag.ContentType == "image/png"))
                {
                    // mostrar mensagem de erro ao utilizador
                    ModelState.AddModelError("", "Só é permitido imagens to tipo jpeg ou png");
                    return View(oficina);
                }
                else
                {
                    // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                    string imagName = Guid.NewGuid().ToString();
                    string imagTypeExt = Path.GetExtension(oficinaImag.FileName).ToString();
                    imagName += imagTypeExt;

                    // adicionar a imagem à oficina
                    oficina.Imagem = imagName;
                }
            }
            // Se os dados fornecidos pelo utilizador forem válidos
            if (ModelState.IsValid)
            {
                try
                {
                    // preparar para guarda os dados na bd
                    _context.Add(oficina);
                    // guardar os dados na bd
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    // Ups! Ocorreu um problema. Mostrar mensagem de erro.
                    ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados");
                    return View(oficina);
                }
                // Se o utilizador forneceu um ficheiro (imagem)
                if (oficinaImag != null)
                {
                    // diretoria onde são armazenadas todas as imagens desta aplicação no servidor
                    string imagStorage = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    // se a diretoria para armazenar a imagem não existir
                    if (!Directory.Exists(imagStorage))
                    {
                        // criar a diretoria definida
                        Directory.CreateDirectory(imagStorage);
                    }
                    // caminho absoluto da imagem da oficina no servidor
                    string imagOficina = Path.Combine(imagStorage, oficina.Imagem);
                    // guardar a imagem no caminho especificado
                    using var stream = new FileStream(imagOficina, FileMode.Create);
                    await oficinaImag.CopyToAsync(stream);
                }
                // retorna à lista de oficinas
                return RedirectToAction(nameof(Index));
            }
            return View(oficina);
        }

        // GET: Oficinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return RedirectToAction("Index");
            }

            var ofic = await _context.Oficinas
                .Where(o => o.IdOficina == id)
                .Include(o => o.ListaServicos)
                .FirstOrDefaultAsync();

            if (ofic == null)
            {
                return RedirectToAction("Index");
            }

            //###########################################################

            // lista de todas os serviços existentes
            ViewBag.ListaDeServicos = _context.Serviços.OrderBy(s => s.IdServ).ToList();

            //###########################################################

            // obtem o nome do gestor associado à oficina
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Nome", ofic.IdGestor);

            // variavel de sessão para guardar o id da oficina
            //HttpContext.Session.SetInt32("IdOficina", oficinas.IdOficina);

            return View(ofic);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas newOficina, IFormFile oficinaImag, string useDefaultImg, int[] ServicoEscolhido)
        {

            // se for verdadeiro é porque o utilizador marcou a checkbox para uso da imagem default para a oficina
            if (useDefaultImg == "true")
            {
                // diretoria onde são armazenadas todas as imagens desta aplicação no servidor
                string imagStorage = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                // caminho absoluto da imagem por omissão para as oficinas
                string defaultImagPath = Path.Combine(imagStorage, "carservice64.png");
                // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                string newImagName = "default_" + Guid.NewGuid().ToString() + ".png";
                // caminho absoluto da copia da imagem carservice64.png com o nome no formato especificado
                string newImagPath = Path.Combine(imagStorage, newImagName);


                string oldImagPath = Path.Combine(imagStorage, newOficina.Imagem.ToString());

                try
                {
                    // efetuar a copia da imagem
                    System.IO.File.Copy(defaultImagPath, newImagPath);
                }
                catch (Exception)
                {
                    // mostrar mensagem de erro ao utilizador
                    ModelState.AddModelError("", "Ocorreu erro durante a edição deste registo. Não é possivel neste momento usar a imagem default.");
                    return View(newOficina);
                }

                // remove a imagem antiga
                System.IO.File.Delete(oldImagPath);

                // adicionar a imagem à oficina
                newOficina.Imagem = newImagName;
            }


            string imagName = "";

            // se foi inicado um ficheiro
            if (oficinaImag != null)
            {
                // Se for detetado um ficheiro que não seja do tipo especificado
                if (!(oficinaImag.ContentType == "image/jpeg" || oficinaImag.ContentType == "image/png"))
                {
                    // mostrar mensagem de erro ao utilizador
                    ModelState.AddModelError("", "Só é permitido imagens to tipo jpeg ou png");
                    return View(newOficina);
                }
                else
                {
                    // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                    imagName = Guid.NewGuid().ToString();
                    string imagTypeExt = Path.GetExtension(oficinaImag.FileName).ToString();
                    imagName += imagTypeExt;

                    // caminho absoluto da imagem no servidor
                    string oficiaImagPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "Images"), newOficina.Imagem);
                    // remove a imagem antiga
                    System.IO.File.Delete(oficiaImagPath);

                    // adicionar o nome da imagem à oficina
                    newOficina.Imagem = imagName;
                }
            }

            if (id != newOficina.IdOficina)
            {
                return NotFound();
            }

            //###############################################################

            // dados anteriormente guardados da Oficina
            var ofic = await _context.Oficinas
                                       .Where(o => o.IdOficina == id)
                                       .Include(o => o.ListaServicos)
                                       .FirstOrDefaultAsync();

            // obter a lista dos IDs dos servicos associadas à oficna, antes da edição
            var oldListaServicos = ofic.ListaServicos
                                           .Select(s => s.IdServ)
                                           .ToList();

            // avaliar se o utilizador alterou algum serviço associada à oficna
            // adicionados -> lista de servicos adicionados
            // retirados   -> lista de servicos retirados
            var adicionados = ServicoEscolhido.Except(oldListaServicos);
            var retirados = oldListaServicos.Except(ServicoEscolhido.ToList());

            // se algum servico foi adicionado ou retirado
            // é necessário alterar a lista de servicos 
            // associada à oficina
            if (adicionados.Any() || retirados.Any())
            {

                if (retirados.Any())
                {
                    // retirar o servico 
                    foreach (int oldServico in retirados)
                    {
                        var servicoToRemove = ofic.ListaServicos.FirstOrDefault(c => c.IdServ == oldServico);
                        ofic.ListaServicos.Remove(servicoToRemove);
                    }
                }
                if (adicionados.Any())
                {
                    // adicionar o servico 
                    foreach (int newServico in adicionados)
                    {
                        var servicoToAdd = await _context.Serviços.FirstOrDefaultAsync(s => s.IdServ == newServico);
                        ofic.ListaServicos.Add(servicoToAdd);
                    }
                }
            }

            //###############################################################

            if (ModelState.IsValid)
            {
                try
                {

                    ofic.Nome = newOficina.Nome;
                    ofic.Morada = newOficina.Morada;
                    ofic.CodigoPostal = newOficina.CodigoPostal;
                    ofic.Localidade = newOficina.Localidade;
                    ofic.NumTelemovel = newOficina.NumTelemovel;

                    // prepara para guardar os dados na bd
                    _context.Update(ofic);
                    // guarda os dados na bd
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // se ocorreu erro, verifica se o id da oficina fornecido existe
                    if (!OficinasExists(newOficina.IdOficina))
                    {
                        // id da oficina não encontrado
                        ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados. Id não encontrado.");
                        return View(newOficina);
                    }
                    else
                    {
                        // id da oficina encontrado
                        ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados");
                        //throw;
                    }
                    return View(newOficina);
                }

                if (imagName != null && oficinaImag != null)
                {
                    // guarda a imagem no servidor
                    SaveImage(imagName, oficinaImag);
                }
                // volta para a lista das oficinas
                return RedirectToAction(nameof(Index));
            }
            // obtem o nome do gestor associado com a oficina
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Nome", newOficina.IdGestor);
            return View(newOficina);
        }

        // GET: Oficinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return NotFound();
            }

            var oficinas = await _context.Oficinas
                .Include(o => o.Gestor)
                .Include(l => l.ListaServicos)
                .FirstOrDefaultAsync(m => m.IdOficina == id);
            if (oficinas == null)
            {
                return NotFound();
            }

            return View(oficinas);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oficinas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Oficinas'  is null.");
            }
            var oficinas = await _context.Oficinas.FindAsync(id);
            if (oficinas != null)
            {
                _context.Oficinas.Remove(oficinas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica se um dado id de oficina existe
        /// </summary>
        /// <param name="id">id da oficina</param>
        /// <returns>true se foi encontrado o id e false caso contrario</returns>
        private bool OficinasExists(int id)
        {
            return _context.Oficinas.Any(e => e.IdOficina == id);
        }

        /// <summary>
        /// Guarda a imagem no servidor
        /// </summary>
        /// <param name="imagName">nome da imagem com extensão</param>
        /// <param name="file"> ficheiro recebido do browser</param>
        private async void SaveImage(String imagName, IFormFile file)
        {
            // diretoria onde são armazenadas todas as imagens desta aplicação no servidor
            string imagStorage = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            // se a diretoria não existir
            if (!Directory.Exists(imagStorage))
            {
                // criar a diretoria
                Directory.CreateDirectory(imagStorage);
            }
            // caminho absoluto da imagem no servidor
            string newImagePath = Path.Combine(imagStorage, imagName);
            try
            {

                // define uma stream de ficheiros para o ficheiro especificado (imagem)
                using var stream = new FileStream(newImagePath, FileMode.Create);
                // guardar o ficheiro (imagem)
                await file.CopyToAsync(stream);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurreu um erro ao tentar guardar a imagem.");
            }
        }
    }
}