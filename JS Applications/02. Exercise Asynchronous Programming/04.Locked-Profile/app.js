async function lockedProfile() {
    let mainDiv = document.getElementById('main');
    mainDiv.innerHTML = '';
    
    try {
        const response = await fetch(`http://localhost:3030/jsonstore/advanced/profiles`);
        const data =  Object.values(await response.json());

        data.forEach((user, i) => {
        let userProfile = document.createElement('div');
        userProfile.classList = 'profile';
        let userId = i + 1;
        userProfile.innerHTML = `<img src="./iconProfile2.png" class="userIcon" />
                                 <label>Lock</label>
                                 <input type="radio" name="user${userId}Locked" value="lock" checked>
                                 <label>Unlock</label>
                                 <input type="radio" name="user${userId}Locked" value="unlock"><br>
                                 <hr>
                                 <label>Username</label>
                                 <input type="text" name="user${userId}Username" value="${user.username}" disabled readonly />
                                 <div id="user${userId}HiddenFields">
                                     <hr>
                                     <label>Email:</label>
                                     <input type="email" name="user${userId}Email" value="${user.email}" disabled readonly />
                                     <label>Age:</label>
                                     <input type="email" name="user${userId}Age" value="${user.age}" disabled readonly />
                                 </div>
                                 <button>Show more</button>`;

        mainDiv.appendChild(userProfile);
    });

    const hiddenElems = mainDiv.querySelectorAll('div');
        for (let i = 1; i < hiddenElems.length; i += 2) {
            hiddenElems[i].style.display = 'none';
        }

    let btnElements = document.querySelectorAll('div button');
    for (let i = 0; i < btnElements.length; i++) {
        let button = btnElements[i];
        let profile = button.parentElement;
        let typeLock = profile.querySelector('input[value="lock"]');
        let hiddenFields = profile.querySelector('div');

        button.addEventListener('click', () => {
            if (!typeLock.checked && button.textContent == 'Show more') {
                hiddenFields.style.display = 'block';
                button.textContent = 'Hide it';
            } else if (!typeLock.checked && button.textContent == 'Hide it') {
                hiddenFields.style.display = 'none';
                button.textContent = 'Show more';
            }
        });
    }
    } catch (error) {
        console.log(error.message)
    }
   
}