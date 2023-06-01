import {
    VictoryAxis,
    VictoryBrushContainer,
    VictoryCandlestick,
    VictoryChart,
    VictoryCursorContainer,
    VictoryTheme
} from "victory";
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

async function request<TResponse>(url: string): Promise<TResponse[]> {
    const response = await fetch(url);
    const data = await response.json();

    // @ts-ignore
    const dataSort = await data.sort((a: TResponse, b: TResponse) => a.date < b.date ? -1 : 1);
    return dataSort as TResponse[];
}

function Candle() {
    const [data, setData] = useState<NasdaqRateData[]>([]);
    const [renderData, setRenderData] = useState<NasdaqRateData[]>([])

    useEffect(() => {
        request<Nasdaq>("nasdaq").then(r => {

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
            setRenderData(rates);

        })

    }, [])

    return (
        <>
            <VictoryChart
                theme={VictoryTheme.material}
                domainPadding={{x: 25}}
                scale={{x: "time"}}
                containerComponent={
                    <VictoryCursorContainer
                        cursorLabel={({datum}) => `Hello, ${(Math.round(datum.y))}`}
                    />
                }
            >

                <VictoryAxis/>

                <VictoryAxis dependentAxis/>

                <VictoryCandlestick
                    candleColors={{positive: "#5f5c5b", negative: "#c43a31"}}
                    data={renderData}
                />
            </VictoryChart>

            <VictoryChart
                theme={VictoryTheme.material}
                domainPadding={{x: 25}}
                scale={{x: "time"}}
                containerComponent={
                    <VictoryBrushContainer
                        responsive={true}
                        brushDimension='x'
                        brushDomain={renderData}
                        onBrushDomainChange={(domain) => console.log(domain)}
                    />
                }
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
