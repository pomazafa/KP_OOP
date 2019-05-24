use master 
go 

DROP database KURSACH
create database KURSACH 

use KURSACH
create table ADDRESS
(	  ADDRESS_ID integer  identity(1,1) constraint PK_ADDRESS  primary key,
	  STREET  nvarchar(64) not null,  
      HOUSE  nvarchar(5)   not null,
	  HOUSING nvarchar(5),
	  FLAT integer   
 )

 insert into ADDRESS
		values ('Кошевого', '15', '1', 20),
			   ('Вернадского','12', '2', 1),
			   ('Тамбовская','12', '1', 14),
			   ('Пушкина','55', '4', 81),
			   ('Ученическая','10', '1', 44);

 insert into ADDRESS (STREET, HOUSE)
		values ('Городская', '10'),
			   ('Короля', '22'),
			   ('Жемчужная', '2'),
			   ('Роговая', '15а'),
			   ('Кижеватова','21'),
			   ('Кольцова','155'),
			   ('Жимайтова','11'),
			   ('Герасимовой','62'),
			   ('Идейная','50');



 create table PATIENT
 (	 PATIENT_ID integer  identity(1,1) constraint PK_PATIENT  primary key,
	 SURNAME nvarchar(30) not null,
	 FIRSTNAME nvarchar(30) not null,
	 FATHERSNAME nvarchar(30),
	 GENDER     nchar(1) CHECK (GENDER in ('м', 'ж')),
	 BDAY   date,
	 TELEPHONE nvarchar(15),
	 ADDRESS_ID integer constraint  FK_ADDRESS_PATIENT foreign key         
								                            references ADDRESS(ADDRESS_ID)
)

 insert into PATIENT(SURNAME, FIRSTNAME, FATHERSNAME, GENDER, BDAY, TELEPHONE, ADDRESS_ID) 
	values				
				('Дубень','Полина','Васильевна','ж','21-10-1999','+375557734164', 1),
				('Глушакова','Алеся','Юрьевна','ж','10-10-2001','+375337126373', 5),
				('Стальмашенко','Анастасия','Павловна', 'ж','08-01-2000','+375297937722', 6),
				('Докурно','Вадим','Валерьевич','м','01-01-1998','+375331827335', 3),
				('Слюсарь','Владислав','Игоревич','м','26-09-1997','+375982911616', 2),
				('Пантилимонов','Богдан','Витальевич','м','01-09-1997','+375677962881', 4),
				('Кухтина','Диана','Валерьевна','ж','30-03-1998','+375681887710', 7),
				('Хмиль','Дмитрий','Витальевич','м','06-09-1994','+375201527318', 8),
				('Ковальчук','Максим','Владимирович','м','01-06-1994','+375662313753', 9),
				('Петренко','Александр','Григорьевич','м','30-08-1996','+375552726229', 10),
				('Шевченко','Пётр','Алексеевич','м','26-02-1995','+375392997210', 11),
				('Некрасова','Юлия','Викторовна','ж','09-05-1999','+375211923544', 12),
				('Квитко','Анастасия','Олеговна','ж','12-05-1998','+375432397733', 13),
				('Волочкова','Анастасия','Юрьевна','ж','20-01-1996','+375241429114', 14)

create table USERS
(
	[USER_ID] integer identity(1,1) constraint PK_USER primary key,
	LOGIN nvarchar(15) not null,
	SURNAME nvarchar(20) not null,
	NAME nvarchar(20) not null,
	FATHERSNAME nvarchar(20) not null,
	PASSWORD_HASH integer not null,
	CHANGE nchar(1)  CHECK (CHANGE in ('1', '2'))
)

insert into USERS 
	values	('admin', 'Дубень', 'Полина', 'Васильевна', 1951755706, 1),
			('pomazafa', 'Кричалов', 'Кирилл', 'Анатольевич', 2019917272, 2)
			
			

