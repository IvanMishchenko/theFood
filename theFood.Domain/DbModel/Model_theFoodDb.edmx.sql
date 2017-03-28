
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2017 14:56:24
-- Generated from EDMX file: C:\Users\Ivan\Documents\theFood\theFood.Domain\DbModel\Model_theFoodDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FoodDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RecipeCategoryRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeSet] DROP CONSTRAINT [FK_RecipeCategoryRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_EatingTimeRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeSet] DROP CONSTRAINT [FK_EatingTimeRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_UserComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_UserComment];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_CommentRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProductProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_CategoryProductProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_IngridientProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngridientSet] DROP CONSTRAINT [FK_IngridientProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_IngridientRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngridientSet] DROP CONSTRAINT [FK_IngridientRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecipeUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRecipeSet] DROP CONSTRAINT [FK_UserRecipeUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecipeRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRecipeSet] DROP CONSTRAINT [FK_UserRecipeRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPostUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPostSet] DROP CONSTRAINT [FK_UserPostUser];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriberUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberSet] DROP CONSTRAINT [FK_SubscriberUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentUserPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_CommentUserPost];
GO
IF OBJECT_ID(N'[dbo].[FK_PictureRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PictureSet] DROP CONSTRAINT [FK_PictureRecipe];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFavoritRecipeUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFavoritRecipeSet] DROP CONSTRAINT [FK_UserFavoritRecipeUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFavoritRecipeRecipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFavoritRecipeSet] DROP CONSTRAINT [FK_UserFavoritRecipeRecipe];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[RecipeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipeSet];
GO
IF OBJECT_ID(N'[dbo].[CategoryRecipeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryRecipeSet];
GO
IF OBJECT_ID(N'[dbo].[EatingTimeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EatingTimeSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[CategoryProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryProductSet];
GO
IF OBJECT_ID(N'[dbo].[IngridientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngridientSet];
GO
IF OBJECT_ID(N'[dbo].[UserRecipeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRecipeSet];
GO
IF OBJECT_ID(N'[dbo].[UserPostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPostSet];
GO
IF OBJECT_ID(N'[dbo].[SubscriberSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriberSet];
GO
IF OBJECT_ID(N'[dbo].[PictureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PictureSet];
GO
IF OBJECT_ID(N'[dbo].[UserFavoritRecipeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserFavoritRecipeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Age] int  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NULL,
    [ConfirmPerson] bit  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Photo] tinyint  NULL
);
GO

-- Creating table 'RecipeSet'
CREATE TABLE [dbo].[RecipeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [LikeDislike] int  NOT NULL,
    [RatingRecipe] int  NOT NULL,
    [CookingTime] datetime  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [CategoryRecipeId] int  NOT NULL,
    [EatingTimeId] int  NOT NULL,
    [UniqueName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoryRecipeSet'
CREATE TABLE [dbo].[CategoryRecipeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EatingTimeSet'
CREATE TABLE [dbo].[EatingTimeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [RecipeId] int  NOT NULL,
    [UserPostId] int  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PriceOnProduct] decimal(18,0)  NULL,
    [Description] nvarchar(max)  NULL,
    [CategoryProductId] int  NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ImageName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoryProductSet'
CREATE TABLE [dbo].[CategoryProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'IngridientSet'
CREATE TABLE [dbo].[IngridientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [RecipeId] int  NOT NULL
);
GO

-- Creating table 'UserRecipeSet'
CREATE TABLE [dbo].[UserRecipeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [RecipeId] int  NOT NULL
);
GO

-- Creating table 'UserPostSet'
CREATE TABLE [dbo].[UserPostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL
);
GO

-- Creating table 'SubscriberSet'
CREATE TABLE [dbo].[SubscriberSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [UserSubscriberID] int  NOT NULL
);
GO

-- Creating table 'PictureSet'
CREATE TABLE [dbo].[PictureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PictureFile] tinyint  NOT NULL,
    [RecipeId] int  NOT NULL
);
GO

-- Creating table 'UserFavoritRecipeSet'
CREATE TABLE [dbo].[UserFavoritRecipeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [RecipeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipeSet'
ALTER TABLE [dbo].[RecipeSet]
ADD CONSTRAINT [PK_RecipeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryRecipeSet'
ALTER TABLE [dbo].[CategoryRecipeSet]
ADD CONSTRAINT [PK_CategoryRecipeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EatingTimeSet'
ALTER TABLE [dbo].[EatingTimeSet]
ADD CONSTRAINT [PK_EatingTimeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryProductSet'
ALTER TABLE [dbo].[CategoryProductSet]
ADD CONSTRAINT [PK_CategoryProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IngridientSet'
ALTER TABLE [dbo].[IngridientSet]
ADD CONSTRAINT [PK_IngridientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserRecipeSet'
ALTER TABLE [dbo].[UserRecipeSet]
ADD CONSTRAINT [PK_UserRecipeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserPostSet'
ALTER TABLE [dbo].[UserPostSet]
ADD CONSTRAINT [PK_UserPostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubscriberSet'
ALTER TABLE [dbo].[SubscriberSet]
ADD CONSTRAINT [PK_SubscriberSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [PK_PictureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserFavoritRecipeSet'
ALTER TABLE [dbo].[UserFavoritRecipeSet]
ADD CONSTRAINT [PK_UserFavoritRecipeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryRecipeId] in table 'RecipeSet'
ALTER TABLE [dbo].[RecipeSet]
ADD CONSTRAINT [FK_RecipeCategoryRecipe]
    FOREIGN KEY ([CategoryRecipeId])
    REFERENCES [dbo].[CategoryRecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecipeCategoryRecipe'
CREATE INDEX [IX_FK_RecipeCategoryRecipe]
ON [dbo].[RecipeSet]
    ([CategoryRecipeId]);
GO

-- Creating foreign key on [EatingTimeId] in table 'RecipeSet'
ALTER TABLE [dbo].[RecipeSet]
ADD CONSTRAINT [FK_EatingTimeRecipe]
    FOREIGN KEY ([EatingTimeId])
    REFERENCES [dbo].[EatingTimeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EatingTimeRecipe'
CREATE INDEX [IX_FK_EatingTimeRecipe]
ON [dbo].[RecipeSet]
    ([EatingTimeId]);
GO

-- Creating foreign key on [UserId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_UserComment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComment'
CREATE INDEX [IX_FK_UserComment]
ON [dbo].[CommentSet]
    ([UserId]);
GO

-- Creating foreign key on [RecipeId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CommentRecipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[RecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentRecipe'
CREATE INDEX [IX_FK_CommentRecipe]
ON [dbo].[CommentSet]
    ([RecipeId]);
GO

-- Creating foreign key on [CategoryProductId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_CategoryProductProduct]
    FOREIGN KEY ([CategoryProductId])
    REFERENCES [dbo].[CategoryProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProductProduct'
CREATE INDEX [IX_FK_CategoryProductProduct]
ON [dbo].[ProductSet]
    ([CategoryProductId]);
GO

-- Creating foreign key on [ProductId] in table 'IngridientSet'
ALTER TABLE [dbo].[IngridientSet]
ADD CONSTRAINT [FK_IngridientProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngridientProduct'
CREATE INDEX [IX_FK_IngridientProduct]
ON [dbo].[IngridientSet]
    ([ProductId]);
GO

-- Creating foreign key on [RecipeId] in table 'IngridientSet'
ALTER TABLE [dbo].[IngridientSet]
ADD CONSTRAINT [FK_IngridientRecipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[RecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngridientRecipe'
CREATE INDEX [IX_FK_IngridientRecipe]
ON [dbo].[IngridientSet]
    ([RecipeId]);
GO

-- Creating foreign key on [UserId] in table 'UserRecipeSet'
ALTER TABLE [dbo].[UserRecipeSet]
ADD CONSTRAINT [FK_UserRecipeUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecipeUser'
CREATE INDEX [IX_FK_UserRecipeUser]
ON [dbo].[UserRecipeSet]
    ([UserId]);
GO

-- Creating foreign key on [RecipeId] in table 'UserRecipeSet'
ALTER TABLE [dbo].[UserRecipeSet]
ADD CONSTRAINT [FK_UserRecipeRecipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[RecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecipeRecipe'
CREATE INDEX [IX_FK_UserRecipeRecipe]
ON [dbo].[UserRecipeSet]
    ([RecipeId]);
GO

-- Creating foreign key on [UserId] in table 'UserPostSet'
ALTER TABLE [dbo].[UserPostSet]
ADD CONSTRAINT [FK_UserPostUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPostUser'
CREATE INDEX [IX_FK_UserPostUser]
ON [dbo].[UserPostSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'SubscriberSet'
ALTER TABLE [dbo].[SubscriberSet]
ADD CONSTRAINT [FK_SubscriberUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriberUser'
CREATE INDEX [IX_FK_SubscriberUser]
ON [dbo].[SubscriberSet]
    ([UserId]);
GO

-- Creating foreign key on [UserPostId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CommentUserPost]
    FOREIGN KEY ([UserPostId])
    REFERENCES [dbo].[UserPostSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentUserPost'
CREATE INDEX [IX_FK_CommentUserPost]
ON [dbo].[CommentSet]
    ([UserPostId]);
GO

-- Creating foreign key on [RecipeId] in table 'PictureSet'
ALTER TABLE [dbo].[PictureSet]
ADD CONSTRAINT [FK_PictureRecipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[RecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PictureRecipe'
CREATE INDEX [IX_FK_PictureRecipe]
ON [dbo].[PictureSet]
    ([RecipeId]);
GO

-- Creating foreign key on [UserId] in table 'UserFavoritRecipeSet'
ALTER TABLE [dbo].[UserFavoritRecipeSet]
ADD CONSTRAINT [FK_UserFavoritRecipeUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFavoritRecipeUser'
CREATE INDEX [IX_FK_UserFavoritRecipeUser]
ON [dbo].[UserFavoritRecipeSet]
    ([UserId]);
GO

-- Creating foreign key on [RecipeId] in table 'UserFavoritRecipeSet'
ALTER TABLE [dbo].[UserFavoritRecipeSet]
ADD CONSTRAINT [FK_UserFavoritRecipeRecipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[RecipeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFavoritRecipeRecipe'
CREATE INDEX [IX_FK_UserFavoritRecipeRecipe]
ON [dbo].[UserFavoritRecipeSet]
    ([RecipeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------