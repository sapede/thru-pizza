package br.com.sapede.thrupizzaback.utils

import br.com.sapede.thrupizzaback.chaveSeguranca
import br.com.sapede.thrupizzaback.entities.Cliente
import br.com.sapede.thrupizzaback.jwt_expiration
import br.com.sapede.thrupizzaback.services.ClienteService
import io.jsonwebtoken.Claims
import io.jsonwebtoken.Jwts
import io.jsonwebtoken.SignatureAlgorithm
import org.springframework.stereotype.Component
import java.util.*

@Component
class JWTUtils(private val clienteService: ClienteService) {

    fun gerarToken(email: String): String =
        Jwts.builder()
            .setSubject(email)
            .setExpiration(Date(System.currentTimeMillis() + jwt_expiration))
            .signWith(SignatureAlgorithm.HS512, chaveSeguranca.toByteArray())
            .compact()

    fun isTokenValido(token: String): Boolean {
        val claims = getClaimsToken(token)

        if (claims != null) {
            val email = claims.subject
            if (!email.isNullOrEmpty() && !email.isNullOrBlank()) {
                return when (clienteService.getByEmail(email)) {
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
        val email = claims?.subject?.toString() ?: return null

        return when (val cliente = clienteService.getByEmail(email)) {
            null -> null
            else -> cliente
        }
    }
}