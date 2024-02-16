<template>
  <button class="btn btn-success">Download</button>
  <div class="container">
    <h2>{{ data.name }}</h2>
    <div v-for="n in data.quastions.length" :key="n" class="form-control mb-3 bg-light p-3">
      <QuastionComponent v-model="data.quastions[n - 1]" :quastion-no="n" />
    </div>
  </div>
</template>

<script setup>
import { useRoute } from 'vue-router'
import { ref } from 'vue'

import QuastionComponent from './QuastionComponent.vue'
const route = useRoute()

const data = ref()
fetch(`https://localhost:7275/api/subject/getwithcorrectanswers/${route.params.id}`)
  .then((r) => r.json())
  .then((r) => {
    data.value = r
  })
  .catch((c) => console.log(c))
</script>

<style scoped>
button {
  position: fixed;
  display: flex;
  justify-content: end;
}
</style>
