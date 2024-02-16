<template>
  <label class="form-label">{{ quastionNo }}. </label>
  <textarea
    type="text"
    class="form-control"
    placeholder="Quastion text"
    v-model="model.text"
  ></textarea>
  <div class="form-control mt-3">
    <AddAnswer
      v-for="n in model.answers.length"
      :key="n"
      v-model="model.answers[n - 1]"
      :answer-no="n"
      :quastion-no="quastionNo"
    />
  </div>
</template>

<script setup>
defineProps({
  quastionNo: Number
})
import AddAnswer from './AddAnswer.vue'
const model = defineModel()
</script>

<style scoped>
.delete-button {
  display: flex;
  justify-content: end;
}
</style>
