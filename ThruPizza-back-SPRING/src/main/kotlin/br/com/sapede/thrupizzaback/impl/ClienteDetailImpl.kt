package br.com.sapede.thrupizzaback.impl

import br.com.sapede.thrupizzaback.entities.Cliente
import org.springframework.security.core.GrantedAuthority
import org.springframework.security.core.userdetails.UserDetails

class ClienteDetailImpl(private val cliente: Cliente) : UserDetails {
    override fun getAuthorities(): MutableCollection<out GrantedAuthority> = mutableListOf()

    override fun getPassword(): String = cliente.senha

    override fun getUsername(): String = cliente.email

    override fun isAccountNonExpired(): Boolean = true

    override fun isAccountNonLocked(): Boolean = true

    override fun isCredentialsNonExpired(): Boolean = true

    override fun isEnabled(): Boolean = true
}