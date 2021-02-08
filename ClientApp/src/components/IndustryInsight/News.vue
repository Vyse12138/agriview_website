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
            <button type="button" class="btn btn-default" data-dismiss="modal">
              Close
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "News",
  props: {
    news: Object
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
  }
};
</script>

<style scoped>
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
  color: black;
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
