using System;
using System.IO;
using System.Collections.Generic;

namespace ejercicio1
{

    // TO-DO: Ejercicio 1.1.
    // Implementación de la clase Servicio

    //TO-DO Ejercicio 1.2. 
    // Implementación del método obtenerServicioString

    public class Servicio
    {
        string codigo;
        string descripcion;
        public int precio {get;}

        public Servicio (string codigo, string descripcion, int precio){
          this.codigo = codigo;
          this.descripcion = descripcion;
          this.precio = precio;
        }

        public string obtenerServiciosString(){

          string servicio = "\n\t Código: " + codigo + "\n \t Desripción: " + descripcion + "\n \t Precio: " + precio;

          return servicio;
        }



    }

}
