<template>
  <label class="form-label">{{ quastionNo }}. </label>
  <textarea
    type="text"
    class="form-control"
    placeholder="Quastion text"
    v-model="model.text"
    readonly
  ></textarea>
  <div class="form-control mt-3">
    <AnswerComponent
      v-for="n in model.answers.length"
      :key="n"
      v-model="model.answers[n - 1]"
      :answer-no="n"
    />
  </div>
</template>

<script setup>
import AnswerComponent from './AnswerComponent.vue'
defineProps({
  quastionNo: Number
})

const model = defineModel()
</script>
