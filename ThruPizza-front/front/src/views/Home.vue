<template>
  <v-app>
    <v-container fill-height fluid class="background">
      <v-col align="center" justify="center">
        <v-row align="center" justify="center">
          <v-img src="../assets/logo.png" max-height="100%" max-width="25%" contain>
          </v-img>
        </v-row>
        <v-row align="center" justify="center">
          <v-btn color="#FA7F35" rounded dark x-large class="py-7 d-flex d-sm-flex d-md-flex" to="/pedido">
            Iniciar Pedido
          </v-btn>
        </v-row>
      </v-col>
    </v-container>
  </v-app>
</template>

<script>

export default {
  name: "Home",
  data: () => ({
    toggle_exclusive: 1,
  }),
  components: {
  },
};
</script>
<style >
.background {
  background: url('../assets/Sem\ título.png');
  background-size: cover;
  height: 100vh;
}
</style>
