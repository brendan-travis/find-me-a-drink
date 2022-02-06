<template>
  <section v-if="locations?.length > 0">
    <section v-if="showHeader" class="mb-6">
      <p class="font-light leading-tight text-6xl">We recommend "{{ headerLocation?.name }}"</p>
      <div class="flex justify-center border-t pt-4">
        <img class="max-h-32 max-w-32 mx-4" :src="headerLocation?.thumbnail">
        <div class="text-left">
          <p class="font-medium leading-tight text-1xl">{{ headerLocation?.address }}</p>
          <p class="font-medium leading-tight text-1xl">{{ headerLocation?.phone }}</p>
          <p class="font-medium leading-tight text-1xl">Beer: {{ headerLocation?.rating.beer }}</p>
          <p class="font-medium leading-tight text-1xl">Amenities: {{ headerLocation?.rating.amenities }}</p>
          <p class="font-medium leading-tight text-1xl">Value: {{ headerLocation?.rating.value }}</p>
          <p class="font-medium leading-tight text-1xl">Atmosphere: {{ headerLocation?.rating.atmosphere }}</p>
        </div>
      </div>
      <p class="mt-10 leading-tight text-2xl">Or maybe one of these</p>
    </section>
    <div class="flex flex-col mx-8 shadow rounded overflow-hidden">
      <table>
        <tr class="bg-blue-200 text-xs font-medium tracking-wider text-left uppercase text-gray-900">
          <th class="py-3 px-6">Name</th>
          <th class="py-3 px-6">Address</th>
          <th class="py-3 px-6">Category</th>
          <th class="py-3 px-6">Phone</th>
          <th class="py-3 px-6">Beer</th>
          <th class="py-3 px-6">Amenities</th>
          <th class="py-3 px-6">Value</th>
          <th class="py-3 px-6">Atmosphere</th>
          <th class="py-3 px-6">Twitter</th>
        </tr>
        <tr
            v-for="location in locations"
            class="border-t bg-gray-100 py-4 px-6 text-sm text-left text-gray-800 whitespace-nowrap"
        >
          <td class="py-3 px-6">{{ location.name }}</td>
          <td class="py-3 px-6">{{ location.address }}</td>
          <td class="py-3 px-6">{{ location.category }}</td>
          <td class="py-3 px-6">{{ location.phone }}</td>
          <td class="py-3 px-6">{{ location.rating.beer }}</td>
          <td class="py-3 px-6">{{ location.rating.amenities }}</td>
          <td class="py-3 px-6">{{ location.rating.value }}</td>
          <td class="py-3 px-6">{{ location.rating.atmosphere }}</td>
          <td class="py-3 px-6">{{ location.twitter }}</td>
        </tr>
      </table>
    </div>
    <div class="flex flex-row justify-end mt-2 mr-8">
      <button
          class="text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center"
          @click="prev"
      >
        Previous
      </button>
      <p class="px-4">Page: {{ pageIndex + 1 }} of {{ pageLimit }}</p>
      <button
          class="text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center"
          @click="next"
      >
        Next
      </button>
    </div>
  </section>
  <section v-else>
    <p class="mt-10 leading-tight text-4xl">I'm sorry but we couldn't find anything with that criteria</p>
    <router-link  to="/" class="underline font-medium leading-tight text-1xl">Try again?</router-link>
  </section>
</template>

<script setup lang="ts">
import {ref, watch} from "vue";
import {getLocations} from "../services/location-service";
import {ILocation} from "../services/interfaces";

interface props {
  showHeader?: boolean,
  rating?: string,
  categories?: string,
  tags?: string,
  search?: string
}

const props = defineProps<props>();

const locations = ref<ILocation[]>();
const headerLocation = ref<ILocation>();
const limit = 10;
const pageIndex = ref(0);
const pageLimit = ref(1);

watch(pageIndex, () => {
  refreshData();
});

const refreshData = async () => {
  const response = await getLocations(pageIndex.value * limit, limit, props.rating, props.categories, props.tags, props.search);
  locations.value = response.data;
  pageLimit.value = Math.ceil((response.recordCount) / limit);

  if (!headerLocation.value) {
    headerLocation.value = locations.value[0];
  }
};

const next = () => {
  if (pageIndex.value < pageLimit.value - 1) {
    pageIndex.value++;
  }
};

const prev = () => {
  if (pageIndex.value > 0) {
    pageIndex.value--;
  }
};

refreshData();
</script>
