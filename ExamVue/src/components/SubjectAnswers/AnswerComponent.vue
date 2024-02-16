<template>
  <textarea
    v-model="model.text"
    type="text"
    class="form-control mb-3"
    placeholder="Answer text"
    :style="model.isCorrect ? 'background-color: greenyellow;' : ''"
    readonly
  ></textarea>
</template>

<script setup>
defineProps({
  answerNo: Number
})
const model = defineModel()
</script>
