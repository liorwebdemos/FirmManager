/** @type {import('tailwindcss').Config} */
module.exports = {
  important: true, // https://sebastiandedeyne.com/why-we-use-important-with-tailwind/
  content: ["./src/**/*.{html,js}"],
  theme: {
    fontFamily: {
      sans: [
        "Heebo",
        "Arial",
        "sans-serif"
      ]
    },
    extend: {},
  },
  plugins: [],
}
