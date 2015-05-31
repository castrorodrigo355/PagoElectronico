USE [GD1C2015]
GO
-------------------------------------------------------
				-- Borrado de tablas --
-------------------------------------------------------
drop table [DBA_GD].FACTURA
drop table [DBA_GD].USUARIO_ROL
drop table [DBA_GD].AUDITORIA_LOG
drop table [DBA_GD].DEPOSITO
drop table [DBA_GD].RETIRO
drop table [DBA_GD].ROL_FUNCIONALIDAD
drop table [DBA_GD].ROL
drop table [DBA_GD].FUNCIONALIDAD
drop table [DBA_GD].CHEQUE
drop table [DBA_GD].BANCO
drop table [DBA_GD].TRANSFERENCIA
drop table [DBA_GD].TARJETA
drop table [DBA_GD].CUENTA
drop table [DBA_GD].TIPO_CUENTA
drop table [DBA_GD].MONEDA
drop table [DBA_GD].CLIENTE
drop table [DBA_GD].USUARIO
drop table [DBA_GD].PAIS
drop table [DBA_GD].TIPO_DOCUMENTO

-------------------------------------------------------
				-- Borrado de PROCEDURES --
-------------------------------------------------------
drop procedure [DBA_GD].Migracion_Datos_Paises
drop procedure [DBA_GD].Migracion_Datos_Tarjetas
drop procedure [DBA_GD].Migracion_Datos_BANCO
drop procedure [DBA_GD].Migracion_Datos_Tipo_Documento
drop procedure [DBA_GD].Migracion_Datos_Moneda
drop procedure [DBA_GD].Migracion_Datos_Tipo_Cuenta
drop procedure [DBA_GD].Migracion_Datos_CLIENTE
drop procedure [DBA_GD].Migracion_Datos_Rol
drop procedure [DBA_GD].Migracion_USUARIO
drop procedure [DBA_GD].Migracion_Datos_USUARIO_ROL
drop procedure [DBA_GD].Migracion_Datos_Funcionalidad
drop procedure [DBA_GD].Migracion_Datos_ROL_FUNCIONALIDAD
drop PROCEDURE [DBA_GD].Migracion_Datos_FACTURA
drop PROCEDURE [DBA_GD].Migracion_Datos_RETIRO
drop PROCEDURE [DBA_GD].Migracion_Datos_CUENTA
drop PROCEDURE [DBA_GD].Migracion_Datos_DEPOSITO
drop PROCEDURE [DBA_GD].Migracion_Datos_CHEQUE
-------------------------------------------------------
				-- Borrado de ESQUEMA --
-------------------------------------------------------
drop schema DBA_GD