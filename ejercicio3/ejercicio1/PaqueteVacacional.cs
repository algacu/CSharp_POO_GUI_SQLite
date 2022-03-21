using System;
using System.IO;
using System.Collections.Generic;

namespace ejercicio1
{

    // TO-DO: Ejercicio 1.1.
    // Implementación de la clase PaqueteVacacional

    //TO-DO Ejercicio 1.2. 
    // Implementación del método comparaDestino

    public abstract class PaqueteVacacional{

        protected string codigo;
        protected string descripcion;
        protected string destino;
        protected int precio;

        public PaqueteVacacional (string codigo, string destino, string descripcion, int precio){
            this.codigo = codigo;
            this.destino = destino;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public abstract string obtenerPaqueteString();

        public bool comparaDestino(string destino){

            bool comprueba = false;

            if (destino == this.destino){
                comprueba = true;
            }

            return comprueba;
        }

    }
        
}