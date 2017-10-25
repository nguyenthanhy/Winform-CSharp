CREATE DATABASE DACNBLBH
GO
USE DACNBLBH
GO
CREATE TABLE Account
(
    id INT  NOT NULL PRIMARY KEY,
	login NVARCHAR(50) NOT NULL,
	pass NVARCHAR(50)NOT NULL,
	status int
)
DROP TABLE dbo.Account
INSERT dbo.Account
        ( id, login, pass, status )
VALUES  (  -- id - int
          1,
          N'admin', -- login - nvarchar(50)
          N'12345', -- pass - nvarchar(50)
          1  -- status - int
          )
SELECT * FROM dbo.Account WHERE login like N'%a%'
