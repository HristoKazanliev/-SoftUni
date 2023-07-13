function calculator() {
    let input1;
    let input2;
    let result;

    let execute = {
        init: (selector1, selector2, selector3) => {
            input1 = document.querySelector(selector1);
            input2 = document.querySelector(selector2);
            result = document.querySelector(selector3);
        },
        add: () => {
            result.value = Number(input1.value) + Number(input2.value);
        },
        subtract: () => {
            result.value = Number(input1.value) - Number(input2.value);
        }
    };

    return execute;
}

const calculate = calculator ();
calculate.init ('#num1', '#num2', '#result');



