function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (e) => {
        let position = e.offsetX;
        let percentage = Math.floor((position / gradientElement.clientWidth) * 100);

        resultElement.textContent = `${percentage}%`;
    });
}