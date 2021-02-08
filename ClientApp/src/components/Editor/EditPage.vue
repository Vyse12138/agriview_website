<template>
  <!-- edit news page -->
  <div v-if="securityCheck">
    <h3>Editing News: {{ id }}</h3>
    <br />
    <!-- upload failure alert -->
    <div class="alert alert-warning" v-if="errors.length">
      <b>Upload failed:</b>
      <ul>
        <li v-for="error in errors" v-bind:key="error">{{ error }}</li>
      </ul>
    </div>
    <form>
      <!-- title input -->
      <div class="form-group">
        <label for="title">Title</label>
        <input
          type="text"
          class="form-control"
          v-model="news.title"
          placeholder="Title"
        />
      </div>
      <!-- author input -->
      <div class="form-group">
        <label for="author">Author</label>
        <input
          type="text"
          class="form-control"
          v-model="news.author"
          placeholder="Author"
        />
      </div>

      <!-- date input -->
      <div class="form-group">
        <label for="date">Date</label>
        <input type="date" class="form-control" v-model="news.date" />
      </div>

      <!-- image upload -->
      <div class="form-group">
        <label for="file">Image</label>
        <input type="file" @change="handleImgChange" accept="image/*" />
        <!-- image preview -->
        <img class="img" v-if="img" :src="imgUrl" />
      </div>

      <!-- detail content editor -->
      <div class="form-group">
        <label for="contentDetail">Content</label>
        <vue-editor
          v-model="news.contentDetail"
          :editor-toolbar="contentDetailToolbar"
        />
      </div>
      <!-- upload and back button -->
      <button class="btn btn-success" v-on:click="handleOnUpload">
        Update
      </button>
      <router-link :to="'/admin/news/' + securityKey" class="btn btn-danger">
        Back
      </router-link>
    </form>
    <!-- upload success alert -->
    <div class="alert alert-success mt" v-if="uploaduccess">
      <b>
        Update successful!
        <br />
        Going back to the editor page...
      </b>
    </div>
  </div>
</template>

<script>
import { VueEditor } from "vue2-editor";
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
import router from "../../router";
Vue.use(VueAxios, axios);
export default {
  components: { VueEditor },
  props: {
    securityKey: {
      type: String
    },
    id: {
      type: String
    }
  },
  data: () => ({
    //customised toolbar for rich text editor
    contentDetailToolbar: [
      [{ header: [false, 1, 2, 3, 4, 5, 6] }],
      ["bold", "italic", "underline", "strike"],
      ["blockquote", "code-block"],
      [{ list: "ordered" }, { list: "bullet" }, { list: "check" }],
      [{ indent: "-1" }, { indent: "+1" }],
      [{ color: [] }, { background: [] }],
      ["link", "clean"]
    ],
    //represeting news being uploaded
    news: {
      id: "",
      title: "",
      date: "2000-11-11",
      author: "",
      img: "",
      content: "",
      contentDetail: "<h4>Content</h4>"
    },
    //image file and link to preview
    img: undefined,
    imgDefault: undefined,
    imgUrl: undefined,
    //input validation errors
    errors: [],
    uploaduccess: false,
    securityCheck: false
  }),
  mounted() {
    //security check
    if (this.securityKey.match(/kyle/)) {
      this.securityCheck = true;
    }
    //get news data from server
    axios
      .get(this.$server + this.id)
      .then(response => {
        this.news = response.data;
        //change date to today
        let date = new Date();
        this.news.date = new Date(
          date.getTime() - date.getTimezoneOffset() * 60000
        )
          .toISOString()
          .slice(0, 10);
      })
      .catch(error => {
        console.error("There was an error loading news!", error);
      });
    //get image data from server
    axios
      .get(this.$server + "image/" + this.news.img)
      .then(response => {
        this.img = response;
        this.imgDefault = response;
        console.log(this.img);
        this.imgUrl = this.$server + "image/" + this.news.img;
      })
      .catch(error => {
        console.error("There was an error loading image!", error);
      });
    window.scrollTo(0, 0);
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
        this.errors.push("Please upload image.");
      }
      if (!this.news.contentDetail) {
        this.errors.push("Please enter detail content.");
      }
      if (this.errors.length) {
        window.scrollTo(0, 0);
        throw new Error("Input cannot be empty");
      }
      //change ' to '' so it  won't affect sql
      this.news.title = this.news.title.replaceAll("'", '"');
      this.news.author = this.news.author.replaceAll("'", '"');
      this.news.contentDetail = this.news.contentDetail.replaceAll("'", '"');

      //post news to server
      axios
        .post(this.$server + this.news.id, this.news)
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error uploading news!", error);
        });
      //post image to server if image is changed
      if (this.img !== this.imgDefault) {
        axios
          .post(`${this.$server}/image/${this.news.img}`, this.img)
          .then(response => {
            console.log(response);
          })
          .catch(error => {
            console.error("There was an error uploading image!", error);
          });
      }
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

      //alet upload success
      this.uploaduccess = true;
      //go back to editor page
      setTimeout(() => {
        router.go(-1);
      }, 1000);
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
