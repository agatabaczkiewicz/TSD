<template>
<h3>Details about task</h3>
  <h1>{{ todo.name }}</h1>
</template>

<script>
export default {
  name: "DetailsTask",

  data() {
    return {
      todo: this.$store.getters.getTask(this.$route.params.id),
    }
  }
}
</script>

<style scoped>

</style>