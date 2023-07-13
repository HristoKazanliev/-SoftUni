function encodeAndDecodeMessages() {
    let encodeTextAreaElement = document.querySelectorAll('textarea')[0];
    let decodeTextAreaElement = document.querySelectorAll('textarea')[1];

    let encodeButtonElement = document.querySelectorAll('button')[0];
    encodeButtonElement.addEventListener('click', encode);
    let decodeButtonElement = document.querySelectorAll('button')[1];
    decodeButtonElement.addEventListener('click', decode);

    function encode() {
        let textToEncode = encodeTextAreaElement.value;
        let encodedResult = '';

        for (let i = 0; i < textToEncode.length; i++) {
            let encodedLetter = textToEncode[i].charCodeAt();
            encodedResult += String.fromCharCode(encodedLetter + 1);
        }

        encodeTextAreaElement.value = '';
        decodeTextAreaElement.value = encodedResult;
    }

    function decode() {
        let textToDecode = decodeTextAreaElement.value;
        let decodedResult = '';

        for (let i = 0; i < textToDecode.length; i++) {
            let decodedLetter = textToDecode[i].charCodeAt();
            decodedResult += String.fromCharCode(decodedLetter - 1);
        }

        decodeTextAreaElement.value = decodedResult;
        encodeTextAreaElement.value = '';
    }
}