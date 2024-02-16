<template>
  <div class="text-center mt-3 grid">
    <router-link
      v-if="Count > 0"
      :to="{ name: routeName, params: { id: Subject.id }, query: { count: Count } }"
      class="text-dark"
      >{{ Subject.name }}</router-link
    >
    <router-link v-else :to="{ name: routeName, params: { id: Subject.id } }" class="text-dark">{{
      Subject.name
    }}</router-link>
  </div>
</template>

<script setup>
defineProps({
  Subject: Object,
  routeName: Text,
  Count: Number
})
</script>

<style scoped>
a {
  text-align: center;
  text-decoration: none;
}
div {
  width: 700px;
  height: 35px;
  border: solid;
  border-width: thin;
  border-radius: 20px;
  box-shadow: 2px 2px darkgrey;
}
</style>
