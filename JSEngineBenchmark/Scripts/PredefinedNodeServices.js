let calculateSum = function(numbers) {
    let sum = 0;
    for(let i = 0; i < numbers.length; i++) {
        sum += numbers[i];
    }
    return sum;
};

module.exports = function(callback, code) {
    let result = eval(code);
    callback(null, result);
};