<template>
  <div class="container">
    <div class="quastion-block" v-for="d in data.quastions" :key="d">
      <p>{{ quastionNo++ }}. {{ d.text }}</p>
      <div v-for="a in d.answers" :key="a" class="answers">
        <input type="radio" :name="d.id" :value="a.id" /> {{ a.text }}
        <br />
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  data: Object
})
const quastionNo = 1
</script>

<style scoped>
.quastion-block {
  width: auto;
  height: auto;
  border: solid;
  background-color: lavenderblush;
  padding: 15px;
  margin-top: 5px;
  border-radius: 5px;
}
</style>
