USE [GD1C2015]
GO
-------------------------------------------------------
				-- Creación de Esquema --
-------------------------------------------------------
CREATE SCHEMA [DBA_GD] AUTHORIZATION [gd]
GO
-------------------------------------------------------
				-- Creacion de tablas ---
-------------------------------------------------------
CREATE TABLE [DBA_GD].TIPO_DOCUMENTO(
	Tipo_Documento_ID numeric(18,0) NOT NULL primary key,
	Tipo_Documento_Desc varchar(16) NOT NULL
	);	
	
CREATE TABLE [DBA_GD].PAIS(
	Pais_ID numeric(18,0) identity(1,1) primary key,
	Pais_Codigo numeric(18,0) NOT NULL,
	Pais_Desc varchar(64) NOT NULL,
	CONSTRAINT UC_Pais_Codigo UNIQUE(Pais_Codigo) 
	);	
	
CREATE TABLE [DBA_GD].USUARIO(
	Usuario_ID numeric(18,0) identity(1,1) primary key,
	Usuario_username varchar(64) NOT NULL,
	Usuario_password varchar(64) NOT NULL,
	Usuario_Fecha_Creacion datetime NOT NULL,
	Usuario_Fecha_Ultima_Modif datetime NOT NULL,
	Usuario_Pregunta_Secreta varchar(128) NOT NULL,
	Usuario_Respuesta_secreta varchar(128) NOT NULL,
	Usuario_Estado bit NOT NULL,
	Usuario_Cant_Intentos tinyint NOT NULL DEFAULT 0,
	CONSTRAINT UC_Usuario_username UNIQUE(Usuario_username) 
	); 	

CREATE TABLE [DBA_GD].AUDITORIA_LOG(
	Log_ID numeric(18,0) identity(1,1) primary key,
	Log_Usuario numeric(18,0) NOT NULL foreign key references [DBA_GD].USUARIO,
	Log_Fecha_Hora datetime NOT NULL,
	Log_Tipo varchar(64) NOT NULL,
	Log_Cant_Intentos tinyint NOT NULL DEFAULT 0
	);

CREATE TABLE [DBA_GD].TIPO_CUENTA(
	Tipo_Cuenta_ID numeric(18,0) identity(1,1) primary key,
	Tipo_Cuenta_Descr varchar(16) NOT NULL,
	Tipo_Cuenta_Costo int NOT NULL
	);

CREATE TABLE [DBA_GD].BANCO(
	Banco_ID  numeric(18,0) identity(1,1) primary key,
	Banco_Codigo numeric(18,0) NOT NULL,
	Banco_Nombre varchar(64) NOT NULL,
	Banco_Direccion varchar(64) NOT NULL,
	CONSTRAINT UC_Banco_Codigo UNIQUE(Banco_Codigo) 
	);

CREATE TABLE [DBA_GD].CLIENTE(
	Cliente_ID numeric(18,0) identity(1,1) primary key,
	Cliente_Pais_Codigo numeric(18,0) NOT NULL foreign key references [DBA_GD].PAIS(Pais_Codigo),
	Cliente_Nacionalidad varchar(64),
	Cliente_Nombre varchar(64) NOT NULL,
	Cliente_Apellido varchar(64) NOT NULL,
	Cliente_Tipo_Doc_Cod numeric(18,0) NOT NULL foreign key references [DBA_GD].TIPO_DOCUMENTO,
	Cliente_Nro_Doc numeric(18,0) NOT NULL, 
	Cliente_Tipo_Doc_Desc varchar(256) NOT NULL,
	Cliente_Dom_Calle varchar(256) NOT NULL,
	Cliente_Dom_Nro numeric(18,0) NOT NULL,
	Cliente_Dom_piso numeric(18,0) NOT NULL,
	Cliente_Dom_Depto varchar(2) NOT NULL,
	Cliente_Fecha_Nac datetime NOT NULL,
	Cliente_Mail varchar(128),
	Cliente_Usuario numeric(18,0) NOT NULL foreign key references [DBA_GD].USUARIO,
	);	
		
CREATE TABLE [DBA_GD].MONEDA(
	Moneda_ID numeric(18,0) identity primary key,
	Moneda_Tipo varchar(10) NOT NULL
	);
	
