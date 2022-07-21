package br.com.sapede.thrupizzaback.dtos

import java.io.Serializable

data class LoginDto(val email: String? = null, val senha: String? = null) : Serializable
