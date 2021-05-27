USE [CoreDb]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 27-May-21 1:49:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Email]    Script Date: 27-May-21 1:49:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Email](
	[Id] [int] NOT NULL,
	[From_Email] [nvarchar](255) NOT NULL,
	[To_Email] [nvarchar](255) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Email_Date] [datetime] NOT NULL,
	[Status] [varchar](max) NULL,
	[CreatedOn] [varchar](max) NULL,
	[CreatedBy] [varchar](max) NULL,
	[ModifiedOn] [varchar](max) NULL,
	[ModifiedBy] [varchar](max) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO