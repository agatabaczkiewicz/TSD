import { createStore } from 'vuex'


export const store = createStore({
    state() {
        return {
            todoList: [
                { id: 0, name: 'My First To Do Item', completed: false }
            ]

        }
    },
    getters: {
        todoList (state) {

            return state.todoList;
        }
    },
    mutations: {
        addTodo (state, todoItem) {
            if(todoItem.id !== undefined && typeof todoItem.name == 'string' && typeof todoItem.completed == 'boolean') {
                state.todoList.push({
                    id: todoItem.id,
                    name: todoItem.name,
                    completed: false,
                })
            }
        }
    }
});