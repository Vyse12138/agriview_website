<template>
  <div class="industry" v-if="securityCheck">
    <!-- header section -->
    <header id="header-section">
      <h1 id="header">Edit News</h1>
    </header>
    <router-link
      :to="'/news/' + securityKey + '/create'"
      class="btn btn-success"
    >
      Create
    </router-link>
    <!-- loading indicator -->
    <h3 class="load" v-if="loading">Loading...</h3>
    <h3 class="load" v-if="error">There was some error...</h3>

    <!-- news section -->
    <div class="newsList" v-for="news in newsList" v-bind:key="news.id">
      <!-- list of news -->
      <div class="news-content">
        <div class="new-img-container">
          <img
            class="news-img"
            :src="$server + 'image/' + news.img"
            alt="Placeholder"
          />
        </div>
        <div class="news-text">
          <h4>{{ news.title }}</h4>
          <p>
            <i class="fas fa-table"></i> {{ news.date }}
            <i class="fas fa-pen"></i> by {{ news.author }}
          </p>
          <span v-html="news.content"></span>
        </div>
        <button class="btn btn-warning">Edit</button>
        <button class="btn btn-danger">Delete</button>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

Vue.use(VueAxios, axios);
Vue.prototype.$server = "https://localhost:44381/api/news/";
export default {
  props: {
    securityKey: {
      type: String
    }
  },
  data: () => ({
    newsList: undefined,
    loading: false,
    error: false,
    securityCheck: false
  }),
  mounted() {
    if (this.securityKey.match(/kyle/)) {
      this.securityCheck = true;
    }
    this.loading = true;
    axios
      .get(this.$server)
      .then(response => {
        this.newsList = response.data;

        console.log(this.newsList);
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

@media (max-width: 767px) {
  #industry-header {
    font-size: 42px;
  }
}

/* loading section */
.load {
  text-align: center;
}

/* list of news */
.news-content {
  border: 1px solid rgba(0, 0, 0, 0.15);
  border-radius: 4px;
  box-shadow: 0 0.125em 0.275em 0 rgba(0, 0, 0, 0.125);
  overflow: hidden;
  float: left;
  margin: 1.5%;
  width: 30.3333333%;
}

.news-img {
  width: 100%;
  height: auto;
}
.news-text {
  padding: 1.5em;
  background-color: #fff;
  height: 350px;
}
@media (max-width: 1199px) {
  .news-content {
    width: 46.3333333%;
  }
}

@media (max-width: 660px) {
  .news-content {
    float: none;
    width: 88%;
    margin-bottom: 45px;
    margin-left: auto;
    margin-right: auto;
  }
  .news-text {
    height: auto;
  }
}

/* buttons */
.btn {
  width: 70px;
  margin: 5px;
}
</style>
