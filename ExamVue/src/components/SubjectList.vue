<template>
  <div v-if="notFound">
    <NotFound />
  </div>
  <div class="container">
    <div class="d-flex align-items-center justify-content-center" v-for="db in data" :key="db.id">
      <SubjectBlock :route-name="routeName" :-subject="db" :-count="Count" />
    </div>
  </div>
</template>

<script setup>
defineProps({
  routeName: Text,
  Count: Number
})
import { ref } from 'vue'
import SubjectBlock from './SubjectBlock.vue'
import NotFound from './NotFound.vue'
const data = ref([])
const notFound = ref(false)
fetch('https://localhost:7275/api/Subject')
  .then((r) => {
    if (!r.ok) {
      notFound.value = true
    }
    return r
  })
  .then((d) => d.json())
  .then((d) => {
    data.value = [...d]
    return d
  })
  .catch(() => {
    notFound.value = true
  })
</script>
