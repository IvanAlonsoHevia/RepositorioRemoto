#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int registro (char username [20], char password [15], MYSQL *conn, int ID)
{
	char consulta[1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int found;
	
	sprintf (consulta, "SELECT * FROM (JUGADOR) WHERE JUGADOR.USERNAME = '%s';", username);
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de un jugador
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	if (row != NULL)
		found = 1;	
	
	else
	{	
		// Ahora construimos el string con el comando SQL
		// para insertar el usuario con su password y su identificador en la base. 
		// Ese string es: INSERT INTO JUGADOR VALUES ('ID', 'username', password);
		sprintf (consulta, "INSERT INTO JUGADOR VALUES (%d, '%s', '%s');", ID, username, password);
		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		found = 0;
		// Si hay alg˙n problema, nos mostrar· que hay un error la introducir los datos.
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}	
	}
	
	return found;  //nos dice si el jugador ya existe en el registro
		
}

int login (char username [20], char password [15], MYSQL *conn)
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [1000];
	sprintf (consulta, "SELECT * FROM (JUGADOR) WHERE JUGADOR.USERNAME = '%s' AND JUGADOR.PASSWD = '%s';", username, password);
	int found;
	int err;
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. Este nos devuelve un puntero en MYSQL_RES
	//con el cual vemos si el jugador con el username, pasword y ID, esta en la base de datos
	//o directamente no existe ese jugador. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row != NULL)
		found = 1;
	
	else
		found = 0;	
	
	return found; //nos dice si el usuario ha podido conectarse a la base de datos.
}

//Consulta1: Usernames de los jugadores que cumplen que el perdedor de la partida sea el nombre introducido por consola, que la posicion del jugador sea la dada por consola, 
//que la puntuaci√≥n del jugador sea m√°s peque√±a que la que da el usuario y que no sea el mismo usuario.
void consulta1 (char perdedor [20], int posicion, int puntuacion, MYSQL *conn, char sresultado [80])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	sprintf (consulta, "SELECT DISTINCT JUGADOR.USERNAME FROM (JUGADOR, PARTIDA, PARTICIPACION) WHERE PARTIDA.PERDEDOR = '%s' AND PARTIDA.ID = PARTICIPACION.ID_P  AND PARTICIPACION.POSICION = %d AND PARTICIPACION.PUNTUACION < %d AND PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME NOT IN ('%s')", perdedor, posicion, puntuacion, perdedor);
	//Utilizamos el sprintf para poder hacer una consulta sin tener que concatenar las diferentes restricciones.
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	
			if (cont!=0)
			{
				sprintf (sresultado, "%s %s", sresultado, row[0]);
			}
			else 
				sprintf (sresultado, "%s", row[0]);
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
	}
}

void consulta2 (char username [20], MYSQL *conn, char sresultado [80])
{
	//Consulta: Usernames de los jugadores que han quedado en primer lugar en alguna de las partidas en las que
	//el jugador introducido por el usuario ha jugado y en las que el numero de participantes >= 3
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	strcpy(consulta,"SELECT DISTINCT JUGADOR.USERNAME FROM (JUGADOR,PARTIDA,PARTICIPACION) WHERE JUGADOR.ID = PARTICIPACION.ID_J AND PARTICIPACION.ID_P = PARTIDA.ID ");
	strcat(consulta,"AND PARTICIPACION.ID_P IN(SELECT PARTICIPACION.ID_P FROM (PARTICIPACION,JUGADOR) WHERE PARTICIPACION.ID_J = JUGADOR.ID AND JUGADOR.USERNAME = '");
	strcat(consulta,username);
	strcat(consulta,"') AND PARTICIPACION.POSICION = 1 AND PARTIDA.NUM_JUGADORES >= 3;");
	//Concatenamos diferentes trozos de la consulta para as√≠ introducir los par√°metros
	//de forma que sea m√°s f√°cil de entender.
	//Buscamos que no haya ningun error al consultar los datos.
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//Recogemos el resultado de la consulta. 
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	
			if (cont!=0)
			{
				sprintf (sresultado, "%s %s", sresultado, row[0]);
			}
			else 
				{
				sprintf (sresultado, "%s", row[0]);
			}
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
	}
	
	
}

