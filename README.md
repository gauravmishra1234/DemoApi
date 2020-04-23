# DemoApi
demo in Asp.netcore 3.0 and Angular 8
First run this command for create the DataBase: create database DemoDB 
after creating DataBase execute PreDeployment.sql from DB folder. 
after completion of pre script then execute PostDeployment.sql 
open api solution in visualstudio 2019 make sure asp.net core 3.0 is installed 
change Data Source name in appsetting.json file "DBConnection": "Data Source=4895PV2\SQLEXPRESS;Initial Catalog=DemoDB;Integrated Security=True" 
First build and run the api solution pressing F5 button. 
Make sure angular 8 is installed on PC. 
download the ui project and open in visual studio code and run below command on terminal 
npm i 
after run above command run below command 
npm start 
copy and paste below url on browser http://localhost:4200/ your application will start.


--
================SQL SCript===============
--=============Start PreDeployment.sql=========================
--create database DemoDB
USE [DemoDB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/22/2020 11:57:41 PM ******/
if exists (select * from [DemoDB].sys.tables where name = 'User')
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/22/2020 11:57:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
truncate table [dbo].[User]
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'Ashish', N'Sahu', N'8744991785', N'asahu@gmail.com', 1, CAST(N'2020-04-22T00:37:40.870' AS DateTime), 1, CAST(N'2020-04-22T09:48:27.573' AS DateTime), 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'Keshav', N'Singh', N'1234567890', N'Keshav@gmail.com', 1, CAST(N'2020-04-22T05:34:33.780' AS DateTime), 1, CAST(N'2020-04-22T09:48:23.773' AS DateTime), 2)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, N'Gaurav', N'Mishra', N'4444444888', N'gmishra@gmail.com', 0, CAST(N'2020-04-22T09:19:54.137' AS DateTime), 0, CAST(N'2020-04-22T09:50:33.493' AS DateTime), 3)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'adfaafaadsf', N'adfa', N'99999999', N'ashish@gmail.com', 1, CAST(N'2020-04-22T09:21:08.027' AS DateTime), 0, CAST(N'2020-04-22T09:48:31.847' AS DateTime), 4)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Gaurav', N'Mishra', N'44444444999', N'gmishra@gmail.com', 0, CAST(N'2020-04-22T09:49:17.983' AS DateTime), 0, CAST(N'2020-04-22T09:57:19.460' AS DateTime), 5)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [PhoneNumber], [Email], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, N'gjgjhgjhg', N'jygjyghg', N'99999999', N'45667@gmail.com', 1, CAST(N'2020-04-22T09:49:43.403' AS DateTime), 0, CAST(N'2020-04-22T09:49:43.403' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[User] OFF
--========================END PreDeployment.sql==================================

--==================Start PostDeployment.sql ===============================
USE [DemoDB]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('AddUserDetails'))
BEGIN
    DROP PROCEDURE AddUserDetails
