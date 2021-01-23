import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Contact from "../views/Contact.vue";
import Editor from "../views/Editor.vue";
import IndustryInsight from "../views/IndustryInsight.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    component: Home
  },
  {
    path: "/contact",
    component: Contact
  },
  {
    path: "/industry_insight",
    component: IndustryInsight
  },
  {
    path: "/news/:securityKey",
    component: Editor,
    props: true
  }
];

const router = new VueRouter({
  routes
});
export default router;
