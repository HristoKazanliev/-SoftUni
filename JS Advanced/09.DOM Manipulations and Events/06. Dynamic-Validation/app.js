function validate() {
    let inputElement = document.getElementById('email');
    let pattern = /[a-z]+@[a-z]+.[a-z]+/g;

    function validation(e) {
        if (pattern.test(e.currentTarget.value)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');
        }
    }
inputElement.addEventListener('change', validation);
}