CREATE TABLE [DBA_GD].CUENTA(
	Cuenta_ID numeric(18,0) identity(1,1) primary key,
	Cuenta_Numero numeric(18,0) NOT NULL,
	Cuenta_Fecha_Creacion datetime NOT NULL,
	Cuenta_Pais_Codigo numeric(18,0) NOT NULL foreign key references [DBA_GD].PAIS,
	Cuenta_Fecha_Cierre datetime,
	Cuenta_tipo numeric(18,0) NOT NULL foreign key references [DBA_GD].TIPO_CUENTA,
	Cuenta_Cliente_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].CLIENTE,
	Cuenta_Moneda numeric(18,0) NOT NULL foreign key references [DBA_GD].MONEDA,
	Cuenta_Estado char(40) NOT NULL,
	CONSTRAINT UC_Cuenta_Numero UNIQUE(Cuenta_Numero) 
	);
	
CREATE TABLE [DBA_GD].LOG_CUENTA_INHABILITADA(
	Cue_Inha_ID numeric(18,0) identity(1,1) primary key,
	Cue_Inha_Cuenta numeric(18,0) NOT NULL foreign key references [DBA_GD].CUENTA
	);	
	
CREATE TABLE [DBA_GD].CHEQUE(
	Cheque_ID  numeric(18,0) identity(1,1) primary key,
	Cheque_Numero numeric(18,0) NOT NULL,
	Cheque_Fecha datetime NOT NULL,
	Cheque_Moneda numeric(18,0) NOT NULL foreign key references [DBA_GD].MONEDA,
	Cheque_Importe numeric(18,2) NOT NULL,
--	Cheque_Nombre varchar(64) NOT NULL ,
	Cheque_Cliente_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].CLIENTE,
	Cheque_Banco numeric(18,0) NOT NULL foreign key references [DBA_GD].BANCO
	);
		
CREATE TABLE [DBA_GD].TARJETA(
	Tarjeta_ID numeric(18,0) identity(1,1) primary key,
	Tarjeta_Numero varchar(16) NOT NULL,
	Tarjeta_Numero_Encriptada varchar(20) NOT NULL,
	Tarjeta_fecha_Emision datetime NOT NULL,
	Tarjeta_Fecha_Vencimiento datetime NOT NULL,
	Tarjeta_Codigo_Seg varchar(64) NOT NULL,
	Tarjeta_Emisor_Descripcion varchar(128) NOT NULL,
	Tarjeta_Cliente_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].CLIENTE,
	);
	
CREATE TABLE [DBA_GD].DEPOSITO(
	Deposito_ID numeric(18,0) identity(1,1) primary key,
	Deposito_Codigo numeric(18,0) NOT NULL,
	Deposito_Fecha datetime NOT NULL,
	Deposito_Moneda numeric(18,0) NOT NULL foreign key references [DBA_GD].MONEDA,
	Deposito_Importe numeric(18,2) NOT NULL,
	Deposito_Nro_Tarjeta_cli numeric(18,0) NOT NULL foreign key references [DBA_GD].TARJETA,
	Deposito_Cuenta_Numero numeric(18,0) NOT NULL foreign key references [DBA_GD].CUENTA,
	CONSTRAINT UC_Deposito_Codigo UNIQUE(Deposito_Codigo) 
	);
	
CREATE TABLE [DBA_GD].RETIRO(
	Retiro_ID numeric(18,0) identity(1,1) primary key,
	Retiro_Fecha datetime NOT NULL,
	Retiro_Moneda numeric(18,0) NOT NULL foreign key references [DBA_GD].MONEDA,
	Retiro_Importe numeric(18,2) NOT NULL,
	Retiro_Cuenta_Numero numeric(18,0) NOT NULL foreign key references [DBA_GD].CUENTA,
	Retiro_Codigo_Egreso numeric(18,0) NOT NULL,
	Retiro_Nro_Cheque numeric(18,0) NOT NULL foreign key references [DBA_GD].CHEQUE,
	CONSTRAINT UC_Retiro_codigo UNIQUE(Retiro_codigo_Egreso) 
	);
	
CREATE TABLE [DBA_GD].TRANSFERENCIA(
	Transferencia_ID numeric(18,0) identity(1,1) primary key,
	Transferencia_Fecha datetime NOT NULL,
	Transferencia_Moneda numeric(18,0) NOT NULL foreign key references [DBA_GD].MONEDA,
	Transferencia_Importe numeric(18,2) NOT NULL,
	Transferencia_Costo_Trans numeric(18,2) NOT NULL,
	Transferencia_Cuenta_Origen numeric(18,0) NOT NULL foreign key references [DBA_GD].CUENTA,
	Transferencia_Cuenta_Dst numeric(18,0) NOT NULL foreign key references [DBA_GD].CUENTA
	);

