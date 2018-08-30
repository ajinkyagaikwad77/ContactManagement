USE [master]
GO
/****** Object:  Database [ContactDB]    Script Date: 08/27/2018 07:22:05 ******/
CREATE DATABASE [ContactDB]
GO
ALTER DATABASE [ContactDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ContactDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ContactDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ContactDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ContactDB] SET ARITHABORT OFF
GO
ALTER DATABASE [ContactDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ContactDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ContactDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ContactDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ContactDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ContactDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ContactDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ContactDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ContactDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ContactDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ContactDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [ContactDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ContactDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ContactDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ContactDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ContactDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ContactDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ContactDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ContactDB] SET  READ_WRITE
GO
ALTER DATABASE [ContactDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ContactDB] SET  MULTI_USER
GO
ALTER DATABASE [ContactDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ContactDB] SET DB_CHAINING OFF
GO
USE [ContactDB]
GO
/****** Object:  Table [dbo].[ContactTB]    Script Date: 08/27/2018 07:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactTB](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Status] bit NULL,	
 CONSTRAINT [PK_ContactTB] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sprocContactTBsSelectSingleItem]    Script Date: 08/27/2018 07:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sprocContactTBsSelectSingleItem]
@ContactID int
as
begin
select 
ContactID,
FirstName,
LastName,
Email,
Status,
PhoneNumber
from ContactTB where ContactID =@ContactID
end
GO
/****** Object:  StoredProcedure [dbo].[sprocContactTBSelectList]    Script Date: 08/27/2018 07:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sprocContactTBSelectList]
as
begin
select 
ContactID,
FirstName,
LastName,
Email,
Status,
PhoneNumber
from ContactTB 
end
GO
/****** Object:  StoredProcedure [dbo].[sprocContactTBInsertUpdateSingleItem]    Script Date: 08/27/2018 07:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[sprocContactTBInsertUpdateSingleItem]  
@ContactID int,  
@FirstName varchar(50),  
@LastName varchar(50),  
@Email varchar(50),  
@Status varchar(50),  
@PhoneNumber varchar(10)  
as  
  
begin  
  
if(@ContactID = 0)  
begin  
Insert into ContactTB  
(  
FirstName,  
LastName,  
Email,  
Status,  
PhoneNumber  
)  
values  
(  
@FirstName,  
@LastName,  
@Email,  
@Status,  
@PhoneNumber  
)  
end  
else   
begin  
Update ContactTB  
set   
FirstName =@FirstName,  
LastName = @LastName,  
Email= @Email,  
Status =@Status,  
PhoneNumber =@PhoneNumber  
where ContactID=@ContactID  
end  
end
GO
/****** Object:  StoredProcedure [dbo].[sprocContactTBDeleteSingleItem]    Script Date: 08/27/2018 07:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sprocContactTBDeleteSingleItem]
@ContactID int
as
begin
Delete from ContactTB where ContactID =@ContactID
end
GO
