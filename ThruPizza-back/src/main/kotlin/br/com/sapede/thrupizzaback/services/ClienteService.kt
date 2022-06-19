package br.com.sapede.thrupizzaback.services

import br.com.sapede.thrupizzaback.entities.Cliente
import br.com.sapede.thrupizzaback.repositories.ClienteRepository
import org.springframework.data.repository.findByIdOrNull
import org.springframework.stereotype.Service

@Service
class ClienteService(private val repository: ClienteRepository) {

    fun save(cliente: Cliente): Cliente {
        return repository.save(cliente)
    }

    fun getAll(): List<Cliente> {
        return repository.findAll()
    }

    fun getById(id: Long): Cliente? {
        return repository.findByIdOrNull(id)
    }

    fun update(cliente: Cliente): Cliente? {
        return repository.findById(cliente.clienteId!!).map {
            val clienteUpdated = cliente.copy(
                nome = cliente.nome,
                email = cliente.email,
                telefone = cliente.telefone,
                endereco = cliente.endereco
            )
            repository.save(clienteUpdated)
        }.orElse(null)
    }
}