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
        <button data-toggle="modal" :data-target="'#' + news.id">
          Read More
        </button>
      </div>

      <!-- news detail dialog box -->
      <div :id="news.id" class="modal fade" role="dialog">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">
                &times;
              </button>
              <h4>{{ news.title }}</h4>
            </div>
            <div class="modal-body">
              <img class="modal-image" :src="$server + 'image/' + news.img" />
              <span v-html="news.contentDetail"></span>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-default"
                data-dismiss="modal"
              >
                Close
              </button>
            </div>
          </div>
        </div>
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
/* news detail dialog box  */
.modal-dialog {
  width: 61%;
}
.modal-image {
  width: 200px;
  height: 200px;
  margin: 40px;
  float: left;
}

.modal-body {
  min-height: 600px;
}

@media (max-width: 767px) {
  .modal-dialog {
    margin-left: auto;
    margin-right: auto;
    width: 90%;
  }
}
@media (max-width: 440px) {
  .modal-image {
    width: 100%;
    height: 100%;
    margin: 0;
    text-align: center;
    float: none;
  }
}
</style>
