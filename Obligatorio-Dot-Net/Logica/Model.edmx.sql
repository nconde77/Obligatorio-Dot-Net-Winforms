
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/07/2019 20:56:17
-- Generated from EDMX file: C:\Users\MTori\Documents\GitHub\Obligatorio-Dot-Net\Logica\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Obligatorio];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ArticuloLinea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LineaSet] DROP CONSTRAINT [FK_ArticuloLinea];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaLinea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LineaSet] DROP CONSTRAINT [FK_FacturaLinea];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioFactura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaSet] DROP CONSTRAINT [FK_UsuarioFactura];
GO
IF OBJECT_ID(N'[dbo].[FK_CadeteDelivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliverySet] DROP CONSTRAINT [FK_CadeteDelivery];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaDelivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaSet] DROP CONSTRAINT [FK_FacturaDelivery];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaNoMedicamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticuloSet_NoMedicamento] DROP CONSTRAINT [FK_CategoriaNoMedicamento];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaTarjeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaSet] DROP CONSTRAINT [FK_FacturaTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FK_NoMedicamento_inherits_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticuloSet_NoMedicamento] DROP CONSTRAINT [FK_NoMedicamento_inherits_Articulo];
GO
IF OBJECT_ID(N'[dbo].[FK_Medicamento_inherits_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticuloSet_Medicamento] DROP CONSTRAINT [FK_Medicamento_inherits_Articulo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ArticuloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticuloSet];
GO
IF OBJECT_ID(N'[dbo].[FacturaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacturaSet];
GO
IF OBJECT_ID(N'[dbo].[LineaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LineaSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[DeliverySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliverySet];
GO
IF OBJECT_ID(N'[dbo].[CadeteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CadeteSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[TarjetaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TarjetaSet];
GO
IF OBJECT_ID(N'[dbo].[ArticuloSet_NoMedicamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticuloSet_NoMedicamento];
GO
IF OBJECT_ID(N'[dbo].[ArticuloSet_Medicamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticuloSet_Medicamento];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArticuloSet'
CREATE TABLE [dbo].[ArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Marca] nvarchar(max)  NOT NULL,
    [CantidadEnStock] smallint  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FacturaSet'
CREATE TABLE [dbo].[FacturaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsuarioId] int  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [TarjetaId] int  NOT NULL,
    [PagoProcesado] bit  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [CanitidadRecetasBlancas] smallint  NOT NULL,
    [CantidadRecetasControladas] smallint  NOT NULL,
    [DescuentoAplicado] decimal(18,0)  NOT NULL,
    [Delivery_Id] int  NOT NULL
);
GO

-- Creating table 'LineaSet'
CREATE TABLE [dbo].[LineaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FacturaId] int  NOT NULL,
    [Cantidad] smallint  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Articulo_Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Roles] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DeliverySet'
CREATE TABLE [dbo].[DeliverySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [FechaEntregado] datetime  NULL,
    [FirmaRecibido] bit  NOT NULL,
    [Cadete_Id] int  NOT NULL
);
GO

-- Creating table 'CadeteSet'
CREATE TABLE [dbo].[CadeteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TarjetaSet'
CREATE TABLE [dbo].[TarjetaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Marca] nvarchar(max)  NOT NULL,
    [Descuento] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ArticuloSet_NoMedicamento'
CREATE TABLE [dbo].[ArticuloSet_NoMedicamento] (
    [CategoriaId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ArticuloSet_Medicamento'
CREATE TABLE [dbo].[ArticuloSet_Medicamento] (
    [Composicion] nvarchar(max)  NOT NULL,
    [Indicaciones] nvarchar(max)  NOT NULL,
    [Presentacion] nvarchar(max)  NOT NULL,
    [RequiereRecetaControlada] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [PK_ArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [PK_FacturaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LineaSet'
ALTER TABLE [dbo].[LineaSet]
ADD CONSTRAINT [PK_LineaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliverySet'
ALTER TABLE [dbo].[DeliverySet]
ADD CONSTRAINT [PK_DeliverySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CadeteSet'
ALTER TABLE [dbo].[CadeteSet]
ADD CONSTRAINT [PK_CadeteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TarjetaSet'
ALTER TABLE [dbo].[TarjetaSet]
ADD CONSTRAINT [PK_TarjetaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticuloSet_NoMedicamento'
ALTER TABLE [dbo].[ArticuloSet_NoMedicamento]
ADD CONSTRAINT [PK_ArticuloSet_NoMedicamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticuloSet_Medicamento'
ALTER TABLE [dbo].[ArticuloSet_Medicamento]
ADD CONSTRAINT [PK_ArticuloSet_Medicamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Articulo_Id] in table 'LineaSet'
ALTER TABLE [dbo].[LineaSet]
ADD CONSTRAINT [FK_ArticuloLinea]
    FOREIGN KEY ([Articulo_Id])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloLinea'
CREATE INDEX [IX_FK_ArticuloLinea]
ON [dbo].[LineaSet]
    ([Articulo_Id]);
GO

-- Creating foreign key on [FacturaId] in table 'LineaSet'
ALTER TABLE [dbo].[LineaSet]
ADD CONSTRAINT [FK_FacturaLinea]
    FOREIGN KEY ([FacturaId])
    REFERENCES [dbo].[FacturaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaLinea'
CREATE INDEX [IX_FK_FacturaLinea]
ON [dbo].[LineaSet]
    ([FacturaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [FK_UsuarioFactura]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioFactura'
CREATE INDEX [IX_FK_UsuarioFactura]
ON [dbo].[FacturaSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [Cadete_Id] in table 'DeliverySet'
ALTER TABLE [dbo].[DeliverySet]
ADD CONSTRAINT [FK_CadeteDelivery]
    FOREIGN KEY ([Cadete_Id])
    REFERENCES [dbo].[CadeteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CadeteDelivery'
CREATE INDEX [IX_FK_CadeteDelivery]
ON [dbo].[DeliverySet]
    ([Cadete_Id]);
GO

-- Creating foreign key on [Delivery_Id] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [FK_FacturaDelivery]
    FOREIGN KEY ([Delivery_Id])
    REFERENCES [dbo].[DeliverySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaDelivery'
CREATE INDEX [IX_FK_FacturaDelivery]
ON [dbo].[FacturaSet]
    ([Delivery_Id]);
GO

-- Creating foreign key on [CategoriaId] in table 'ArticuloSet_NoMedicamento'
ALTER TABLE [dbo].[ArticuloSet_NoMedicamento]
ADD CONSTRAINT [FK_CategoriaNoMedicamento]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaNoMedicamento'
CREATE INDEX [IX_FK_CategoriaNoMedicamento]
ON [dbo].[ArticuloSet_NoMedicamento]
    ([CategoriaId]);
GO

-- Creating foreign key on [TarjetaId] in table 'FacturaSet'
ALTER TABLE [dbo].[FacturaSet]
ADD CONSTRAINT [FK_FacturaTarjeta]
    FOREIGN KEY ([TarjetaId])
    REFERENCES [dbo].[TarjetaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaTarjeta'
CREATE INDEX [IX_FK_FacturaTarjeta]
ON [dbo].[FacturaSet]
    ([TarjetaId]);
GO

-- Creating foreign key on [Id] in table 'ArticuloSet_NoMedicamento'
ALTER TABLE [dbo].[ArticuloSet_NoMedicamento]
ADD CONSTRAINT [FK_NoMedicamento_inherits_Articulo]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ArticuloSet_Medicamento'
ALTER TABLE [dbo].[ArticuloSet_Medicamento]
ADD CONSTRAINT [FK_Medicamento_inherits_Articulo]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------