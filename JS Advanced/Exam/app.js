window.addEventListener("load", solve);

function solve() {
  document.getElementById('form-btn').addEventListener('click', createStory);
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');
  let previewElement = document.getElementById('preview-list');
  let buttonElement = document.getElementById('form-btn');

  function createStory(e) {
    e.preventDefault();
    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let storyTitleValue = storyTitle.value;
    let genreValue = genre.value;
    let storyValue = story.value;

    if (!firstNameValue || !lastNameValue ||
      !ageValue || !storyTitleValue || !storyValue) {
      return;
    }

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    story.value = '';
    buttonElement.disabled = true;

    createPublication(firstNameValue, 
      lastNameValue, 
      ageValue, 
      storyTitleValue, 
      genreValue,
      storyValue);
  }

  function createPublication(firstNameValue, 
    lastNameValue, 
    ageValue, 
    storyTitleValue, 
    genreValue,
    storyValue) {
    let liElement = document.createElement('li');
    liElement.classList.add('story-info');

    let article = document.createElement('article');
    article.innerHTML = `<h4>Name: ${firstNameValue} ${lastNameValue}</h4>` + 
    `<p>Age: ${ageValue}</p>` +
     `<p>Title: ${storyTitleValue}</p>` +
     `<p>Genre: ${genreValue}</p>` +
     `<p>${storyValue}</p>`;

     let saveBtn = document.createElement('button');
     saveBtn.classList.add('save-btn');
     saveBtn.textContent = 'Save Story';
     saveBtn.addEventListener('click', saveFunc);

     let editBtn = document.createElement('button');
     editBtn.classList.add('edit-btn');
     editBtn.textContent = 'Edit Story';
     editBtn.addEventListener('click', editFunc);

     let deleteBtn = document.createElement('button');
     deleteBtn.classList.add('delete-btn');
     deleteBtn.textContent = 'Delete Story';
     deleteBtn.addEventListener('click', () => {
      let allCompleted = previewElement.getElementsByClassName('story-info');
      while (allCompleted[0]) {
        previewElement.removeChild(allCompleted[0]);
      }
      buttonElement.disabled = false; 
     })

     liElement.appendChild(article);
     liElement.appendChild(saveBtn);
     liElement.appendChild(editBtn);
     liElement.appendChild(deleteBtn);
     previewElement.appendChild(liElement);
  }

  function saveFunc(e) {
    let mainElement = document.getElementById('main');
    while (!mainElement.children) {
      mainElement.remove(children);
    }
    mainElement.innerHTML = `<h1>Your scary story is saved!</h1>`;
  }

  function editFunc(e) {
    buttonElement.disabled = false;
    e.target.setAttribute('disabled', true);
    let saveBtn = e.target.parentElement.getElementsByClassName('save-btn')[0];
    saveBtn.disabled = true;
    let deleteBtn = e.target.parentElement.getElementsByClassName('delete-btn')[0];
    deleteBtn.disabled = true;

    firstName.value = e.target.parentElement.children[0].children[0].textContent.split(' ')[1];
    lastName.value = e.target.parentElement.children[0].children[0].textContent.split(' ')[2];
    age.value = e.target.parentElement.children[0].children[1].textContent.split(' ')[1];
    storyTitle.value = e.target.parentElement.children[0].children[2].textContent.split(' ')[1];
    genre.value = e.target.parentElement.children[0].children[3].textContent.split(' ')[1];
    story.value = e.target.parentElement.children[0].children[4].textContent;

    previewElement.removeChild(e.target.parentElement);
  }
}
