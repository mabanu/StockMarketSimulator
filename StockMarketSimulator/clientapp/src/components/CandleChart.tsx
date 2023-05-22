import {VictoryAxis, VictoryCandlestick, VictoryChart, VictoryTheme} from "victory";
import {useEffect, useState} from "react";

type Nasdaq = {
    id: string,
    date: Date,
    closeLast: number,
    volume: string,
    open: number,
    high: number,
    low: number
}

type NasdaqRateData = {
    x: Date,
    close: number,
    open: number,
    high: number,
    low: number
}

function request<TResponse>(url: string): Promise<TResponse> {
    return fetch(url)
        .then(response => response.json())
        .then(data => data as TResponse);
}


function Candle() {
    const [data, setData] = useState<NasdaqRateData[]>([])

    useEffect(() => {
        request<Nasdaq[]>("nasdaq").then(r => {
            r.sort((a, b) => {
                if (a.date < b.date) {
                    return -1;
                }
                return 1;
            });
            let rates: NasdaqRateData[] = [];
            r.forEach(row => {
                let item: NasdaqRateData = {
                    x: row.date,
                    close: row.closeLast,
                    open: row.open,
                    high: row.high,
                    low: row.low
                };
                rates.push(item);

            })

            setData(rates);

        })

    }, [])


    console.log(data)

    return (
        <>

            <VictoryChart
                theme={VictoryTheme.material}
                domainPadding={{x: 25}}
                scale={{x: "time"}}
            >
                <VictoryAxis/>
                <VictoryAxis dependentAxis/>
                <VictoryCandlestick
                    candleColors={{positive: "#5f5c5b", negative: "#c43a31"}}
                    data={data}
                />
            </VictoryChart>
        </>
    )
}

export default Candle;