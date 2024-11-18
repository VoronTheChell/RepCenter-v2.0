-- �������� ��
-- CREATE DATABASE RepCenter;
USE RepCenter;

-- �������� �������������
create table register
(
	id_User int PRIMARY KEY IDENTITY,
	login_user NVARCHAR(50) UNIQUE NOT NULL,
	password_user NVARCHAR(50) NOT NULL,
	subject_user NVARCHAR(50) NOT NULL,
	status_user NVARCHAR(50) CHECK (status_user IN ('admin', '��������', '�������')) NOT NULL,
);

insert into register (login_user, password_user, subject_user, status_user) 
			values ('admin', 'admin', 'All', 'admin'),
				   ('Anna', 'antares21', '����������', '�������'),
				   ('Vladimer228', '@uth2281', '����������', '��������');

-- �������� ��������:
create table Student
(
	student_id int PRIMARY KEY IDENTITY,
	FIO NVARCHAR(50) NOT NULL,
	Date_Birth NVARCHAR(50) NOT NULL,
	Number_Phone NVARCHAR(50) UNIQUE NOT NULL,
	Predmet NVARCHAR(50) NOT NULL
);

INSERT INTO Student (FIO, Date_Birth, Number_Phone, Predmet) 
			VALUES ('�������� ��������� �������', '09.01.2005', '8(905)384-68-79', '����������');

-- �������� �����������:
create table Repetitors
(
	tutor_id int PRIMARY KEY IDENTITY,
	FIO NVARCHAR(50) NOT NULL,
	Phone_Number NVARCHAR(50) UNIQUE NOT NULL,
	Kvalification NVARCHAR(50) UNIQUE NOT NULL,
	Predmets NVARCHAR(50) NOT NULL
);

INSERT INTO Repetitors (FIO, Phone_Number, Kvalification, Predmets) 
			VALUES ('��������� ��������� �������������', '8(905)651-49-81', '������ ����', '����������');

-- �������� ����������:
create table Raspisanie_Zaniyatiy
(
	schedule_id int PRIMARY KEY IDENTITY,
	student_id int,
	tutor_id int,
	Time_Learn NVARCHAR(50) NOT NULL,
	Learn_Status NVARCHAR(65) CHECK (Learn_Status IN ('������� ��������', '������� �����������', '������� �� ����������', '������� �� ��������')) NOT NULL,

	FOREIGN KEY (student_id) REFERENCES Student(student_id),
	FOREIGN KEY (tutor_id) REFERENCES Repetitors(tutor_id),
);

INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Begin, Time_Out, Learn_Status) 
			VALUES (1, 1, '18:30', '20:30', '������� ��������');


-- �������� ���������:
create table Pridments
(
	subject_id int PRIMARY KEY IDENTITY,
	Name_Pridment NVARCHAR(50) NOT NULL
);

INSERT INTO Pridments (Name_Pridment) 
			VALUES ('����������'),
				   ('������� ����'),
				   ('������'),
				   ('�����'),
				   ('���������� ����');

-- �������� ������ �������
create table Payment
(
	payment_id int PRIMARY KEY IDENTITY,
	student_id int NOT NULL,
	tutor_id int NOT NULL,
	Date_of_Payment NVARCHAR(50) NOT NULL,
	Summ_Payment int NOT NULL,
	Status_Pay NVARCHAR(50) CHECK (Status_Pay IN ('��������', '�� ���������')) NOT NULL,

	FOREIGN KEY (student_id) REFERENCES Student(student_id),
	FOREIGN KEY (tutor_id) REFERENCES Repetitors(tutor_id),
);

INSERT INTO Payment (student_id, tutor_id, Date_of_Payment, Summ_Payment, Status_Pay) 
			VALUES (1, 1, '25.09.2022', 5000, '��������');

-- �������� ������ �� �������
--create table links_of_Zanytia
--(
--	links_id int PRIMARY KEY IDENTITY,
--	schedule_id int,
--	link_name NVARCHAR(250)
--);