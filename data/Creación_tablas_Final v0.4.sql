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
	Pais_Nacionalidad varchar(250),
	CONSTRAINT UC_Pais_Codigo UNIQUE(Pais_Codigo) 
	);	
	
CREATE TABLE [DBA_GD].USUARIO(
	Usuario_ID numeric(18,0) identity(1,1) primary key,
	Usuario_username varchar(255),
	Usuario_password varbinary(40),
	Usuario_Fecha_Creacion datetime,
	Usuario_Fecha_Ultima_Modif datetime,
	Usuario_Pregunta_Secreta varchar(60),
	Usuario_Respuesta_secreta varbinary(60),
	Usuario_Estado char(1),
	Usuario_Cant_Intentos tinyint,
	CONSTRAINT UC_Usuario_username UNIQUE(Usuario_username) 
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
	Tipo_Cuenta_Codigo numeric(18,0),
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

CREATE TABLE [DBA_GD].CHEQUE(
	Cheque_ID  numeric(18,0) identity(1,1) primary key,
	Cheque_Numero numeric(18,0),
	Cheque_Fecha datetime,
	Cheque_Moneda varchar(255),
	Cheque_Importe numeric(18,2),
	Cheque_Nombre varchar(255),
	Cheque_Banco numeric(18,0) foreign key references [DBA_GD].BANCO
	);

CREATE TABLE [DBA_GD].CLIENTE(
	Cliente_ID numeric(18,0) identity(1,1) primary key,
	Cliente_Pais_Codigo numeric(18,0) foreign key references [DBA_GD].PAIS(Pais_Codigo),
	Cliente_Nombre varchar(255),
	Cliente_Apellido varchar(255),
	Cliente_Tipo_Doc_Cod numeric(18,0),
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
	
CREATE TABLE [DBA_GD].CUENTA(
	Cuenta_ID  numeric(18,0) identity(1,1) primary key,
	Cuenta_Numero numeric(18,0),
	Cuenta_Fecha_Creacion datetime,
	Cuenta_Pais_Codigo numeric(18,0),
	Cuenta_Fecha_Cierre datetime,
	Cuenta_tipo numeric(18,0) foreign key references [DBA_GD].TIPO_CUENTA,
	Cuenta_Cliente_ID numeric(18,0) foreign key references [DBA_GD].CLIENTE,
	Cuenta_Moneda varchar(255),
	Cuenta_Estado char(10),
	CONSTRAINT UC_Cuenta_Numero UNIQUE(Cuenta_Numero) 
	);
		
CREATE TABLE [DBA_GD].TARJETA(
	Tarjeta_ID numeric(18,0) identity(1,1) primary key,
	Tarjeta_Numero varchar(16),
	Tarjeta_Numero_Encriptada varchar(20),
	Tarjeta_fecha_Emision datetime,
	Tarjeta_Fecha_Vencimiento datetime,
	Tarjeta_Codigo_Seg varchar(3),
	Tarjeat_Emisor_Descripcion varchar(255),
	Tarjeta_Cliente_ID numeric(18,0) foreign key references [DBA_GD].CLIENTE,
	);
	
CREATE TABLE [DBA_GD].DEPOSITO(
	Deposito_ID numeric(18,0) identity(1,1) primary key,
	Deposito_Codigo numeric(18,0),
	Deposito_Fecha datetime,
	Deposito_Moneda varchar(255),
	Deposito_Importe numeric(18,2),
	Deposito_Nro_Tarjeta_cli numeric(18,0) foreign key references [DBA_GD].TARJETA,
	Deposito_Cuenta_Numero numeric(18,0) foreign key references [DBA_GD].CUENTA,
	CONSTRAINT UC_Deposito_Codigo UNIQUE(Deposito_Codigo) 
	);
	
CREATE TABLE [DBA_GD].RETIRO(
	Retiro_ID numeric(18,0) identity(1,1) primary key,
	Retiro_codigo numeric(18,0),
	Retiro_Fecha datetime,
	Retiro_Moneda varchar(255),
	Retiro_Importe numeric(18,2),
	Retiro_Cuenta_Numero numeric(18,0) foreign key references [DBA_GD].CUENTA,
	Retiro_Codigo_Egreso integer,
	Retiro_Nro_Cheque numeric(18,0) foreign key references [DBA_GD].CHEQUE,
	CONSTRAINT UC_Retiro_codigo UNIQUE(Retiro_codigo) 
	);
	
CREATE TABLE [DBA_GD].TRANSFERENCIA(
	Transferencia_ID numeric(18,0) identity(1,1) primary key,
	Transferencia_Fecha datetime,
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

CREATE TABLE [DBA_GD].FACTURA(
	Factura_Numero numeric(18,0) primary key,
	Factura_Fecha datetime,
	Item_Factura_Desc varchar(255),
	Item_Factura_Importe numeric(18,2),
	Factura_Nro_Cliente numeric(18,0) foreign key references [DBA_GD].CLIENTE
	);
	CREATE TABLE [DBA_GD].MONEDA(
	Moneda_ID numeric(18,0) identity primary key,
	Moneda_Tipo varchar(10)
	);

--VALORES POR DEFAULT
ALTER TABLE [DBA_GD].DEPOSITO ADD CONSTRAINT DF_Deposito_Fecha DEFAULT GETDATE() FOR [Deposito_Fecha]
GO
ALTER TABLE [DBA_GD].TRANSFERENCIA ADD CONSTRAINT DF_Transferencia_Fecha DEFAULT GETDATE() FOR [Transferencia_Fecha]
GO
ALTER TABLE [DBA_GD].RETIRO ADD CONSTRAINT DF_Retiro_Fecha DEFAULT GETDATE() FOR [Retiro_Fecha]
GO


--MIGRACION DATOS A TABLA BANCO--
	--LISTO--

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
--MIGRACION DATOS TABLA CHEQUE--
	--RESTA HACER
--MIGRACION DATOS TABLA CLIENTE
	--INCOMPLETO
CREATE PROCEDURE [DBA_GD].Migracion_Datos_CLIENTE
	as
	BEGIN
		INSERT INTO [DBA_GD].CLIENTE
		(Cliente_Pais_Codigo,
		Cliente_Nombre,Cliente_Apellido,
		Cliente_Tipo_Doc_Cod,Cliente_Nro_Doc,
		Cliente_Tipo_Doc_Desc,Cliente_Dom_Calle,
		Cliente_Dom_Nro,Cliente_Dom_Piso,Cliente_Dom_Depto,
		Cliente_Fecha_Nac,Cliente_Mail)
		
		SELECT distinct Cli_Pais_Codigo,Cli_Nombre,Cli_Apellido,Cli_Tipo_Doc_Cod,Cli_Nro_Doc,Cli_Tipo_Doc_Desc,
		Cli_Dom_Calle,Cli_Dom_Nro,Cli_Dom_Piso,Cli_Dom_Depto,Cli_Fecha_Nac,Cli_Mail
		FROM GD1C2015.gd_esquema.Maestra
	
		INSERT INTO [DBA_GD].CLIENTE
					(Cliente_Pais_Codigo,
					Cliente_Nombre,Cliente_Apellido,
					Cliente_Tipo_Doc_Cod,Cliente_Nro_Doc,
					Cliente_Tipo_Doc_Desc,Cliente_Dom_Calle,
					Cliente_Dom_Nro,Cliente_Dom_Piso,Cliente_Dom_Depto,
					Cliente_Fecha_Nac,Cliente_Mail)
		VALUES 
		(8,'Nicolas','Ziella',10002,33204530,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','nziella@hotmail.com.ar'),
		(8,'Rodrigo','Castro',10002,33204530,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','castrorodrigo355@gmail.com'),
		(8,'Juan Manuel','Cugat',10002,35493525,'Pasaporte','Arce',851,1,'A','1987-08-06','juamma.cugat@gmail.com'),
		(8,'Oscar Martin','Bianchini',10002,33204530,'Pasaporte','Alejandro Magariños Cervantes',3557,0,'6','1987-08-06','tinchob@gmail.com')
	END
go
	
--MIGRACION DATOS TABLA CLIENTE_CUENTA
	--RESTA HACER
--MIGRACION DATOS TABLA CLIENTE_TARJETA
	--RESTA HACER
--MIGRACION DATOS TABLA CUENTA
	--RESTA HACER
--MIGRACION DATOS TABLA DEPOSITO
	--RESTA HACER
--MIGRACION DATOS TABLA FACTURA
	--RESTA HACER
--MIGRACION DATOS FUNCIONALIDAD
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
--MIGRACION DATOS TABLA ITEM_FACTURA
	--RESTA HACER
	
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
		(Pais_Codigo,Pais_Desc,Pais_Nacionalidad)
		SELECT distinct Cli_Pais_Codigo AS CODIGO_PAIS,Cli_Pais_Desc AS PAIS_DESCRIPCION, Cli_Pais_Desc as NACIONALIDAD
		FROM GD1C2015.gd_esquema.Maestra	
	END
go

--MIGRACION DATOS TABLA RETIRO--
	--RESTA HACER

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
		Tarjeta_Fecha_Vencimiento,Tarjeta_Codigo_Seg,Tarjeat_Emisor_Descripcion)
		
		SELECT distinct Tarjeta_Numero as NUMERO_TARJETA,
		(convert(varchar(16),HASHBYTES('MD5',SUBSTRING(Tarjeta_Numero,0,12)),2)
		+SUBSTRING(Tarjeta_Numero,13,4)),Tarjeta_Fecha_Emision as FECHA_EMISION,
		Tarjeta_Fecha_Vencimiento as FECHA_VENCIMIENTO,Tarjeta_Codigo_Seg as COD_SEG,
		Tarjeta_Emisor_Descripcion as EMISOR

		FROM GD1C2015.gd_esquema.Maestra
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

--MIGRACION DATOS TRANSFERENCIA
	--RESTA HACER

--MIGRACION DATOS USUARIO
CREATE PROCEDURE [DBA_GD].Migracion_USUARIO
	as
	BEGIN
		DECLARE @VARIABLE INT
		SET @VARIABLE = 1
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado,Usuario_Cant_Intentos)
		SELECT distinct SUBSTRING(Cliente_Mail,0,patindex('%@%',Cliente_Mail)),hashbytes('SHA1',CAST(Cliente_Nro_Doc as varchar(200))),
		getdate(),getdate(),'¿Sabes como identificarte?',
		hashbytes('SHA1',CAST('Algo que solo tu posees'as varchar(40))),'A',0
		
		FROM GD1C2015.[DBA_GD].CLIENTE	
	
		INSERT INTO [DBA_GD].USUARIO
		(Usuario_Username,Usuario_Password,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modif,
		Usuario_Pregunta_Secreta,Usuario_Respuesta_Secreta,Usuario_Estado,Usuario_Cant_Intentos)
		
		VALUES
		('Admin1',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0),
		('Admin2',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0),
		('Admin3',hashbytes('SHA1',CAST('w23e'as varchar(10))),getdate(),getdate(),
		'Una combinación de letras que te dijeron en el tp',hashbytes('SHA1',CAST('Lo que dice el enunciado'as varchar(40))),'A',0)
	END
go
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
		((SELECT Usuario_ID FROM [DBA_GD].USUARIO WHERE Usuario_username = 'Admin3'),2)
	END
go

-------------------------------------------------------
			-- EJECUCION DE PROCEDURES --
-------------------------------------------------------

exec [DBA_GD].Migracion_Datos_Paises
exec [DBA_GD].Migracion_Datos_Tarjetas
exec [DBA_GD].Migracion_Datos_BANCO
exec [DBA_GD].Migracion_Datos_Tipo_Documento
exec [DBA_GD].Migracion_Datos_Moneda
exec [DBA_GD].Migracion_Datos_Tipo_Cuenta
exec [DBA_GD].Migracion_Datos_CLIENTE
exec [DBA_GD].Migracion_Datos_Rol
exec [DBA_GD].Migracion_USUARIO
exec [DBA_GD].Migracion_Datos_USUARIO_ROL
exec [DBA_GD].Migracion_Datos_Funcionalidad
exec [DBA_GD].Migracion_Datos_ROL_FUNCIONALIDAD



