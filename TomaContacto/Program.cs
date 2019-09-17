
namespace TomaContacto
{

    using System;    
    //Para pillar información video del Andaluz
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using MySql.Data.MySqlClient;  //Además de añadir la referencia, hay que indicar el using correspondiente
    using System.Configuration;   //Para utilizar el  ConnectionStringSettings conns = ConfigurationManager.ConnectionStrings["Conexion"];
                                  //y poder pillar las cadenas de conexión que tengamos definidad en el Properties 
                                  //OjO  que tambien podemos añadirlo como referencia y no habria que poner el using 








    class Program
    {
        static void Main(string[] args)
        {
            /*
            //El siguiente código muestra cómo conectar con el motor SQL Server de la máquina local 
            // y acceder a la base de datos (el catálogo) "Almacen"
            // utilizando seguridad integrada SSPI (Security Support Provider Interface):


                    // Preparamos el objeto Connection
                    string cadenaConexion = @"Data source=(local);
                                           Initial catalog=Datos;   
                                           Integrated Security=SSPI;";
                    SqlConnection conexion = new SqlConnection(cadenaConexion);

                    // Abrimos realmente la conexión
                    conexion.Open();

                    // Hacemos algo con ella...
                    Console.WriteLine("Estado de la conexión: " + conexion.State);

                    // Y la cerramos explícitamente
                    conexion.Close();

                    Console.ReadKey();


            */

            //--------------------------------------------------------------------------------------------------------------
            //
            //    COMANDOS 
            //
            //-------------------------------------------------------------------------------------------------------------
            /*
               
                ExecuteScalar  EJECUTA LA BUSQUEDA, CON LOS VALORES QUE HEMOS CARGADO EN LOS PARAMETROS.... ???
                --------------------------------------------------------------------------------------------------

                •	ExecuteScalar()  Retorna un object con el valor de la primera columna de la primera fila del conjunto de datos obtenido,
                                     ignorando el resto. 
                                     El tipo concreto dependerá de la consulta realizada y del valor obtenido.
                                     Por ejemplo, en el código anterior era un entero,  puesto que estábamos realizando un recuento de filas.

                •	ExecuteNonQuery()  Ejecuta una orden sobre la base de datos, normalmente de actualización de datos, 
                                       retornando el número de filas afectadas,  o  -1    si hay algún error.

                •	ExecuteReader()    Ejecuta una consulta, retornando una secuencia de sólo avance y sólo lectura 
                                       con los datos obtenidos. 
                                       El recorrido de estos datos, como veremos más adelante, 
                                       se realiza a través del objeto DbDataReader propio del data provider en uso
                   
                 El proveedor SqlClient proporciona también el método    ExecuteXmlReader(), 
                 que permite obtener un objeto  XmlReader   directamente desde los datos obtenidos en la consulta, 
                 en formato XML. 
                   
             */


            //-------------->>     PRIMER EJEMPLO  DE COMANDOS  <<-----------------------------------------

            ////->Instanciar y definir la cadena de conexion 
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;
            //                          Integrated Security=True;
            //                          Database=Datos; 
            //                          Connect Timeout=15;
            //                          Encrypt=False;
            //                          TrustServerCertificate=True;
            //                          ApplicationIntent=ReadWrite;
            //                          MultiSubnetFailover=False";

            //con.Open();

            ////-->Instanciar un objeto Command  Ademas le indicamos la sentencia a ejecutar  y  la cadena de conexion que vamos a utilizar 
            //SqlCommand cmd = new SqlCommand("Select count(*) from Archivos", con);   //--> Conteo de filas de una tabla...
            //int numeroArchivos = (int)cmd.ExecuteScalar();

            //Console.WriteLine("Cantidad de registros en la tabla Arichivos : " + numeroArchivos);



            ////--> Obtención del nombre del primer registro de la tabla Archivos            
            //SqlCommand cmd2 = new SqlCommand("Select  top 1   Nombre  from Archivos" ,  con);            
            //string nombreArchi = (string)cmd2.ExecuteScalar();   //string nombreArchi = cmd2.ExecuteScalar().ToString();

            //Console.WriteLine("Primer nombre de la tabla Archivos " + nombreArchi);

            //con.Close();



            //-------------->>     SEGUNDO EJEMPLO  DE COMANDOS  <<-----------------------------------------


            //->Instanciar y definir la cadena de conexion 
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=MBO9IBSTHERRERO\SQLEXPRESS;
            //                          Integrated Security=True;
            //                          Database=Datos; 
            //                          Connect Timeout=15;
            //                          Encrypt=False;
            //                          TrustServerCertificate=True;
            //                          ApplicationIntent=ReadWrite;
            //                          MultiSubnetFailover=False";

            //con.Open();

            // ME CAGO EN TODO LO QUE SE MENEA....ME ESTAN FALLANDO EL RESTO DE COSAS PORQUE AQUÍ SOLO ESTOY 
            // PILLANDO DOS CAMPOS DE LA TABLA JODERRRRRRRR QUE IDIOTA :
            //
            //SqlCommand cmd = new SqlCommand("Select Nombre ,  Kilobytes from Archivos", con);

            //-- Pillo todos los campos de la tabla :
            //--------------------------------------
            //   SqlCommand cmd = new SqlCommand("Select * from Archivos", con);
            //   SqlDataReader reader = cmd.ExecuteReader();



            //string UbicaCampos;


            //while (reader.Read())  //sirve para obtener la siguiente fila y retorna false en caso de haber llegado al final, 
            //{
            //    string nombre = reader.GetString(0);   //GetBoolean(),GetByte(), GetChar(), GetDateTime(), GetDecimal(), GetSqlMoney(), GetSqlGuid(), GetSqlBoolean(), 
            //    int kilobytes = reader.GetInt32(1);   //el 1 hace referencia al orden de la columna en la tabla 

            //    Console.WriteLine(nombre + ": " + kilobytes);


            //    //-->Nos deberia de informar del lugar que ocupa el campo en la tabla, para poder utilizarlo 
            //    ---------------------------------------------------------------------------------------------
            //    //UbicaCampos = reader.GetString(reader.GetOrdinal("Nombre"));
            //    //Console.WriteLine("Ubiacion del campo  Nombre en la Tabla Articulos : " + UbicaCampos);


            //}


            //-->ESTE EJEMPLO ES UTILIZANDO LOS PROPIOS NOMBRES DE LOS CAMPOS 
            //---------------------------------------------------------------
            //while (reader.Read())
            //{
            //    string nombre = (string)reader["Nombre"];
            //    int kilobytes = (int)reader["Kilobytes"];
            //    Console.WriteLine(nombre + ": " + kilobytes);
            //}
            //reader.Close();


            // !!! ATENCION   :  El código anterior funcionará correctamente siempre que no se obtengan valores nulos, 
            //                   en cuyo caso se lanzará una excepción
            //
            // Por tanto, antes de intentar realizar una conversión hacia cualquier tipo de datos, 
            // es conveniente comprobar que la columna no contenga un nulo, 
            // tarea que podemos realizar de muchas formas distintas:


            //-------------------------------------------------
            //VARIOS EJEMPLOS PREGUNTADO POR EL VALOR DE NULL :
            //------------------------------------------------

            //--> AQUI ESTAMOS PILLANDO LA POSICION DEL CAMPO EN  EL READER,   OJO LO QUE TUVIERA SELECCIONADO  
            //----------------------------------------------------------------------------------------------
            //int UbicaCampos  = reader.GetOrdinal("IdDocumento");
            //int UbicaCampos0 = reader.GetOrdinal("Nombre");
            //int UbicaCampos1 = reader.GetOrdinal("Kilobytes");
            //int UbicaCampos2 = reader.GetOrdinal("FechaCreacion");
            //int UbicaCampos3 = reader.GetOrdinal("Tipo");
            //int UbicaCampos4 = reader.GetOrdinal("Ancho");
            //int UbicaCampos5 = reader.GetOrdinal("Alto");
            //int UbicaCampos6 = reader.GetOrdinal("DuracionMinutos");
            //int UbicaCampos7 = reader.GetOrdinal("NumeroPaginas");


            //Console.WriteLine(reader.GetName(0));
            //Console.WriteLine(reader.GetName(1));
            //Console.WriteLine(reader.GetName(2));
            //Console.WriteLine(reader.GetName(3));
            //Console.WriteLine(reader.GetName(4));


            //int VarAncho = 0;
            //int NoSeCuantos = 0;
            //while (reader.Read())
            //{

            //    //if (reader["Ancho"] != DbNull.Value) //  JODER  ES CON  B  MAYUSCULA (DBNull)   PUTO PROFERSORRRRRR

            //    //-------------  Comprobando el tipo  -------------------------------------------//
            //    if (reader["Ancho"] != DBNull.Value)
            //    {
            //        Console.WriteLine("NO ES  NULO");
            //    }
            //    else
            //    {
            //        Console.WriteLine("ES UN PUTO NULO");
            //    }

            //    //--------------------------------------------------------//
            //    if (reader["Ancho"] is DBNull) 
            //    {
            //        Console.WriteLine("ES UN PUTO NULO - V2");
            //    }
            //    else
            //    {
            //        Console.WriteLine("NO ES  NULO  -  V2 ");
            //    }
            //    //----------------  Usando System.Conver ----------------------------//


            //    //--->>> Usando System.Conver   

            //    if (Convert.IsDBNull(reader["Ancho"]))                    
            //    {
            //        Console.WriteLine("ES UN PUTO NULO - V3");
            //        NoSeCuantos =  0;
            //    }
            //    else
            //    {
            //        Console.WriteLine("NO ES  NULO  -  V3 ");
            //        NoSeCuantos = (int)reader["Ancho"];
            //    }


            //------------------  Usando tipos referencia y anulables   ----------------------------------------


            //string nombre = reader["Nombre"] as string;
            //decimal? precio = reader["Precio"] as decimal?; ;

            //------------------ Incluso usando el null coalescing operator...   ----------------------------------------

            // string nombre = reader["Nombre"] as string ?? "Desconocido";



            // Obtención de resultados múltiples   DOS consultas en el mismo  CommandText
            // --------------------------------------------------------------------------

            // ADO.NET permite obtener múltiples conjuntos de resultados en el mismo comando.
            // El siguiente ejemplo muestra cómo sobre un único comando realizamos 
            // dos consultas consecutivamente, 
            // que podemos obtener desde el DataReader:


            //SqlCommand cmd = con.CreateCommand();

            ////--> Dos consultas en el mismo comando:            
            //cmd.CommandText = "Select * from Archivos;   select * from Personas";

            //SqlDataReader reader = cmd.ExecuteReader();

            //Console.WriteLine("Mostramos los Archivos");
            //Console.WriteLine("======================");
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["Nombre"]);
            //}

