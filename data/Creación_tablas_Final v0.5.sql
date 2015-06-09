USE [GD1C2015]
GO

-------------------------------------------------------
				-- Creación de Esquema --
-------------------------------------------------------
create schema [DBA_GD]
go
-------------------------------------------------------
				-- Creacion de tablas ---
-------------------------------------------------------

CREATE TABLE [DBA_GD].TIPO_DOCUMENTO(
	Tipo_Documento_ID numeric(18,0) NOT NULL primary key,
	Tipo_Documento_Desc varchar(10)
	);
	
CREATE TABLE [DBA_GD].PAIS(
	Pais_ID numeric(18,0) identity(1,1) primary key,
	Pais_Codigo numeric(18,0),
	Pais_Desc varchar(250),
	--Pais_Nacionalidad varchar(250),
	--Se quita Nacionalidad y se agrega al usuario ya que puede tener documento de un pais
	--pero tener otra nacionalidad
	
	CONSTRAINT UC_Pais_Codigo UNIQUE(Pais_Codigo) 
	);	
	
CREATE TABLE [DBA_GD].USUARIO(
	Usuario_ID numeric(18,0) identity(1,1) primary key,
	Usuario_Username varchar(255),
	Usuario_Password varbinary(128),
	Usuario_Fecha_Creacion datetime,
	Usuario_Fecha_Ultima_Modif datetime,
	Usuario_Pregunta_Secreta varchar(60),
	Usuario_Respuesta_secreta varbinary(60),
	Usuario_Estado char(1),
	Usuario_Cant_Intentos tinyint,
	CONSTRAINT UC_Usuario_Username UNIQUE(Usuario_Username) 
	); 	

CREATE TABLE [DBA_GD].AUDITORIA_LOG(
	Log_ID numeric(18,0) identity(1,1) primary key,
	Log_Usuario numeric(18,0) foreign key references [DBA_GD].USUARIO,
	Log_Fecha_Hora datetime,
	Log_Tipo varchar(50),
	Log_Cant_Intentos tinyint
	);

CREATE TABLE [DBA_GD].TIPO_CUENTA(
	Tipo_Cuenta_ID numeric(18,0) identity(1,1) primary key,
	Tipo_Cuenta_Descr varchar(255),
	Tipo_Cuenta_Costo int
	);

CREATE TABLE [DBA_GD].BANCO(
	Banco_ID  numeric(18,0) identity(1,1) primary key,
	Banco_Codigo numeric(18,0),
	Banco_Nombre varchar(255),
	Banco_Direccion varchar(255),
	CONSTRAINT UC_Banco_Codigo UNIQUE(Banco_Codigo) 
	);

CREATE TABLE [DBA_GD].CLIENTE(
	Cliente_ID numeric(18,0) identity(1,1) primary key,
	Cliente_Pais_Codigo numeric(18,0) foreign key references [DBA_GD].PAIS(Pais_Codigo),
	Cliente_Nacionalidad varchar(250),
	Cliente_Nombre varchar(255),
	Cliente_Apellido varchar(255),
	Cliente_Tipo_Doc_Cod numeric(18,0) foreign key references [DBA_GD].TIPO_DOCUMENTO,
	Cliente_Nro_Doc numeric(18,0), 
	Cliente_Tipo_Doc_Desc varchar(255),
	Cliente_Dom_Calle varchar(255),
	Cliente_Dom_Nro numeric(18,0),
	Cliente_Dom_piso numeric(18,0),
	Cliente_Dom_Depto varchar(2),
	Cliente_Fecha_Nac datetime,
	Cliente_Mail varchar(255),
	Cliente_Usuario numeric(18,0)foreign key references [DBA_GD].USUARIO,
	);	
		
CREATE TABLE [DBA_GD].MONEDA(
	Moneda_ID numeric(18,0) identity primary key,
	Moneda_Tipo varchar(10)
	);
	
CREATE TABLE [DBA_GD].CUENTA(
	Cuenta_ID numeric(18,0) identity(1,1) primary key,
	Cuenta_Numero numeric(18,0),
	Cuenta_Fecha_Creacion datetime,
	Cuenta_Pais_Codigo numeric(18,0) foreign key references [DBA_GD].PAIS,
	Cuenta_Fecha_Cierre datetime,
	Cuenta_tipo numeric(18,0) foreign key references [DBA_GD].TIPO_CUENTA,
	Cuenta_Cliente_ID numeric(18,0) foreign key references [DBA_GD].CLIENTE,
	Cuenta_Moneda numeric(18,0) foreign key references [DBA_GD].MONEDA,
	Cuenta_Estado char(40),
	CONSTRAINT UC_Cuenta_Numero UNIQUE(Cuenta_Numero) 
	);
		
