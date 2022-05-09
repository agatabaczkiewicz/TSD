
// import HomeView from "../views/HomeView.vue";
import { createRouter, createWebHistory } from 'vue-router'
import AddTask from "@/components/AddTask";
import DetailsTask from "@/components/DetailsTask";
import HomePage from "@/components/HomePage";


const routes = [
    {
        path: "/",
        name: "home",
        component: HomePage
    },
    {
        path: "/add",
        name: "AddTask",
        component: AddTask
    },
    {
        path: "/detail/:id",
        name: "DetailTask",
        component: DetailsTask
    },

];


const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
})

export default router