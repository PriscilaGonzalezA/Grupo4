using System; 
using System.Collections.Generic; 
using System.Linq; 
using Microsoft.Extensions.Logging; 
using Publicaciones.Backend; 
using Publicaciones.Models; 

namespace Publicaciones.Service {

    /// <summary>
    /// Metodos de la interface
    /// </summary>
    public interface IMainService {

        void Add(Persona persona); 
        List < Persona > FindPersonas(string nombre);
        List <Persona> Personas();

        void AddPublicaciones(Publicacion publicacion);
        List <Publicacion> Publicaciones(string rut);
        List <Publicacion> Publicaciones();

        void AddAutor(Autor autor);
        List<Autor> Autores(String rut);
        List<Autor> Autores();

        void AddEstadoPostulacion(EstadoDePostulacion estadoPostulacion);
        List<EstadoDePostulacion> EstadoPostulaciones(String tipo);
        List<EstadoDePostulacion> EstadoPostulaciones();

        void AddPaper(Paper paper);
        List<Paper> Papers(String titulo);
        List<Paper> Papers();




        void Initialize(); 
    }

    /// <summary>
    /// Implementacion de la interface IMainService
    /// </summary>


    public class MainService:IMainService {

        /// <summary>
        /// Acceso al Backend
        /// </summary>
        /// <returns></returns>
        private BackendContext BackendContext { get; set; }

        /// <summary>
        /// The Logger 
        /// </summary>
        /// <returns></returns>
        private ILogger Logger { get; set; }

        private Boolean Initialized { get; set; }

        /// <summary>
        /// Constructor via DI
        /// </summary>
        /// <param name="backendContext"></param>
        /// <param name="loggerFactory"></param>
         public MainService(BackendContext backendContext, ILoggerFactory loggerFactory) {

            // Inicializacion del Logger
            Logger = loggerFactory?.CreateLogger < MainService > (); 
            if (Logger == null) {
                throw new ArgumentNullException(nameof(loggerFactory)); 
            }

            // Obtengo el backend
            BackendContext = backendContext; 
            if (BackendContext == null) {
                throw new ArgumentNullException("MainService requiere del BackendService != null"); 
            }

            // No se ha inicializado
            Initialized = false;

            Logger.LogInformation("MainService created"); 
        }

        public void Add(Persona persona) {

            // Guardo la Persona en el Backend
            BackendContext.Personas.Add(persona); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }
        public void AddPublicaciones(Publicacion publicacion){
            // Guardo la Publicacion en el Backend
            BackendContext.Publicaciones.Add(publicacion); 

            // Guardo los cambios
            BackendContext.SaveChanges();
        }
        public void AddAutor(Autor autor){
            // Guardo el Autor en el Backend
            BackendContext.Autores.Add(autor); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }
        public void AddPaper(Paper paper){
            // Guardo el paper en el Backend
            BackendContext.Papers.Add(paper); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }
        public void AddEstadoPostulacion(EstadoDePostulacion estadoPostulacion){
            // Guardo el paper en el Backend
            BackendContext.EstadosdePostulaciones.Add(estadoPostulacion); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }
       
        public List<Persona> Personas() {
            return BackendContext.Personas.ToList();
        }

        public List <Publicacion> Publicaciones(){
            return BackendContext.Publicaciones.ToList();
        }
        public List<Autor> Autores(){
            return BackendContext.Autores.ToList();
        }
        public List<Paper> Papers(){
            return BackendContext.Papers.ToList(); 
        }
        public List<EstadoDePostulacion> EstadoPostulaciones(){
            return BackendContext.EstadosdePostulaciones.ToList();
        }


        public List < Persona > FindPersonas(string nombre) {
            return BackendContext.Personas
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToList(); 
        }
         public List<Publicacion> Publicaciones(string rut){
             return null;
         //    return BackendContext.Publicacion
         //    Where()
         }
         public List<Autor> Autores(string rut){
             return null;
         }
         public List<Paper> Papers(String titulo){
             return null;
         }
        public List<EstadoDePostulacion> EstadoPostulaciones(String tipo){
            return null;
        }



        public void Initialize() {

            if (Initialized) {
                throw new Exception("Solo se permite llamar este metodo una vez");
            }

            Logger.LogDebug("Realizando Inicializacion .."); 
            // Persona por defecto
            Persona persona = new Persona(); 
            persona.Nombre = "Diego"; 
            persona.Apellido = "Urrutia"; 

            // Agrego la persona al backend
            this.Add(persona); 

            foreach (Persona p in BackendContext.Personas) {
                Logger.LogDebug("Persona: {0}", p); 
            }

            Initialized = true;

            Logger.LogDebug("Inicializacion terminada :)");
        }
    }

}