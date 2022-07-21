<template>
  <v-app>
    <v-container fluid>
      <v-row>
        <v-col cols="12">
          <v-card flat color="#E2F2E5" class="rounded-xl mt-8">
            <v-toolbar flat color="transparent" class="mb-4">
              <v-toolbar-title class="text-h6 mt-5">Popular Bundle Pack</v-toolbar-title>
              <v-spacer></v-spacer>
            </v-toolbar>
            <Product />
          </v-card>
          
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar";
import Footer from "@/components/Footer";
import Category from "@/components/Category.vue";
import Product from "@/components/Product.vue";
import Pack from "@/components/Pack.vue";
import Client from "@/components/Client.vue";
import Partner from "@/components/Partner.vue";

export default {
  name: "Pedido",
  data: () => ({
    toggle_exclusive: 1,
  }),
  components: {
    Navbar,
    Footer,
    Category,
    Product,
    Pack,
    Client,
    Partner,
  },
};
</script>
<style >
.marginLeft {
  margin-left: -90px;
}

.mtop {
  margin-top: 100px;
}

.mbottom {
  margin-bottom: 100px;
}

.v-card.borderme {
  border: 2px solid green !important;
}

.v-card.borderout {
  border: 1px solid #d5f0db !important;
}

.v-btn:not(.v-btn--round).v-size--default.add {
  min-width: 0px !important;
}

.theme--light.v-sheet--outlined.mobile {
  border: 2px solid black !important;
}

@media only screen and (max-width: 600px) {
  h2.title1 {
    font-size: 15px;
  }

  h2.title2 {
    font-size: 15px;
  }

  .top {
    margin-top: 20px;
  }
}

@media only screen and (min-width: 600px) {
  .top {
    margin-top: 70px;
  }
}

@media only screen and (min-width: 768px) {
  .top {
    margin-top: 120px;
  }
}
</style>
