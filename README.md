Application Overview
  
Developer Task
Te ndertohet REST API per nje blog te thjesht duke perdorur .Net Core. 
API duhet te perfshije endpointe per: 
-	Regjistrimin e perdoruesve 
-	Regjistrimin, editimin, fshirjen, listimin e kategorive te postimeve (CRUD). Kategoria duhet te kete emer dhe pershkrim. Menaxhimi I kategorive duhet te lejohet vetem per perdorues te autorizuar. 
Kategorite te cilat jane te lidhura me postime, nuk duhet te lejohen te fshihen. 
-	Krijimin e nje postimi te ri. Postimi do te kete 
o	titull, 
o	permbajtje (content), 
o	kategori (nje ose me shume se nje kategori)
o	status. (publik, draft, I fshire)
o	Date krijimi
o	Date publikimi
Postimet duhet te krijohen vetem nga perdoruest te autorizuar.
-	Listimin/Filtrimin e postimeve. Filtrimi te behet nepermjet tekstit (titullit ose permbajtjes se postimit) dhe dates se postimit. 
-	Editimin/Fshirjen e postimeve vetem nga perdoruesi qe I ka krijuar.  
Teknologjite
Te perdoret .NET Core per zhvillimin e REST API
Per lidhjen me databazen duhet te perdoret Entity Framework Code first approach.
Te behet dokumentimi i API me Swagger. 
Bonus
Te perdoret Repository Pattern dhe Unit Of Work Pattern.
Task te hidhet ne Git duket perdorur gitflow branching model

Shpjegime te tjera: 
Nuk eshte e nevojshme te zhvillohet api per menaxhimin e perdoruesve (pervec regjistrimit). 
Zgjedhja e databazes eshte ne doren e zhvilluesit
Lejohet perdorimi i teknologjive/librarive te tjera per zhvillim




ngarkimi databases:
update-database



disa query per te futur disa te rrjeshta ne db per testime:



INSERT INTO [dbo].[Posts] ([Title], [Content], [Status], [Date_Krijimi], [Date_Publikimi], [UserId])
VALUES 
('Introduction to SQL', 'SQL (Structured Query Language) is a domain-specific language...', 'Published', '2024-03-20 09:00:00', '2024-03-20 09:30:00', 1),
('Advanced SQL Techniques', 'Learn advanced SQL techniques such as...', 'Draft', '2024-03-19 10:00:00', '2024-03-20 11:00:00', 2),
('SQL Server Optimization', 'Optimizing SQL Server performance for better scalability...', 'Published', '2024-03-18 11:00:00', '2024-03-19 12:00:00', 3),
('Understanding Indexing in SQL', 'Indexing plays a crucial role in database performance...', 'Published', '2024-03-17 12:00:00', '2024-03-18 13:00:00', 1),
('Normalization in Databases', 'Learn about the normalization process in database design...', 'Draft', '2024-03-16 13:00:00', '2024-03-17 14:00:00', 2),
('Data Warehousing Concepts', 'Understanding data warehousing and its benefits...', 'Published', '2024-03-15 14:00:00', '2024-03-16 15:00:00', 3),
('SQL Injection Prevention', 'Prevent SQL injection attacks by using parameterized queries...', 'Published', '2024-03-14 15:00:00', '2024-03-15 16:00:00', 1),
('Backup and Recovery Strategies', 'Implementing effective backup and recovery strategies...', 'Draft', '2024-03-13 16:00:00', '2024-03-14 17:00:00', 2),
('Transactions in SQL', 'Understanding transactions and their role in ensuring data integrity...', 'Published', '2024-03-12 17:00:00', '2024-03-13 18:00:00', 3),
('Data Encryption Techniques', 'Learn about various data encryption techniques to secure sensitive data...', 'Published', '2024-03-11 18:00:00', '2024-03-12 19:00:00', 1),
('Database Design Best Practices', 'Best practices for designing efficient and scalable databases...', 'Draft', '2024-03-10 19:00:00', '2024-03-11 20:00:00', 2),
('Introduction to NoSQL Databases', 'An overview of NoSQL databases and their advantages...', 'Published', '2024-03-09 20:00:00', '2024-03-10 21:00:00', 3),
('Data Modeling Techniques', 'Learn different data modeling techniques such as...', 'Published', '2024-03-08 21:00:00', '2024-03-09 22:00:00', 1),
('Query Optimization Strategies', 'Optimizing queries for better performance in SQL Server...', 'Draft', '2024-03-07 22:00:00', '2024-03-08 23:00:00', 2),
('Data Replication Methods', 'Understanding data replication methods for redundancy and scalability...', 'Published', '2024-03-06 23:00:00', '2024-03-07 00:00:00', 3),
('Database Security Best Practices', 'Implementing security measures to protect databases from unauthorized access...', 'Published', '2024-03-05 00:00:00', '2024-03-06 01:00:00', 1),
('ETL Processes in Data Warehousing', 'Extract, Transform, Load processes in data warehousing...', 'Draft', '2024-03-04 01:00:00', '2024-03-05 02:00:00', 2),
('Database Migration Strategies', 'Strategies for migrating databases with minimal downtime and data loss...', 'Published', '2024-03-03 02:00:00', '2024-03-04 03:00:00', 3),
('Database Performance Tuning', 'Tips for tuning database performance for optimal speed and efficiency...', 'Published', '2024-03-02 03:00:00', '2024-03-03 04:00:00', 1),
('Data Archiving Techniques', 'Archiving data for long-term storage and compliance requirements...', 'Draft', '2024-03-01 04:00:00', '2024-03-02 05:00:00', 2);




INSERT INTO [dbo].[Kategori] ([Name], [Description])
VALUES 
('Technology', 'Articles related to technology and innovation'),
('Programming', 'Posts about various programming languages and techniques'),
('Data Science', 'Content related to data analysis, machine learning, and AI'),
('Web Development', 'Articles on web development frameworks, libraries, and best practices'),
('Mobile Development', 'Content about mobile app development for iOS and Android'),
('Database Management', 'Information about database administration and optimization'),
('Networking', 'Posts about network infrastructure and protocols'),
('Cloud Computing', 'Content about cloud services and deployment strategies'),
('Cybersecurity', 'Articles on cybersecurity threats, prevention, and best practices'),
('Artificial Intelligence', 'Content about AI algorithms, applications, and ethics'),
('Blockchain', 'Posts about blockchain technology and cryptocurrencies'),
('DevOps', 'Information about DevOps practices and tools'),
('UI/UX Design', 'Content about user interface and user experience design principles'),
('Software Engineering', 'Articles on software engineering methodologies and practices'),
('Game Development', 'Posts about game design, development, and engines'),
('IoT (Internet of Things)', 'Content about IoT devices, protocols, and applications'),
('Agile Methodologies', 'Information about agile software development methodologies'),
('Big Data', 'Articles on big data processing, analytics, and platforms'),
('Robotics', 'Content about robotics engineering and applications'),
('Virtual Reality', 'Posts about virtual reality technology and applications');




USE [APIDB]
GO

INSERT INTO [dbo].[User] ([Username], [Password], [Role])
VALUES 
('marin', 'marin', 'Admin'),
('user', 'user', 'User');