CREATE TABLE [DBA_GD].CHEQUE(
	Cheque_ID  numeric(18,0) identity(1,1) primary key,
	Cheque_Numero numeric(18,0),
	Cheque_Fecha datetime,
	Cheque_Moneda numeric(18,0) foreign key references [DBA_GD].MONEDA,
	Cheque_Importe numeric(18,2),
	Cheque_Nombre varchar(255),
	Cheque_Banco numeric(18,0) foreign key references [DBA_GD].BANCO
	);
		
CREATE TABLE [DBA_GD].TARJETA(
	Tarjeta_ID numeric(18,0) identity(1,1) primary key,
	Tarjeta_Numero varchar(16),
	Tarjeta_Numero_Encriptada varchar(20),
	Tarjeta_fecha_Emision datetime,
	Tarjeta_Fecha_Vencimiento datetime,
	Tarjeta_Codigo_Seg varchar(40),
	Tarjeta_Emisor_Descripcion varchar(255),
	Tarjeta_Cliente_ID numeric(18,0) foreign key references [DBA_GD].CLIENTE,
	);
	
CREATE TABLE [DBA_GD].DEPOSITO(
	Deposito_ID numeric(18,0) identity(1,1) primary key,
	Deposito_Codigo numeric(18,0),
	Deposito_Fecha datetime,
	Deposito_Moneda numeric(18,0) foreign key references [DBA_GD].MONEDA,
	Deposito_Importe numeric(18,2),
	Deposito_Nro_Tarjeta_cli numeric(18,0) foreign key references [DBA_GD].TARJETA,
	Deposito_Cuenta_Numero numeric(18,0) foreign key references [DBA_GD].CUENTA,
	CONSTRAINT UC_Deposito_Codigo UNIQUE(Deposito_Codigo) 
	);
	
CREATE TABLE [DBA_GD].RETIRO(
	Retiro_ID numeric(18,0) identity(1,1) primary key,
	Retiro_Fecha datetime,
	Retiro_Moneda numeric(18,0) foreign key references [DBA_GD].MONEDA,
	Retiro_Importe numeric(18,2),
	Retiro_Cuenta_Numero numeric(18,0) foreign key references [DBA_GD].CUENTA,
	Retiro_Codigo_Egreso numeric(18,0),
	Retiro_Nro_Cheque numeric(18,0) foreign key references [DBA_GD].CHEQUE,
	CONSTRAINT UC_Retiro_codigo UNIQUE(Retiro_codigo_Egreso) 
	);
	
CREATE TABLE [DBA_GD].TRANSFERENCIA(
	Transferencia_ID numeric(18,0) identity(1,1) primary key,
	Transferencia_Fecha datetime,
	Transferencia_Moneda numeric(18,0) foreign key references [DBA_GD].MONEDA,
	Transferencia_Importe numeric(18,2),
	Transferencia_Costo_Trans numeric(18,2),
	Transferencia_Cuenta_Origen numeric(18,0) foreign key references [DBA_GD].CUENTA,
	Transferencia_Cuenta_Dst numeric(18,0) foreign key references [DBA_GD].CUENTA
	);

	
CREATE TABLE [DBA_GD].ROL(
	Rol_ID numeric(18,0) identity(1,1) primary key,
	Rol_Nombre varchar(50),
	Rol_Estado varchar(15),
	);
	
CREATE TABLE [DBA_GD].FUNCIONALIDAD(
	Funcionalidad_ID numeric(18,0) identity(1,1) primary key,
	Funcionalidad_Nombre varchar(100)
	);
		
CREATE TABLE [DBA_GD].FACTURA(
	Factura_Numero numeric(18,0) primary key,
	Factura_Fecha datetime,
	Factura_Item_Desc varchar(255),
	Factura_Item_Importe numeric(18,2),
	Factura_Nro_Cliente numeric(18,0) foreign key references [DBA_GD].CLIENTE
	);
	
