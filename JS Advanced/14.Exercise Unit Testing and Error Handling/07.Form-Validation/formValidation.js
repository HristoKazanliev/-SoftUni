function validate() {
    let formElement = document.getElementById('registerForm');
    let companyElement = document.getElementById('company');
    let companyInfoElement = document.getElementById('companyInfo');
    let validElement = document.getElementById('valid');
    
    companyElement.addEventListener('change', () => {
        if (companyElement.checked) {
            companyInfoElement.style.display = 'block';
        } else {
            companyInfoElement.style.display = 'none';
        }
    })

    formElement.addEventListener('submit', (e) => {
        e.preventDefault();

        let usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        let passwordPattern = /^[\w]{5,15}$/;
        let emailPattern = /[^@.]+@[^@]*\.[^@]*$/;

        let [username, email, password, confirmPassword] = Array.from(formElement.elements).slice(1);

        if (usernamePattern.test(username.value) == true) {
            username.style.borderColor = 'none';
        } else {
            username.style.borderColor = 'red';
        }

        if (emailPattern.test(email.value) == true) {
            email.style.borderColor = 'none';
        } else {
            email.style.borderColor = 'red';
        }

        if (passwordPattern.test(password.value) == true 
            && passwordPattern.test(confirmPassword.value) == true 
            && password.value == confirmPassword.value) {
                password.style.borderColor = 'none';
                confirmPassword.style.borderColor = 'none';
        } else {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';
        }

        if (companyElement.checked) {
            let companyNumber = document.getElementById('companyNumber');
            if (companyNumber.value < 1000 || companyNumber.value > 9999) {
                companyNumber.style.borderColor = 'red';
            } else {
                companyNumber.style.borderColor = 'none';
            }
        }

        let submitFields = Array.from(formElement.elements).slice(1).map(x => x.style.borderColor);
        
        if (submitFields.some(x => x == "red")) {
            validElement.style.display = "none";
        } else {
            validElement.style.display = "block";
        }
    });
}
