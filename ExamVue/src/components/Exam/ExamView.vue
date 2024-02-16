<template>
  <div v-if="notFound">
    <NotFound />
  </div>

  <div class="container">
    <h2>Test Exam</h2>

    <div v-if="!examFinished">
      <QuastionForm :data="data" />
      <button @click="postRequest" class="btn btn-primary mt-3">Submit</button>
    </div>
    <div v-else-if="examFinished">
      <ExamReults :correct-answers-count="correctAnswersCount" :quastion-count="quastionCount" />
    </div>
  </div>
</template>

<script setup>
import QuastionForm from './QuastionForm.vue'
import NotFound from '../NotFound.vue'
import ExamReults from './ExamResults.vue'
import { useRoute } from 'vue-router'
import { ref } from 'vue'
import axios from 'axios'

const route = useRoute()
const data = ref()
const notFound = ref(false)
const examFinished = ref(false)
const Id = route.params.id
const correctAnswersCount = ref(0)
let quastionCount = 1

fetch(`https://localhost:7275/api/Subject/Mix/${Id}?quastionsCount=${route.query.count}`)
  .then((res) => {
    if (res.ok) {
      res = res.json()
      notFound.value = false
    } else {
      notFound.value = true
    }
    return res
  })
  .then((d) => (data.value = d))
  .catch((e) => console.log(e))

const pickedAnswers = ref([])
const getValues = () => {
  const checkedRadios = document.querySelectorAll('input[type="radio"]:checked')
  pickedAnswers.value = Array.from(checkedRadios, (radio) => radio.value)
}

const postRequest = async () => {
  getValues()
  const bodyData = { pickedAnswers: [...pickedAnswers.value] }
  quastionCount = data.value.quastions.length
  axios
    .post('https://localhost:7275/api/Answer/check', bodyData)
    .then((r) => {
      r.data.forEach((v) => {
        if (v) correctAnswersCount.value++
      })
      return r
    })
    .catch((e) => console.log(e))

  examFinished.value = true
}
</script>

<style scoped>
h2 {
  display: flex;
  justify-content: center;
  text-align: center;
  margin-top: 10px;
  margin-bottom: 10px;
}
</style>
