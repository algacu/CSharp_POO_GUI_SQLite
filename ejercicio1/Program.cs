using System;

namespace ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Capturamos los argumentos pasados por terminal
            string destino=args.Length>0 ? args[0] : null;
            string filename=args.Length>1 ? args[1] : null;

            // Creamos el objeto Aplicación
            App myApp=new App();
            myApp.start();

            
            // TO-DO Ejercicio 1.3
            // Descomentar para probar la implementación de obtenerDestinos
            // Mostramos los paquetes correspondientes al destino
            // que se busca.
            Console.WriteLine(myApp.obtenerDestinos(destino));

            // TO-DO Ejercicio 1.4
            // Descomentar para probar la implementación de guardarDestinos
            // Si se ha indicado un segundo argumento, lo guardamos 
            // en el fichero indicado.
            if (filename!=null) myApp.guardarDestinos(destino, filename);
        }
    }
}
