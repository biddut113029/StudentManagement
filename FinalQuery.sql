USE [master]
GO
/****** Object:  Database [myDB]    Script Date: 6/3/2018 5:02:25 PM ******/
CREATE DATABASE [myDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\myDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'myDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\myDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [myDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [myDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [myDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [myDB] SET  MULTI_USER 
GO
ALTER DATABASE [myDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [myDB]
GO
/****** Object:  StoredProcedure [dbo].[spAddCourse]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddCourse]         
(        
    @credit VARCHAR(20),        
    @semester VARCHAR(20),        

	@CourseID VARCHAR(6),
	@StudentID VARCHAR(6)      
)        
as         
Begin         
    Insert into tblCourse (Semester,Credit,StudentId, CourseID)         
    Values (@semester,@credit,Convert(int,@StudentID),Convert(int,@CourseID))         
End  




GO
/****** Object:  StoredProcedure [dbo].[spAddStudent]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddStudent]         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6) ,
	  @LastName VARCHAR(250) ,
	    @FatherName VARCHAR(250) ,
		  @MotherName VARCHAR(250), 
		    @ContactNo VARCHAR(10) ,
			  @Email VARCHAR(10)        
)        
as         
Begin         
    Insert into tblStudent (Name,City,Department, Gender,LastName,FatherName,MotherName,ContactNo,Email)         
    Values (@Name,@City,@Department, @Gender,@LastName,@FatherName,@MotherName,@ContactNo,@Email)         
End  



GO
/****** Object:  StoredProcedure [dbo].[spDeleteCourse]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spDeleteCourse]       
(        
   @CrsId int        
)        
as         
begin        
   Delete from tblCourse where ID=@CrsId        
End




GO
/****** Object:  StoredProcedure [dbo].[spDeleteStudent]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteStudent]       
(        
   @StdId int        
)        
as         
begin        
   Delete from tblStudent where StudentId=@StdId        
End



GO
/****** Object:  StoredProcedure [dbo].[spGetAllCourseNames]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spGetAllCourseNames]      
as      
Begin      
    select *      
    from tblCourseNames  
    order by CourseID    
End  





GO
/****** Object:  StoredProcedure [dbo].[spGetAllCourses]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetAllCourses]      
as      
Begin      
    select *      
    from tblCourse   
    order by CourseId      
End  




GO
/****** Object:  StoredProcedure [dbo].[spGetAllStudents]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllStudents]      
as      
Begin      
    select *      
    from tblStudent   
    order by StudentId      
End  



GO
/****** Object:  StoredProcedure [dbo].[spUpdateCourse]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spUpdateCourse]        
(        
   @ID INTEGER ,      
   @Credit VARCHAR(20),       
   @Semester VARCHAR(20),      
   @StudentID VARCHAR(6),      
   @CourseID VARCHAR(6)      
)        
as        
begin        
   Update tblCourse         
   set Credit=@Credit,        
   Semester =@Semester,        
   StudentId=Convert(int,@StudentID),      
   CourseID=Convert(int,@CourseID)        
   where CourseId=@ID       
End   





GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudent]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spUpdateStudent]        
(        
   @StdId INTEGER ,      
   @Name VARCHAR(20),       
   @City VARCHAR(20),      
   @Department VARCHAR(20),      
   @Gender VARCHAR(6) ,
   	  @LastName VARCHAR(250) ,
	    @FatherName VARCHAR(250) ,
		  @MotherName VARCHAR(250), 
		    @ContactNo VARCHAR(10) ,
			  @Email VARCHAR(10)       
)        
as        
begin        
   Update tblStudent         
	set Name=@Name,        
	City=@City,        
	Department=@Department,      
	Gender=@Gender  ,      
	LastName = @LastName ,   
	FatherName=@FatherName ,      
	MotherName=@MotherName ,     
	ContactNo=@ContactNo  ,    
	Email =@Email       
   where StudentId=@StdId        
End   



GO
/****** Object:  Table [dbo].[tblCourse]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCourse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Semester] [varchar](20) NOT NULL,
	[Credit] [varchar](20) NOT NULL,
	[StudentId] [int] NULL,
	[CourseID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCourseNames]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseNames](
	[CourseID] [int] NOT NULL,
	[Code] [nchar](20) NULL,
	[Name] [nchar](250) NULL,
	[Credit] [nchar](10) NULL,
 CONSTRAINT [PK_tblCourseNames] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 6/3/2018 5:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblStudent](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[Department] [varchar](20) NOT NULL,
	[Gender] [varchar](6) NOT NULL,
	[LastName] [nchar](250) NULL,
	[FatherName] [nchar](250) NULL,
	[MotherName] [nchar](250) NULL,
	[ContactNo] [nchar](10) NULL,
	[Email] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [myDB] SET  READ_WRITE 
GO
