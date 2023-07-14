function attachEvents() {
     const symbolEnum = {
        'Sunny': '☀', 
        'Partly sunny': '⛅', 
        'Overcast': '☁', 
        'Rain': '☂', 
        'Degrees': '°' 
     }

     const url = 'http://localhost:3030/jsonstore/forecaster';
     const forecastDiv = document.getElementById('forecast');
     const currentDiv = document.getElementById('current');
     const upcomingDiv = document.getElementById('upcoming');
     const submitBtn = document.getElementById('submit');
     submitBtn.addEventListener('click', getWeather);
     let currentForecast = createTag('div', null, 'forecasts');
     let threeDayForecast = createTag('div', null, 'forecast-info');

     async function getWeather() {
        currentForecast.innerHTML = '';
        threeDayForecast.innerHTML = '';
        let location = document.getElementById('location').value;

        try {
         const response = await fetch(`${url}/locations`);
         const data =  await response.json();
         let city = data.find(c => c.name == location);

         let currentFetch = await fetch(`${url}/today/${city.code}`);
         const currentData =  await currentFetch.json();

         let threeDayFetch = await fetch(`${url}/upcoming/${city.code}`);
         const threeDayData =  await threeDayFetch.json();

         showCurrentForecast(currentData);
         showThreeDayForecast(threeDayData);

        } catch (error) {
            currentForecast.innerHTML = '';
            threeDayForecast.innerHTML = '';
            forecastDiv.style.display = 'block';
            currentForecast.innerHTML = '<span>Error</span>'; 
            currentDiv.appendChild(currentForecast);
        }
     }

     function showCurrentForecast(data) {
         forecastDiv.style.display = 'block';

         currentForecast.appendChild(createTag('span', symbolEnum[data.forecast.condition], 'condition symbol'));
         let spanElement = createTag('span', null, 'condition');
         spanElement.appendChild(createTag('span', `${data.name}`, 'forecast-data'));
         spanElement.appendChild(createTag('span', `${data.forecast.low}${symbolEnum['Degrees']}/${data.forecast.high}${symbolEnum.Degrees}`, 'forecast-data'));
         spanElement.appendChild(createTag('span', `${data.forecast.condition}`, 'forecast-data'));

         currentForecast.appendChild(spanElement);
         currentDiv.appendChild(currentForecast);
     }

     function showThreeDayForecast(data) {
         for (let day of data.forecast) {
            let spanElement = createTag('span', null, 'upcoming');
            spanElement.appendChild(createTag('span', symbolEnum[day.condition], 'symbol'));
            spanElement.appendChild(createTag('span', `${day.low}°/${day.high}°`, 'forecast-data'));
            spanElement.appendChild(createTag('span', `${day.condition}`, 'forecast-data'));

            threeDayForecast.appendChild(spanElement);
         }

         upcomingDiv.appendChild(threeDayForecast);
     }

     function createTag(tag, text = null, className = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (className) { el.className = className; }
        return el;
    }
}

attachEvents();