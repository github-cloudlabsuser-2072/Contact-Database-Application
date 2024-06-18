// Replace 'YOUR_API_KEY' with your actual API key from OpenWeatherMap
const apiKey = '5e97732f4a142b5ac9d5e39ac7c68694';
const city = 'London'; // Example city
const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric`;

// Function to fetch weather data
async function fetchWeather() {
  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    console.log(`Current temperature in ${city}: ${data.main.temp}°C`);
  } catch (error) {
    console.error("Error fetching weather data: ", error);
  }
}

// Call the function to fetch weather data
fetchWeather();