<template>
  <div class="industry">
    <!-- header section -->
    <header id="header-section">
      <h1 id="header">Industry Insights</h1>
      <p id="sub-header">
        Welcome to Industry Insights this will be updated quarterly.
      </p>
    </header>

    <!-- loading indicator -->
    <h3 class="load" v-if="loading">Loading...</h3>
    <h3 class="load" v-if="error">There was some error...</h3>

    <News v-for="news in newsList" v-bind:key="news.id" :news="news" />
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
import News from "@/components/IndustryInsight/News.vue";

Vue.use(VueAxios, axios);
Vue.prototype.$server = "https://localhost:44381/api/news/";
export default {
  name: "IndustryInsight",
  components: {
    News
  },
  data: () => ({
    newsList: undefined,
    loading: false,
    error: false
  }),
  mounted() {
    this.loading = true;
    axios
      .get(this.$server)
      .then(response => {
        this.newsList = response.data;
      })
      .catch(error => {
        this.error = true;
        console.error("There was an error!", error);
      })
      .finally(() => {
        this.loading = false;
      });
  }
};
</script>

<style scoped>
.industry {
  margin-top: 95px;
  overflow: hidden;
  max-width: 980px;
  margin-left: auto;
  margin-right: auto;
  width: 88%;
}
/* header */
#header-section {
  margin: 34px auto 0;
  text-align: center;
}
#header {
  margin: 0;
  padding-bottom: 8px;
  letter-spacing: -3px;
  display: inline-block;
  position: relative;
}
#header:before,
#header:after {
  content: "";
  position: absolute;
  top: 50%;
  height: 1px;
  width: 275%;
  display: block;
  background-color: rgba(0, 0, 0, 0.1);
  box-shadow: 0 1px 0 0 rgba(255, 255, 255, 0.795);
}
#header:before {
  right: 100%;
  margin-right: 0.5em;
}
#header:after {
  left: 100%;
  margin-left: 0.5em;
}
#sub-header {
  font-size: 24px;
  letter-spacing: -1px;
}
@media (max-width: 767px) {
  #industry-header {
    font-size: 42px;
  }
  #industry-sub-header {
    font-size: 18px;
  }
}

/* loading section */
.load {
  text-align: center;
}
</style>
