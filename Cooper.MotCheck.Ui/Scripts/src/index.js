import React from 'react';
import ReactDOM from 'react-dom';

const App = () => <div>Hello world!</div>;

let root = document.getElementById("root");
if (root !== null) {
    ReactDOM.render(<App />, root);
}