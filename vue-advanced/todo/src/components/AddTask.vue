<template>
<div class="addPage">
  <div class="mb-3">
    <label for="exampleFormControlInput1" class="form-label">New task</label>
    <input type="email" class="form-control" v-model="newTodoItem" id="exampleFormControlInput1" placeholder="New task">
  </div>
  <button type="button" class="btn btn-primary" @click="addNewTaskSubmit">+Add new task</button>
</div>
</template>

<script>
export default {
  name: "AddTask",
  data() {
    return {
      newTodoItem: ''
    }
  },
  methods:{
    addNewTaskSubmit() {
        if(this.newTodoItem !== '') {
          this.$store.commit('addTodo', {
            id:0,
            name: this.newTodoItem,
            completed: false
          })
        }
      this.$emit('addTask')
    }
  }
}
</script>

<style scoped>
.addPage{
  /*max-width: 70%;*/
  text-align: center;
  justify-content: center;
  display: inline-block;
}
</style>