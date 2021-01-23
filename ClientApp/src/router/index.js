import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Contact from "../views/Contact.vue";
import Editor from "../views/Editor.vue";

import EditPage from "../components/Editor/EditPage.vue";
import CreatePage from "../components/Editor/CreatePage.vue";
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
    props: true,
    children: [
      {
        path: "/",
        component: EditPage,
        props: true
      },
      {
        path: "create",
        component: CreatePage,
        props: true
      }
    ]
  }
];

const router = new VueRouter({
  routes
});
export default router;
