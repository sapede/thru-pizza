<template>
    <v-row justify="center" class="space px-16 ">
        <v-col cols="12" xs="12" sm="6" md="4" v-for="(product, i) in products" :key="i">
            <v-card class="mx-auto rounded-xl" max-wight="300" flat outlined>
                <div align="center" justify="center">
                    <v-img max-height="300" max-width="300" contain :src="product.img"></v-img>
                </div>
            </v-card>
        </v-col>
    </v-row>
</template>

<script>
export default {
  data: () => ({
      bpm: 1,
    products: [
      { img: "pr1.png", title: "Cabbage", subtitle: "1kg", price: "$13" },
      { img: "pr2.png", title: "Perry's Ice Cream", subtitle: "1kg", price: "$23" },
      { img: "pr3.png", title: "Potato", subtitle: "1kg", price: "$17" },
      { img: "pr4.png", title: "Bundle Pack", subtitle: "Potato, Papaya, Oil, Cabbage", price: "$40" },
      { img: "pr5.png", title: "Oreo Biscuit", subtitle: "270GM", price: "$20" },
      { img: "pr6.png", title: "Papaya", subtitle: "1kg", price: "$10" },
    ],
  }),
   methods: {
      decrement () {
        this.bpm--
      },
      increment () {
        this.bpm++
      },
     
    },
};
</script>

<style>
</style>