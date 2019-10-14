USE [Task]
GO

/****** Object:  Table [dbo].[Redemption]    Script Date: 10/10/2019 10:08:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Redemption](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coupon_id] [int] NOT NULL,
	[coupon_amount] [money] NULL,
	[redemption_date] [date] NULL,
 CONSTRAINT [PK_Redemption] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE nonclustered index redemption_index on [dbo].[Redemption]([redemption_date])
GO

 
alter table [Redemption] add constraint fk_redemption_id foreign key(coupon_id) references [Coupon](id) on update cascade on delete cascade;
GO