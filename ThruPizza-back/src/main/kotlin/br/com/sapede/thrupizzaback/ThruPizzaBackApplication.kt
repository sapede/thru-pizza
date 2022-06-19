package br.com.sapede.thrupizzaback

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.autoconfigure.security.servlet.SecurityAutoConfiguration
import org.springframework.boot.runApplication

@SpringBootApplication(exclude = [SecurityAutoConfiguration::class])
class ThruPizzaBackApplication

fun main(args: Array<String>) {
	runApplication<ThruPizzaBackApplication>(*args)
}
