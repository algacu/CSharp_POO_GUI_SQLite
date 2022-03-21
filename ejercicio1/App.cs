using System;
using System.IO;
using System.Collections.Generic;

namespace ejercicio1
{
    public class App
    {
        // Lista de paquetes Premium que contemplará la aplicación
        List<PaquetePremium> paquetes = new List<PaquetePremium>();
        public void start()
        {
            PaquetePremium paquete1 = new PaquetePremium("VLC1", "València", "Playa y gastronomía valenciana", 300, new List<Servicio>());
            paquete1.anyadirServicio(new Servicio("CEP", "Comida en el Palmar", 50));
            paquete1.anyadirServicio(new Servicio("PCB", "Paseo en barca por la Albufera", 10));
            paquetes.Add(paquete1);

            PaquetePremium paquete2 = new PaquetePremium("BEN1", "Benidorm", "Benidorm, playa y Montaña", 350, new List<Servicio>());
            paquete2.anyadirServicio(new Servicio("ETM", "Entrada a Terra Mítica", 20));
            paquete2.anyadirServicio(new Servicio("VPA", "Visita a la playa del Albir", 10));
            paquetes.Add(paquete2);

        }

        // TO-DO Ejercicio 1.3
        // Implementación del método obtenerDestinos

        public string obtenerDestinos(string destino)
        {
            // Este método devuelve un string con todos los paquetes
            // que tienen por destino el destino indicado como argumento.
            // Si el destino indicado es null, devolverá todos los paquetes.
            // Consejo: Utiliza el método obtenerPaqueteString para obtener un string
            // con los paquetes.
            string respuesta = "";

            if (destino == null)
            {

                foreach (PaquetePremium paquete in paquetes)
                {
                    respuesta += paquete.obtenerPaqueteString();
                }

            }
            else
            {
                foreach (PaquetePremium paquete in paquetes)
                {

                    if (paquete.obtenerPaqueteString().Contains(destino))
                    {
                        respuesta += paquete.obtenerPaqueteString();
                    }
                }

            }

            return respuesta;

        }

        // TO-DO Ejercicio 1.4
        // Implementación del método guardarDestinos
        // Guarda en el fichero "filename" un string con todos los paquetes
        // que tienen por destino el destino indicado como argumento.
        // Consejos: - El método obtenerDestinos anterior te será de utilidad.
        //           - Tened en cuenta que se podría generar alguna excepción en la gestión de los archivos.

        public void guardarDestinos(string destino, string filename)
        {
          try{
          foreach (PaquetePremium paquete in paquetes)
          {
            if (paquete.obtenerPaqueteString().Contains(destino))
            {
              using StreamWriter sw = File.CreateText(filename);
              sw.WriteLine(paquete.obtenerPaqueteString());
            }
          }
          } catch (Exception error) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error.Message);
            Console.ResetColor();
          }
        }

        



    }
}