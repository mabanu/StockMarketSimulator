import React from 'react';
import './App.css';
import Candle from "./components/CandleChart";
import UsersData from "./components/UsersData";
import DrawAndEraseLines from "./components/DrawAndEraseLines";

function App() {
    return (
        <div className="flex">

            <UsersData/>

            < Candle/>

            <DrawAndEraseLines/>

        </div>
    );
}

export default App;
