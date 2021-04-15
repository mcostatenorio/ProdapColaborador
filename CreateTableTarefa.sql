CREATE TABLE Tarefa(
   Id int IDENTITY(1,1) PRIMARY KEY,
   DataCriacao datetime,
   Descricao varchar(500),
   Status varchar(30),
   IdUsuarioResponsavel int not null,
   CONSTRAINT FK_UsuarioTarefa FOREIGN KEY (IdUsuarioResponsavel)
   REFERENCES Usuario(Id) 
)