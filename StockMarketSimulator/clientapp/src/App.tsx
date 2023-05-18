import React from 'react';
import logo from './logo.svg';
import './App.css';
import {FetchData} from "./components/FetchData";
import {NasdaqData} from "./components/NasdaqData";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo"/>
                <p>
                    Edit <code>src/App.tsx</code> and save to reload.
                </p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
            <h1 className="text-3xl text-green-900">Lilou & Emily</h1>
            < FetchData/>
            < NasdaqData />
            <h1>Hell</h1>
        </div>
    );
}

export default App;
