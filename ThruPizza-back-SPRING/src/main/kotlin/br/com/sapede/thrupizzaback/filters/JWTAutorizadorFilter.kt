package br.com.sapede.thrupizzaback.filters


import br.com.sapede.thrupizzaback.authorization
import br.com.sapede.thrupizzaback.bearer
import br.com.sapede.thrupizzaback.impl.ClienteDetailImpl
import br.com.sapede.thrupizzaback.services.ClienteService
import br.com.sapede.thrupizzaback.utils.JWTUtils
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.security.authentication.AuthenticationManager
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken
import org.springframework.security.core.context.SecurityContextHolder
import org.springframework.security.core.userdetails.UsernameNotFoundException
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter
import javax.servlet.FilterChain
import javax.servlet.http.HttpServletRequest
import javax.servlet.http.HttpServletResponse

class JWTAutorizadorFilter(authenticationManager: AuthenticationManager, private val jwtUtils: JWTUtils) :
    BasicAuthenticationFilter(authenticationManager) {


    override fun doFilterInternal(request: HttpServletRequest, response: HttpServletResponse, chain: FilterChain) {
        val authorization = request.getHeader(authorization)

        if (authorization != null && authorization.startsWith(bearer)) {
            val autorizado = getAuthentication(authorization)
            SecurityContextHolder.getContext().authentication = autorizado
        }

        chain.doFilter(request, response)
    }

    private fun getAuthentication(authorization: String): UsernamePasswordAuthenticationToken {
        val token = authorization.substring(7)

        if (jwtUtils.isTokenValido(token)) {
            val cliente = jwtUtils.getUsuario(token)
            if (cliente != null){
                val clienteImpl = ClienteDetailImpl(cliente)

                return UsernamePasswordAuthenticationToken(clienteImpl, null, clienteImpl.authorities)
            }
        }

        throw UsernameNotFoundException("Token não está válido")
    }
}