CREATE TABLE [DBA_GD].ROL(
	Rol_ID numeric(18,0) identity(1,1) primary key,
	Rol_Nombre varchar(64) NOT NULL,
	Rol_Estado bit NOT NULL,
	);
	
CREATE TABLE [DBA_GD].FUNCIONALIDAD(
	Funcionalidad_ID numeric(18,0) identity(1,1) primary key,
	Funcionalidad_Nombre varchar(128) NOT NULL
	);
		
CREATE TABLE [DBA_GD].FACTURA(
	Factura_Numero numeric(18,0) NOT NULL primary key,
	Factura_Fecha datetime NOT NULL,
	Factura_Nro_Cliente numeric(18,0) NOT NULL foreign key references [DBA_GD].CLIENTE
	);
	
CREATE TABLE [DBA_GD].ITEM_FACTURA(
	Item_Factura_ID numeric(18,0) identity(1,1) primary key,
	Item_Factura_Descripcion varchar(128) NOT NULL,
	Item_Factura_Importe numeric(18,2) NOT NULL,
	Item_Factura_ID_Factura numeric(18,0) NOT NULL foreign key references [DBA_GD].FACTURA
	);

	---------------------INICIO TABLAS RELACIONALES--------------------------

CREATE TABLE [DBA_GD].ROL_FUNCIONALIDAD(
	Rol_Funcionalidad_Rol_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].ROL,
	Rol_Funcionalidad_Funcionalidad_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].Funcionalidad
	constraint Rol_Funcionalidad_ID primary key(Rol_Funcionalidad_Rol_ID,Rol_Funcionalidad_Funcionalidad_ID)
	);
		
CREATE TABLE [DBA_GD].USUARIO_ROL(
	Usuario_Rol_Usuario_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].USUARIO,
	Usuario_Rol_Rol_ID numeric(18,0) NOT NULL foreign key references [DBA_GD].ROL
	constraint Cliente_Usuario_ID primary key(Usuario_Rol_Usuario_ID,Usuario_Rol_Rol_ID)
	);
	--------------------FIN TABLAS RELACIONALES-----------------------------


	------------------AGREGADO DE VALORES POR DEFAULT-----------------------
ALTER TABLE [DBA_GD].DEPOSITO ADD CONSTRAINT DF_Deposito_Fecha DEFAULT GETDATE() FOR [Deposito_Fecha]
GO
ALTER TABLE [DBA_GD].TRANSFERENCIA ADD CONSTRAINT DF_Transferencia_Fecha DEFAULT GETDATE() FOR [Transferencia_Fecha]
GO
ALTER TABLE [DBA_GD].RETIRO ADD CONSTRAINT DF_Retiro_Fecha DEFAULT GETDATE() FOR [Retiro_Fecha]
GO
	-----------------------------------------------------------------------
						-- PROCESOS DE MIGRACION DE DATOS ---
	-----------------------------------------------------------------------


--MIGRACION DATOS A TABLA BANCO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_BANCO
	AS
	BEGIN
		INSERT INTO [DBA_GD].BANCO
		(Banco_Codigo,Banco_Nombre,Banco_direccion)
		SELECT DISTINCT Banco_Cogido as CODIGO_BANCO, Banco_Nombre as NOMBRE, 
						Banco_Direccion as DIRECCION

		FROM GD1C2015.gd_esquema.Maestra

		WHERE Banco_Cogido is not null 	
	END
GO
--MIGRACION DATOS USUARIO--

