import React, { Component } from 'react';
import logo from './logo.svg';
import './styles/App.css';

import CalculatorPad from './services/CalculatorPad.js';
import CalculatorWindow from './services/CalculatorWindow.js';

class App extends Component {

  constructor(){
      super();
      this.state = {
        result: ""
      }
  }

  render() {
    return (
      <div>
        <div className="calculator">
          <header className="calculator-header">
            <img src={logo} className="calculator-logo" alt="logo" />
            <p>Задачка про калькулятор</p>
          </header>
        </div>
        <div className="calculator-body">
            <CalculatorWindow result={this.state.result}/>
            <CalculatorPad onClick={this.onClick}/>
        </div>
      </div>
    );
  }

  onClick = button => {
    if(button === "="){
          this.calculate()
      }
      else if(button === "C"){
          this.reset()
      }
      else if(button === "CE"){
          this.backspace()
      }
      else {
          this.setState({
              result: this.state.result + button
      })
    }
  };

  calculate = () => {
    try {
      this.setState({
          result: ( eval(this.state.result) || "" ) + ""
      })
    } catch (e) {
      this.setState({
          result: "error"
      })
    }
  };

  reset = () => {
      this.setState({
          result: ""
      })
  };

  backspace = () => {
      this.setState({
          result: this.state.result.slice(0, -1)
      })
  };
}

export default App;
