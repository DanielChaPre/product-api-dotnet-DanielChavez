Pasos para levantar el entorno


  1.- Lo primero se tiene que crear una base de datos en sql server con el nombre 'PruebaApi'.
  
  2.- Al tener creada la base de datos, se copiara el siguiente script y se pegara para poderlo ejecutar, este script servira para poder crear la tabla de productos
    y algunos registros para realizar pruebas

    CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Stock] [int] NOT NULL,
	[Activo] [int] NOT NULL,
  CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
  (
  	[Id] ASC
  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
  ) ON [PRIMARY]

  INSERT [dbo].[Product] ([Id], [Nombre], [Precio], [Stock], [Activo]) VALUES (1, N'lapis 23', CAST(12 AS Decimal(18, 0)), 55, 0)
  INSERT [dbo].[Product] ([Id], [Nombre], [Precio], [Stock], [Activo]) VALUES (2, N'Laptop', CAST(12352 AS Decimal(18, 0)), 10, 1)

  3.- Despues de haber ejecutado el script, ahora toca descargar el proyecto de github.

  4.- Cuando ya se tenga descargado el proyecto y abierto en visual studio, se tendra que modificar el archivo 'appsetting.json', se modificara la cadena de coneccion a la base de datos 
  para esto se cambiara el nombre de server por el nombre del servidor que se tiene en sql server, ademas de que se cambiaran tanto el usuario como la contraseñan que se tengan para el acceso,
  para saber cual es el nombre del servidor que se tiene, se ingresara a sql server(SSMS) y en la intancia se dara clic derecho, propiedades y en el apartado de generales hay una opcion 
  de nombre, lo que venga en ese renglon se colocara en la cadena de coneccion.

  <img width="525" alt="1" src="https://github.com/user-attachments/assets/28d476f8-15e1-4bb3-afc6-17925b06bd94" />

  5.- Despues de haber modificado la cadena de coneccion al momento de ejecutar revisar que en las opciones de compilacion colocar ya sea explorador web o IIS para ejecutar en modo local
  <img width="230" alt="1 5" src="https://github.com/user-attachments/assets/818744bf-a1dc-4e1c-ba55-096cd1a847d3" />

  si se tiene todo bien se ejecutara sin problemas y le tiene que aparecer algo asi
  <img width="957" alt="2" src="https://github.com/user-attachments/assets/7129b476-c954-4b72-98d0-2576a591166a" />

  Para levantar y ejecutar los contenedores.

  Para poder levantar y ejecutar los contenedores, solo hay que revisar en el archivo DockerFil, en la variable 'DB_CONNECTION_STRING', este apuntando correctamente a un servidor de pruebas donde ya se encuentra 
  alojado la base de datos, despues antes de ejecutar revisar que opciones de ejecucion sean los siguientes.
  <img width="203" alt="3" src="https://github.com/user-attachments/assets/a059e2cf-b48d-4773-912c-66c2c119bd21" />

  Al tener esa configuracion ya se puede ejecutar sin problema el proyecto y tendria que abrirle y poder hacer uso del api y de sus metodos.


  ************** COMANDOS DE PRUEBA PARA LOS ENDPOINTS *****************

  - GETs
    - https://localhost:5001/api/Product/products
    - https://localhost:5001/api/Product/products/1
  - POST
    - https://localhost:5001/api/Product/products
      
      {
        "id": 0,
        "nombre": "string",
        "precio": 0,
        "stock": 0,
        "activo": true
      }

  - PUTs
    - https://localhost:5001/api/Product/products/1
      
      {
        "id": 0,
        "nombre": "string",
        "precio": 0,
        "stock": 0,
        "activo": true
      }
      
    - https://localhost:5001/api/Product/products/activate/1
  - DELETE
    - https://localhost:5001/api/Product/products/1


   
************** HISTORIAL DE COMMITS *****************


<img width="489" alt="4" src="https://github.com/user-attachments/assets/8d46317a-cc0b-4a75-a33e-a8e27758b5e9" />



************** ENLACE A DEMO *****************


Para la parte del demo se subio tanto el api como la base de datos a un hostting el cual la url es el siguiente 

http://www.crudproducto.somee.com

Para su buen funcionamiento se recomienda usar ya sea Postman o Swagger para su ejecucion teniendo en cuenta los comandos de los endpoint que se proporcionaron arriba

Ejemplo

<img width="852" alt="5" src="https://github.com/user-attachments/assets/c4ad2eff-f308-47f4-a9af-87964c4fafa1" />


  



  
