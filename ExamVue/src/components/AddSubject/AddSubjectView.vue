<template>
  <div class="container">
    <h2>Create Subject and Quastions</h2>
    <div class="form-control mb-3 bg-light">
      <label class="form-label">Subject Name</label>
      <input type="text" class="form-control" v-model="bodyData.name" />
    </div>
    <div v-for="n in quastionCount" :key="n" class="form-control mb-3 bg-light p-3">
      <button @click="removeQuastion(n - 1)" class="btn btn-danger">X</button>
      <br />
      <AddQuastion v-model="bodyData.quastions[n - 1]" :quastion-no="n" />
    </div>
    <button class="btn btn-primary mb-3" @click="addQuastion">+</button>
    <br />
    <button @click="addSubject" class="btn btn-success">Submit</button>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'
import AddQuastion from '../AddSubject/AddQuastion.vue'

const bodyData = ref({
  name: '',
  quastions: [
    {
      text: '',
      answers: [
        {
          text: '',
          isCorrect: false
        },
        {
          text: '',
          isCorrect: false
        },
        {
          text: '',
          isCorrect: false
        },
        {
          text: '',
          isCorrect: false
        },
        {
          text: '',
          isCorrect: false
        }
      ]
    }
  ]
})

const quastionCount = ref(1)

const addSubject = () => {
  axios
    .post('https://localhost:7275/api/Subject/fullsubject', bodyData.value)
    .catch((e) => console.log(e))
}

const addQuastion = () => {
  bodyData.value.quastions.push({
    text: '',
    answers: [
      {
        text: '',
        isCorrect: false
      },
      {
        text: '',
        isCorrect: false
      },
      {
        text: '',
        isCorrect: false
      },
      {
        text: '',
        isCorrect: false
      },
      {
        text: '',
        isCorrect: false
      }
    ]
  })
  quastionCount.value++
}

const removeQuastion = (index) => {
  bodyData.value.quastions.splice(index, 1)
  quastionCount.value--
}
</script>

<style scoped>
h2 {
  display: flex;
  text-align: center;
  justify-content: center;
}

.btn-danger {
  position: relative;
  left: 98%;
}
</style>
