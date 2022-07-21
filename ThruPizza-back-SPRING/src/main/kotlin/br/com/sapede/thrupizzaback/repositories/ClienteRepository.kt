package br.com.sapede.thrupizzaback.repositories

import br.com.sapede.thrupizzaback.entities.Cliente
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.data.jpa.repository.Query
import org.springframework.data.repository.query.Param

interface ClienteRepository : JpaRepository<Cliente, Long> {
    @Query("select c from Cliente c where c.email = :email")
    fun findByEmail(@Param("email") email: String): Cliente?
}