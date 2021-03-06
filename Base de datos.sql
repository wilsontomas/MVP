USE [Agenda]
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contactos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Numero] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Contactos] ON 

INSERT [dbo].[Contactos] ([Id], [Nombre], [Apellido], [Numero]) VALUES (1, N'Wilson', N'Tomas', 8298414926)
INSERT [dbo].[Contactos] ([Id], [Nombre], [Apellido], [Numero]) VALUES (2, N'Eduardo', N'Alcantara', 8095537183)
INSERT [dbo].[Contactos] ([Id], [Nombre], [Apellido], [Numero]) VALUES (3, N'Juan', N'Gomes', 8295689652)
INSERT [dbo].[Contactos] ([Id], [Nombre], [Apellido], [Numero]) VALUES (4, N'Matias', N'Goner', 8495698596)
SET IDENTITY_INSERT [dbo].[Contactos] OFF
/****** Object:  StoredProcedure [dbo].[EditarContacto]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditarContacto]
(@id int,@Nombre varchar(255), @Apellido varchar(255), @Numero bigint)
as set nocount on
begin
	if(@Nombre ='' or @Nombre=null or  @Apellido='' or @Apellido=null or @Numero=0) return 0;
update Contactos set Nombre = @Nombre,Apellido =@Apellido ,Numero =@Numero where Contactos.id = @id;
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarContacto]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EliminarContacto]
(@id int)
as set nocount on
begin
delete from Contactos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[InsertarContacto]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarContacto]
(@Nombre varchar(255), @Apellido varchar(255), @Numero bigint)
as set nocount on
begin
	if(@Nombre ='' or @Nombre=null or  @Apellido='' or @Apellido=null or @Numero=0) return 0;
	 insert into Contactos(Nombre,Apellido,Numero) values (@Nombre,@Apellido,@Numero)
end
GO
/****** Object:  StoredProcedure [dbo].[VerContactos]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[VerContactos]
as 
begin
select c.id, c.Nombre, c.Apellido, c.Numero from Contactos c
end
GO
/****** Object:  StoredProcedure [dbo].[VerContactosPorId]    Script Date: 14/8/2021 12:29:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[VerContactosPorId]
(@id int)
as 
begin
select c.id, c.Nombre, c.Apellido, c.Numero from Contactos c where c.id = @id
end
GO
