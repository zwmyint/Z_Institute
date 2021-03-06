USE [Z_Institute]
GO
/****** Object:  Table [dbo].[tbl_Instructor]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Instructor](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](25) NULL,
	[FirstName] [nvarchar](max) NULL,
	[HireDate] [date] NOT NULL,
 CONSTRAINT [PK_tbl_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Instructor] ON
INSERT [dbo].[tbl_Instructor] ([InstructorId], [LastName], [FirstName], [HireDate]) VALUES (1, N'INS', N'Name 1', CAST(0xF9410B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_Instructor] OFF
/****** Object:  Table [dbo].[tbl_Student]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[EnrollmentDate] [date] NOT NULL,
 CONSTRAINT [PK_tbl_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OfficeAssignment]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OfficeAssignment](
	[InstructorId] [int] NOT NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_OfficeAssignment] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tbl_OfficeAssignment] ([InstructorId], [Location]) VALUES (1, N'Main Location')
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[Budget] [decimal](18, 2) NOT NULL,
	[InstructorId] [int] NULL,
 CONSTRAINT [PK_tbl_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Department] ON
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (1, N'Programming', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (2, N'Design', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (3, N'Network', CAST(0.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[tbl_Department] OFF
/****** Object:  Table [dbo].[tbl_Course]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[Credits] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Course] ON
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (1, N'C#', 8, 1)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (2, N'HTML', 8, 2)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (3, N'CCNA', 8, 3)
SET IDENTITY_INSERT [dbo].[tbl_Course] OFF
/****** Object:  Table [dbo].[tbl_Enrollment]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Enrollment](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CourseAssignment]    Script Date: 12/29/2020 23:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CourseAssignment](
	[InstructorId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_CourseAssignment] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[InstructorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_CourseAssignment] ([InstructorId], [CourseId]) VALUES (1, 1)
INSERT [dbo].[tbl_CourseAssignment] ([InstructorId], [CourseId]) VALUES (1, 2)
/****** Object:  Default [DF__tbl_Instr__HireD__014935CB]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Instructor] ADD  DEFAULT (getdate()) FOR [HireDate]
GO
/****** Object:  Default [DF__tbl_Stude__Enrol__0425A276]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT (getdate()) FOR [EnrollmentDate]
GO
/****** Object:  ForeignKey [FK_tbl_Course_tbl_Department_DepartmentId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Course_tbl_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tbl_Department] ([DepartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Course] CHECK CONSTRAINT [FK_tbl_Course_tbl_Department_DepartmentId]
GO
/****** Object:  ForeignKey [FK_tbl_CourseAssignment_tbl_Course_CourseId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_CourseAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CourseAssignment_tbl_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tbl_Course] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_CourseAssignment] CHECK CONSTRAINT [FK_tbl_CourseAssignment_tbl_Course_CourseId]
GO
/****** Object:  ForeignKey [FK_tbl_CourseAssignment_tbl_Instructor_InstructorId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_CourseAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CourseAssignment_tbl_Instructor_InstructorId] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_CourseAssignment] CHECK CONSTRAINT [FK_tbl_CourseAssignment_tbl_Instructor_InstructorId]
GO
/****** Object:  ForeignKey [FK_tbl_Department_tbl_Instructor_InstructorId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Department]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Department_tbl_Instructor_InstructorId] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[tbl_Department] CHECK CONSTRAINT [FK_tbl_Department_tbl_Instructor_InstructorId]
GO
/****** Object:  ForeignKey [FK_tbl_Enrollment_tbl_Course_CourseId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Enrollment_tbl_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tbl_Course] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Enrollment] CHECK CONSTRAINT [FK_tbl_Enrollment_tbl_Course_CourseId]
GO
/****** Object:  ForeignKey [FK_tbl_Enrollment_tbl_Student_StudentId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Enrollment_tbl_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[tbl_Student] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Enrollment] CHECK CONSTRAINT [FK_tbl_Enrollment_tbl_Student_StudentId]
GO
/****** Object:  ForeignKey [FK_tbl_OfficeAssignment_tbl_Instructor_InstructorId]    Script Date: 12/29/2020 23:35:30 ******/
ALTER TABLE [dbo].[tbl_OfficeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OfficeAssignment_tbl_Instructor_InstructorId] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_OfficeAssignment] CHECK CONSTRAINT [FK_tbl_OfficeAssignment_tbl_Instructor_InstructorId]
GO
