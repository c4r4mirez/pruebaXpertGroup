using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using EN;
using BL;

namespace WPFInventarioPesebrera
{
    /// <summary>
    /// Lógica de interacción para RecepcionDeArchivo.xaml
    /// </summary>
    public partial class RecepcionDeArchivo : Window
    {
        // Instancias de las entidades.
        EquinosBovinosDTO _tipoAnimal = new EquinosBovinosDTO();
        FiltrosDTO _filtros = new FiltrosDTO();
        // Instancia la capa de negocio.
        InventarioBL _bl = new InventarioBL();

        //Constructor.
        public RecepcionDeArchivo()
        {
            InitializeComponent();            
        }

        #region EVENTOS
        /// <summary>
        /// Abre el cuadro de dialogo para seleccionar un archivo
        /// Autor: Juan Camilo Ramirez Velez
        /// Fecha: 24/04/2018
        /// Req: Prueba xpertGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Configuración al abrir la ventana para seleccionar el archivo.
                OpenFileDialog dlg = new OpenFileDialog();                
                // Tipos de archivos permitidos.
                dlg.Filter = "DAT Files|*.DAT|Log Files|*.log|Text Files|*.txt|All Files|*.*";                
                // Extension de archivo por defecto
                dlg.DefaultExt = ".DAT";

                // Carga el estado del cuadro de dialogo del archivo abierto en la variable result.
                Nullable<bool> result = dlg.ShowDialog();

                // Procesa el resultado del cuadro de diálogo de archivo.
                if (result == true)
                {
                    // Pinta el nombre del archivo seleccionado en el txtArchivo.
                    txtArchivo.Text = dlg.FileName;
                    // Carga el objeto _filtros con la ruta del archivo seleccionado.
                    _filtros.Ruta = txtArchivo.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        /// <summary>
        /// Clasifica los animales según requerimiento
        /// Autor: Juan Camilo Ramirez Velez
        /// Fecha: 24/04/2017
        /// Req: Prueba xpertGroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClasificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Valida el txtArchivo.
                if (string.IsNullOrEmpty(this.txtArchivo.Text))
                {
                    MessageBox.Show("Debe seleccionar un archivo","Alerta",MessageBoxButton.OK,MessageBoxImage.Warning);                
                }
                else
                {   
                    // Llama el método LeerArchivo de la capa de negocio.
                    string rpt = _bl.LeerArchivo(_filtros);

                    MessageBox.Show(rpt, "Clasificación", MessageBoxButton.OK, MessageBoxImage.Information);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
        #endregion        

    }
}
