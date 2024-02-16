<template>
  <label>{{ quastionNo }}. </label>
  <textarea type="text" v-model="model.text" class="form-control"></textarea>
  <div class="form-control mt-3">
    <UpdateAnswer
      class="form-control mt-3"
      v-for="a in model.answers.length"
      :key="a"
      v-model="model.answers[a - 1]"
      :answer-no="a"
      :quastion-no="quastionNo"
    />
  </div>
</template>

<script setup>
defineProps({
  quastionNo: Number
})

import UpdateAnswer from './UpdateAnswer.vue'

const model = defineModel()
</script>
