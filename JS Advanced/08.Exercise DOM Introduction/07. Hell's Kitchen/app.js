function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('#inputs textarea').value);
      let bestRestaurantInfo = document.querySelector('#bestRestaurant p');
      let bestWorker = document.querySelector('#workers p');
      let result = [];

      for (const info of input) {
         let [name, workers] = info.split(' - ');
         if (!result.find(e => e.name === name)) {
            result.push({
               name,
               avgSalary: 0,
               bestSalary: 0,
               sumSalary: 0,
               workers: []
            });
         }
         let currRestaurant = result.find(e => e.name === name);
         workers = workers && workers.split(', ');
         for (const worker of workers) {
            updateRestaurant(currRestaurant, worker);
         }
      }

      let bestRestaurant = result.sort(((a, b) => b.avgSalary - a.avgSalary))[0];
      bestRestaurantInfo.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;
      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);
      let text = '';
      for (const worker of sortedWorkers) {
         text += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }
      bestWorker.textContent += text;
   }

   function updateRestaurant(obj, worker) {
      let [name, salary] = worker.split(' ');
      salary = Number(salary);
      obj.sumSalary += salary;
      if (obj.bestSalary < salary) {
         obj.bestSalary = salary;
      }
      obj.workers.push({
         name,
         salary
      });
      obj.avgSalary = obj.sumSalary / obj.workers.length;
   }
}