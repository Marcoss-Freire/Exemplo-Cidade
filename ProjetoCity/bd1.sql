create database bd1;
use bd1;

create table cliente(
CodCli int primary key auto_increment,
Nome varchar(40) ,
Telefone varchar(20),
Email varchar(40),
Senha varchar(20)
);

insert into cliente (Nome, Telefone, Email, Senha) values ('admin', '111111111111', 'admin@gmail', '12345678');
