USE [WitcherDB]

CREATE TABLE [Chapters](
	[Id] int IDENTITY primary key,
	[Chapter_Name] nvarchar(150) NOT NULL,
);

CREATE TABLE [Characters](
	[Id] int IDENTITY primary key,
	[Name] nvarchar(150) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[Chapert_Id] int foreign key references [Chapters]([Id]),
	[Sex] nvarchar(50) NOT NULL,
	[Race] nvarchar(50) NOT NULL,
	[Occupation] nvarchar(150) NOT NULL,
	[Affiliation] nvarchar(150) NOT NULL,
	[Image_Url] nvarchar(max) NOT NULL,
);

INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи Пролога')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи I Главы')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи II Главы')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи III Главы')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи IV Главы')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи V Главы')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'Персонажи Эпилога')


INSERT [dbo].[Characters] ([Name], [Description], [Chapert_Id], [Sex], [Race], [Occupation], [Affiliation], [Image_Url]) VALUES (N'Геральт', N'Ге?ральт из Ри?вии (ориг. Geralt z Rivii) — главный герой литературной саги и протагонист последующих игр, ведьмак, профессиональный охотник на монстров, один из лучших фехтовальщиков Севера.

Имеет романтический интерес к двум чародейкам: Йеннифэр и Трисс. Его лучшими друзьями помимо ведьмаков из Школы Волка являются бард Лютик, краснолюд Золтан Хивай и высший вампир Эмиель Регис. ', 1, N'Мужской', N'
Человек (Ведьмак)', N'Ведьмак', N'Школа Волка', N'https://bit.ly/3VzEzGj')
INSERT [dbo].[Characters] ([Name], [Description], [Chapert_Id], [Sex], [Race], [Occupation], [Affiliation], [Image_Url]) VALUES (N'Весемир', N'Весемир (ориг. Vesemir) — второстепенный персонаж литературной саги, а также игр Ведьмак и Ведьмак 3: Дикая Охота, старейший, самый опытный и уважаемый ведьмак из Школы Волка, являвшийся её мастером и хранителем традиций Цеха.

Являясь одним из немногих ведьмаков, переживших в прошлом нападение на Каэр Морхен, он выступал в роли наставника и практически отца легендарного Геральта из Ривии и ряда других охотников на чудовищ. Обладал широкими познаниями в области фехтования и монстрологии, что, главным образом, и преподавал своим ученикам. ', 1, N'
Мужской', N'Человек (Ведьмак)', N'Ведьмак
Наставник ведьмаков
Учитель фехтования и монстрологии', N'Школа Волка', N'https://bit.ly/3BiFZNR')