CREATE TABLE [DBA_GD].ITEM_FACTURA(
	Item_Factura_ID numeric(18,0) identity(1,1) primary key,
	Item_Factura_Descripcion varchar(100),
	Item_Factura_Importe numeric(18,2),
	Item_Factura_ID_Factura numeric(18,0) foreign key references [DBA_GD].FACTURA
	);

	-----------------TABLAS DE RELACION-----------------------------------

CREATE TABLE [DBA_GD].ROL_FUNCIONALIDAD(
	Rol_Funcionalidad_Rol_ID numeric(18,0) not NULL foreign key references [DBA_GD].ROL,
	Rol_Funcionalidad_Funcionalidad_ID numeric(18,0) not NULL foreign key references [DBA_GD].Funcionalidad
	constraint Rol_Funcionalidad_ID primary key(Rol_Funcionalidad_Rol_ID,Rol_Funcionalidad_Funcionalidad_ID)
	);
	
	
CREATE TABLE [DBA_GD].USUARIO_ROL(
	Usuario_Rol_Usuario_ID numeric(18,0) not NULL foreign key references [DBA_GD].USUARIO,
	Usuario_Rol_Rol_ID numeric(18,0) not NULL foreign key references [DBA_GD].ROL
	constraint Cliente_Usuario_ID primary key(Usuario_Rol_Usuario_ID,Usuario_Rol_Rol_ID)
	);
	
	--------------------FIN TABLAS RELACIONALES-----------------------------


--VALORES POR DEFAULT
ALTER TABLE [DBA_GD].DEPOSITO ADD CONSTRAINT DF_Deposito_Fecha DEFAULT GETDATE() FOR [Deposito_Fecha]
GO
ALTER TABLE [DBA_GD].TRANSFERENCIA ADD CONSTRAINT DF_Transferencia_Fecha DEFAULT GETDATE() FOR [Transferencia_Fecha]
GO
ALTER TABLE [DBA_GD].RETIRO ADD CONSTRAINT DF_Retiro_Fecha DEFAULT GETDATE() FOR [Retiro_Fecha]
GO
				-------------------------------------------------------
						-- PROCESOS DE MIGRACION DE DATOS ---
				-------------------------------------------------------


--MIGRACION DATOS A TABLA BANCO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_BANCO
	as
	BEGIN
		INSERT INTO [DBA_GD].BANCO
		(Banco_Codigo,Banco_Nombre,Banco_direccion)
		
		SELECT distinct Banco_Cogido as CODIGO_BANCO, Banco_Nombre as NOMBRE, Banco_Direccion as DIRECCION
		FROM GD1C2015.gd_esquema.Maestra
		WHERE Banco_Cogido is not null 	
	END
go

--MIGRACION DATOS USUARIO--

CREATE PROCEDURE [DBA_GD].Migracion_USUARIO
	as
	BEGIN
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado,Usuario_Cant_Intentos)
		SELECT distinct SUBSTRING(Cli_Mail,0,patindex('%@%',Cli_Mail)),hashbytes('SHA1',CAST(Cli_Nro_Doc as varchar(200))),
		getdate(),getdate(),'¿Sabes como identificarte?',
		hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0
		
		FROM gd_esquema.Maestra	
	
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado,Usuario_Cant_Intentos)
		
		VALUES
		('Admin1',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0),
		('Admin2',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0),
		('Admin3',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0),	
	
		('nziella',hashbytes('SHA1',CAST(33204530 as varchar(10))),getdate(),getdate(),
		'¿Sabes como identificarte?',hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0),		
		('castrorodrigo355',hashbytes('SHA1',CAST(33204530 as varchar(10))),getdate(),getdate(),
		'¿Sabes como identificarte?',hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0),
		('juamma.cugat',hashbytes('SHA1',CAST(35493525 as varchar(10))),getdate(),getdate(),
		'¿Sabes como identificarte?',hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0),
		('tinchob',hashbytes('SHA1',CAST(33204530 as varchar(10))),getdate(),getdate(),
		'¿Sabes como identificarte?',hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0)
	END
go
	
