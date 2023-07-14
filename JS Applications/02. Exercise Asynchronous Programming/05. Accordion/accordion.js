async function solution() {
    let mainSection = document.getElementById('main');
    mainSection.innerHTML = '';
    
    try {
        const response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
        const data = await response.json();
    
        for (const obj of data) {
            let divContainer = document.createElement('div');
            divContainer.className = 'accordion';
    
            divContainer.innerHTML = `<div class="head">
                                            <span>${obj.title}</span>
                                            <button class="button" id="${obj._id}">More</button>
                                        </div>
                                        <div class="extra"></div>`;
    
            let moreBtn = divContainer.querySelector('button');
            moreBtn.addEventListener('click', moreClick);
            mainSection.appendChild(divContainer);                            
        }
    } catch (error) {
        console.log(error.message);
    }
   
}

async function moreClick(e) {
    let currDivContainer = e.currentTarget.parentElement.parentElement;
    let id = e.currentTarget.id;
    let extraDiv = currDivContainer.querySelector('div.extra');

    try {
        let response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
    let data = await response.json();

    extraDiv.innerHTML = `<p>${data.content}</p>`;

    if (e.target.textContent == 'More') {
        e.target.textContent = 'Less';
        extraDiv.style.display = 'block';
    } else {
        e.target.textContent = 'More';
        extraDiv.style.display = 'none';
    }
    } catch (error) {
        console.log(error.message);
    }
}

solution();