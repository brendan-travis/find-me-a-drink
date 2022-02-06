<template>
  <p class="font-light leading-tight text-6xl mt-4">Let's find you a drink 🍺</p>
  <p class="font-medium">What's important to you?</p>
  <Form class="border-t" v-slot="{values}" @submit="submit">
    <div class="flex justify-center text-left mt-2">
      <fieldset class="mx-2">
        <p class="font-medium">Rating</p>
        <section v-for="rating in ratings">
          <Field v-slot="{ field }" name="rating" type="radio" :value="rating">
            <label class="capitalize">
              <input type="radio" v-bind="field" :value="rating" />
              {{ rating }}
            </label>
          </Field>
        </section>
      </fieldset>
      <fieldset class="mx-2">
        <p class="font-medium">Categories</p>
        <section v-for="category in categories">
          <Field v-slot="{ field }" :name="category" type="checkbox" :value="true">
            <label class="capitalize">
              <input type="checkbox" v-bind="field" :value="true" />
              {{ category }}
            </label>
          </Field>
        </section>
      </fieldset>
      <fieldset class="mx-2">
        <p class="font-medium">Tags</p>
        <section v-for="tag in tags">
          <Field v-slot="{ field }" :name="tag" type="checkbox" :value="true">
            <label class="capitalize">
              <input type="checkbox" v-bind="field" :value="true" />
              {{ tag }}
            </label>
          </Field>
        </section>
      </fieldset>
      <fieldset class="mx-2">
        <p class="font-medium">Keywords</p>
        <Field class="border" name="search" type="text" />
      </fieldset>
    </div>
    <div class="flex flex-row mt-4 ml-4 justify-center">
      <button class="text-gray-100 border bg-blue-700 hover:bg-blue-800 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center mr-2" type="submit">Submit</button>
      <router-link class="text-gray-800 border bg-gray-100 hover:bg-gray-200 focus:ring-2 focus:ring-blue-400 font-medium rounded-lg text-sm px-4 py-1 text-center" to="/locations">See all locations</router-link>
    </div>
  </Form>
</template>

<script setup lang="ts">
import { Form, Field } from "vee-validate";
import router from "../router";
import {ref} from "vue";

const ratings = [
    "beer",
    "atmosphere",
    "amenities",
    "value"
]
const categories = [
    "Bar reviews",
    "Pub reviews",
    "Closed venues",
    "Other reviews",
    "Uncategorized"
];
const tags = [
  "arcade games",
  "beer garden",
  "breakfast",
  "coffee",
  "dance floor",
  "darts",
  "food",
  "free wifi",
  "jukebox",
  "karaoke",
  "lgbt",
  "live music",
  "membership discount",
  "pool table",
  "quiz",
  "sofas",
  "sports",
  "sunday roasts",
]

const selectedTags = ref<string>();
const selectedCategories = ref<string>();

const addTag = (tag: string) => {
  if (tag) {
    if (selectedTags.value) {
      selectedTags.value += ","
    } else {
      selectedTags.value = ""
    }
    selectedTags.value += tag;
  }
}

const addCategory = (category: string) => {
  if (category) {
    if (selectedCategories.value) {
      selectedCategories.value += ","
    } else {
      selectedCategories.value = ""
    }
    selectedCategories.value += category;
  }
}

const submit = (values: unknown) => {
  tags.forEach(tag => {
    if (values[tag]) {
      addTag(tag);
    }
  });
  categories.forEach(category => {
    if (values[category]) {
      addCategory(category)
    }
  });

  router.push({
    path: "recommended",
    query : {
      rating: values.rating,
      categories: selectedCategories.value,
      tags: selectedTags.value,
      search: values.search
    }
  });
}
</script>
