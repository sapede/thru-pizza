package br.com.sapede.thrupizzaback.dtos

import java.io.Serializable

data class LoginDto(val Email: String? = null, val Senha: String? = null) : Serializable
