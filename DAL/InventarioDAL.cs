using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using System.IO;

namespace DAL
{
    public class InventarioDAL
    {        

        /// <summary>
        /// Método para leer el archivo seleccionado
        /// Autor: Juan Camilo Ramirez Velez
        /// Fecha: 24/04/2017
        /// Req: Prueba XpertGroup
        /// </summary>
        /// <returns>retorna una lista de EquinosBovinos</returns>
        public List<EquinosBovinosDTO> LeerArchivo(FiltrosDTO _filtros)
        {
            try
            {
                // Variable que recibe la ruta del archivo seleccionado.
                string path = _filtros.Ruta;

                // Define una lista de EquinosBovinosDTO para retornar.
                List<EquinosBovinosDTO> listaAnimales = new List<EquinosBovinosDTO>();

                // Lee el archivo.
                StreamReader file = new StreamReader(@path);

                // Mientras no ha terminado de leer la secuencia.
                while (!file.EndOfStream)
                {
                    // Agrega el fila leida a la variable de tipo string.
                    string tipoAnimal = file.ReadLine();

                    // Define un objeto de tipo EquinoBovinosDTO y carga su propiedad tipo con la linea leida.
                    EquinosBovinosDTO animal = new EquinosBovinosDTO()
                    {
                        Tipo = tipoAnimal
                    };

                    // Agrega el objeto a la lista.
                    listaAnimales.Add(animal);
                }

                // Cierra la conexión.
                file.Close();

                // Retorna la lista de animales.
                return listaAnimales;
            }
            catch (Exception)
            {
                throw;
            }            
        }

    }
}
