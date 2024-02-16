<template>
  <div class="container">
    <UpdateSubjectComponent v-model="subject" />
    <button @click="updateQuastion" class="btn btn-primary m-3">Submit</button>
  </div>
</template>

<script setup>
import { useRoute, useRouter } from 'vue-router'
import { ref } from 'vue'
import UpdateSubjectComponent from './UpdateSubjectComponent.vue'
import axios from 'axios'
const route = useRoute()
const router = useRouter()
const id = route.params.id
const subject = ref()

fetch(`https://localhost:7275/api/subject/getwithcorrectanswers/${id}`)
  .then((res) => res.json())
  .then((data) => {
    subject.value = data
    return data
  })

const updateQuastion = () => {
  console.log(JSON.stringify(subject.value))
  axios
    .patch(`https://localhost:7275/api/subject/${id}`, subject.value)
    .then((r) => {
      router.push({ path: '/' })
      return r
    })
    .catch()
}
</script>
