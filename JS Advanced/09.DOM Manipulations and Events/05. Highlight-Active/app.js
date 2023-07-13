function focused() {
    let inputElements = document.querySelectorAll('input');

    for (const element of inputElements) {
        element.addEventListener('focus', onFocus);
        element.addEventListener('blur', onBlur);
    }

    function onFocus(e) {
        e.target.parentElement.className = 'focused';
    }

    function onBlur(e) {
        e.target.parentElement.className = '';
    }
}