function validate() {
    let inputElement = document.getElementById('email');
    let validPattern = /^[a-z]+@{1}[a-z]+\.{1}[a-z]+$/;

    inputElement.addEventListener('change', (e) => {
        if (validPattern.test(e.currentTarget.value)) {
            e.currentTarget.classList.remove("error");
        } else {
            e.currentTarget.classList.add("error");
        }
    });
}