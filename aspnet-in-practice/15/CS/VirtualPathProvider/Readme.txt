Run this script to create the table in your database:

USE [virtualfilesystem]
GO
/****** Object:  Table [dbo].[VirtualFiles]    Script Date: 06/30/2009 12:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VirtualFiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VirtualPath] [varchar](900) NOT NULL,
	[Contents] [varchar](max) NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_VirtualFiles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_VirtualFiles] UNIQUE NONCLUSTERED 
(
	[VirtualPath] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

then modify web.config to include your own connection string.

--
A sample record to insert:
VirtualPath: ~/Virtual/test.aspx
Contents: 
<%@Page Language="C#"%>
This is a test page.

<SCRIPT RUNAT="server">
void Page_Load()
{
	Response.Write("this is a piece of code");
}
</SCRIPT>