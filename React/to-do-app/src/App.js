import logo from './logo.svg';
import './App.css';
import TodoList from "./components/ToDoList";
import AddTodo from "./components/AddToDo";

function App() {
  return (
    <div className="App">
        <h1>Todo List</h1>
        <AddTodo />
        <TodoList />
    </div>
  );
}

export default App;
