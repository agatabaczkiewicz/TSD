<template>
  <div>
<!--  <button type="button" class="btn btn-primary" @click="addNewTaskClick">+Add new task</button>-->
      <div id="todo-list">
        <ul class="list-group" v-for="n in todos" :key="n.id">
          <li class="list-group-item" :data-status="n.completed">
            <input type="checkbox" @click="updateTodo" :data-id="n.id" :id="n.id"  :checked="n.completed"> <label :data-id="n.id" :for="n.id">{{ n.name }}</label>
            <button type="button"  :data-id="n.id" class="ms-3 btn btn-primary" @click="detailsClick">detail</button>
            <!--            <div class="delete-item" @click="deleteItem" :data-id="n.id">Delete</div>-->
<!--            <div class="archive-item" v-if="n.location !== 'archive'" @click="archiveItem" :data-id="n.id">Archive</div>-->
          </li>

    </ul>
        </div>
    <button type="button" class="btn btn-primary" @click="addNewTaskClick">+Add new task</button>
      </div>
  <router-view :key="$route.path"></router-view>
</template>

<script>
// import useStore from "vuex/dist/vuex.mjs";

export default {
  name: "HomePage",
  data() {
    return {
      newTodoItem: '',
      todos: this.$store.getters.todoList,

    }
  },
  props: {
    location: String
  },

  methods: {
    addNewTaskClick(){
      this.$router.push('/add')
    },
    detailsClick: function(e){
      const id = e.currentTarget.getAttribute('data-id');
     this.$router.push(`/detail/${id}`)
    },
    updateTodo: function(e) {
      let newStatus = e.currentTarget.parentElement.getAttribute('data-status') == "true" ? false : true;
      this.$store.commit('updateTodo', {
        id: e.currentTarget.getAttribute('data-id'),
        completed: newStatus
      })
    },
  }
}
</script>

<style scoped>
.list-group {
  /*display: flex;*/
  max-width: 50%;
  min-width: 40%;
  text-align: left;
  margin-left: 10%;
  /*justify-content: center;*/
  display: flex;
}

[data-status="true"] label {
  text-decoration: line-through;
}
</style>