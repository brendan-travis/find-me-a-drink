<template>
  <div class="flex flex-row mt-4 ml-4">
    <router-link class="mr-4" to="/">
      <button
          class="text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center"
      >
        I'm ready to choose
      </button>
    </router-link>
  </div>
  <section class="mt-4">
    <LocationList/>
  </section>
</template>

<script setup lang="ts">
import LocationList from "../components/LocationList.vue";
</script>
