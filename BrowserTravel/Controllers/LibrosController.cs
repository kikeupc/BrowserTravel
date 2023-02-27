using BrowserTravel.Entidades;
using BrowserTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravel.Controllers
{
    public class LibrosController: Controller
    {
        private readonly LibrosController    _librosController;
        private readonly BdtravelContext bdtravelContext;

   
        public LibrosController(BdtravelContext bdtravelContext) 
        {
            this.bdtravelContext = bdtravelContext;
        }   

        /// <summary>
        /// Obtiene un listado de libros
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index() 
        {

            var libros = await bdtravelContext.Libros.Select(l => new LibroViewModel
            {
                Isbn=l.Isbn,
                Titulo = l.Titulo,
                Sinopsis = l.Sinopsis,
                NPaginas = l.NPaginas,                
                Autores = l.Autores

            }).ToListAsync();

            var modelo = new ListadoLibrosViewModel();
            modelo.Libros= libros;

            return View(modelo);  
        }

        /// <summary>
        /// Consulta libro por isbn para obtener detalle de este
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detalle(int isbn)
        {

            var libro = await bdtravelContext.Libros.Where(d => d.Isbn == isbn).Select(l=>new LibroViewModel 
            {
                Titulo = l.Titulo,
                Sinopsis = l.Sinopsis,
                Editoriales= l.Editoriales, 
                Autores =l.Autores  
            }).FirstOrDefaultAsync();

            if (libro == null) 
            {
                return NotFound();
            }
            

            return View(libro);
        }
    }
}