CREATE PROCEDURE [DBA_GD].Migracion_USUARIO
	AS
	BEGIN
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado)
		
		SELECT DISTINCT SUBSTRING(Cli_Mail,0,patindex('%@%',Cli_Mail)),
		--la contraseña es 123--
		'DFA7A2273567DCD1EFFFB9A46308E91C20FA13C44C3441BC69CD6A7869B3F7FD',
		getdate(),getdate(),'¿Que materia cursas?',
		--gestion de datos--
		'2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1
		
		FROM gd_esquema.Maestra	
	
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado,Usuario_Cant_Intentos)
		
		VALUES
		--pass es w23e--
		('Admin1','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',
		'2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),
		
		('Admin2','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',
		'2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),
		
		('Admin3','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',
		'2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),	
		
		('nziella','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'¿Que materia cursas?','2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),		
		
		('castrorodrigo355','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'¿Que materia cursas?','2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),
		
		('juamma.cugat','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'¿Que materia cursas?','2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0),
		
		('tinchob','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),getdate(),
		'¿Que materia cursas?','2EB8D2D6A83DD4DB081F290BE198590EE01A2C685FF62F6BFC2D0E34CB2E74E8',1,0)
	END
GO	
--MIGRACION DATOS TABLA CLIENTE--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CLIENTE
	AS
	BEGIN
		INSERT INTO [DBA_GD].CLIENTE
		(Cliente_Pais_Codigo,
		Cliente_Nombre,Cliente_Apellido,
		Cliente_Tipo_Doc_Cod,Cliente_Nro_Doc,
		Cliente_Tipo_Doc_Desc,Cliente_Dom_Calle,
		Cliente_Dom_Nro,Cliente_Dom_Piso,Cliente_Dom_Depto,
		Cliente_Fecha_Nac,Cliente_Mail,Cliente_Usuario)
		
		SELECT DISTINCT Cli_Pais_Codigo,
		Cli_Nombre,Cli_Apellido,Cli_Tipo_Doc_Cod,Cli_Nro_Doc,Cli_Tipo_Doc_Desc,
		Cli_Dom_Calle,Cli_Dom_Nro,Cli_Dom_Piso,Cli_Dom_Depto,Cli_Fecha_Nac,Cli_Mail,
		(SELECT Usuario_ID FROM DBA_GD.USUARIO WHERE Usuario_username =
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
		(SELECT Usuario_ID FROM DBA_GD.USUARIO WHERE Usuario_username = 'nziella')),
		
		(8,'Rodrigo','Castro',10002,33501904,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','castrorodrigo355@gmail.com',
		(SELECT Usuario_ID FROM DBA_GD.USUARIO WHERE Usuario_username = 'castrorodrigo355')),

		(8,'Juan Manuel','Cugat',10002,35493525,'Pasaporte','Arce',851,1,'A','1987-08-06','juamma.cugat@gmail.com',
		(SELECT Usuario_ID FROM DBA_GD.USUARIO WHERE Usuario_username = 'juamma.cugat')),
		(8,'Oscar Martin','Bianchi',10002,31958375,'Pasaporte','Artigas',3442,0,'6','1987-08-06','tinchob@gmail.com',
		(SELECT Usuario_ID FROM DBA_GD.USUARIO WHERE Usuario_username = 'tinchob'))
	END
GO
	
--MIGRACION DATOS TABLA CUENTA--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CUENTA
	AS	
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
GO
--MIGRACION DATOS TABLA DEPOSITO--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_DEPOSITO
	AS
	BEGIN
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
	END
GO	
--MIGRACION DATOS FUNCIONALIDAD--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Funcionalidad
	AS
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
GO
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
	AS
	BEGIN
		INSERT INTO [DBA_GD].MONEDA
		(Moneda_Tipo)

		VALUES ('USD')
	END
GO
--MIGRACION DE DATOS A TABLA PAIS--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Paises
	AS
	BEGIN
		INSERT INTO [DBA_GD].PAIS
		(Pais_Codigo,Pais_Desc)

		SELECT distinct Cli_Pais_Codigo AS CODIGO_PAIS,Cli_Pais_Desc AS PAIS_DESCRIPCION

		FROM GD1C2015.gd_esquema.Maestra

		INSERT INTO [DBA_GD].PAIS
		(Pais_Codigo,Pais_Desc)

		SELECT distinct Cuenta_Pais_Codigo,Cuenta_Pais_Desc

		FROM GD1C2015.gd_esquema.Maestra T1

		WHERE NOT EXISTS (SELECT 1 FROM DBA_GD.PAIS as T2 where T1.Cuenta_Pais_Codigo = T2.Pais_Codigo)
	END
GO

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
GO

--MIGRACION DE DATOS A TABLA ROL--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Rol
	AS
	BEGIN
		INSERT INTO [DBA_GD].ROL
		(Rol_Nombre,Rol_Estado)
		VALUES
		('Administrador',1),
		('Cliente',1)
	END
GO

--MIGRACION DATOS TABLA ROL_FUNCIONALIDAD

CREATE PROCEDURE [DBA_GD].Migracion_Datos_ROL_FUNCIONALIDAD
	AS
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
GO

--MIGRACION DE DATOS A TABLA TARJETA--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_Tarjetas
	AS
	BEGIN
		INSERT INTO [DBA_GD].TARJETA
		(Tarjeta_Numero,Tarjeta_Numero_Encriptada,Tarjeta_fecha_Emision,
		Tarjeta_Fecha_Vencimiento,Tarjeta_Codigo_Seg,Tarjeta_Emisor_Descripcion,Tarjeta_Cliente_ID)
		
		SELECT distinct Tarjeta_Numero as NUMERO_TARJETA,
		(convert(varchar(16),HASHBYTES('MD5',SUBSTRING(Tarjeta_Numero,0,12)),2)
		+SUBSTRING(Tarjeta_Numero,13,4)),Tarjeta_Fecha_Emision AS FECHA_EMISION,
		Tarjeta_Fecha_Vencimiento AS FECHA_VENCIMIENTO,
		hashbytes('SHA1',CAST(Tarjeta_Codigo_Seg AS varchar(40))),
		Tarjeta_Emisor_Descripcion AS EMISOR,
		(SELECT C.Cliente_ID FROM [DBA_GD].CLIENTE AS C 
		WHERE C.Cliente_Nro_Doc = M.Cli_Nro_Doc AND C.Cliente_Tipo_Doc_Cod = M.Cli_Tipo_Doc_Cod)

		FROM GD1C2015.gd_esquema.Maestra as M

		WHERE Tarjeta_Numero is not null 	
	END
GO

--MIGRACION DE DATOS A TABLA TIPO_CUENTA--
CREATE PROCEDURE [DBA_GD].Migracion_Datos_Tipo_Cuenta
	AS
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
	AS
	BEGIN
		INSERT INTO [DBA_GD].TIPO_DOCUMENTO
		(TIPO_DOCUMENTO_ID,TIPO_DOCUMENTO_Desc)
		SELECT distinct Cli_Tipo_Doc_Cod as CODIGO_DOCUMENTO,Cli_Tipo_Doc_Desc as CODIGO_DESCRIPCION
		FROM GD1C2015.gd_esquema.Maestra	
	END
GO

--MIGRACION DATOS TRANSFERENCIA--

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
	
		WHERE M.Cuenta_Dest_Numero IS NOT NULL
	END
GO

--MIGRACION DATOS USUARIO ROL	
	CREATE PROCEDURE [DBA_GD].Migracion_Datos_USUARIO_ROL
	AS
	BEGIN
		INSERT INTO [DBA_GD].USUARIO_ROL
		(Usuario_Rol_Usuario_ID,Usuario_Rol_Rol_ID)
		SELECT (Usuario_ID),1
		
		FROM [DBA_GD].USUARIO
		
		WHERE (Usuario_username != 'Admin1') and (Usuario_username != 'Admin2') and (Usuario_username != 'Admin3')
	
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
GO

--MIGRACION DATOS TABLA FACTURA--
CREATE PROCEDURE [DBA_GD].Migracion_Datos_FACTURA
	AS
	BEGIN
		
	INSERT INTO [DBA_GD].FACTURA
		(Factura_Numero,
		Factura_Fecha, 
		Factura_Nro_Cliente)
		SELECT DISTINCT M.Factura_Numero, 
						M.Factura_Fecha, 
						(SELECT C.Cliente_ID 
							FROM DBA_GD.CLIENTE AS C 
							WHERE M.Cli_Apellido = C.Cliente_Apellido AND 
								M.Cli_Nombre = C.Cliente_Nombre)
		FROM gd_esquema.Maestra AS M
		WHERE M.Factura_Numero IS NOT NULL
	END
GO

--MIGRACION DATOS TABLA CHEQUE--

CREATE PROCEDURE [DBA_GD].Migracion_Datos_CHEQUE
	AS
	BEGIN
		
	INSERT INTO [DBA_GD].CHEQUE
		(Cheque_Numero,
		Cheque_Fecha, 
		Cheque_Moneda, 
		Cheque_Importe,
		Cheque_Cliente_ID, 
		Cheque_Banco)
		SELECT DISTINCT M.Cheque_Numero,
						M.Cheque_Fecha,
						(SELECT Moneda_ID FROM [DBA_GD].MONEDA WHERE Moneda_Tipo = 'USD'),
						M.Cheque_Importe,
						(SELECT Cliente_ID 
							FROM [DBA_GD].CLIENTE AS C, [DBA_GD].TIPO_DOCUMENTO AS T
							WHERE C.Cliente_Nro_Doc = M.Cli_Nro_Doc AND
								C.Cliente_Tipo_Doc_Cod = T.Tipo_Documento_ID AND
								T.Tipo_Documento_Desc = M.Cli_Tipo_Doc_Desc),
						(SELECT Banco_ID FROM [DBA_GD].BANCO as B WHERE B.Banco_Codigo = M.Banco_Cogido)
		
		FROM gd_esquema.Maestra AS M
		
		WHERE M.Cheque_Numero IS NOT NULL
	END
GO

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