            //reader.NextResult(); // Obtenemos el siguiente conjunto de resultados con NextResult

            //Console.WriteLine("Mostramos las Personas ");
            //Console.WriteLine("======================");
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["Nombre"]);
            //}
            //reader.Close();






            //La forma más verbosa para crear e incluir el parámetro 
            //en el comando consistiría en instanciar el objeto Parameter específico del proveedor, 
            //establecer sus propiedades y añadirlo ya configurado a esta colección:


            //string sql = @"Select IdPersona, Nombre From Personas  Where Username=@nombre and Apellidos=@apellidos";
            //SqlCommand cmd = new SqlCommand(sql, con);

            // ESTA SINTAXIS NO LA ENTIENDE: SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.NVarChar);
            // Necesita toda la ruta(System.Data.SqlDbType.)    ¿faltara incluirla en las referencias?

            //SqlParameter nombre = new SqlParameter("@nombre", System.Data.SqlDbType.NVarChar);
            //  nombre.Value = "Rafael";
            //  cmd.Parameters.Add(nombre);

            //SqlParameter apellidos = new SqlParameter("@apellidos", System.Data.SqlDbType.NVarChar);
            //  apellidos.Value = "Farulla";
            //  cmd.Parameters.Add(apellidos);



            /*   Miembros de DbParameter
                 -----------------------
             
            •	DbType        : Indica el tipo de dato del parámetro, de entre los miembros de la enumeración DbType. 
                                Los proveedores que implementan DbParameter normalmente añaden una propiedad 
                                que especifica el tipo específico del motor de datos; 
                                por ejemplo, en SqlClient, esta propiedad es SqlDbType, que es la que utilizaremos normalmente.

            •	Direction     : Permite indicar la dirección del parámetro (entrada, salida, bidireccional o valor de retorno) 
                                mediante uno de los miembros de la enumeración System.Data.ParameterDirection.

            •	IsNullable    : Indica si el parámetro admite valores nulos.

            •	ParameterName : Nombre del parámetro.

            •	Size          : Tamaño máximo admitido para el valor del parámetro. 
                                En el caso de las cadenas de texto, será el número de caracteres.

            •	Value         : Es el valor del parámetro. 
                                Cuando sea un parámetro de entrada, deberemos establecerlo antes de ejecutar el comando; 
                                en los parámetros de salida, podremos consultar su valor tras su ejecución.

             */


