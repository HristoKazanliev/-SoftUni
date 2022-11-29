export function validator(data) {
    let [make, model, year, description, price, image, material] = data;

    let isValid = true;
    make.value.length >= 4 ? decorator(make, true) : decorator(make, false);
    model.value.length >= 4 ? decorator(model, true) : decorator(model, false);
    Number(year.value) > 1950 && Number(year.value) < 2050 ? decorator(year, true) : decorator(year, false);
    description.value.length > 10 ? decorator(description, true) : decorator(description, false);
    Number(price.value) > 0 ? decorator(price, true) : decorator(price, false);
    image.value != '' ? decorator(image, true) : decorator(image, false);

    function decorator(element, bool) {
        if (bool) {
            element.classList.add('is-valid');
            element.classList.remove('is-invalid');
        } else {
            isValid = false;
            element.classList.add('is-invalid');
            element.classList.remove('is-valid');
        }
    }

    let info = {
        make: make.value,
        model: model.value,
        description: description.value,
        year: year.value,
        price: price.value,
        img: image.value,
        material: material.value
    }

    return isValid ? info : false;
}