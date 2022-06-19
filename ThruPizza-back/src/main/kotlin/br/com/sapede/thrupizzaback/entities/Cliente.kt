package br.com.sapede.thrupizzaback.entities

import javax.persistence.Entity
import javax.persistence.GeneratedValue
import javax.persistence.Id

@Entity
data class Cliente(
    @Id @GeneratedValue
    val clienteId: Long,
    val nome: String,
    val telefone: String,
    val email: String,
    val endereco: String,
    val senha: String,
)