class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || Number(salary) < 0) throw new Error('Invalid input!');

        let  employee = {name, salary, position};
        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let company = Object.entries(this.departments);
        let bestAvgSalary = 0;
        let bestDepartment = '';

        for (let [department, employees] of company) {
            let sumSalary = 0;
            for (let employee of employees) {
                sumSalary += Number(employee.salary);
            }
            let avgSalary = sumSalary / employees.length;

            if (bestAvgSalary < avgSalary) {
                bestAvgSalary = avgSalary;
                bestDepartment = department;
            }
        }

        let sortedEmployees = this.departments[bestDepartment].sort((a, b) => {
            return b.salary - a.salary || a.name.localeCompare(b.name)})
            .map(x => `${x.name} ${x.salary} ${x.position}`)
            .join('\n');

            return `Best Department is: ${bestDepartment}\nAverage salary: ${bestAvgSalary.toFixed(2)}\n${sortedEmployees}`; 
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());