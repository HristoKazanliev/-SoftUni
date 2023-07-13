function solve(obj) {
    const methodEnum = ['POST', 'GET', 'DELETE', 'CONNECT'];
    const uriPattern = /^[\w.]+$/g;
    const versionEnum = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messagePattern = /^[^\<\>\\\&\'\"]*$/gm;

    if (obj.method == undefined | !methodEnum.includes(obj.method)) {
        throw new Error(`Invalid request header: Invalid Method`)
    }
    if (obj.uri == undefined | !uriPattern.test(obj.uri)) {
        throw new Error(`Invalid request header: Invalid URI`);
    }
    if (obj.version == undefined | !versionEnum.includes(obj.version)) {
        throw new Error(`Invalid request header: Invalid Version`);
    }
    if (obj.message == undefined | !messagePattern.test(obj.message)) {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    return obj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));