--MIGRACION DATOS TABLA CLIENTE--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CLIENTE
	as
	BEGIN
		--Inicializo nacionalidad como null y no tiene que ser obligatorio
		-- Si no se inserta un valor, va como null por defecto
		INSERT INTO [DBA_GD].CLIENTE
		(Cliente_Pais_Codigo,--Cliente_Nacionalidad,
		Cliente_Nombre,Cliente_Apellido,
		Cliente_Tipo_Doc_Cod,Cliente_Nro_Doc,
		Cliente_Tipo_Doc_Desc,Cliente_Dom_Calle,
		Cliente_Dom_Nro,Cliente_Dom_Piso,Cliente_Dom_Depto,
		Cliente_Fecha_Nac,Cliente_Mail,Cliente_Usuario)
		
		SELECT distinct Cli_Pais_Codigo,--null,
		Cli_Nombre,Cli_Apellido,Cli_Tipo_Doc_Cod,Cli_Nro_Doc,Cli_Tipo_Doc_Desc,
		Cli_Dom_Calle,Cli_Dom_Nro,Cli_Dom_Piso,Cli_Dom_Depto,Cli_Fecha_Nac,Cli_Mail,
		(select Usuario_ID from DBA_GD.USUARIO where Usuario_username =
		 SUBSTRING(Cli_Mail,0,patindex('%@%',Cli_Mail)))
				
		FROM GD1C2015.gd_esquema.Maestra
	
		INSERT INTO [DBA_GD].CLIENTE
					(Cliente_Pais_Codigo,
					Cliente_Nombre,Cliente_Apellido,
					Cliente_Tipo_Doc_Cod,Cliente_Nro_Doc,
					Cliente_Tipo_Doc_Desc,Cliente_Dom_Calle,
					Cliente_Dom_Nro,Cliente_Dom_Piso,Cliente_Dom_Depto,
					Cliente_Fecha_Nac,Cliente_Mail,Cliente_Usuario)
		VALUES 
		(8,'Nicolas','Ziella',10002,33204530,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','nziella@hotmail.com.ar',
		(select Usuario_ID from DBA_GD.USUARIO where Usuario_username = 'nziella')),
		
		(8,'Rodrigo','Castro',10002,33501904,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','castrorodrigo355@gmail.com',
		(select Usuario_ID from DBA_GD.USUARIO where Usuario_username = 'castrorodrigo355')),

		(8,'Juan Manuel','Cugat',10002,35493525,'Pasaporte','Arce',851,1,'A','1987-08-06','juamma.cugat@gmail.com',
		(select Usuario_ID from DBA_GD.USUARIO where Usuario_username = 'juamma.cugat')),
		(8,'Oscar Martin','Bianchi',10002,31958375,'Pasaporte','Artigas',3442,0,'6','1987-08-06','tinchob@gmail.com',
		(select Usuario_ID from DBA_GD.USUARIO where Usuario_username = 'tinchob'))
	END
go
	
--MIGRACION DATOS TABLA CUENTA--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CUENTA
	as	
	BEGIN
		INSERT INTO [DBA_GD].CUENTA
		(Cuenta_Numero, 
		Cuenta_Fecha_Creacion, 
		Cuenta_Pais_Codigo,
		Cuenta_Fecha_Cierre, 
		Cuenta_Cliente_ID,
		Cuenta_Moneda,
		Cuenta_Estado,Cuenta_tipo)
		
		SELECT DISTINCT Cuenta_Numero,
						Cuenta_Fecha_Creacion,
						(SELECT Pais_ID FROM [DBA_GD].PAIS WHERE Pais_Codigo = Cuenta_Pais_Codigo),
						Cuenta_Fecha_Cierre,						
						(SELECT Cliente_ID FROM [DBA_GD].CLIENTE WHERE Cliente_Nro_Doc = Cli_Nro_Doc AND 
																		Cliente_Tipo_Doc_Cod = Cli_Tipo_Doc_Cod),
						(SELECT Moneda_ID FROM [DBA_GD].MONEDA WHERE Moneda_Tipo = 'USD'),
						'Habilitada',4						
		FROM GD1C2015.gd_esquema.Maestra
	END
go


