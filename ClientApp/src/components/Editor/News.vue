<template>
  <div class="news">
    <!-- news section -->
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
        <span v-html="coverContent"></span>
      </div>
      <!-- link to edit news page -->
      <router-link
        class="btn btn-warning"
        :to="'/admin/news/' + securityKey + '/edit/' + news.id"
      >
        Edit
      </router-link>
      <!-- button to delete news -->
      <button class="btn btn-danger" :id="news.id" v-on:click="handleOnDelete">
        Delete
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "News",
  props: {
    news: Object,
    securityKey: String
  },
  data() {
    return {
      coverContent: ""
    };
  },
  mounted() {
    this.coverContent = this.news.contentDetail
      .replace(/<(style|script|iframe)[^>]*?>[\s\S]+?<\/\1\s*>/gi, "")
      .replace(/<[^>]+?>/g, "")
      .replace(/\s+/g, " ")
      .replace(/ /g, " ")
      .replace(/>/g, " ")
      .substring(0, 380);
    this.coverContent = this.coverContent
      .substring(0, this.coverContent.lastIndexOf(" "))
      .concat("...");
  },
  methods: {
    //delete function
    handleOnDelete: function() {
      this.$emit("onDelete", this.news.id);
    }
  }
};
</script>

<style scoped>
/* list of news */
.news-content {
  border: 1px solid rgba(0, 0, 0, 0.15);
  border-radius: 4px;
  box-shadow: 0 0.125em 0.275em 0 rgba(0, 0, 0, 0.125);
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
  color: black;
  background-color: #fff;
  overflow: hidden;
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

/* buttons */
.btn {
  width: 70px;
  margin: 5px;
}
</style>
