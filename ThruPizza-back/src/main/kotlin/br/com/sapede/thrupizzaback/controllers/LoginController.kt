package br.com.sapede.thrupizzaback.controllers

import br.com.sapede.thrupizzaback.dtos.LoginDto
import br.com.sapede.thrupizzaback.dtos.ResponseLoginDto
import br.com.sapede.thrupizzaback.services.LoginService
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RestController

@RestController
@RequestMapping("api/login")
class LoginController(val loginService: LoginService){

    @PostMapping
    fun logar(@RequestBody dto: LoginDto) : ResponseEntity<ResponseLoginDto> {
        return when (val token = loginService.validarLogin(dto)) {
            null -> ResponseEntity.notFound().build()
            else -> { ResponseEntity.ok(token)}
        }
    }
}
