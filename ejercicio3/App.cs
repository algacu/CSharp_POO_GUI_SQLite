using System;
using System.IO;
using System.Collections.Generic;
using ejercicio1;

namespace ejercicio3
{
    public class App
    {
        List<PaquetePremium> paquetes = new List<PaquetePremium>();
        public void start()
        {
          paquetes = paquetesDAO.cargarDB();
        }

        // TO-DO: 
        // Para probar el funcionamiento, debes
        // copiar aquí los métodos obtenerDestinos y guardarDestinos
        // de tu clase App del ejercicio1.

        public string obtenerDestinos(string destino)
        {
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