CREATE TABLE Usuario (
    Id int IDENTITY(1,1) PRIMARY KEY,
	DataCriacao datetime,
	Login varchar(100),
	Senha varchar(100)
)