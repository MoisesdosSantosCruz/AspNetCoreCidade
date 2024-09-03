create database BDevReads;
Use BDevReads;
drop database BDevReads;
-- drop database BD1;
-- drop table tb_Cliente;
-- select * from tb_Cliente;
-- drop table tb_Cliente;

create table tb_Cliente(
Cod int primary key auto_increment,
Nome varchar(40) not null,
Telefone varchar(20) not null,
Email varchar(40) not null,
Senha varchar(20) 
);

insert into tb_Cliente(nome, telefone, email, senha)
values('admin', 111111111, 'admin@gmail.com', 123456);

select * from tb_cliente;