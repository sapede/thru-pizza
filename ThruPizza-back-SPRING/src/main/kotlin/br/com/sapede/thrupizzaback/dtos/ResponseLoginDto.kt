package br.com.sapede.thrupizzaback.dtos

data class ResponseLoginDto(
    val nome: String,
    val email: String,
    val token: String
)