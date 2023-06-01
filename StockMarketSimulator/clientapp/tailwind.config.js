/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: 'jit',
    darkMode: 'class',
    purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
    content: [
        "./src/**/*.{js,jsx,ts,tsx}",
    ],
    theme: {
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [],
}

