<template>
  <h2>{{ correctAnswersCount }}/{{ quastionCount }}</h2>
</template>

<script setup>
defineProps({
  quastionCount: Number,
  correctAnswersCount: Number
})
</script>
