<template>
  <!-- Editor page -->

  <div class="editor">
    <h3>Upload News</h3>
    <br />
    <div class="alert alert-warning" v-if="errors.length">
      <b>Upload failed:</b>
      <ul>
        <li v-for="error in errors" v-bind:key="error">{{ error }}</li>
      </ul>
    </div>
    <form>
      <div class="form-group">
        <label for="title">Title</label>
        <input
          type="text"
          class="form-control"
          v-model="news.title"
          placeholder="Title"
        />
      </div>
      <div class="form-group">
        <label for="author">Author</label>
        <input
          type="text"
          class="form-control"
          v-model="news.author"
          placeholder="Author"
        />
      </div>
      <div class="form-group">
        <label for="date">Date</label>
        <input type="date" class="form-control" v-model="news.date" />
      </div>
      <div class="form-group">
        <label for="file">Cover Image</label>
        <input type="file" @change="handleImgChange" accept="image/*" />
        <img class="img" v-if="img" :src="imgUrl" />
      </div>
      <div class="form-group">
        <label for="content">Cover Content</label>
        <vue-editor v-model="news.content" :editor-toolbar="contentToolbar" />
      </div>
      <div class="form-group">
        <label for="file">Detail Image</label>
        <input type="file" @change="handleImgDetailChange" accept="image/*" />
        <img class="img" v-if="imgDetail" :src="imgDetailUrl" />
      </div>
      <div class="form-group">
        <label for="contentDetail">Detail Content</label>
        <vue-editor
          v-model="news.contentDetail"
          :editor-toolbar="contentDetailToolbar"
        />
      </div>
      <button class="btn btn-primary" v-on:click="handleOnUpload">
        Upload
      </button>
    </form>
  </div>
</template>

<script>
import { VueEditor } from "vue2-editor";
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);
    Vue.prototype.$server = "https://localhost:44381/api/news/";
export default {
  components: { VueEditor },

  data: () => ({
    contentToolbar: [["bold", "italic", "underline", "strike"]],
    contentDetailToolbar: [
      [{ header: [false, 1, 2, 3, 4, 5, 6] }],
      ["bold", "italic", "underline", "strike"],
      ["blockquote", "code-block"],
      [{ list: "ordered" }, { list: "bullet" }, { list: "check" }],
      [{ indent: "-1" }, { indent: "+1" }],
      [{ color: [] }, { background: [] }],
      ["link", "clean"]
    ],
    news: {
      id: "",
      title: "",
      date: "",
      author: "",
      img: "",
      imgDetail: "",
      content: "Cover Content",
      contentDetail: "<h4>Detail Content</h4>"
    },
    img: undefined,
    imgDetail: undefined,
    imgUrl: undefined,
    imgDetailUrl: undefined,
    errors: []
  }),
  methods: {
    //img file selection function
    handleImgChange: function(e) {
      this.news.img = e.target.files[0].name;
      this.img = e.target.files[0];
      this.imgUrl = URL.createObjectURL(e.target.files[0]);
    },
    handleImgDetailChange: function(e) {
      this.news.imgDetail = e.target.files[0].name;
      this.imgDetail = e.target.files[0];
      this.imgDetailUrl = URL.createObjectURL(e.target.files[0]);
    },
    //upload function
    handleOnUpload: function(e) {
      e.preventDefault();
      // input validation
      this.errors = [];
      if (!this.news.title) {
        this.errors.push("Please enter title.");
      }
      if (!this.news.date) {
        this.errors.push("Please enter date.");
      }
      if (!this.news.author) {
        this.errors.push("Please enter author.");
      }
      if (!this.news.img) {
        this.errors.push("Please upload cover image.");
      }
      if (!this.news.imgDetail) {
        this.errors.push("Please upload detail image.");
      }
      if (!this.news.content) {
        this.errors.push("Please enter cover content.");
      }
      if (!this.news.contentDetail) {
        this.errors.push("Please enter detail content.");
      }
      if (this.errors.length) {
        window.scrollTo(0, 0);
        throw new Error("Input cannot be empty");
      }
      //generate id
      this.news.id = `Post${this.news.date.replace("-", "").slice(0, 6)}_${
        this.news.title.split(" ")[0]
      }`;
      //post to server
      axios
        .post(`${this.$server}`, this.news)
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error!", error);
        });

      axios
        .post(`${this.$server}/image/${this.news.img}`, this.img)
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error!", error);
        });

      axios
        .post(`${this.$server}/image/${this.news.imgDetail}`, this.imgDetail)
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error!", error);
        });
      alert("Upload successful.");
      //reset the
      this.news = {
        id: "",
        title: "",
        date: "",
        author: "",
        img: "",
        imgDetail: "",
        content: "Cover Content",
        contentDetail: "<h4>Detail Content</h4>"
      };
    }
  }
};
</script>

<style scoped>
.editor {
  margin-top: 95px;
  max-width: 980px;
  margin-left: auto;
  margin-right: auto;
  width: 88%;
  padding-bottom: 200px;
}
#date {
  color: #999;
  line-height: normal;
}
input,
textarea {
  background-color: #f2f2f2;
}

/* upload img preview */
.img {
  height: 300px;
  width: 300px;
  margin: 10px;
  box-shadow: 5px 5px 5px;
}

/* errors */
li {
  color: #8a6d3b;
}
</style>
