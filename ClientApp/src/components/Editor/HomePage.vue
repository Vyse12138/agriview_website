<template>
  <!-- editor page -->
  <div v-if="securityCheck">
    <div class="title">
      <h3 class="header">Editor</h3>
      <!-- link to upload news page -->
      <router-link
        :to="'/admin/news/' + securityKey + '/upload'"
        class="btn btn-success upload"
      >
        Upload
      </router-link>
    </div>
    <!-- loading indicator -->
    <h3 class="load" v-if="loading">Loading...</h3>
    <h3 class="load" v-if="error">There was some error...</h3>

    <News
      v-for="news in newsList"
      v-bind:key="news.id"
      :news="news"
      :securityKey="securityKey"
      @onDelete="handleOnDelete"
    />
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
import News from "@/components/Editor/News.vue";

Vue.use(VueAxios, axios);
//change the server link here
Vue.prototype.$server = "https://localhost:44381/api/news/";
export default {
  name: "HomePage",
  components: {
    News
  },
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
    //security check
    if (this.securityKey.match(/kyle/)) {
      this.securityCheck = true;
    }
    //show loading indicator
    this.loading = true;
    //get request to render the page
    axios
      .get(this.$server)
      .then(response => {
        this.newsList = response.data;
      })
      .catch(error => {
        //show error
        this.error = true;
        console.error("There was an error on getting data!", error);
      })
      .finally(() => {
        //turn off loading indicator
        this.loading = false;
      });
  },
  methods: {
    //delete function
    handleOnDelete: function(id) {
      let answer = window.confirm("Are you sure you want to delete this news?");
      if (answer) {
        //delete request
        axios
          .delete(`${this.$server}` + id)
          .then(response => {
            console.log(response);
          })
          .catch(error => {
            console.error("There was an error when deleting news!", error);
          });
        //get request to rerender the page
        setTimeout(() => {
          axios
            .get(this.$server)
            .then(response => {
              this.newsList = response.data;
            })
            .catch(error => {
              console.error("There was an error!", error);
            });
        }, 100);
      }
    }
  }
};
</script>

<style scoped>
/* loading section */
.load {
  text-align: center;
}

/* buttons */
.btn {
  width: 70px;
  margin: 5px;
}

/* title section */
.title {
  display: flex;
}

.header {
  flex: 0 0 80%;
}

.upload {
  height: 35px;
  flex: 1;
  margin-top: 10px;
}
</style>
