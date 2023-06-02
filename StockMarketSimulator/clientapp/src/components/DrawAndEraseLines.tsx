import React, {useRef, useState} from "react";

type Coordinates = {
    x: number;
    y: number;
};

type Line = [Coordinates, Coordinates];

const DrawAndEraseLines: React.FC = () => {
    const canvasRef = useRef<HTMLCanvasElement | null>(null);
    const [lines, setLines] = useState<Line[]>([]);
    const [currentLine, setCurrentLine] = useState<Line | null>(null);

    const startDrawing = (event: React.MouseEvent<HTMLCanvasElement>) => {
        const startCoords = getMouseCoordinates(event);
        setCurrentLine([startCoords, startCoords]);
    };

    const drawLine = (event: React.MouseEvent<HTMLCanvasElement>) => {
        if (!currentLine) return;

        const endCoords = getMouseCoordinates(event);
        setCurrentLine([currentLine[0], endCoords]);
        redrawCanvas();
    };

    const endDrawing = () => {
        if (!currentLine) return;

        setLines((prevLines) => [...prevLines, currentLine]);
        setCurrentLine(null);
    };

    const eraseLastLine = () => {
        if (lines.length === 0) {
            redrawCanvas();
            return;
        }

        setLines((prevLines) => prevLines.slice(0, -1));
        redrawCanvas();
    };

    const getMouseCoordinates = (
        event: React.MouseEvent<HTMLCanvasElement>
    ): Coordinates => {
        const rect = canvasRef.current?.getBoundingClientRect();
        const x = event.clientX - rect!.left;
        const y = event.clientY - rect!.top;
        return {x, y};
    };

    const redrawCanvas = () => {
        const canvas = canvasRef.current;
        if (!canvas) return;

        const ctx = canvas.getContext("2d");
        if (!ctx) return;

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        lines.forEach(drawLineSegment);
        if (currentLine) drawLineSegment(currentLine);
    };

    const drawLineSegment = (line: Line) => {
        const [startCoords, endCoords] = line;
        const ctx = canvasRef.current!.getContext("2d");
        // @ts-ignore
        ctx.beginPath();
        // @ts-ignore
        ctx.moveTo(startCoords.x, startCoords.y);
        // @ts-ignore
        ctx.lineTo(endCoords.x, endCoords.y);
        // @ts-ignore
        ctx.stroke();
    };

    return (
        <div>
            <canvas
                ref={canvasRef}
                width={500}
                height={500}
                onMouseDown={startDrawing}
                onMouseMove={drawLine}
                onMouseUp={endDrawing}
                onMouseOut={endDrawing}
                style={{border: "1px solid #000"}}
            ></canvas>
            <button onClick={eraseLastLine}>Erase Last Line</button>
        </div>
    );
};

export default DrawAndEraseLines;