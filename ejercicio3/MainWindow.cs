using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;


namespace ejercicio3
{
    class MainWindow : Window
    {
        // TO-DO: Ejercicio 3
        // Asociar los elementos de la interfaz correspondientes
        // A los siguientes elementos GTK:
        
        // [UI] private Button ...
        // [UI] private Button ...
        // [UI] private TextView ...

        [UI] private Button _btBuscar = null;
        [UI] private Button _btExportar = null;
        [UI] private TextView _textoDB = null;
        [UI] private ComboBoxText _selectorPaquete = null; // ComboBox con el selector de destino


        private App myApp; 
        
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            

            DeleteEvent += Window_DeleteEvent;
            
            // TO-DO: Ejercicio 3
            // Asociar los eventos:
            // - Clic en el botón Buscar al método buscarPaquetes
            // - Clic en el botón de exportar al método guardaDBTexto

            _btBuscar.Clicked += buscarPaquetes;
            _btExportar.Clicked += guardaDBTexto;

            // Creamos el objeto aplicación
            myApp = new App();
            // Y cargamos la Base de datos
            myApp.start();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void buscarPaquetes(object sender, EventArgs a){
            
            // TO-DO: Ejercicio 3
            // Añadir al texto del buffer del TextView el
            // resultado del método obtenerDestinos de tu aplicación

            //  Nota: 
            // Para acceder al destino seleccionado en el comboBox,
            // utilizamos _selectorPaquete.ActiveText
            _textoDB.Buffer.Text = myApp.obtenerDestinos(_selectorPaquete.ActiveText);

        }
        private void guardaDBTexto(object sender, EventArgs a)
        {
            // Seleccionamos el fichero a guardar la salida
            Gtk.FileChooserDialog filechooser =
            new Gtk.FileChooserDialog("Selecciona el fichero de base de datos",
                this,
                FileChooserAction.Save,
                "Cancelar", ResponseType.Cancel,
                "Guardar", ResponseType.Accept);

            // Lo lanzamos y comprobamos que se haya seleccionado "Aceptar"
            if (filechooser.Run() == (int)ResponseType.Accept)
            {

                // TO-DO: Ejercicio 3
                // Invocamos al método guardarDestinos de la aplicación, proporcionándole
                // el destino (a partir del _selectorPaquete) y el nombre del fichero (Filename del Filechooser)
                myApp.guardarDestinos(_selectorPaquete.ActiveText, filechooser.Filename);
                
            }
            filechooser.Destroy();
        }

    }
}
