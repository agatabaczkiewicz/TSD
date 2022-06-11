import './Counter.css'
const {Component} = require("react");
export class Counter extends Component {

    state = {
        count: 0
    };

    handlePlusClick = () => {
        this.setState((prevState, { count }) => ({
            count: prevState.count + 1
        }));
    };
    handleMinusClick = () => {
        this.setState((prevState, { count }) => ({
            count: prevState.count - 1
        }));
    };
    render() {
        return(
            <div>
                <button >{this.state.count}</button>
                <div>
                <button className="btnPlus" onClick={this.handlePlusClick} >+</button>
                <button className="btnPlus" onClick={this.handleMinusClick}>-</button>
                    </div>
            </div>
    );
    }
}