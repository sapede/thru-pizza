/*
 * Copyright 2020 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.example.jetsnack.model

import androidx.compose.runtime.Immutable

@Immutable
data class Snack(
    val id: Long,
    val name: String,
    val imageUrl: String,
    val price: Long,
    val tagline: String = "",
    val tags: Set<String> = emptySet()
)

/**
 * Static data
 */

val snacks = listOf(
    Snack(
        id = 1L,
        name = "Molho tradicional",
        tagline = "A tag line",
        imageUrl = "https://akdelicatessen.com.br/wp-content/uploads/2021/11/molho-tomate-caseiro.jpg",
        price = 5
    ),
    Snack(
        id = 2L,
        name = "Molho Apimentando",
        tagline = "A tag line",
        imageUrl = "https://www.receiteria.com.br/wp-content/uploads/receitas-de-molho-de-pimenta-1.jpg",
        price = 5
    ),
    Snack(
        id = 3L,
        name = "Frango Desfiado",
        tagline = "A tag line",
        imageUrl = "https://img.itdg.com.br/tdg/images/recipes/000/157/785/357336/357336_original.jpg?mode=crop&width=710&height=400",
        price = 10
    ),
    Snack(
        id = 4L,
        name = "Calabresa",
        tagline = "A tag line",
        imageUrl = "https://img.freepik.com/fotos-premium/linguica-calabresa-fatiada-com-cebola-em-fundo-de-madeira-petisco-brasileiro_311876-57.jpg?w=2000",
        price = 8
    ),
    Snack(
        id = 5L,
        name = "Filé Mignon",
        tagline = "A tag line",
        imageUrl = "https://thumb-cdn.soluall.net/prod/shp_products/sp1280fw/61b0dd09-b9c4-4632-8585-30dfac1e09ff/61b0dd09-73ec-401e-a5d0-30dfac1e09ff.jpg",
        price = 20
    ),
    Snack(
        id = 6L,
        name = "Mussarela",
        tagline = "A tag line",
        imageUrl = "https://friosdonavila.com.br/wp-content/uploads/2021/05/mussarela-ralada.jpg",
        price = 10
    ),
    Snack(
        id = 7L,
        name = "Chedder",
        tagline = "A tag line",
        imageUrl = "https://static.vecteezy.com/ti/fotos-gratis/p2/708074-ralado-com-queijo-cheddar-foto.jpg",
        price = 15
    ),
    Snack(
        id = 8L,
        name = "Gorgonzola",
        tagline = "A tag line",
        imageUrl = "http://guiadacozinha.com.br/wp-content/uploads/2020/09/shutterstock_347148638.jpg",
        price = 15
    ),
    Snack(
        id = 9L,
        name = "Tomate",
        tagline = "A tag line",
        imageUrl = "https://thumbs.dreamstime.com/b/tomate-cortado-vermelho-54022186.jpg",
        price = 5
    ),
    Snack(
        id = 10L,
        name = "Cebola",
        tagline = "A tag line",
        imageUrl = "https://www.designi.com.br/images/preview/10103454.jpg",
        price = 3
    ),
    Snack(
        id = 11L,
        name = "Catupiry",
        tagline = "A tag line",
        imageUrl = "https://a-static.mlcdn.com.br/800x560/kit-queijo-cheddar-ingles-1kg-requeijao-catupiry-15kg/emporiosantos/bf8ddf269b0f11ec90144201ac185055/df58698ed5bd4d108fcda5bfba639923.jpeg",
        price = 10
    ),
    Snack(
        id = 12L,
        name = "Nougat",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/qRE_OpbVPR8",
        price = 299
    ),
    Snack(
        id = 13L,
        name = "Oreo",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/33fWPnyN6tU",
        price = 299
    ),
    Snack(
        id = 14L,
        name = "Pie",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/aX_ljOOyWJY",
        price = 299
    ),
    Snack(
        id = 15L,
        name = "Chips",
        imageUrl = "https://source.unsplash.com/UsSdMZ78Q3E",
        price = 299
    ),
    Snack(
        id = 16L,
        name = "Pretzels",
        imageUrl = "https://source.unsplash.com/7meCnGCJ5Ms",
        price = 299
    ),
    Snack(
        id = 17L,
        name = "Smoothies",
        imageUrl = "https://source.unsplash.com/m741tj4Cz7M",
        price = 299
    ),
    Snack(
        id = 18L,
        name = "Popcorn",
        imageUrl = "https://source.unsplash.com/iuwMdNq0-s4",
        price = 299
    ),
    Snack(
        id = 19L,
        name = "Almonds",
        imageUrl = "https://source.unsplash.com/qgWWQU1SzqM",
        price = 299
    ),
    Snack(
        id = 20L,
        name = "Cheese",
        imageUrl = "https://source.unsplash.com/9MzCd76xLGk",
        price = 299
    ),
    Snack(
        id = 21L,
        name = "Apples",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/1d9xXWMtQzQ",
        price = 299
    ),
    Snack(
        id = 22L,
        name = "Apple sauce",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/wZxpOw84QTU",
        price = 299
    ),
    Snack(
        id = 23L,
        name = "Apple chips",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/okzeRxm_GPo",
        price = 299
    ),
    Snack(
        id = 24L,
        name = "Apple juice",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/l7imGdupuhU",
        price = 299
    ),
    Snack(
        id = 25L,
        name = "Apple pie",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/bkXzABDt08Q",
        price = 299
    ),
    Snack(
        id = 26L,
        name = "Grapes",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/y2MeW00BdBo",
        price = 299
    ),
    Snack(
        id = 27L,
        name = "Kiwi",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/1oMGgHn-M8k",
        price = 299
    ),
    Snack(
        id = 28L,
        name = "Mango",
        tagline = "A tag line",
        imageUrl = "https://source.unsplash.com/TIGDsyy0TK4",
        price = 299
    )
)
