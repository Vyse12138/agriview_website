import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Contact from "../views/Contact.vue";
import Editor from "../views/Editor.vue";
import HomePage from "../components/Editor/HomePage.vue";
import EditPage from "../components/Editor/EditPage.vue";
import UploadPage from "../components/Editor/UploadPage.vue";
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
        component: HomePage,
        props: true
      },
      {
        path: "upload",
        component: UploadPage,
        props: true
      },
      {
        path: "edit/:id",
        component: EditPage,
        props: true
      }
    ]
  }
];

const router = new VueRouter({
  routes
});
export default router;
