function solve(nums) {
    console.log(aggregate(nums, x => x));
    console.log(inverseSum(nums, x => 1 / x));
    console.log(aggregate(nums, x => x.toString()));

    function aggregate(nums, func) {
        let result = nums[0];
        for (let index = 1; index < nums.length; index++) {
            result += func(nums[index])
        }

        return result;
    }

    function inverseSum(nums, func) {
        let result = 0;
        for (let index = 0; index < nums.length; index++) {
            result += func(nums[index])
        }

        return result;
    }
}

solve([1, 2, 4]);
solve([2, 4, 8, 16]);