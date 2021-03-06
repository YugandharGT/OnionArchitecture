USE [CoreDb]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 22-Mar-20 12:05:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Name] [varchar](300) NULL,
	[Email] [varchar](300) NULL,
	[Department] [varchar](150) NULL,
	[Created] [varchar](150) NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Email], [Department], [Created], [CreatedOn]) VALUES (1000, N'Yugandhar T', N'yugan@gmail.com', N'IT', N'Yugandhar ThirugnanaSambandam', CAST(N'2019-10-11T07:58:47.990' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Department], [Created], [CreatedOn]) VALUES (1001, N'Ajith Kumar', N'Ajith@gmail.com', N'IT', N'Yugandhar ThirugnanaSambandam', CAST(N'2019-10-11T08:00:15.353' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Department], [Created], [CreatedOn]) VALUES (1002, N'Hari Kumar', N'Hari@gmail.com', N'Law', N'Yugandhar ThirugnanaSambandam', CAST(N'2019-10-11T08:00:15.403' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Email], [Department], [Created], [CreatedOn]) VALUES (2003, N'James', N'James@gmail.com', N'Medicine', NULL, CAST(N'2019-12-15T22:24:26.130' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
