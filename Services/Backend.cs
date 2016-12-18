using Microsoft.EntityFrameworkCore; 
using Publicaciones.Models; 

namespace Publicaciones.Backend {

    /// <summary>
    /// Representacion de la base de datos.
    /// </summary>
    public class BackendContext : DbContext {

        /// <summary>
        /// Constructor vacio para pruebas
        /// </summary>
        public BackendContext() {
            
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        public BackendContext(DbContextOptions < BackendContext > options) : base(options) {
        }

        /// <summary>
        /// Representacion de las Personas del Backend
        /// </summary>
        /// <returns>Link a la BD de Personas</returns>
        public DbSet < Persona > Personas {get; set; }
        public DbSet<Autor> Autores{get;set;}
        public DbSet <Publicacion> Publicaciones{get;set;}
        public DbSet <Paper> Papers{get;set;}
        public DbSet <EstadoDePostulacion> EstadoDePostulaciones{get;set;}

    }

}