//Consulta3: IDs de partida en las que la puntuacion total de la partida sea mayor a una dada por consola,
//que se haya jugado en una fecha y hora determinada y que haya un minimo de jugadores indicado por consola.
void consulta3 (int minjug, int minpunt, char f_h [200], MYSQL *conn, char sresultado [80])
{
	char consulta [1000];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char minpunts[10];
	char minjugs[10];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "JUEGO",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// construimos la consulta SQL
	strcpy (consulta,"SELECT DISTINCT PARTIDA.ID FROM (PARTIDA, JUGADOR, PARTICIPACION) WHERE PARTIDA.FECHA_HORA = '");  
	strcat (consulta,f_h);
	strcat (consulta,"' ");
	strcat (consulta,"AND PARTIDA.NUM_JUGADORES >= "); 
	sprintf(minjugs,"%d ", minjug); 
	strcat (consulta, minjugs);
	strcat (consulta,"AND "); 
	sprintf(minpunts, "%d ", minpunt);
	strcat (consulta, minpunts);
	strcat (consulta,"< ( SELECT SUM(PARTICIPACION.PUNTUACION) FROM (PARTIDA, PARTICIPACION) WHERE PARTIDA.FECHA_HORA = '");
	strcat (consulta,f_h);
	strcat (consulta,"' ");
	strcat (consulta, "AND PARTIDA.ID = PARTICIPACION.ID_P) ");
	strcat (consulta,"AND PARTICIPACION.ID_P = PARTIDA.ID;");
	//Combinamos tanto el sprintf para meter las variables numericas dentro de la consulta como strings,
	//y tambien el strcat para concatenar las diferentes consultas a realizar en SQL.
	// hacemos la consulta  
	err = mysql_query (conn, consulta); 
	//Buscamos que no haya ningun error al consultar los datos.
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		int cont=0;
		while (row !=NULL) 
		{
			//Si todo es correcto, el resultado de la consulta sera el siguiente:	
			if (cont!=0)
			{
				sprintf (sresultado, "%s %s", sresultado, row[0]);
			}
			else 
				sprintf (sresultado, "%s", row[0]);
			cont = cont+1;
			row = mysql_fetch_row (resultado);
		}
	}		
		
}

int main(int argc, char *argv[]){
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];  //mensaje que recibimos del cliente a traves del socket
	char respuesta[512]; //mensaje que se envia al cliente a travÈs del socket
	
	// INICIALIZACIONESDB
	MYSQL *conn;

	char username[20];
	char perdedor[20];
	char password [15];
	int ID = 4;
	int posicion;
	int puntuacion;
	int found; //nos indica si el jugador que quiere registrarse ya esta registrado
	int minjug;
	int minpunt;
	char f_h[200];
	

	char sresultado [100];  //string donde guarda el resultado de la consulta
	//Creamos una conexion al servidor MYSQL.
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Se inicializa la conexion.
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "JUEGO",0, NULL, 0);
	
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Hacemos el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9050);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	//Si hubiese algun fallo en el momento de realizar la conexion con el servidor, nos lo notificara.
	
	
	int i;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		int terminar = 0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			printf ("Peticion: %s\n",peticion);
			
			// vamos a ver que quieren
			char *p = strtok(peticion, "/");
			int codigo =  atoi (p);
			// Ya tenemos el c?digo de la petici?n
			//Dependiendo del valor numerico del codigo, se asociara a una consulta u otra.
			
			if (codigo ==0) //peticiOn de desconexiOn
				terminar = 1;
			
			else if (codigo == 1) //piden hacer un registro
			{		
				p = strtok( NULL, "/");
				strcpy (perdedor, p);
				p = strtok( NULL, "/");
				strcpy (password, p);
				found = registro(perdedor, password, conn, ID);
				
				if (found ==0) {
					sprintf (respuesta, "SI");
					ID = ID+1;
				} 
				else 
					sprintf(respuesta, "NO");
				
			}
			
			else if (codigo == 2)
			{
				// El usuario introducir· sus datos y veremos 
				// si puede entrar o no a realizar las consultas
				// si ese usuario est· registrado con esa contraseÒa.
				p = strtok( NULL, "/");
				strcpy (username, p);
				p = strtok( NULL, "/");
				strcpy (password, p);
				found = login(username, password, conn);
				if (found == 0) {
					sprintf (respuesta, "NO");
				} 
				else 
				{
					sprintf(respuesta, "SI");
				}
			}
				
			else if (codigo == 3) //consulta1
			{
				p = strtok( NULL, "/");
				strcpy (username, p);
				p = strtok( NULL, "/");
				posicion =  atoi (p);
				p = strtok( NULL, "/");
				puntuacion =  atoi (p);
				consulta1 (username, posicion, puntuacion, conn, sresultado);
				strcpy (respuesta, sresultado);
			}
			
			else if (codigo == 4) //consulta2
			{
				p = strtok( NULL, "/");
				strcpy (username, p);
				consulta2 (username, conn, sresultado);
				strcpy (respuesta, sresultado);
			}
			
			else if (codigo == 5) //consulta3
			{
				p = strtok( NULL, "/");
				minjug = atoi(p);
				p = strtok( NULL, "/");
				minpunt = atoi(p);
				p = strtok( NULL, "/");
				strcpy (f_h, p);
				
				consulta3 (minjug, minpunt, f_h, conn, sresultado);
				strcpy (respuesta, sresultado);
			}
				
			if (codigo !=0)
			{
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		
		//Cerrar la conexiÛn con el servidor SQL
		mysql_close (conn);
		exit(0);
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
}

