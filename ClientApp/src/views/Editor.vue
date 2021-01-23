<template>
  <!-- Editor page -->
  <div class="editor">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  props: {
    securityKey: {
      type: String
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
</style>
