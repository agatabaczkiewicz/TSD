<template>
  <div>
    <router-view @addTask = AddTaskHandler></router-view>
  </div>
</template>

<script>


export default {
  name: 'App',
  components: {

  },
  methods: {
    AddTaskHandler() {
      alert("add click");
      this.$router.push("/");
    }

}
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