--MIGRACION DATOS TABLA DEPOSITO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_DEPOSITO
	as
	BEGIN
		BEGIN TRANSACTION
		INSERT INTO [DBA_GD].DEPOSITO
		(Deposito_Codigo,
		Deposito_Fecha,
		Deposito_Moneda,
		Deposito_Importe,
		Deposito_Nro_Tarjeta_cli,
		Deposito_Cuenta_Numero)
		
		SELECT DISTINCT M.Deposito_Codigo,
						M.Deposito_Fecha,
						(SELECT Moneda_ID FROM [DBA_GD].MONEDA WHERE Moneda_Tipo = 'USD'),
						M.Deposito_Importe,
						(SELECT Tarjeta_ID FROM [DBA_GD].TARJETA as T WHERE T.Tarjeta_Numero = M.Tarjeta_Numero),
						(SELECT Cuenta_ID FROM [DBA_GD].CUENTA as C WHERE C.Cuenta_Numero = M.Cuenta_Numero)
		FROM GD1C2015.gd_esquema.Maestra as M
		WHERE M.Deposito_Codigo IS NOT NULL
		COMMIT TRANSACTION
	END
go
	
--MIGRACION DATOS FUNCIONALIDAD--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Funcionalidad
	as
	BEGIN
		INSERT INTO [DBA_GD].FUNCIONALIDAD
		(Funcionalidad_Nombre)
	VALUES
		('ABM de Rol'),
		('ABM de Usuario'),
		('ABM de Cliente'),
		('ABM de Cuenta'),
		('Depositos'),
		('Retiro de Efectivo'),
		('Transferencias entre cuentas'),
		('Facturacion de costos'),
		('Consulta de saldos'),
		('Listado Estadistico')
	END

go
--MIGRACION DATOS TABLA ITEM_FACTURA--

----INCOMPLETO----

CREATE PROCEDURE [DBA_GD].Migracion_Datos_ITEM_FACTURA
	AS
	BEGIN
		INSERT INTO [DBA_GD].ITEM_FACTURA
		(Item_Factura_Descripcion,Item_Factura_Importe, Item_Factura_ID_Factura)
		SELECT	M.Item_Factura_Descr,
				M.Item_Factura_Importe,
				(SELECT DISTINCT F.Factura_Numero FROM [DBA_GD].FACTURA AS F WHERE F.Factura_Numero = M.Factura_Numero) 
		FROM GD1C2015.gd_esquema.Maestra AS M
		WHERE Item_Factura_Descr IS NOT NULL
		
	END
GO

--MIGRACION DE DATOS A TABLA MONEDA--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Moneda
	as
	BEGIN
		INSERT INTO [DBA_GD].MONEDA
		(Moneda_Tipo)
		VALUES ('USD')
	END
go

--MIGRACION DE DATOS A TABLA PAIS--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Paises
	as
	BEGIN
		INSERT INTO [DBA_GD].PAIS
		(Pais_Codigo,Pais_Desc)
		SELECT distinct Cli_Pais_Codigo AS CODIGO_PAIS,Cli_Pais_Desc AS PAIS_DESCRIPCION
		FROM GD1C2015.gd_esquema.Maestra

--AGREGA PAISES QUE ESTAN EN CUENTAS PERO NO EN CLIENTES				
		INSERT INTO [DBA_GD].PAIS
		(Pais_Codigo,Pais_Desc)
		SELECT distinct Cuenta_Pais_Codigo,Cuenta_Pais_Desc
		FROM GD1C2015.gd_esquema.Maestra T1
		WHERE NOT EXISTS (SELECT 1 FROM DBA_GD.PAIS as T2 where T1.Cuenta_Pais_Codigo = T2.Pais_Codigo)
	END
go

--MIGRACION DATOS TABLA RETIRO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_RETIRO
	as
	BEGIN
		INSERT INTO [DBA_GD].RETIRO
		(Retiro_Codigo_Egreso, Retiro_Fecha,Retiro_Moneda,Retiro_Importe,
		Retiro_Cuenta_Numero,Retiro_Nro_Cheque)
		SELECT DISTINCT M.Retiro_Codigo, M.Retiro_Fecha,1, M.Retiro_Importe,
		(SELECT C.Cuenta_ID FROM DBA_GD.CUENTA AS C WHERE C.Cuenta_Numero = M.Cuenta_Numero),
		(SELECT CH.Cheque_ID FROM DBA_GD.CHEQUE AS CH WHERE M.Cheque_Numero = CH.Cheque_Numero)
	
		FROM gd_esquema.Maestra AS M
		WHERE Retiro_Codigo IS NOT NULL
	END
go


--MIGRACION DE DATOS A TABLA ROL--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Rol
	as
	BEGIN
		INSERT INTO [DBA_GD].ROL
		(Rol_Nombre,Rol_Estado)
	VALUES
		('Administrador','activado'),
		('Cliente','activado')
	END
