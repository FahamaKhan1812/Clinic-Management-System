USE [master]
GO
CREATE DATABASE [CMS]
 CONTAINMENT = NONE
begin
EXEC [CMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS] SET RECOVERY FULL 
GO
ALTER DATABASE [CMS] SET  MULTI_USER 
GO
ALTER DATABASE [CMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMS', N'ON'
GO
ALTER DATABASE [CMS] SET QUERY_STORE = OFF
GO
USE [CMS]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 2/19/2022 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NULL,
	[PatientID] [int] NULL,
	[Date] [date] NOT NULL,
	[BillAmount] [numeric](18, 0) NULL,
	[Disease] [varchar](50) NOT NULL,
	[Prescription] [varchar](50) NOT NULL,
	[Service_ID] [int] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[AppointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](max) NULL,
	[DoctorAddress] [varchar](50) NULL,
	[DoctorAge] [int] NOT NULL,
	[DoctorGender] [varchar](50) NULL,
	[DoctorPhone] [char](10) NULL,
	[Qualification] [varchar](50) NULL,
	[Specialization] [varchar](50) NULL,
	[Charges] [int] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NULL,
	[PatientAddress] [varchar](100) NULL,
	[PatientAge] [int] NOT NULL,
	[PatientGender] [varchar](10) NULL,
	[PatientPhone] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[appointment_id] [int] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorIID] [int] NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Services_Name] [varchar](50) NOT NULL,
	[Charges] [int] NOT NULL,
 CONSTRAINT [PK_Services_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Doctor]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Patient]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Appointment] FOREIGN KEY([appointment_id])
REFERENCES [dbo].[Appointment] ([AppointID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Appointment]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Doctor] FOREIGN KEY([DoctorIID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Doctor]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPatientRecords]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllPatientRecords]
AS
begin
select app.AppointID, p.PatientName, p.PatientAge,p.PatientGender ,d.DoctorName, app.Date, 
app.BillAmount, app.Disease, app.Prescription
from 
dbo.Appointment app
inner join Patient p on p.PatientID = app.PatientID
inner join Doctor d on d.DoctorID = app.DoctorID
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePatient]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE      proc [dbo].[sp_DeletePatient]
(
	@PatientID int,
	@ReturnMessage varchar(50) OUTPUT 
)
AS
BEGIN
		BEGIN TRY
			BEGIN TRAN	
					DELETE FROM Appointment
					WHERE PatientID = @PatientID
					DELETE FROM Patient
					WHERE PatientID = @PatientID

					SET @ReturnMessage = 'Patinet Deleted a Successfully.'
			COMMIT TRAN
		END TRY

BEGIN CATCH
	ROLLBACK TRAN 
	SET @ReturnMessage = ERROR_MESSAGE()
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GePatientID]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GePatientID]
(
@PatientID int
)
as 
begin 
select 
		PatientID
	   ,PatientName
	   ,PatientAddress
	   ,PatientAge
	   ,PatientGender
	   ,PatientPhone
 
 FROM 
 dbo.Patient
  
  where 	PatientID= @PatientID

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPatients]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_GetAllPatients]
as 
begin
select * from dbo.Patient with (nolock)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPatientID]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   proc [dbo].[sp_GetPatientID]
(
@PatientID int
)
as 
begin 
select 
		PatientID
	   ,PatientName
	   ,PatientAddress
	   ,PatientAge
	   ,PatientGender
	   ,PatientPhone
 
 FROM 
 dbo.Patient
  
  where 	PatientID= @PatientID

end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPatients]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertPatients]
(
@PatientName varchar(50),
@PatientAddress varchar(100),
@PatientAge int,
@PatientGender varchar(10) = NULL,
@PatientPhone int
)
as 
begin
	insert into dbo.Patient
	(
	   PatientName
      ,PatientAddress
      ,PatientAge
      ,PatientGender
      ,PatientPhone
	)
	values 
	(
		@PatientName, 
		@PatientAddress, 
		@PatientAge, 
		@PatientGender,
		@PatientPhone
	)
end
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatient]    Script Date: 2/19/2022 6:14:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[UpdatePatient]
(
@PatientID int,
@PatientName varchar(50),
@PatientAddress varchar(100),
@PatientAge int,
@PatientGender varchar(10) = NULL,
@PatientPhone int

)
as 
begin
	update Patient
		set 
		 PatientName = @PatientName
		,PatientAddress = @PatientAddress
		,PatientAge = PatientAge
		,PatientGender = PatientGender
		,PatientPhone = PatientPhone

	where PatientID = @PatientID
end
GO
USE [master]
GO
ALTER DATABASE [CMS] SET  READ_WRITE 
GO
