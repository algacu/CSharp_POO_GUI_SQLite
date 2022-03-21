using System;
using System.IO;
using System.Data.SQLite;   // Importamos los elementos necesarios para conectrarnos al proveedor de datos.
using System.Collections.Generic;
using ejercicio1;

namespace ejercicio3
{
    public static class paquetesDAO
    {

        public static List<PaquetePremium> cargarDB()
        {

            // Este método carga la información de la base de datos
            // y la devuelve en forma de lista de paquetes premium         

            List<PaquetePremium> paquetes = new List<PaquetePremium>();

            try
            {
                // Creamos la cadena de conexión (directamente al fichero viajes.db)
                string cs = @"URI=file:viajes.db";

                // TO-DO. Ejercicio 2. Completa la carga de la base de datos
                // La consulta a realizar será:
                // select codigo, Destino, Descripcion, Precio from Paquete;

                using var conection = new SQLiteConnection(cs);

                conection.Open();

                string statement = "select codigo, Destino, Descripcion, Precio from Paquete;";

                using var command = new SQLiteCommand(statement, conection);

                using SQLiteDataReader reader = command.ExecuteReader();

                // Con cada fila del resultado devuelto, deberemos crear un objeto de
                // tipo paquetePremium. Fijáos que el orden de la consulta nos determina
                // los campos de éstos objetos:
                // codigo -> Columna 0 (String) -> campo codigo de paquetePremium
                // destino -> Columna 1 (String) -> campo destino de paquetePremium
                // descripcion -> Columna 2 (String) -> campo descripcion de paquetePremium
                // precio -> Columna 3 (Int32) -> campo precio de paquetePremium

                while (reader.Read())
                {
                    String codigo = reader.GetString(0);
                    String destino = reader.GetString(1);
                    String descripcion = reader.GetString(2);
                    int precio = reader.GetInt32(3);

                    paquetes.Add(new PaquetePremium(codigo, destino, descripcion, precio, obtenerServicios(conection, codigo)));

                }
                
                // La dificultad añadida está en que deberemos crear también una lista de
                // servicios asociados a este paquete. Esta lista nos la proporcionará el método
                // obtenerServicios(con, codigo), que implementamos a continuación.
                
            }
            catch (SQLiteException err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error de SQLite: " + err.Message);
                Console.ResetColor();
            }

            return paquetes;

        }


        public static List<Servicio> obtenerServicios(SQLiteConnection conection, string codigo)
        {
            // Hacemos la consulta sobre la misma conexión que nos pasan

            // Este método carga la información de la base de datos
            // y la devuelve en forma de lista de paquetes premium

            List<Servicio> servicios = new List<Servicio>();

            try
            {
                // TO-DO. Ejercicio 2
                // Realizar la consulta paramétrizada:
                // select codigo, Descripcion, Precio from Servicio S, servicioPaquete SP
                //  where S.codigo=SP.Servicio and SP.Paquete=@idPaquete
                // Siendo idPaquete el código que se nos proporciona en la llamada
                // Deberás utilizar la conexión con que se te proporciona, así
                // no hace falta crear una conexión nueva a la BD

                string statement = "select codigo, Descripcion, Precio from Servicio S, servicioPaquete SP where S.codigo=SP.Servicio and SP.Paquete=@idPaquete;";

                using var command = new SQLiteCommand(statement, conection);

                command.Parameters.AddWithValue("@idPaquete", codigo);

                command.Prepare();

                using SQLiteDataReader reader = command.ExecuteReader();

                // Cada fila de la consulta se corresponderá con un servicio asociado al id del Paquete.
                // La correspondencia entre columna será:
                // - código del servicio: columna 0 (String)
                // - Descripción: columna 1 (String)
                // - Precio: columna 2 (Int32)

                while (reader.Read())
                {
                    String Codigo = reader.GetString(0);
                    String Descripcion = reader.GetString(1);
                    int Precio = reader.GetInt32(2);

                    servicios.Add(new Servicio (Codigo, Descripcion, Precio));
                }
                    
            }
            catch (SQLiteException err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error de SQLite: " + err.Message);
                Console.ResetColor();
            }

            return servicios;

        }
    }

}