go

--MIGRACION DATOS TABLA ROL_FUNCIONALIDAD

CREATE PROCEDURE [DBA_GD].Migracion_Datos_ROL_FUNCIONALIDAD
	as
	BEGIN
		INSERT INTO [DBA_GD].ROL_FUNCIONALIDAD
		(Rol_Funcionalidad_Rol_ID,Rol_Funcionalidad_Funcionalidad_ID)
	VALUES
		(1,1),
		(1,2),
		(1,3),
		(1,4),
		(1,5),
		(1,6),
		(1,7),
		(1,8),
		(1,9),
		(1,10),
		(2,4),
		(2,5),
		(2,6),
		(2,7),
		(2,8),
		(2,9),
		(2,10)
	END
go

--MIGRACION DE DATOS A TABLA TARJETA--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Tarjetas
	as
	BEGIN
		INSERT INTO [DBA_GD].TARJETA
		(Tarjeta_Numero,Tarjeta_Numero_Encriptada,Tarjeta_fecha_Emision,
		Tarjeta_Fecha_Vencimiento,Tarjeta_Codigo_Seg,Tarjeta_Emisor_Descripcion,Tarjeta_Cliente_ID)
		
		SELECT distinct Tarjeta_Numero as NUMERO_TARJETA,
		(convert(varchar(16),HASHBYTES('MD5',SUBSTRING(Tarjeta_Numero,0,12)),2)
		+SUBSTRING(Tarjeta_Numero,13,4)),Tarjeta_Fecha_Emision as FECHA_EMISION,
		Tarjeta_Fecha_Vencimiento as FECHA_VENCIMIENTO,
		hashbytes('SHA1',CAST(Tarjeta_Codigo_Seg as varchar(40))),
		Tarjeta_Emisor_Descripcion as EMISOR,
		(SELECT C.Cliente_ID FROM [DBA_GD].CLIENTE as C 
		WHERE C.Cliente_Nro_Doc = M.Cli_Nro_Doc AND C.Cliente_Tipo_Doc_Cod = M.Cli_Tipo_Doc_Cod)

		FROM GD1C2015.gd_esquema.Maestra as M
		WHERE Tarjeta_Numero is not null 	
	END
go

--MIGRACION DE DATOS A TABLA TIPO_CUENTA--
CREATE PROCEDURE [DBA_GD].Migracion_Datos_Tipo_Cuenta
	as
	BEGIN
		INSERT INTO [DBA_GD].TIPO_CUENTA
		(Tipo_Cuenta_Descr,Tipo_Cuenta_Costo)
	VALUES
		('Oro',100),
		('Plata',50),
		('Bronce',25),
		('Gratuita',0)
	END
go

--MIGRACION DE DATOS A TABLA TIPO_DOCUMENTO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Tipo_Documento
	as
	BEGIN
		INSERT INTO [DBA_GD].TIPO_DOCUMENTO
		(TIPO_DOCUMENTO_ID,TIPO_DOCUMENTO_Desc)
		SELECT distinct Cli_Tipo_Doc_Cod as CODIGO_DOCUMENTO,Cli_Tipo_Doc_Desc as CODIGO_DESCRIPCION
		FROM GD1C2015.gd_esquema.Maestra	
	END
go

--MIGRACION DATOS TRANSFERENCIA--

-- Se agrega campo de tipo de moneada en la transferencia

--COMPLETO PERO VERIFICAR CON ENUNCIADO --

CREATE PROCEDURE [DBA_GD].Migracion_Datos_TRANSFERENCIA
	AS
	BEGIN
		INSERT INTO [DBA_GD].TRANSFERENCIA
			(Transferencia_Fecha,
			Transferencia_Moneda, 
			Transferencia_Importe,
			Transferencia_Costo_Trans, 
			Transferencia_Cuenta_Origen, 
			Transferencia_Cuenta_Dst)
		SELECT DISTINCT M.Transf_Fecha,
		(SELECT Moneda_ID FROM [DBA_GD].MONEDA WHERE Moneda_Tipo = 'USD'),
		M.Trans_Importe, 
		M.Trans_Costo_Trans, 
		(SELECT C.Cuenta_ID FROM [DBA_GD].CUENTA AS C WHERE C.Cuenta_Numero = M.Cuenta_Numero), 
		(SELECT C.Cuenta_ID FROM [DBA_GD].CUENTA AS C WHERE C.Cuenta_Numero = M.Cuenta_Dest_Numero) 
		FROM GD1C2015.gd_esquema.Maestra AS M
	END
