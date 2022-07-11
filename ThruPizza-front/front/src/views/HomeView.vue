<template>
  <v-app>
    <Navbar />
    <v-container fluid>
      <v-row>
        <v-col cols="12">
          <v-card class="mx-auto rounded-xl" flat>
            <v-img src="https://cdn.vuetifyjs.com/images/cards/cooking.jpg" max-height="100%" max-width="100%"> </v-img>
            <v-card-title class="top ml-10">
              <h2 class="title1">Order your</h2>
            </v-card-title>
            <v-card-tile class="ml-10 mt-n8">
              <h2 class="title2">Daily Groceries</h2>
            </v-card-tile>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
import Navbar from '@/components/Navbar.vue'

export default {
  name: 'Home',

  components: {
    Navbar
  },
}
</script>
<style>
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