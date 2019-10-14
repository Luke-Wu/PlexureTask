USE [Task]
GO

/****** Object:  Table [dbo].[Coupon]    Script Date: 10/10/2019 9:42:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coupon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[money] [money] NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[status] [int] NULL,
	[number_per] [int] NULL,
	[number_all] [int] NULL,
 CONSTRAINT [PK_Coupon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

create nonclustered index coupon_index on [dbo].[Coupon]([status])

GO



