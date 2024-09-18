create database BDevReads;
Use BDevReads;
-- drop database BDevReads;

create table tb_Cliente(
Cod int primary key auto_increment,
Nome varchar(40) not null,
Telefone varchar(20) not null,
Email varchar(40) not null,
Senha varchar(20) 
);
desbribe tbCliente;
select * from tb_cliente;

/*create procedure sgInsertCliente(vCod int, vNome varchar(40), vTelefone varchar(20), vEmail varchar(40), vSenha varchar(20))
begin
if 
insert into tb_Cliente(nome, telefone, email, senha)
values('admin', 111111111, 'admin@gmail.com', 123456);


end $$
*/
