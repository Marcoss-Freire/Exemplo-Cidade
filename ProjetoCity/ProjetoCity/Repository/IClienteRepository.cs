﻿using ProjetoCity.Models;

namespace ProjetoCity.Repository;

public interface IClienteRepository
{
    // CRUD
    //login
    // Em verde model, amarelo = método (dentro dele  está as funçoes do sql(select, insert, etc))
    Cliente Login(string Email, string Senha);

    // Cadastrar cliente
    void Cadastrar(Cliente cliente);

    //Buscar Todos os clientes
    IEnumerable<Cliente> TodosClientes();

}
