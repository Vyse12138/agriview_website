<template>
  <div id="app">
    <Navigation />
    <router-view />
    <BackToTop />
  </div>
</template>

<script>
import BackToTop from "./components/BackToTop.vue";
import Navigation from "./components/Navigation.vue";
export default {
  name: "App",
  components: {
    BackToTop,
    Navigation,
  },
};
</script>

<style>
@import "https://use.fontawesome.com/releases/v5.7.2/css/all.css";
@import "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css";
@import "./style/Style.css";
</style>
