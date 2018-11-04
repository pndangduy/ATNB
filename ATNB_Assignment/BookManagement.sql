use master
go

if db_id('BookManagement') is null
	create database BookManagement
else
	drop database BookManagement
go

use BookManagement
go

/* ---------------------------- TABLE ---------------------------- */
-- Table Users
create table dbo.Users
(
	UserName varchar(50) primary key, -- Username of user
	Password varchar(100) not null, -- Password of user
	Email varchar(100), -- Email of user
	IsActive bit default 1 -- 1 : active, 0 : not active
)
go

-- Table Category
create table dbo.Category
(
	CateID int identity(1,1) primary key, -- Category id
	CateName nvarchar(50) not null, -- Category name
	Description nvarchar(max) -- description of category
)
go

-- Table Publisher
create table dbo.Publisher
(
	PubID int identity(1,1) primary key, -- Publisher id
	Name nvarchar(100), -- publisher name
	Description nvarchar(max) -- description publisher
)
go

-- Table Author
create table dbo.Author
(
	AuthorID int identity(1,1) primary key, -- Author id 
	AuthorName nvarchar(100), -- author name
	History nvarchar(max) -- history of author
)
go

-- Table Book
create table dbo.Book
(
	BookID int identity(1,1) primary key, -- id book
	Title nvarchar(100), -- title book
	CateID int references Category(CateID), -- category of book
	PubID int references Publisher(PubID), -- publisher of book
	AuthorID int references Author(AuthorID), -- author of book
	Summary nvarchar(max), -- description of book
	ImgUrl nvarchar(max), -- path image of book
	Price money, -- price of book
	Quantity int, -- quantity of book
	CreatedDate datetime, -- date create book
	ModifiedDate datetime, -- Date modified book
	IsActive bit default 1 -- 1 : active , 0 : not active
)
go

-- Table Comment
create table dbo.Comment
(
	CommentID int identity(1,1) primary key, -- comment id
	BookID int references Book(BookID), -- book of comment
	[Content] nvarchar(max), -- content of commen
	CreatedDate datetime, -- date create comment
	IsActive bit default 1 -- 1 : active, 0 : not active
)
go

/* ---------------------------- INSERT ---------------------------- */

-- INSERT AUTHOR
INSERT INTO dbo.Author VALUES
(N'Nguyễn Nhật Ánh',N'Sinh năm ... Mất năm ...'),
(N'Trang Hạ',N'Sinh năm ... Mất năm ...'),
(N'Hạ Vũ',N'Sinh năm ... Mất năm ...'),
(N'Anh Khang',N'Sinh năm ... Mất năm ...'),
(N'Gào',N'Sinh năm ... Mất năm ...')
GO

-- INSERT CATEGORY
INSERT INTO dbo.Category VALUES
(N'Trinh thám',N'Bla bla....'),
(N'Tiểu thuyết',N'Bla bla....'),
(N'Tình yêu',N'Bla bla....'),
(N'Văn học',N'Bla bla....'),
(N'Khoa học',N'Bla bla....')
GO

-- INSERT CATEGORY
INSERT INTO dbo.Publisher VALUES
(N'NXB Kim Đồng',N'Bla bla....'),
(N'Tuổi Trẻ',N'Bla bla....'),
(N'Thời Đại',N'Bla bla....'),
(N'Chém Gió',N'Bla bla....'),
(N'Lao Động',N'Bla bla....')
GO

-- INSERT CATEGORY
INSERT INTO dbo.Book(Title,Summary,CateID,PubID,AuthorID,Price,Quantity,CreatedDate,ImgUrl) VALUES
(N'Hoa vàng trên cỏ xanh',N'Một cuốn sách hay',4,1,1,150,1000,GETDATE(),''),
(N'Kính vạn hoa',N'Một cuốn sách hay',4,1,3,50,1500,GETDATE(),''),
(N'Sherlock Home',N'Một cuốn sách nước ngoài',1,3,1,200,10000,GETDATE(),''),
(N'Buồn làm sao buông',N'Một cuốn sách hay',3,1,4,30,500,GETDATE(),''),
(N'Thuyết vạn vật',N'Một cuốn sách hay',5,3,5,150,1000,GETDATE(),'')
GO

-- INSERT USERS
INSERT INTO dbo.Users(UserName,Password,Email) VALUES
('admin','admin','abc@gmail.com')
GO

/* ---------------------------- STORE PRODUCE ---------------------------- */

-- Get all author
CREATE PROC SP_GetAllAuthor
AS
BEGIN
	SELECT *
	FROM dbo.Author
END
GO

-- Get all publisher
CREATE PROC SP_GetAllPublisher
AS
BEGIN
	SELECT *
	FROM dbo.Publisher
END
GO

-- Get all author
CREATE PROC SP_GetAllCategory
AS
BEGIN
	SELECT *
	FROM dbo.Category
END
GO

-- Get all author
CREATE PROC SP_GetAllBook
AS
BEGIN
	SELECT *
	FROM dbo.Book
END
GO	

-- Login User
CREATE PROC SP_Login
	@Username varchar(50),
	@Password varchar(100)
AS
BEGIN
	SELECT UserName,Email
	FROM dbo.Users
	WHERE UserName = @Username and Password = @Password
END
GO

-- Create new publisher
CREATE PROC SP_CreatePublisher
	@PublisherName nvarchar(100),
	@Description nvarchar(max)
AS
BEGIN
	INSERT INTO dbo.Publisher VALUES(@PublisherName,@Description)
END
GO

-- Create new category
CREATE PROC SP_CreateCategory
	@CategoryName nvarchar(100),
	@Description nvarchar(max)
AS
BEGIN
	INSERT INTO dbo.Category VALUES(@CategoryName,@Description)
END
GO