GO

--MIGRACION DATOS USUARIO ROL	
	CREATE PROCEDURE [DBA_GD].Migracion_Datos_USUARIO_ROL
	as
	BEGIN
	INSERT INTO [DBA_GD].USUARIO_ROL
		(Usuario_Rol_Usuario_ID,Usuario_Rol_Rol_ID)
		select (Usuario_ID),1
		FROM [DBA_GD].USUARIO
		where (Usuario_username != 'Admin1') and (Usuario_username != 'Admin2') and (Usuario_username != 'Admin3')
	
	INSERT INTO [DBA_GD].USUARIO_ROL
		(Usuario_Rol_Usuario_ID,Usuario_Rol_Rol_ID)
	VALUES
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'Admin1'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'Admin2'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'Admin3'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'nziella'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'castrorodrigo355'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'juamma.cugat'),2),
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'tinchob'),2)
	END
go

--MIGRACION DATOS TABLA FACTURA--
-------------INCOMPLETO--------------------
CREATE PROCEDURE [DBA_GD].Migracion_Datos_FACTURA
	as
	BEGIN
		
	INSERT INTO [DBA_GD].FACTURA
		(Factura_Numero,Factura_Fecha, Factura_Item_Desc, Factura_Item_Importe,Factura_Nro_Cliente)
		SELECT DISTINCT Factura_Numero, Factura_Fecha, Item_Factura_Descr, Item_Factura_Importe,
		(SELECT C.Cliente_ID FROM DBA_GD.CLIENTE AS C WHERE M.Cli_Apellido = C.Cliente_Apellido and 
		M.Cli_Nombre = C.Cliente_Nombre)
		FROM gd_esquema.Maestra AS M
		WHERE Factura_Numero IS NOT NULL
	END
go

--MIGRACION DATOS TABLA CHEQUE--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CHEQUE
	as
	BEGIN
		
	INSERT INTO [DBA_GD].CHEQUE
		(Cheque_Numero,
		Cheque_Fecha, 
		Cheque_Moneda, 
		Cheque_Importe,
		Cheque_Nombre, 
		Cheque_Banco)
		SELECT DISTINCT M.Cheque_Numero,
						M.Cheque_Fecha,
						(SELECT Moneda_ID FROM [DBA_GD].MONEDA WHERE Moneda_Tipo = 'USD'),
						M.Cheque_Importe,
						(M.Cli_Nombre +' '+Cli_Apellido),
						(SELECT Banco_ID FROM [DBA_GD].BANCO as B WHERE B.Banco_Codigo = M.Banco_Cogido)
		FROM gd_esquema.Maestra AS M
		WHERE M.Cheque_Numero IS NOT NULL
	END
go	

-------------------------------------------------------
			-- EJECUCION DE PROCEDURES --
-------------------------------------------------------

exec [DBA_GD].Migracion_Datos_Paises
exec [DBA_GD].Migracion_Datos_BANCO
exec [DBA_GD].Migracion_Datos_Tipo_Documento
exec [DBA_GD].Migracion_Datos_Moneda
exec [DBA_GD].Migracion_Datos_Tipo_Cuenta
exec [DBA_GD].Migracion_USUARIO
exec [DBA_GD].Migracion_Datos_CLIENTE
exec [DBA_GD].Migracion_Datos_Tarjetas
exec [DBA_GD].Migracion_Datos_Rol
exec [DBA_GD].Migracion_Datos_USUARIO_ROL
exec [DBA_GD].Migracion_Datos_Funcionalidad
exec [DBA_GD].Migracion_Datos_ROL_FUNCIONALIDAD
exec [DBA_GD].Migracion_Datos_FACTURA
exec [DBA_GD].Migracion_Datos_ITEM_FACTURA
exec [DBA_GD].Migracion_Datos_CUENTA
exec [DBA_GD].Migracion_Datos_CHEQUE
exec [DBA_GD].Migracion_Datos_RETIRO
exec [DBA_GD].Migracion_Datos_DEPOSITO
exec [DBA_GD].Migracion_Datos_TRANSFERENCIA
