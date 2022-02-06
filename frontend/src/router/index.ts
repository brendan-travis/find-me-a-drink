import { createWebHistory, createRouter } from "vue-router";
import QueryBuilder from "@/views/QueryBuilder.vue";
import AllLocations from "@/views/AllLocations.vue";
import RecommendedLocations from "@/views/RecommendedLocations.vue";

const routes = [
    {
        path: "/",
        name: "Query",
        component: QueryBuilder,
    },
    {
        path: "/locations",
        name: "Locations",
        component: AllLocations,
    },
    {
        path: "/recommended",
        name: "Recommended Locations",
        component: RecommendedLocations,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
