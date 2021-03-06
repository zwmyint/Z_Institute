USE [Z_Institute]
GO
/****** Object:  Table [dbo].[tbl_Instructor]    Script Date: 12/27/2020 23:53:16 ******/
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
INSERT [dbo].[tbl_Instructor] ([InstructorId], [LastName], [FirstName], [HireDate]) VALUES (1, N'Instructor N 1', N'Name 1', CAST(0xE9410B00 AS Date))
INSERT [dbo].[tbl_Instructor] ([InstructorId], [LastName], [FirstName], [HireDate]) VALUES (2, N'Instructor N 2', N'Name 2', CAST(0xEE410B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_Instructor] OFF
/****** Object:  Table [dbo].[tbl_Student]    Script Date: 12/27/2020 23:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EnrollmentDate] [date] NOT NULL,
	[Gender] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Student] ON
INSERT [dbo].[tbl_Student] ([StudentId], [FirstName], [LastName], [EnrollmentDate], [Gender]) VALUES (1, N'A Student A', N'Name A', CAST(0xF3410B00 AS Date), 1)
INSERT [dbo].[tbl_Student] ([StudentId], [FirstName], [LastName], [EnrollmentDate], [Gender]) VALUES (2, N'B Student B', N'Name B', CAST(0xEE410B00 AS Date), 2)
INSERT [dbo].[tbl_Student] ([StudentId], [FirstName], [LastName], [EnrollmentDate], [Gender]) VALUES (3, N'C Student C', N'Name C', CAST(0xF9410B00 AS Date), 1)
INSERT [dbo].[tbl_Student] ([StudentId], [FirstName], [LastName], [EnrollmentDate], [Gender]) VALUES (4, N'D New Student D', N'Name D', CAST(0xF9410B00 AS Date), 2)
SET IDENTITY_INSERT [dbo].[tbl_Student] OFF
/****** Object:  Table [dbo].[tbl_OfficeAssignment]    Script Date: 12/27/2020 23:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OfficeAssignment](
	[OfficeAssignmentId] [int] NOT NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_OfficeAssignment] PRIMARY KEY CLUSTERED 
(
	[OfficeAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tbl_OfficeAssignment] ([OfficeAssignmentId], [Location]) VALUES (1, N'HQ')
INSERT [dbo].[tbl_OfficeAssignment] ([OfficeAssignmentId], [Location]) VALUES (2, N'Location 1')
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 12/27/2020 23:53:16 ******/
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
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (1, N'Programming', CAST(1800.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (2, N'Design', CAST(1200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (3, N'Network', CAST(1500.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[tbl_Department] ([DepartmentId], [DepartmentName], [Budget], [InstructorId]) VALUES (7, N'Cloud', CAST(2000.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[tbl_Department] OFF
/****** Object:  Table [dbo].[tbl_Course]    Script Date: 12/27/2020 23:53:16 ******/
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
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (2, N'PhotoShop', 10, 2)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (3, N'CCNA', 8, 3)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (4, N'JavaScript', 10, 1)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (5, N'PHP', 10, 1)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (6, N'Fusion 360', 6, 2)
INSERT [dbo].[tbl_Course] ([CourseId], [CourseName], [Credits], [DepartmentId]) VALUES (7, N'AWS', 30, 7)
SET IDENTITY_INSERT [dbo].[tbl_Course] OFF
/****** Object:  Table [dbo].[tbl_Enrollment]    Script Date: 12/27/2020 23:53:16 ******/
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
SET IDENTITY_INSERT [dbo].[tbl_Enrollment] ON
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (1, 2, 1, 1)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (2, 3, 1, 2)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (3, 1, 2, 3)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (4, 2, 1, 4)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (5, 3, 3, 3)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (6, 2, 3, 6)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (7, 3, 2, 7)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (8, 2, 3, 7)
INSERT [dbo].[tbl_Enrollment] ([EnrollmentId], [Grade], [StudentId], [CourseId]) VALUES (9, 4, 3, 4)
SET IDENTITY_INSERT [dbo].[tbl_Enrollment] OFF
/****** Object:  Table [dbo].[tbl_CourseAssignment]    Script Date: 12/27/2020 23:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CourseAssignment](
	[CourseAssignmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_CourseAssignment] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[CourseAssignmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_CourseAssignment] ([CourseAssignmentId], [CourseId]) VALUES (1, 1)
INSERT [dbo].[tbl_CourseAssignment] ([CourseAssignmentId], [CourseId]) VALUES (1, 3)
INSERT [dbo].[tbl_CourseAssignment] ([CourseAssignmentId], [CourseId]) VALUES (1, 5)
INSERT [dbo].[tbl_CourseAssignment] ([CourseAssignmentId], [CourseId]) VALUES (2, 5)
/****** Object:  Default [DF__tbl_Instr__HireD__0DAF0CB0]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Instructor] ADD  DEFAULT (getdate()) FOR [HireDate]
GO
/****** Object:  Default [DF__tbl_Stude__Enrol__03317E3D]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT (getdate()) FOR [EnrollmentDate]
GO
/****** Object:  Default [DF__tbl_Stude__Gende__07020F21]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT ((0)) FOR [Gender]
GO
/****** Object:  ForeignKey [FK_tbl_Course_tbl_Department_DepartmentId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Course_tbl_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tbl_Department] ([DepartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Course] CHECK CONSTRAINT [FK_tbl_Course_tbl_Department_DepartmentId]
GO
/****** Object:  ForeignKey [FK_tbl_CourseAssignment_tbl_Course_CourseId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_CourseAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CourseAssignment_tbl_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tbl_Course] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_CourseAssignment] CHECK CONSTRAINT [FK_tbl_CourseAssignment_tbl_Course_CourseId]
GO
/****** Object:  ForeignKey [FK_tbl_CourseAssignment_tbl_Instructor_CourseAssignmentId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_CourseAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CourseAssignment_tbl_Instructor_CourseAssignmentId] FOREIGN KEY([CourseAssignmentId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_CourseAssignment] CHECK CONSTRAINT [FK_tbl_CourseAssignment_tbl_Instructor_CourseAssignmentId]
GO
/****** Object:  ForeignKey [FK_tbl_Department_tbl_Instructor_InstructorId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Department]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Department_tbl_Instructor_InstructorId] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[tbl_Department] CHECK CONSTRAINT [FK_tbl_Department_tbl_Instructor_InstructorId]
GO
/****** Object:  ForeignKey [FK_tbl_Enrollment_tbl_Course_CourseId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Enrollment_tbl_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tbl_Course] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Enrollment] CHECK CONSTRAINT [FK_tbl_Enrollment_tbl_Course_CourseId]
GO
/****** Object:  ForeignKey [FK_tbl_Enrollment_tbl_Student_StudentId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Enrollment_tbl_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[tbl_Student] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Enrollment] CHECK CONSTRAINT [FK_tbl_Enrollment_tbl_Student_StudentId]
GO
/****** Object:  ForeignKey [FK_tbl_OfficeAssignment_tbl_Instructor_OfficeAssignmentId]    Script Date: 12/27/2020 23:53:16 ******/
ALTER TABLE [dbo].[tbl_OfficeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OfficeAssignment_tbl_Instructor_OfficeAssignmentId] FOREIGN KEY([OfficeAssignmentId])
REFERENCES [dbo].[tbl_Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_OfficeAssignment] CHECK CONSTRAINT [FK_tbl_OfficeAssignment_tbl_Instructor_OfficeAssignmentId]
GO