            //    ALTA DE REGISTROS    -  MODIFICACION  DE REGISTROS 
            //------------------------------------------------------------

            // CADENA TRABAJO :
            string cadenaConexTRA = @"Data Source=MBO9IBSTHERRERO\SQLEXPRESS;
                                      Integrated Security=True;
                                      Database=Datos; 
                                      Connect Timeout=15;
                                      Encrypt=False;
                                      TrustServerCertificate=True;
                                      ApplicationIntent=ReadWrite;
                                      MultiSubnetFailover=False";
            // CADENA CASA :
            
            string cadenaConex = @"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;
                                      Integrated Security=True;
                                      Database=Datos; 
                                      Connect Timeout=15;
                                      Encrypt=False;
                                      TrustServerCertificate=True;
                                      ApplicationIntent=ReadWrite;
                                      MultiSubnetFailover=False";
             



            using (SqlConnection con = new SqlConnection(cadenaConex))
                {
                  con.Open();


                //-->ALTA  ----------------------------------------------------------------------------------------------------------------
                string sqlInsert = @"Insert into Personas (Nombre,  Apellidos, IdLocalidad)
                                                     Values (@Nombre, @Apellidos, @IdLocalidad )";

                  SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);

                  cmdInsert.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 25).Value = "Pedro";
                  cmdInsert.Parameters.Add("@Apellidos", System.Data.SqlDbType.NVarChar, 50).Value = "Caballero";
                  cmdInsert.Parameters.Add("@IdLocalidad", System.Data.SqlDbType.Int, 2).Value = 19;

                //-->>>>    Con el   .Value ##
                //--> Observa que estamos utilizando una sobrecarga del método Add() de la colección Parameters 
                //    que nos permite indicar el tamaño del valor a introducir en la base de datos. 
                //    En este caso, si el texto excede la longitud  indicada será truncado, 
                //    con objeto de evitar errores al almacenarlo.


                    int filasdeAlta = cmdInsert.ExecuteNonQuery();   //ExecuteNonQuery()  Ejecuta una orden sobre la base de datos, normalmente de actualización de datos,
                //                   retornando el número de filas afectadas,  o - 1    si hay algún error.

                 Console.WriteLine("Filas de alta : "  + filasdeAlta);

                //-->MODIFICACION ----------------------------------------------------------------------------------------------------------------

                //string sqlUpdate = @"Update Personas Set Nombre=@NuevoNombre  Where Nombre=@NombreAnterior";

                //SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);

                //cmdUpdate.Parameters.Add("@NuevoNombre", System.Data.SqlDbType.NVarChar, 25).Value = "Rafaelico";
                //cmdUpdate.Parameters.Add("@NombreAnterior", System.Data.SqlDbType.NVarChar).Value = "Rafael";

                
                //int filasModificadas = cmdUpdate.ExecuteNonQuery();   //ExecuteNonQuery()  Ejecuta una orden sobre la base de datos, normalmente de actualización de datos,
                //                                                      //                   retornando el número de filas afectadas,  o - 1    si hay algún error.

                //Console.WriteLine("Filas modificadas : " + filasModificadas);


                //-->BAJA  ELIMINACION -----------------------------------------------------------------------------------------------------

                //string sqlDelete = @"Delete from Personas Where Nombre=@Nombre";

                //SqlCommand cmdDelete = new SqlCommand(sqlDelete, con);
                //cmdDelete.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = "Rafaelico";                
                //int filasEliminadas = cmdUpdate.ExecuteNonQuery();   //ExecuteNonQuery()  Ejecuta una orden sobre la base de datos, normalmente de actualización de datos,
                //                                                      //                   retornando el número de filas afectadas,  o - 1    si hay algún error.

                //Console.WriteLine("Filas Eliminadas : " + filasEliminadas);


                // Operaciones DDL
                //-----------------------------------------------------

                //Este mismo mecanismo se puede utilizar para enviar a la base de datos sentencias DDL(Data Definition Language), 
                //que permiten manipular la estructura de la base de datos: crear o eliminar tablas, campos, índices, etc.
                //
                // El siguiente código, escrito utilizando una sintaxis compacta, elimina la tabla "Pruebas" de la base de datos:

                //using (SqlConnection conn = new SqlConnection(cadenaConex))
                //{
                //    conn.Open();
                //    new SqlCommand("Drop Table Pruebas", conn).ExecuteNonQuery();
                //}





            }










            // Afortunadamente, disponemos de formas más ágiles de conseguir el mismo resultado 
            // en la mayoría de los casos. A continuación veremos varias:
            //-------------------------------------------------------------------------------------------------------------------------
            //string sql2 = @"Select IdUsuario, NombreReal From Usuarios  Where Username=@nombre and Password=@password";
            //SqlCommand cmd2 = new SqlCommand(sql2, con);

            ////-->Esta sobrecarga de Add() añade un parámetro a la colección y retorna una referencia hacia él...
            //cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = "jmaguilar";

            //// Otra forma, más compacta. El tipo del parámetro es inferido a partir del valor suministrado en el segundo parámetro:
            //cmd.Parameters.AddWithValue("@password", "miclave");

            //using (SqlDataReader reader = cmd.ExecuteReader())
            //{

            //}







            //---------------------------------------------------------------------------------------------------------------------------------------------
            //
            // Pool de conexiones,  ESTA CLARO QUE ESTO ES PARA AHORRAR TIEMPO Y MEJORAR RENDIMIENTO, PERO NO TENGO CLARA SU UTILIZACION
            // EN LA EJECUCION DE UNA APLICACION ...VOY A ESTAR ABRIENDO Y CERRANDO LA CONEXION CADA VEZ QUE QUIERA LEER O ESCRIBIR.... MENUDA MIERDA NO..
            //
            // NOTA : Esto me ha funcionado utilizando el SqlConnectionStringBuilder, pillando la cadena de conexion de la configuracion
            //        NO consigo añadirle los parametros del Pool 
            //----------------------------------------------------------------------------------------------------------------------------------------------


            //var builder = new SqlConnectionStringBuilder();

            //builder.DataSource = @"DESKTOP-TMO9LFM\SQLEXPRESS";
            //builder.InitialCatalog = "Datos";
            //builder.IntegratedSecurity = true;
            //builder.Pooling = true;   // No es necesario, por defecto está activado 
            //builder.MinPoolSize = 10; // Mínimo 10 conexiones abiertas en el pool 
            //builder.MaxPoolSize = 50; // Máximo 50 conexiones abiertas en el pool 


            ////Al utilizar el USING estoy instanciando directamente el objeto con la cadena de conexión que ya tengo pillada 
            //using (SqlConnection conPol = new SqlConnection(builder.ConnectionString))
            //{
            //    conPol.Open();
            //    Console.WriteLine("Hacer algo a continuación,  vamos a mirar en  Management  a ver la conexiones ");
            //    Console.ReadKey(); // Esperamos una tecla para salir

            //    //No hace fala el Close, como estamos utilizando el using  cuando salga de su anbito se cierra la conexion 
            //}

            //Console.WriteLine("AHORA LAS CONEXIONES DEBEN DE ESTAR CERRADAS ");

            //Console.ReadKey(); // Esperamos una tecla para salir


            /*   CODIGO PARA CONSULTAR DESDE EL MANAGEMENT LAS CONEXIONES ACTIVAS 

                    --PROCESO DE UN FULANO EN CONCRETO 
                        USE Datos;  
                        GO  
                        EXEC sp_who 'DESKTOP-TMO9LFM\tomas';  
                        GO 

                     --  TODOS LOS PROCESOS ACTIVOS 
                        USE Datos;  
                        GO  
                        EXEC sp_who 'active';  
                        GO 

                    --Mostrar un proceso específico identificado mediante un Id. de sesión
                        USE Datos;  
                        GO  
                        EXEC sp_who '10' --specifies the process_id;  
                        GO

             */






            //-----------------------------------------------------------------------------------------------------------------------------------
            //
            // Conexiones seguras contra SQL Server
            //
            //-----------------------------------------------------------------------------------------------------------------------------------

            //  TECNICAS SNIFFING
            //  Si la información es especialmente sensible y las redes por las que pasa son públicas o fácilmente accesibles por terceros,
            //  esto podría llegar a ser un problema grave de seguridad.

            //  Un SNIFFER es un programa informático que registra la información que envían los periféricos, 
            //  así como la actividad realizada en un determinado ordenador. 



            //string cadenaConexion = @"Data source=(local);
            //                         Initial catalog=Almacen; 
            //                         Encrypt=True;
            //                         Integrated Security=SSPI;";

            //SqlConnection conexionX = new SqlConnection(cadenaConexion);


            // La activación de SSL requiere instalar un certificado digital en el servidor, 
            // así como configurar los servicios de comunicaciones. 
            // Ambos temas quedan fuera del alcance de este curso.

            // SQL Server permite la realización de conexiones bajo el protocolo SSL(Secure Sockets Layer), 
            // el cual crea un canal seguro entre cliente y servidor, protegiendo la información de posibles observadores.


            // -> Desde el punto de vista del cliente, para establecer una comunicación segura con el servidor, 
            //    es necesario establecer la propiedad Encrypt de la cadena de conexión al valor True:

            //              string cadenaConexion = @"Data source=(local);
            //                                        Initial catalog=Almacen; 
            //                                        Encrypt=True;
            //                                        Integrated Security=SSPI;";
            //                                        SqlConnection conexion = new SqlConnection(cadenaConexion);


            // Si quisiéramos ignorar la comprobación de confianza del certificado del servidor, 
            // podemos añadir a la cadena de conexión la siguiente asignación:
            //-----------------------------------------------------------------------------------
            //  TrustServerCertificate = true;




            //-------------------------------------------------------------------------------------------------------------------
            //
            //-->Ahora vemos los GENERADORES DE CADENAS DE CONEXION -------------------------------------------------------------
            //
            //   Cada proveedor implementa su generador de cadenas
            //
            //   ESTA ES LA GRACIA-VENTAJA .....:  Crea propiedades que ofrecen acceso directo a los parámetros de conexión disponibles. 
            //                                     y no a otras poropiedades que nosotros creemos que existen pero puede no contemple
            //                                     el proveedor en cuestión.
            //   Esto nos da seguridad a la hora de crear la cadenas y elimina posibles errores 
            //
            //   Evita la vulnerabilidad, conocida como "Connection String Inyection"  
            //
            //=============================================================================================================
            //        PROVEEDOR                                           GENERADOR DE CADENAS DE CONEXION 
            //-------------------------------------------------------------------------------------------------------------
            //System.Data.SqlClient                              System.Data.SqlClient.SqlConnectionStringBuilder
            //System.Data.Odbc                                   System.Data.Odbc.OdbcConnectionStringBuilder
            //System.Data.OleDb                                  System.Data.OleDb.OleDbConnectionStringBuilder
            //System.Data.OracleClient                           System.Data.OracleClient.OracleConnectionStringBuilder
            //=============================================================================================================

            //      var builder = new SqlConnectionStringBuilder();

            //      builder.DataSource = "(local)";
            //      builder.InitialCatalog = "Almacen";
            //      builder.IntegratedSecurity = true;

            //      Console.WriteLine(builder.ConnectionString);
            //      Console.ReadKey();

            //       Muestra por consola:
            //       Data Source=(local);Initial Catalog=Almacen;Integrated Security=True 

            //-->> Ejemplo de un MIX con la cadena de conexión que tengamos definida y le añadimos el año al InitialCatalog
            //-------------------------------------------------------------------------------------------------------------

            //ConnectionStringSettings conns = ConfigurationManager.ConnectionStrings["Conexion"];

            //var builder = new SqlConnectionStringBuilder(conns.ConnectionString);

            //builder.InitialCatalog = "Almacen" + DateTime.Now.Year;

            //Console.WriteLine(builder.ConnectionString);
            //Console.ReadKey();

            // Muestra por consola:
            // Data Source=(local);Initial Catalog=Almacen2010;Integrated Security=True 




            //------------------------------------------------------------------------------------------------------------------------------
            //
            //  ENCRIPTACION DE LAS CADENAS DE CONEXION     **SEGURIDAD**
            //
            //  OjO  para probar esto hay que lanzar el EXE desde fuera de Visual Studio, desde dentro no parece que haga nada...
            //  RUTA  :   c:\aa_CAMPUS  MVP\curso de ACCESO A DATOS\PRACTICAS\MIAS\TomaContacto\TomaContacto\bin\Debug\
            //------------------------------------------------------------------------------------------------------------------------------



            //SqlConnection con = new SqlConnection();  //Instanciamos objeto de la clase SqlConnection


            ////-->Instanciamos un objeto de la clase Configuration para pillar el archivo de configuración...
            //Configuration conf =  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ////-->Encriptamos la sección con el proveedor de protección indicado...
            //conf.ConnectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            ////--> Y salvamos el cambio que hemos hecho en el archivo de configuración
            //conf.Save();

            ////->Ahora vamos a preguntar primero si la sección  ConectionStrings  del fichero de configuracion está protegida o no
            //if( !conf.ConnectionStrings.SectionInformation.IsProtected)
            //{
            //    //->Si fuera que no, entonces vamos a encriptar la sección, vamos a a pasarle el proveedor para encriptar 
            //    //  en este caso    DataProtectionConfigurationProvider
            //    conf.ConnectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");                                                     

            //    //--> Y salvamos el cambio que hemos hecho en el archivo de configuración
            //    conf.Save();
            //}

            ////->Pillamos la cadena de conexión en un objeto  ConnectionStringSettings
            //ConnectionStringSettings concon =  ConfigurationManager.ConnectionStrings["TomaContacto.Properties.Settings.Conexion"];

            ////-> Indicamos la cadena de conexión capturada en concon al objeto SqlConnection 
            //con.ConnectionString = concon.ConnectionString;

            ////-> Abrimos 
            //con.Open();

            //Console.WriteLine("Estado de la conexión: " + con.State);
            //Console.WriteLine("Cadena de conexión : " + con.ConnectionString);

            //con.Close();





            //------------------------------------------------------------------------------------------------------------------------------
            //
            // ABRIR  CON    ConfigurationManager()    hay que añadir -si no la tenemos- una referencia el System.Configuration y el using
            //
            // Esta opción es la buena para abstraerse de tipo de BB.DD a utilizar  ya que accede al nombre del ProviderName
            //
            // Otra cosa buena que tiene es que descrifra automáticamente la información del fichero App.config si se hubiera 
            // encriptado para proteger información confidencial
            //
            //------------------------------------------------------------------------------------------------------------------------------

            //->  Este chorizo  "Properties.Settings.Default.Conexion"     es lo que pone en el  fichero App.config 
            //->  La clase  ConnectionStringSettings tiene acceso a las distintas cadenas de conexión que tengamos 

            //SqlConnection con = new SqlConnection();  //Instanciamos objeto de la clase SqlConnection

            //ConnectionStringSettings concon =  ConfigurationManager.ConnectionStrings["TomaContacto.Properties.Settings.Conexion"];

            //con.ConnectionString = concon.ConnectionString;

            //con.Open();

            //Console.WriteLine("Estado de la conexión: " + con.State);

            //con.Close();

            //------------------------------------------------------------------------------------------------------------------
            //
            // PILLAR LA CADENA DE CONEXION QUE TENGO DEFINIDA EN LOS PROPERTIES 
            //
            //----------------------------------------------------------------------------------------------------------------------

            //SqlConnection con = new SqlConnection();

            ////-->La cadena de conexión esta aquí :  Pillar la cadena de conexion desde los settings de la aplicacion :
            ////   Properties.Settings.Default.Conexion;

            ////->Indicamos el valor de la cadena "Conexion" que cree en las Properties 
            //con.ConnectionString =  Properties.Settings.Default.Conexion;

            //con.Open();

            //Console.WriteLine("Estado de la conexión: " + con.State);

            //con.Close();



            //-----------------------------------------------------------------------------------------------------------------------
            //--->>>>>>  EJEMPLO PARA CONEXION CON  SQL INDICADO EN EL VIDEO  instanciando un objeto de la clase SqlConnection()
            //
            //    SQL Server 
            //    Provider :   SqlClient
            //------------------------------------------------------------------------------------------------------------------------



            //SqlConnection con = new SqlConnection();

            ////--> Este usuario no existe, paso de darlo de alta 
            ////con.ConnectionString = @"Data source=DESKTOP-TMO9LFM\SQLEXPRESS; Initial Catalog=Datos; User Id=usuario; Password=clave;";            

            //con.ConnectionString =  @"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;
            //                          Integrated Security=True;
            //                          Database=Datos; 
            //                          Connect Timeout=15;
            //                          Encrypt=False;
            //                          TrustServerCertificate=True;
            //                          ApplicationIntent=ReadWrite;
            //                          MultiSubnetFailover=False";

            //con.Open();

            //Console.WriteLine("Estado de la conexión: " + con.State);

            //con.Close();

            //-----------------------------------------------------------------------------------------------------------------------------
            //--->>>>>>  EJEMPLO PARA CONEXION CON  MySQL INDICADO EN EL VIDEO  instanciando un objeto de la clase SqlConnection()
            //
            //    MySQL 
            //    Provider :   MySqlClient
            //------------------------------------------------------------------------------------------------------------------------

            /*
             LO PRIMERO : si no lo tenemos, ir a pillar las Referencias del proveedor en cuestión para poder utilizar sus clases 
                          SITUARSE en  Referencias  y añadir referencia,  lo hice  via  NUGet 
             SEGUNDO :  Indicar arriba el    using              


             Instanciariamos el objeto de MySql 
             -------------------------------------------------------
             MySqlConnection  cono = new MySqlConnection();

             Indicamos la cadena de conexión 
             ----------------------------------------------------------
             cono.ConnectionString = @"Data source=DESKTOP-TMO9LFM\SQLEXPRESS; Initial Catalog=TEST; User Id=usuario; Password=clave;";
             con.Open();

             Console.WriteLine("Estado de la conexión: " + con.State);

             con.Close();

            */





            //--------------------------------------------------------------------------------------------------------------------------------
            //----- UTILIZANDO   TRY CATCH       EJMEPLO MUY BUENO DONDE VEMOS COMO CAPTURAR VARIOS TIPOS DE ERRORES QUE SE PUDIERAN PRODUCIR
            //--------------------------------------------------------------------------------------------------------------------------------
            //// Preparamos el objeto Connection            
            //string cadenaConexion = @"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;
            //                          Integrated Security=True;
            //                          Database=Datos; 
            //                          Connect Timeout=15;
            //                          Encrypt=False;
            //                          TrustServerCertificate=True;
            //                          ApplicationIntent=ReadWrite;
            //                          MultiSubnetFailover=False";


            //try
            //{

            //    //--> Un patrón muy recomendable y que suele utilizarse muy habitualmente es la inclusión de las conexiones en bloques using, 
            //    //    asegurando la liberación de recursos al finalizar su ámbito, impidiendo que una conexión quede abierta un tiempo indeterminado 
            //    //    si no es cerrada de forma explícita o se lanza alguna excepción en el código que hace que el flujo de ejecución 
            //    //    nunca llegue a las instrucciones de cierre.
            //    //
            //    //    Al salir del ámbito del bloque using,  el objeto conexion ya no estará disponible.
            //    //    El framework.NET se habrá encargado de liberar los recursos utilizados llamando a su método Dispose(), cerrando automáticamente la conexión.
            //    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            //    {
            //        conexion.Open();
            //        Console.WriteLine("Estado de la conexión: " + conexion.State);  //Open


            //        Console.WriteLine("Servidor: " + conexion.DataSource);  //  DESKTOP - TMO9LFM\SQLEXPRESS
            //        Console.WriteLine("Database: " + conexion.Database);    // Datos
            //        Console.WriteLine("Server: " + conexion.ServerVersion); //11.00.2218

            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine("Operación inválida: " + ex.Message);
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error en conexión: " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error indeterminado: " + ex.Message);
            //}

            Console.ReadKey();




            



        }
    }
}

