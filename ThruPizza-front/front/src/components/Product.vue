<template>
  <v-row justify="center" class="space px-16">
    <v-col cols="12" xs="12" sm="6" md="4" v-for="(product, i) in products" :key="i">
      <v-card class="mx-auto rounded-xl" max-width="300" color="" flat outlined>
        <div align="center" justify="center">
          <v-img max-height="300" max-width="300" contain :src="product.img"></v-img>
        </div>

        <v-card-title class="">{{ product.title }}</v-card-title>
        <v-card-title class="grey--text text-grey-darken-1 caption mt-n6">{{
            product.subtitle
        }}</v-card-title>
        <v-card-title class="mt-n4">{{ product.price }}</v-card-title>

        <v-card-actions class="mx-2 mt-n4" >
          <v-btn outlined class="mt-n2 add" @click="decrement(i)">
            <v-icon color="green" > mdi-minus </v-icon>
          </v-btn>

          <strong class="mx-2" v-text="product.bpm"></strong>
          <v-btn outlined class="mt-n2 add" @click="increment(i)">
            <v-icon color="green" > mdi-plus </v-icon>
          </v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
export default {
  data: () => ({
    products: [
      { img: "pr1.png", title: "Molho Tradicional", subtitle: "1kg", price: "$13" , bpm: 0},
      { img: "pr2.png", title: "Perry's Ice Cream", subtitle: "1kg", price: "$23" , bpm: 0},
      { img: "pr3.png", title: "Potato", subtitle: "1kg", price: "$17" , bpm: 0},
      { img: "pr4.png", title: "Bundle Pack", subtitle: "Potato, Papaya, Oil, Cabbage", price: "$40" , bpm: 0},
      { img: "pr5.png", title: "Oreo Biscuit", subtitle: "270GM", price: "$20" , bpm: 0},
      { img: "pr6.png", title: "Papaya", subtitle: "1kg", price: "$10" , bpm: 0},
    ],
  }),
  methods: {
    decrement(i) {
      if (this.products[i].bpm > 0){
        this.products[i].bpm--
      }
    },
    increment(i) {
      this.products[i].bpm++
    },

  },
};
</script>

<style>
</style>