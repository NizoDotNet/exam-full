<template>
  <div>
    <h2>Update Subject and Quastions</h2>
    <div class="form-control mb-3 bg-light">
      <label class="form-label">Subject Name</label>
      <textarea type="text" class="form-control" v-model="model.name"></textarea>
    </div>
    <div class="form-control mb-3 bg-light p-3" v-for="q in quastionCount" :key="q">
      <button @click="removeQuastion(n - 1)" class="btn btn-danger">X</button>
      <br />
      <UpdateQuastions v-model="model.quastions[q - 1]" :quastion-no="q" />
    </div>

    <button @click="addQuastion" class="btn btn-success">+</button>
  </div>
</template>

<script setup>
import UpdateQuastions from './UpdateQuastions.vue'
import { ref } from 'vue'
const model = defineModel()

const quastionCount = ref(model.value.quastions.length)

const addQuastion = () => {
  model.value.quastions.push({
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
  model.value.quastions.splice(index, 1)
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
