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

Shpjegime:
Jane dy endpoint per user: 1- shton user (username, password, role -->("admin, operator,etj")) 
                           2- login: qe kthen nje bearer. Ky bearer perdor per te autorizuar veprimet qe do behen me pas ku disa prej tyre jane vetem me rolin admin.        
                              

disa query per te futur disa te rrjeshta ne db per testime:

INSERT INTO [dbo].[Posts] ([Title], [Content], [Status], [Date_Krijimi], [Date_Publikimi], [UserId])
VALUES 
('Introduction to SQL', 'SQL (Structured Query Language) is a domain-specific language...', 'Published', '2024-03-20 09:00:00', '2024-03-20 09:30:00', 1),
('Advanced SQL Techniques', 'Learn advanced SQL techniques such as...', 'Draft', '2024-03-19 10:00:00', '2024-03-20 11:00:00', 2),
('SQL Server Optimization', 'Optimizing SQL Server performance for better scalability...', 'Published', '2024-03-18 11:00:00', '2024-03-19 12:00:00', 3),
('Understanding Indexing in SQL', 'Indexing plays a crucial role in database performance...', 'Published', '2024-03-17 12:00:00', '2024-03-18 13:00:00', 1),
('Normalization in Databases', 'Learn about the normalization process in database design...', 'Draft', '2024-03-16 13:00:00', '2024-03-17 14:00:00', 2),
('Data Warehousing Concepts', 'Understanding data warehousing and its benefits...', 'Published', '2024-03-15 14:00:00', '2024-03-16 15:00:00', 3);



INSERT INTO [dbo].[Kategori] ([Name], [Description])
VALUES 
('Technology', 'Articles related to technology and innovation'),
('Programming', 'Posts about various programming languages and techniques'),
('Data Science', 'Content related to data analysis, machine learning, and AI'),
('Web Development', 'Articles on web development frameworks, libraries, and best practices'),
('Mobile Development', 'Content about mobile app development for iOS and Android'),
('Database Management', 'Information about database administration and optimization'),
('Networking', 'Posts about network infrastructure and protocols'),
('Cloud Computing', 'Content about cloud services and deployment strategies');


INSERT INTO [dbo].[User] ([Username], [Password], [Role])
VALUES 
('marin', 'marin', 'Admin'),
('user', 'user', 'User');


