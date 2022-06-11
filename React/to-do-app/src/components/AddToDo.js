import React, {useState} from "react";
import { connect } from "react-redux";
import { addTodo } from "../redux/actions";
import store from "../redux/store";

export default function AddTodo(props) {
    const [input, setInput] = useState("");



    // handleAddTodo = () => {
    //     this.props.addTodo(this.state.input);
    //     this.setState({ input: "" });
    // };
    const handleAddTodo = () => {
        store.dispatch({ type: "ADD", content: input });
        setInput("");
    };


    return (
        <div>
            <input onChange={(e) => setInput(e.target.value)} value={input} />
            <button className="add-todo" onClick={handleAddTodo}>
                Add Todo
            </button>
        </div>
    );

}
//
// export default connect(
//     null,
//     { addTodo }
// )(AddTodo);
// export default AddTodo;
