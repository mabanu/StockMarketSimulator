import React, {Component} from 'react';

export class NasdaqData extends Component {
    static displayName = NasdaqData.name;

    constructor(props) {
        super(props);
        this.state = {forecasts: [], loading: true};
    }

    static renderForecastsTable(forecasts) {
        console.log(forecasts)
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
                </thead>
                <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.low}</td>
                        <td>{forecast.high}</td>
                        
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : NasdaqData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tableLabel">Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('nasdaq');
        const data = await response.json();
        this.setState({forecasts: data, loading: false});
    }
}
