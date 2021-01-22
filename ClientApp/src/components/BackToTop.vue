<template>
  <transition name="fade">
    <div class="back-to-top" v-show="visible" @click="backToTop">
      <i class="fas fa-angle-up"></i>
    </div>
  </transition>
</template>

<script>
export default {
  name: "BackToTop",

  data() {
    return {
      visible: false
    };
  },
  mounted() {
    window.smoothscroll = () => {
      let currentScroll =
        document.documentElement.scrollTop || document.body.scrollTop;
      if (currentScroll > 0) {
        window.requestAnimationFrame(window.smoothscroll);
        window.scrollTo(0, Math.floor(currentScroll - currentScroll / 8));
      }
    };
    window.addEventListener("scroll", this.catchScroll);
  },
  destroyed() {
    window.removeEventListener("scroll", this.catchScroll);
  },
  methods: {
    catchScroll() {
      this.visible = window.pageYOffset > parseInt(200);
    },
    backToTop() {
      window.smoothscroll();
    }
  }
};
</script>

<style>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.7s;
}
.fade-enter,
.fade-leave-to {
  opacity: 0;
}
.back-to-top {
  cursor: pointer;
  position: fixed;
  z-index: 1000;
  bottom: 30px;
  right: 30px;
  border: 2px solid #272727;
  border-radius: 100%;
  width: 35px;
  height: 35px;
  font-size: 25px;
  line-height: 27px;
  color: #272727;
  text-align: center;
}
</style>