END
/****** Object:  StoredProcedure [dbo].[AddUserDetails]    Script Date: 4/22/2020 11:37:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddUserDetails] (
@FirstName varchar(30),
@LastName varchar(30),
@PhoneNumber nvarchar(20),
@Email nvarchar(100),
@IsActive bit,
@CreatedBy int,
@UpdatedBy int,
@returnValue int OUTPUT
)
AS
BEGIN
       Declare @UserId int;

BEGIN TRY
       
       IF NOT EXISTS (SELECT TOP 1 1 FROM [USER] WHERE [Email] = @Email)
       BEGIN
	   
				  INSERT INTO [USER] (
									 [FirstName]
								   , [LastName]
								   , [PhoneNumber]
								   , [Email]
								   , [IsActive]
								   , [CreatedDate]
								   , [CreatedBy]
								   , [UpdatedDate]
								   , [UpdatedBy]
								 )
					VALUES (@FirstName,@LastName,@PhoneNumber,@Email,@IsActive, getdate(),@CreatedBy,getDate(),@UpdatedBy)

					SELECT @userId=SCOPE_IDENTITY();
         
				SELECT @returnValue = 1;  --If Record inserted successfully
	   
				
  END
	  ELSE
	  BEGIN
		 SELECT  @returnValue = 2;  ---If Email Exist
	  END
END TRY
BEGIN CATCH
  SELECT @returnValue = 0;  --If any error
END CATCH
END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('GetAllUser'))
BEGIN
    DROP PROCEDURE GetAllUser
END
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 4/22/2020 11:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllUser]
as
Begin 
   select u.UserID,u.FirstName,u.LastName,u.PhoneNumber,u.Email,u.IsActive,u.CreatedDate,u.CreatedBy,u.UpdatedDate,u.UpdatedBy
   from [User] u where u.IsActive=1
END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('GetUserProfileByUserID'))
BEGIN
    DROP PROCEDURE GetUserProfileByUserID
END
/****** Object:  StoredProcedure [dbo].[GetUserProfileByUserID]    Script Date: 4/22/2020 11:49:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetUserProfileByUserID] --1
@UserID INTEGER=NULL
as
Begin 
   select u.UserID,u.FirstName,u.LastName,u.PhoneNumber,u.Email,u.IsActive,u.CreatedDate,u.CreatedBy,u.UpdatedDate,u.UpdatedBy
   from [User] u where u.UserID=@UserID and u.IsActive=1
END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('UpdateUserDetails'))
BEGIN
    DROP PROCEDURE UpdateUserDetails
END

/****** Object:  StoredProcedure [dbo].[UpdateUserDetails]    Script Date: 4/22/2020 11:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateUserDetails] 
(
@UserID int,
@FirstName varchar(30),
@LastName varchar(30),
@PhoneNumber nvarchar(20),
@Email nvarchar(100),
@IsActive bit,
@CreatedBy int,
@UpdatedBy int,
@returnValue int OUTPUT
)
AS
BEGIN  

       Declare @RecordCount int;
       Declare @Account int;
       Declare @Count int;
       set @Count=1
 BEGIN TRY

   IF EXISTS (SELECT TOP 1 1 FROM [USER] WHERE [Email] = @Email)
BEGIN 
	            Update [USER] SET
                [FirstName]=@FirstName
              , [LastName]=@LastName
              , [PhoneNumber]=@PhoneNumber
              , [Email]=@Email
			  , [IsActive]=@IsActive
              --, [CreatedDate]=getdate() 
			  --, [CreatedBy]=@CreatedBy
			  , [UpdatedDate]=getdate() 
			  ,[UpdatedBy]=@UpdatedBy
               where [UserID]=@UserID      
                             	    
              SELECT @returnValue = 1; --If Record updated successfully
      END
   ELSE 
   Begin 
		   Declare @UserIDChk int = 0;
		   select @UserIDChk=isnull(userid,0) FROM [USER] WHERE [Email]=@Email		

		    IF @UserIDChk<>@UserId
			BEGIN 
	            Update [USER] SET
                [FirstName]=@FirstName
              , [LastName]=@LastName
              , [PhoneNumber]=@PhoneNumber
              , [Email]=@Email
			  , [IsActive]=@IsActive
              --, [CreatedDate]=getdate() 
			  --, [CreatedBy]=@CreatedBy
			  , [UpdatedDate]=getdate() 
			  ,[UpdatedBy]=@UpdatedBy
                where [UserID]=@UserID  

		    SELECT @returnValue = 1; --If Record updated successfully

		   END
   End  

END TRY
BEGIN CATCH
  SELECT @returnValue = 0;  --If any error
END CATCH
	 
END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('DeleteUserDetails'))
BEGIN
    DROP PROCEDURE DeleteUserDetails
END
/****** Object:  StoredProcedure [dbo].[DeleteUserDetails]    Script Date: 4/22/2020 11:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteUserDetails] 
(
@UserID int,
@UpdatedBy int,
@returnValue int OUTPUT
)
AS
BEGIN  
       Declare @Count int;
       set @Count=1
 BEGIN TRY

   IF EXISTS (SELECT TOP 1 1 FROM [USER] WHERE UserID<>0)
	BEGIN 
	            Update [USER] SET
			      [IsActive]=0
              --, [CreatedDate]=getdate() 
			  --, [CreatedBy]=@CreatedBy
			  , [UpdatedDate]=getdate() 
			  ,[UpdatedBy]=@UpdatedBy
               where [UserID]=@UserID      
                             	    
              SELECT @returnValue = 1; --If Record updated successfully
      END 

END TRY
BEGIN CATCH
  SELECT @returnValue = 0;  --If any error
END CATCH
	 
END
GO
--=====================================END PostDeployment.sql=============================


