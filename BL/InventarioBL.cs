using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;
using System.IO;

namespace BL
{
    public class InventarioBL
    {
        // Instancia la capa de acceso a datos.
        InventarioDAL _dal = new InventarioDAL();

        /// <summary>
        /// Método para leer el archivo importado
        /// Autor: Juan Camilo Ramirez Velez
        /// Fecha: 24/04/2017
        /// Req: Prueba XpertGroup
        /// </summary>
        /// <returns></returns>
        public string LeerArchivo(FiltrosDTO _filtros)
        {
            try
            {
                // Define una lista de tipo EquinosBovinosDTO.
                List<EquinosBovinosDTO> listaAnimales = new List<EquinosBovinosDTO>();
                
                // Llama el método LeerArchivo de la capa de acceso a datos.
                listaAnimales = _dal.LeerArchivo(_filtros);

                // Llama el método para clasificar los animales.
                return clasificarAnimales(listaAnimales);                
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método para clasificar los animales
        /// Autor: Juan Camilo Ramirez Velez
        /// Fecha: 24/04/2017
        /// Req: Prueba xpertGroup
        /// </summary>
        private string clasificarAnimales(List<EquinosBovinosDTO> listaAnimales)
        {
            try
            {
                // Define la lista de bovinos a guardar en el archivo txt.
                List<EquinosBovinosDTO> listaBovinos = new List<EquinosBovinosDTO>();
                // Define la lista de equinos a guardar en el archivo txt.
                List<EquinosBovinosDTO> listaEquinos = new List<EquinosBovinosDTO>();

                // Clasifica las listas por bovinos y equinos según el requerimiento.
                foreach (var animal in listaAnimales)
                {
                    // Si el animal recorrido contiene la letra "b" lo agrega a la lista de bovinos sino a la lista de equinos.
                    if (animal.Tipo.Contains("b"))
                    {
                        listaBovinos.Add(animal);
                    }
                    else
                    {
                        listaEquinos.Add(animal);
                    }
                }

                // Define las rutas para la creación de los archivos txt.
                string pathTxtBovinos = @"C:\Bovinos.txt";
                string pathTxtEquinos = @"C:\Equinos.txt";

                // Crear el archivo txt con la lista de bovinos.
                using (StreamWriter sw = File.CreateText(pathTxtBovinos))
                {
                    foreach (var animal in listaBovinos)
                    {
                        sw.WriteLine(animal.Tipo);
                    }
                }

                // Crear el archivo txt con la lista de equinos.
                using (StreamWriter sw = File.CreateText(pathTxtEquinos))
                {
                    foreach (var animal in listaEquinos)
                    {
                        sw.WriteLine(animal.Tipo);
                    }
                }

                // Valida que los archivos .txt existan en la ruta especificada para retornar un mensaje.
                if (File.Exists(pathTxtBovinos) && File.Exists(pathTxtEquinos))
                {
                    return "Los archivos han sido creados con éxito en la raíz de su disco local C: ";
                }
                else
                {
                    return "El proceso no se pudo completar";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}