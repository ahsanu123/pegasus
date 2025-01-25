
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2010 01:20:55
-- Generated from EDMX file: c:\work\Sviluppo 4.0\ProveVarieSolution\CoolMvcBlog\BlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CoolMvcBlog];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PostSet'
CREATE TABLE [dbo].[PostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AuthorId] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [DatePublished] datetime  NOT NULL
);
GO

-- Creating table 'AuthorSet'
CREATE TABLE [dbo].[AuthorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PostCategory'
CREATE TABLE [dbo].[PostCategory] (
    [PostCategory_Category_Id] int  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [PK_PostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AuthorSet'
ALTER TABLE [dbo].[AuthorSet]
ADD CONSTRAINT [PK_AuthorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PostCategory_Category_Id], [Categories_Id] in table 'PostCategory'
ALTER TABLE [dbo].[PostCategory]
ADD CONSTRAINT [PK_PostCategory]
    PRIMARY KEY NONCLUSTERED ([PostCategory_Category_Id], [Categories_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AuthorId] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [FK_PostAuthor]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[AuthorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PostAuthor'
CREATE INDEX [IX_FK_PostAuthor]
ON [dbo].[PostSet]
    ([AuthorId]);
GO

-- Creating foreign key on [PostCategory_Category_Id] in table 'PostCategory'
ALTER TABLE [dbo].[PostCategory]
ADD CONSTRAINT [FK_PostCategory_Post]
    FOREIGN KEY ([PostCategory_Category_Id])
    REFERENCES [dbo].[PostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'PostCategory'
ALTER TABLE [dbo].[PostCategory]
ADD CONSTRAINT [FK_PostCategory_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PostCategory_Category'
CREATE INDEX [IX_FK_PostCategory_Category]
ON [dbo].[PostCategory]
    ([Categories_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------