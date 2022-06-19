package br.com.sapede.thrupizzaback.services

import br.com.sapede.thrupizzaback.dtos.LoginDto
import br.com.sapede.thrupizzaback.dtos.ResponseLoginDto
import br.com.sapede.thrupizzaback.repositories.ClienteRepository
import br.com.sapede.thrupizzaback.utils.JWTUtils
import org.springframework.stereotype.Service

@Service
class LoginService(val repository: ClienteRepository, val jwtUtils: JWTUtils){

    fun validarLogin(dto: LoginDto) : ResponseLoginDto? {
        return when (val cliente = repository.findByEmail(dto.Email!!)) {
            null -> null
            else -> ResponseLoginDto(cliente.nome, cliente.email, jwtUtils.gerarToken(cliente.clienteId))
        }
    }
}
