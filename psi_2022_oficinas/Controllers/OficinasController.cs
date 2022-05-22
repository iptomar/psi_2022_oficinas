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

        // GET: Oficinas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Oficinas.Include(o => o.Gestor);
            return View(await applicationDbContext.ToListAsync());
        }

        // procurar oficinas por localidade
        //public async Task<IActionResult> Index(string local)
        //{
        //    // define a query LINQ para selecionar as oficinas
        //    var oficinas = from m in _context.Oficinas select m;

        //    // se local contem uma string
        //    if (!String.IsNullOrEmpty(local))
        //    {
        //        // modificar a query para filtrar as oficinas onde Localidade contem a string local
        //        oficinas = oficinas.Where(s => s.Localidade!.Contains(local));
        //    }

        //    // query é executada aqui quando este metodo é invocado.
        //    // Retorna à view (Index) um objeto do modelo do tipo Oficinas
        //    // que contem uma lista de oficinas onde foi encontrado a string local no atributo Localidade
        //    return View(await oficinas.ToListAsync());
        //}

        // procurar oficinas por localidade
        public async Task<IActionResult> Search(string local)
        {
            // define a query LINQ para selecionar as oficinas
            var oficinas = from m in _context.Oficinas select m;

            // se local contem uma string
            if (!String.IsNullOrEmpty(local))
            {
                // modificar a query para filtrar as oficinas onde Localidade contem a string local
                oficinas = oficinas.Where(s => s.Localidade!.Contains(local));
            }

            // query é executada aqui quando este metodo é invocado.
            // Retorna à view (Index) um objeto do modelo do tipo Oficinas
            // que contem uma lista de oficinas onde foi encontrado a string local no atributo Localidade
            return View(await oficinas.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas oficinas, IFormFile oficinaImag)
        {
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

                // efetuar a copia da imagem
                System.IO.File.Copy(defaultImagPath, newImagPath);

                // adicionar a imagem à oficina
                oficinas.Imagem = newImagName;
            }
            else
            {
                // Se for detetado um ficheiro que não seja do tipo especificado
                if (!(oficinaImag.ContentType == "image/jpeg" || oficinaImag.ContentType == "image/png"))
                {
                    // mostrar mensagem de erro ao utilizador
                    ModelState.AddModelError("", "Só é permitido imagens to tipo jpeg ou png");
                    return View(oficinas);
                }
                else
                {
                    // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                    string imagName = "oficina_" + Guid.NewGuid().ToString();
                    string imagTypeExt = Path.GetExtension(oficinaImag.FileName).ToString();
                    imagName += imagTypeExt;

                    // adicionar a imagem à oficina
                    oficinas.Imagem = imagName;
                }
            }
            // Se os dados fornecidos pelo utilizador forem válidos
            if (ModelState.IsValid)
            {
                try
                {
                    // preparar para guarda os dados na bd
                    _context.Add(oficinas);
                    // guardar os dados na bd
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    // Ups! Ocorreu um problema. Mostrar mensagem de erro.
                    ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados");
                    return View(oficinas);
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
                    string imagOficina = Path.Combine(imagStorage, oficinas.Imagem);
                    // guardar a imagem no caminho especificado
                    using var stream = new FileStream(imagOficina, FileMode.Create);
                    await oficinaImag.CopyToAsync(stream);
                }
                // retorna à lista de oficinas
                return RedirectToAction(nameof(Index));
            }
            return View(oficinas);
        }

        // GET: Oficinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return RedirectToAction("Index");
            }

            var oficinas = await _context.Oficinas.FindAsync(id);
            if (oficinas == null)
            {
                return RedirectToAction("Index");
            }
            // obtem o nome do gestor associado à oficina
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Nome", oficinas.IdGestor);

            // variavel de sessão para guardar o id da oficina
            //HttpContext.Session.SetInt32("IdOficina", oficinas.IdOficina);

            return View(oficinas);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas oficinas, IFormFile oficinaImag, string useDefaultImg)
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


                string oldImagPath = Path.Combine(imagStorage, oficinas.Imagem.ToString());

                // efetuar a copia da imagem
                System.IO.File.Copy(defaultImagPath, newImagPath);

                // remove a imagem antiga
                System.IO.File.Delete(oldImagPath);

                // adicionar a imagem à oficina
                oficinas.Imagem = newImagName;
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
                    return View(oficinas);
                }
                else
                {
                    // Normalizar um novo nome para a imagem no formato. oid_<oficinaID>_guid
                    imagName = Guid.NewGuid().ToString();
                    string imagTypeExt = Path.GetExtension(oficinaImag.FileName).ToString();
                    imagName += imagTypeExt;

                    // caminho absoluto da imagem no servidor
                    string oficiaImagPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "Images"), oficinas.Imagem);
                    // remove a imagem antiga
                    System.IO.File.Delete(oficiaImagPath);

                    // adicionar o nome da imagem à oficina
                    oficinas.Imagem = imagName;
                }
            }

            if (id != oficinas.IdOficina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // prepara para guardar os dados na bd
                    _context.Update(oficinas);
                    // guarda os dados na bd
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // se ocorreu erro, verifica se o id da oficina fornecido existe
                    if (!OficinasExists(oficinas.IdOficina))
                    {
                        // id da oficina não encontrado
                        ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados. Id não encontrado.");
                        return View(oficinas);
                    }
                    else
                    {
                        // id da oficina encontrado
                        ModelState.AddModelError("", "Não foi possivel guardar o registo na base de dados");
                        //throw;
                    }
                    return View(oficinas);
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
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Nome", oficinas.IdGestor);
            return View(oficinas);
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurreu um erro ao tentar guardar a imagem. " + ex.Message);
            }
        }
    }
}
