CREATE DATABASE [N5Challenge]
GO

USE [N5Challenge]
GO

CREATE TABLE [dbo].[PermissionTypes](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL
)
GO

CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeForname] [varchar](100) NOT NULL,
	[EmployeeSurname] [varchar](100) NULL,
	[PermissionType] [int] NULL REFERENCES PermissionTypes,
	[PermissionDate] [date] NULL
)
GO

INSERT [dbo].[PermissionTypes] ([Description]) VALUES ('Tipo1')
GO