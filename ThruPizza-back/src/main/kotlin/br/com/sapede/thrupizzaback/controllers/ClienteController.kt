package br.com.sapede.thrupizzaback.controllers

import br.com.sapede.thrupizzaback.entities.Cliente
import br.com.sapede.thrupizzaback.services.ClienteService
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.*

@RestController
@RequestMapping("/api/cliente")
class ClienteController (private val clienteService: ClienteService){

    @PostMapping
    fun create(@RequestBody cliente:Cliente) : Cliente = clienteService.save(cliente)

    @GetMapping
    fun getAll(): List<Cliente> = clienteService.getAll()


}