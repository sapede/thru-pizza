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
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.delay
import kotlinx.coroutines.withContext

/**
 * A fake repo for searching.
 */
object SearchRepo {
    fun getCategories(): List<SearchCategoryCollection> = searchCategoryCollections
    fun getSuggestions(): List<SearchSuggestionGroup> = searchSuggestions

    suspend fun search(query: String): List<Snack> = withContext(Dispatchers.Default) {
        delay(200L) // simulate an I/O delay
        snacks.filter { it.name.contains(query, ignoreCase = true) }
    }
}

@Immutable
data class SearchCategoryCollection(
    val id: Long,
    val name: String,
    val categories: List<SearchCategory>
)

@Immutable
data class SearchCategory(
    val name: String,
    val imageUrl: String
)

@Immutable
data class SearchSuggestionGroup(
    val id: Long,
    val name: String,
    val suggestions: List<String>
)

/**
 * Static data
 */

private val searchCategoryCollections = listOf(
    SearchCategoryCollection(
        id = 0L,
        name = "Categories",
        categories = listOf(
            SearchCategory(
                name = "Molhos",
                imageUrl = "https://img.estadao.com.br/thumbs/640/resources/jpg/1/7/1569458466971.jpg"
            ),
            SearchCategory(
                name = "Proteinas",
                imageUrl = "https://st2.depositphotos.com/1027198/7804/i/600/depositphotos_78049188-stock-photo-various-raw-meat.jpg"
            ),
            SearchCategory(
                name = "Queijos",
                imageUrl = "https://blogs.correiobraziliense.com.br/nqv/wp-content/uploads/sites/22/2017/04/18056649_1093750974063084_3148698085417389679_n-1-1280x720.jpg"
            ),
            SearchCategory(
                name = "Adicionais",
                imageUrl = "https://img.freepik.com/fotos-premium/pizza-saborosa-e-ingredientes-isolados-no-branco_185193-20017.jpg?w=2000"
            )
        )
    )
)

private val searchSuggestions = listOf(
    SearchSuggestionGroup(
        id = 0L,
        name = "Perquisas Recentes",
        suggestions = listOf(
            "Molho Tradicional",
            "Mussarela"
        )
    ),
    SearchSuggestionGroup(
        id = 1L,
        name = "Pesquisas Populares",
        suggestions = listOf(
            "Organic",
            "Gluten Free",
            "Paleo",
            "Vegan",
            "Vegitarian",
            "Whole30"
        )
    )
)