/*

---------------------------------------------------------------------------------
Las propiedades de uso habitual en los objetos DbConnection son las siguientes:
--------------------------------------------------------------------------------

ConnectionString : que permite obtener o establecer la cadena de conexión utilizada por el objeto.
                   Como es obvio, sólo será posible modificar la propiedad cuando la conexión esté cerrada.

ConnectionTimeOut : que permite obtener el tiempo máximo, en segundos, que se esperará al intentar establecer una conexión 
                    antes de lanzar un error. Este valor normalmente se establece en la cadena de conexión.

Database :  que cuando el objeto Connection representa a una conexión abierta retorna el nombre de la base de datos 
            sobre la que se está trabajando, o la indicada en la cadena de conexión en su defecto.

DataSource : retorna el servidor contra el que va a realizarse la conexión, 
             tal y como se indica en la propiedad "Data Source" de la cadena de conexión.

             Indica el servidor donde se encuentran los datos. 
             Habitualmente será el nombre de red del servidor (por ejemplo, "SERVIDOR-SQL"), 
             su dirección IP (como puede ser 192.168.1.23), 
             o el texto "(local)" 
             o un punto ".", para indicar la máquina local.
             Es posible indicar una instancia concreta del motor identificándola tras el servidor, separándolos por una barra invertida:

ServerVersion :  permite obtener información sobre la versión del servidor de bases de datos utilizado.

State :  que ya hemos usado en un ejemplo anterior, permite conocer el estado de una conexión.
         Los valores posibles son los miembros de la enumeración System.Data.ConnectionState, 
         aunque sólo los dos primeros estados son utilizados en la versión actual del producto: 

         - ConnectionState.Open       : la conexión está abierta
         - ConnectionState.Closed     : la conexión está cerrada.
         - ConnectionState.Broken     : se ha perdido la conexión, previamente abierta, con la base de datos.
         - ConnectionState.Connecting : se está intentando establecer la conexión con el origen de datos.
         - ConnectionState.Executing  : se está ejecutando un comando.
         - ConnectionState.Fetching   : el objeto está obteniendo datos.

Integrated Security o Trusted_Connection

        Indica si se utilizará el método de seguridad integrada, también llamado conexiones de confianza, 
        para acceder a la base de datos. 
        Este modelo de seguridad permite el acceso a bases de datos utilizando las credenciales del usuario asociado al proceso.
        Para activarla, basta con asignar a este parámetro el valor SSPI, 
        aunque puede utilizarse también True o Yes; 
        si no se desea utilizar este modelo de seguridad deberán 
        especificarse obligatoriamente valores para Password e User ID.

------------------------------------------------------------------
 Principales métodos
------------------------------------------------------------------
Los principales métodos expuestos por la clase DbConnection, y por tanto por todas las clases que heredan de ésta son los siguientes:

Open() y Close()   : indican el inicio y fin de la conexión.

BeginTransaction() :  permite iniciar una transacción y, a través del objeto DbTransaction devuelto, 
                      controlar cuándo se comprometen o cuando se deshacen los cambios. 
                     
ChangeDatabase() :   que modifica la base de datos sobre la que se opera sin necesidad de cerrar la conexión con el servidor.

CreateCommand()  :   retorna un objeto Command específico del Data Provider, 
                     preparado para enviar órdenes de consulta o actualización a la base de datos.

GetSchema()      :  puede utilizarse para obtener información del esquema del origen de datos.

--->>Puedes encontrar la lista completa con sus signaturas y descripciones completas, como es habitual, en MSDN.

-------------------------------------------
Extensiones de los Data Providers
-------------------------------------------

SqlConnection hereda de DbConnectionComo sabemos, cada proveedor de ADO.NET extiende, 
entre otras, la clase DbConnection, implementando el proceso de conexión específico de la fuente de datos.

Pero además, estas clases incluyen nuevos miembros (métodos y propiedades), 
diseñadas para explotar características y capacidades específicas del origen de datos.

Así, por ejemplo, la clase SqlConnection dispone de la propiedad StatisticsEnabled, 
que permite activar y desactivar la recolección de datos estadísticos sobre la conexión, 
que pueden ser obtenidas y reseteadas a través de los respectivos 
métodos RetrieveStatistics() y ResetStatistics(), también exclusivos de esta clase.

De la misma forma, la clase OdbcConnection dispone de la propiedad Driver, 
que permite consultar el nombre del controlador que está siendo usado, 
exclusiva de las conexiones realizadas a través de ODBC.


Como cada Data Provider de ADO.NET puede añadir funcionalidades a los objetos base 
para tener acceso a características específicas del motor de datos subyacente, 
es conveniente consultar el manual del fabricante para sacarles mayor provecho.







    using System.Configuration;
    using System.Data.SqlClient;
[...]

  // Accedemos a los datos de la conexión con nombre 'Conexion'
  // en el archivo .config...
  
   ConnectionStringSettings datosConexion =  ConfigurationManager.ConnectionStrings["Conexion"];

  // Y ahora, a sus propiedades...
  string connectionString = datosConexion.ConnectionString;
  string dataProvider =     datosConexion.ProviderName; 

  SqlConnection conn = new SqlConnection(connectionString);
  conn.Open();
    

*/





