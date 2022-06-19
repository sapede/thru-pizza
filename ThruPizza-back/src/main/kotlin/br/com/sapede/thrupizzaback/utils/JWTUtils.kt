package br.com.sapede.thrupizzaback.utils

import br.com.sapede.thrupizzaback.chaveSeguranca
import br.com.sapede.thrupizzaback.entities.Cliente
import br.com.sapede.thrupizzaback.services.ClienteService
import io.jsonwebtoken.Claims
import io.jsonwebtoken.Jwts
import io.jsonwebtoken.SignatureAlgorithm
import org.springframework.stereotype.Component

@Component
class JWTUtils(private val clienteService: ClienteService) {

    fun gerarToken(clienteId: Long): String =
        Jwts.builder()
            .setSubject(clienteId.toString())
            .signWith(SignatureAlgorithm.HS512, chaveSeguranca.toByteArray())
            .compact()

    fun isTokenValido(token: String): Boolean {
        val claims = getClaimsToken(token)

        if (claims != null) {
            val clienteId = claims.subject
            if (!clienteId.isNullOrEmpty() && !clienteId.isNullOrBlank()) {
                return when (clienteService.getById(clienteId.toLong())) {
                    null -> false
                    else -> true
                }

            }
        }

        return false
    }

    private fun getClaimsToken(token: String): Claims? =
        try {
            Jwts.parser().setSigningKey(chaveSeguranca.toByteArray()).parseClaimsJws(token).body
        } catch (exeption: java.lang.Exception) {
            null
        }

    fun getUsuario(token: String): Cliente? {
        val claims = getClaimsToken(token)
        val clienteId = claims?.subject?.toLong() ?: return null

        return when (val cliente = clienteService.getById(clienteId)) {
            null -> null
            else -> cliente
        }
    }
}