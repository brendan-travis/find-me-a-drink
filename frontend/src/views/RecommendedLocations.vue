<template>
  <div class="flex flex-row mt-4 ml-4">
    <router-link
        class="mr-4 text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center"
        to="/"
    >
        Let me choose again
    </router-link>
    <router-link to="/locations">
      <button
          class="text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center"
      >
        Show me all locations
      </button>
    </router-link>
  </div>
 <LocationList
     show-header
     :rating="route?.query?.rating"
     :categories="route?.query?.categories"
     :tags="route?.query?.tags"
     :search="route?.query?.search"
 />
</template>

<script setup lang="ts">
import LocationList from "../components/LocationList.vue";
import {useRoute} from "vue-router";

const route=useRoute();
</script>
