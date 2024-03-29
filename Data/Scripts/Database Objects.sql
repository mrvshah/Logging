USE [Logging]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/26/2011 23:03:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Machine] [nvarchar](100) NOT NULL,
	[ThreadName] [nvarchar](100) NOT NULL,
	[Application] [nvarchar](100) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](250) NOT NULL,
	[Method] [nvarchar](250) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[ExceptionData] [nvarchar](250) NULL,
	[Inserted] [datetime] NOT NULL,
 CONSTRAINT [PK_Log_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spLogInsert]    Script Date: 12/26/2011 23:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLogInsert]
(
	@Created NVARCHAR(100),
	@Machine NVARCHAR(100),
	@ThreadName NVARCHAR(100),
	@Application NVARCHAR(100),
	@Level NVARCHAR(50),
	@Type NVARCHAR(250),
	@Method NVARCHAR(250),
	@Message NVARCHAR(MAX),
	@Exception NVARCHAR(MAX),
	@ExceptionData NVARCHAR(250)
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	INSERT INTO [Logging].[dbo].[Log] 
	(
		[Created],
		[Machine],
		[ThreadName],
		[Application],
		[Level],
		[Type],
		[Method],
		[Message],
		[Exception],
		[ExceptionData],
		[Inserted]
	) 
	VALUES 
	(
		CONVERT(DATETIME, REPLACE(@Created, ',', '.'), 21),
		@Machine,
		@ThreadName,
		@Application,
		@Level,
		@Type,
		@Method,
		@Message,
		@Exception,
		@ExceptionData,
		GETUTCDATE()
	)
	
END
GO
