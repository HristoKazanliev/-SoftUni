function editElement(reference, match, replacer) {
    const pattern = new RegExp(match, 'g');
    const result = reference.textContent.replace(pattern, replacer);
    reference.textContent = result;
}