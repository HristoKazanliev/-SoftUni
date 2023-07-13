function lockedProfile() {
    let buttonElements = document.querySelectorAll('div button');

    for (let i = 0; i < buttonElements.length; i++) {
        let button = buttonElements[i];
        let profile = button.parentElement;
        let typeLock = profile.querySelector('input[value="lock"]');
        let hiddenFields = document.getElementById(`user${i + 1}HiddenFields`);

        button.addEventListener('click', (e) => {
            if (!typeLock.checked && button.textContent == 'Show more') {
                hiddenFields.style.display = 'block';
                button.textContent = 'Hide it';
            } else if (!typeLock.checked && button.textContent == 'Hide it') {
                hiddenFields.style.display = 'none';
                button.textContent = 'Show more';
            }
        })
    }
}