<template>
  <label class="form-label">{{ answerNo }}</label>
  <textarea
    v-model="model.text"
    type="text"
    class="form-control"
    placeholder="Answer text"
  ></textarea>
  <input
    type="checkbox"
    :name="quastionNo"
    class="form-control-input"
    v-model="model.isCorrect"
    :value="true"
  />
  <span>Answer {{ answerNo }} is Correct Variant</span>
  <br />
</template>

<script setup>
defineProps({
  answerNo: Number,
  quastionNo: Number
})
const model = defineModel()
</script>
