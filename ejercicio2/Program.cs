using System;
using ejercicio1;

namespace ejercicio2
{
    class Program
    {
      static void Main(string[] args)
        {
            // Capturamos los argumentos pasados por terminal
            string destino=args.Length>0 ? args[0] : null;
            string filename=args.Length>1 ? args[1] : null;

            App myApp=new App();
            myApp.start();

            Console.WriteLine(myApp.obtenerDestinos(destino));

            if (filename!=null) myApp.guardarDestinos(destino, filename);
        }
    }
}
