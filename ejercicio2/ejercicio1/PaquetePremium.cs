using System;
using System.IO;
using System.Collections.Generic;


namespace ejercicio1
{

    // TO-DO: Ejercicio 1.1
    // Implementación de la clase PaquetePremium

    //TO-DO Ejercicio 1.2. 
    // Implementación de los métodos anyadirServicio, obtenerServiciosString, 
    //  calculaPrecioServicios y obtenerPaqueteString.
    
    public class PaquetePremium : PaqueteVacacional
    {

        List<Servicio> servicios;

        public PaquetePremium (string codigo, string destino, string descripcion, int precio, List<Servicio> servicios) : base (codigo, destino, descripcion, precio)
        {
            this.servicios = servicios;
            servicios = new List<Servicio>();
        }

        public void anyadirServicio(Servicio servicio){

            this.servicios.Add(servicio);
        }

        public string obtenerServiciosString(){
            string respuesta = "";

            foreach (Servicio servicio in servicios){
                respuesta += servicio.obtenerServiciosString();
            }

            return respuesta;
        }

        public int CalculaPrecioServicios(){

            int suma = 0;

            foreach (Servicio servicio in servicios){
                suma += servicio.precio;
            }
            
            return suma;
        }

        public override string obtenerPaqueteString(){

            string respuesta = "";

            respuesta += "\n Paquete Premium: " + codigo + "\n Destino: " + destino + "\n Descripción: " + descripcion + "\n Precio base: " + precio + "\n";

            foreach (Servicio servicio in servicios){
                respuesta += servicio.obtenerServiciosString();
            }

            int sumaprecio = precio + CalculaPrecioServicios();

            respuesta += "\n Precio total: " + sumaprecio + "\n ";

            return respuesta;

        }


    }

}