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

INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� �������')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� I �����')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� II �����')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� III �����')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� IV �����')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� V �����')
INSERT [dbo].[Chapters] ([Chapter_Name]) VALUES (N'��������� �������')


INSERT [dbo].[Characters] ([Name], [Description], [Chapert_Id], [Sex], [Race], [Occupation], [Affiliation], [Image_Url]) VALUES (N'�������', N'��?����� �� ��?���(����. Geralt z Rivii)�� ������� ����� ������������ ���� � ����������� ����������� ���,��������, ���������������� ������� �� ��������, ���� �� ������ �������������� ������.

����� ������������� ������� � ���� ����������:��������� � �����. ��� ������� �������� ������ ��������� �� ����� ����� �������� ���������,���������������� ������ ������ ������ ������ �����. ', 1, N'�������', N'
������� (�������)', N'�������', N'����� �����', N'https://bit.ly/3VzEzGj')
INSERT [dbo].[Characters] ([Name], [Description], [Chapert_Id], [Sex], [Race], [Occupation], [Affiliation], [Image_Url]) VALUES (N'�������', N'������� (����. Vesemir)�� �������������� �������� ������������ ����,�� ����� ���������� �������� 3: ����� �����, ���������, ����� ������� � ��������� ������� �� ����� �����, ���������� � �������� � ���������� �������� ����.

������� ����� �� �������� ���������, ���������� � ������� ��������� �� ���� ������, �� �������� � ���� ���������� � ����������� ���� �������������������� �� ����� � ���� ������ ��������� �� �������.�������� �������� ���������� � ������� ���������� � ������������, ���, ������� �������, � ���������� ����� ��������. ', 1, N'
�������', N'������� (�������)', N'�������
��������� ���������
������� ���������� � ������������', N'����� �����', N'https://bit.ly/3BiFZNR')

