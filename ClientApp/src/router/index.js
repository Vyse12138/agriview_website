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
    name: "Home",
    component: Home
  },
  {
    path: "/contact",
    name: "Contact",
    component: Contact
  },
  {
    path: "/industry_insight",
    name: "Industry insight",
    component: IndustryInsight
  },
  {
    path: "/editor",
    name: "Editor",
    component: Editor
  }
];

const router = new VueRouter({
  routes
});

export default router;
