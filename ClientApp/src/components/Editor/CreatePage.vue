<template>
  <!-- Editor page -->

  <div class="editor" v-if="securityCheck">
    <router-view></router-view>
    <h3>Upload News</h3>
    <br />

    <!-- upload failure alert -->
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
        <!-- image preview -->
        <img class="img" v-if="img" :src="imgUrl" />
      </div>
      <div class="form-group">
        <label for="content">Cover Content</label>
        <vue-editor v-model="news.content" :editor-toolbar="contentToolbar" />
      </div>
      <div class="form-group">
        <label for="contentDetail">Detail Content</label>
        <vue-editor
          v-model="news.contentDetail"
          :editor-toolbar="contentDetailToolbar"
        />
      </div>
      <button class="btn btn-success " v-on:click="handleOnUpload">
        Upload
      </button>
      <router-link
      :to="'/news/' + securityKey"
      class="btn btn-danger"
      >
        Back
      </router-link>
    </form>
    <!-- upload success alert -->
    <div class="alert alert-success mt" v-if="uploaduccess">
      <b>Upload successful!</b>
    </div>
  </div>
</template>

<script>
import { VueEditor } from "vue2-editor";
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);
Vue.prototype.$server = "https://localhost:44381/";
export default {
  components: { VueEditor },
  props: {
    securityKey: {
      type: String
    }
  },
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
      content: "Cover Content",
      contentDetail: "<h4>Detail Content</h4>"
    },
    img: undefined,
    imgUrl: undefined,
    errors: [],
    uploaduccess: false,
    securityCheck: false
  }),
  mounted() {
    if (this.securityKey.match(/kyle/)) {
      this.securityCheck = true;
    }
  },
  methods: {
    //img file selection function
    handleImgChange: function(e) {
      this.news.img = e.target.files[0].name;
      this.img = e.target.files[0];
      this.imgUrl = URL.createObjectURL(e.target.files[0]);
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

      //alet upload success
      this.uploaduccess = true;
      //reset the page
      this.news = {
        id: "",
        title: "",
        date: "",
        author: "",
        img: "",
        content: "",
        contentDetail: ""
      };
      this.img = undefined;
      this.imgUrl = undefined;
    }
  }
};
</script>

<style scoped>
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

/* margin top */
.mt {
  margin-top: 1em;
}

/* buttons */
.btn {
  width: 70px;
  margin-right: 10px;
}
</style>
