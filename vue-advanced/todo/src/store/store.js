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
        },
        getTask: (state) => (id) =>{
            let findEl = state.todoList.find((x) => x.id == id);


            return findEl
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
        },
        updateTodo (state, todoItem) {
            let id = todoItem.id;
            let completed = todoItem.completed;
            let name = todoItem.name;
            let findEl = state.todoList.find((x) => x.id == id);
            if(findEl.id != null) {
                if(completed !== undefined) {
                    findEl.completed = completed;
                }
                if(name !== undefined) {
                    findEl.name = name;
                }
            }
            else {
                console.log(`To Do List Item ${id} couldn't be found`);
            }
        },
         }
});