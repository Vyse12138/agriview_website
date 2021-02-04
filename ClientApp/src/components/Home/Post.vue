<template>
  <div class="post">
    <img :src="require(`@/assets/${this.img}`)" alt="Placeholder" />
    <div class="post-text">
      <h4>{{ this.title }}</h4>
      <p>
        {{ this.content }}
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Post",
  props: {
    title: {
      type: String
    },
    img: {
      type: String
    },
    content: {
      type: String
    }
  }
};
</script>

<style scoped>
.post {
  overflow: hidden;
  height: 400px;
  float: left;
  margin-left: 2%;
  margin-right: 2%;
  margin-bottom: 75px;
  margin-top: 45px;
  width: 29.33333333%;
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.15);
  border-radius: 4px;
  box-shadow: 0 0.125em 0.275em 0 rgba(0, 0, 0, 0.125);
}

.post-text {
  padding: 0.5em 1.5em;
}

@media (max-width: 800px) {
  .post {
    float: none;
    width: 100%;
    margin-bottom: 45px;
    height: auto;
  }
}
</style>
