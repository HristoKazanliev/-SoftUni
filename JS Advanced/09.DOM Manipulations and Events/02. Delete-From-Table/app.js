function deleteByEmail() {
    let inputElement = document.querySelector('input[name="email"]');
    let emailElements = Array.from(document.querySelectorAll('td:nth-of-type(2)'));
    let resultElement = document.getElementById('result');

    let targetElement = emailElements.find(e => e.textContent == inputElement.value);
    if (targetElement) {
        targetElement.parentElement.remove();
        resultElement.textContent = 'Deleted';
    } else {
        resultElement.textContent = 'Not found.';
    }
}