CREATE TABLE VISIT
(
	VISIT_ID integer  identity(1,1) constraint PK_VISIT primary key,
	PATIENT_ID integer constraint  FK_VISIT_PATIENT foreign key         
								                            references PATIENT(PATIENT_ID),
	VISIT_DATE_TIME1 datetime not null,
	COMPLAINTS nvarchar(300),
	PRESSURE nvarchar(10),
	HEIGHT decimal(4,1),
	WEIGHT decimal(5,2),
	IS_PLANNED bit not null,
	IS_COMPLETED bit not null,
	DIAGNOSIS nvarchar(max),
	ADDITIONAL_INFORMATION nvarchar(max),
	[USER_ID] integer constraint FK_VISIT_USER foreign key
														references USERS([USER_ID]),
	VISIT_DATE_TIME2 datetime default '01-01-1970'

)					

insert into VISIT(PATIENT_ID, VISIT_DATE_TIME1, COMPLAINTS, PRESSURE, HEIGHT, WEIGHT, IS_PLANNED, IS_COMPLETED, DIAGNOSIS, ADDITIONAL_INFORMATION, [USER_ID])
	values (1, GETDATE(), 'Повышенная утомляемость', '90/65', 170.1, 58.8, 1, 0, 'Хронический недосып', 'Рекомендуется больше отдыхать', 2),
		   (2, '2019-05-24T16:00:00', 'Повышенная утомляемость', '112/69', 164, 54.7, 0, 0,'АИТ', 'Рекомендуется постельный режим', 2),
		   (2, '2019-05-24T16:15:00', 'Головокружение', '107/80', 164, 54.5, 0,0,'АИТ', 'Рекомендуется постельный режим, необходимо постоянное наблюдение', 2),
		   (3, '2019-05-24T16:30:00', 'Частая простуда, насморок', '100/70', 178.3, 68, 1, 0, 'Снижение иммунитета', 'Рекомендуется принимать витамины А, всей группы В, а также кальций, железо, магний', 2),
		   (4, '2019-05-24T17:45:00', 'Повышенная утомляемость', '118/72', 170.5, 71, 0, 0, 'АИТ', 'Рекомендуется постельный режим', 2),
		   (5, GETDATE(), 'Слишком красив', '140/80', 173.8, 64, 1, 0, 'ЧСВ', 'Рекомендуется больше работать', 2),
		   (6, '2019-05-20T13:00:00', 'Повышенная температура', '111/82', 192, 85, 1, 0,'ОРВИ', 'Рекомендуется постельный режим', 2),
		   (7, '2019-05-20T13:15:00', 'Повышенная утомляемость', '135/77', 159.5, 56.4, 1, 0,'АИТ', 'Рекомендуется постельный режим', 2),
		   (8, '2019-05-20T10:15:00', 'Повышенная температура, кашель, насморок', '128/72', 178.5, 66.4, 0, 0, 'ОРВИ', 'Рекомендуется постельный режим', 2),
		   (9, '2019-05-20T11:30:00', 'Повышенная утомляемость', '114/80', 170, 74.2, 1, 0, 'АИТ', 'Рекомендуется постельный режим', 2),
		   (10, '2019-05-23T12:15:00', 'Повышенная утомляемость', '143/82', 184.5, 74, 0, 0,'АИТ', 'Рекомендуется постельный режим', 2),
		   (11, '2019-05-23T12:45:00', 'Повышенная температура', '105/68', 178.6, 73.4, 1, 0,'ОРВИ', 'Рекомендуется постельный режим', 2),
		   (12, '2019-05-23T12:30:00', 'Повышенная утомляемость', '132/82', 165.9, 64, 1, 0,'АИТ', 'Рекомендуется постельный режим', 2),
		   (13, '2019-05-23T11:00:00', 'Повышенная температура, кашель', '127/74', 169, 49.6, 0, 0, 'ОРВИ', 'Постальный режим', 2),
		   (14, '2019-05-23T09:15:00', 'Боль в спине', '122/71', 172.2, 53.8, 1, 0, 'Кифоз', 'Физиотерапевтические процедуры, ЛФК и массаж', 2)

 create table RECIPE
 ( 
	RECIPE_ID integer  identity(1,1) constraint PK_RECIPE  primary key,
	MEDICAMENT nvarchar(30) not null,
	QUANTITY nvarchar(20) not null,
	EXPIRATION_DATE date,
	PATIENT_ID integer constraint FK_RECIPE_PATIENT foreign key
														references PATIENT(PATIENT_ID)
)

insert into RECIPE
	values ('Карвалол', '20 таблеток', '23-09-2019', 2),
		   ('Фармил', '30 мг', '10-06-2019', 1)