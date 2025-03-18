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

-- �������� ��������:
create table Student
(
	student_id int PRIMARY KEY IDENTITY,
	id_User int,
	FIO NVARCHAR(50) NOT NULL,
	Date_Birth NVARCHAR(50) NOT NULL,
	Number_Phone NVARCHAR(50) UNIQUE NOT NULL,
	Email_adress NVARCHAR(50) UNIQUE NOT NULL,
	Predmet NVARCHAR(50) NOT NULL

	FOREIGN KEY (id_User) REFERENCES register(id_User),
);

-- �������� �����������:
create table Repetitors
(
	tutor_id int PRIMARY KEY IDENTITY,
	id_User int,
	FIO NVARCHAR(50) NOT NULL,
	Phone_Number NVARCHAR(50) UNIQUE NOT NULL,
	Kvalification NVARCHAR(50) UNIQUE NOT NULL,
	Predmets NVARCHAR(50) NOT NULL
	
	FOREIGN KEY (id_User) REFERENCES register(id_User),
);

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


-- �������� ���������:
create table Pridments
(
	subject_id int PRIMARY KEY IDENTITY,
	Name_Pridment NVARCHAR(50) NOT NULL
);



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

CREATE TABLE StudentGrades (
    GradeId INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    Subject NVARCHAR(100) NOT NULL,
    Grade DECIMAL(4, 2) NOT NULL,
    Comments NVARCHAR(255),
    EvaluationDate DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Student(student_id)
);


-- �������� ������ �� �������
--create table links_of_Zanytia
--(
--	links_id int PRIMARY KEY IDENTITY,
--	schedule_id int,
--	link_name NVARCHAR(250)
--);

-- ���������� ����� �������������
INSERT INTO register (login_user, password_user, subject_user, status_user) 
VALUES 
	('admin', 'admin', 'All', 'admin'),
    ('teacherIgory', 'teachpass123', '������', '�������'),
    ('studentMaria', 'mypass456', '������� ����', '��������'),
    ('adminAssistant', 'secureAdmin', 'All', 'admin'),
    ('teacherOlga', 'olgapass789', '�����', '�������'),
    ('studentIgor', 'studentIgor123', '���������� ����', '��������');

-- ���������� ����� ���������
INSERT INTO Student (id_User, FIO, Date_Birth, Number_Phone, Email_adress, Predmet) 
VALUES 
    (6, '���� �������� �������', '15.05.2004', '8(917)123-45-67', 'kontychan@yandex.ru', '������'),
    (3, '����� �������� ���������', '22.08.2006', '8(916)987-65-43', 'mariaIvanova@yandex.ru', '������� ����'),
    (null, '��������� ���������� ��������', '11.03.2005', '8(915)555-55-55', 'ekatirinaValerevna@yandex.ru','�����'),
    (null, '����� ��������� �������', '29.12.2007', '8(912)444-44-44', 'igorSergergy@yandex.ru','���������� ����'),
    (null, '������ ���������� ��������', '07.07.2006', '8(910)222-22-22', 'sergeyNikolay@yandex.ru','����������');

-- ���������� ����� �����������
INSERT INTO Repetitors (id_User, FIO, Phone_Number, Kvalification, Predmets) 
VALUES 
    (5, '������� ����� ��������', '8(903)333-33-33', '������ ����', '�����'),
    (2, '������ ����� ����������', '8(901)111-11-11', '�������� ����', '������'),
    (null, '��������� ���� ���������', '8(902)666-66-66', '������� ������ ���������', '���������� ����'),
    (null, '������� ������� ��������', '8(905)999-99-99', '�������', '������� ����');

INSERT INTO Pridments (Name_Pridment) 
			VALUES ('����������'),
				   ('������� ����'),
				   ('������'),
				   ('�����'),
				   ('���������� ����');

-- ���������� ���������� �������
INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Learn, Learn_Status) 
VALUES 
    (2, 2, '09:00', '������� ��������'),
    (3, 1, '10:00', '������� �� ��������'),
    (4, 3, '14:00', '������� �����������'),
    (5, 4, '16:00', '������� �� ����������'),
    (1, 2, '12:00', '������� ��������');

-- ���������� ������ �� ������
INSERT INTO Payment (student_id, tutor_id, Date_of_Payment, Summ_Payment, Status_Pay) 
VALUES 
    (1, 1, '01.10.2022', 4500, '��������'),
    (2, 2, '15.10.2022', 3000, '��������'),
    (3, 1, '20.10.2022', 5000, '�� ���������'),
    (4, 3, '25.10.2022', 2500, '��������'),
    (5, 4, '28.10.2022', 3500, '�� ���������');

-- ���������� ������ �� �������
-- INSERT INTO links_of_Zanytia (schedule_id, link_name) 
-- VALUES 
--    (1, 'https://zoom.us/j/1234567890'),
--    (2, 'https://zoom.us/j/2345678901'),
--    (3, 'https://zoom.us/j/3456789012'),
--    (4, 'https://zoom.us/j/4567890123'),
--    (5, 'https://zoom.us/j/5678901234');