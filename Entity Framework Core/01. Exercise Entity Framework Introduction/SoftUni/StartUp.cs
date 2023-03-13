using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            //Console.WriteLine("Success");

            //string result = GetEmployeesFullInformation(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesWithSalaryOver50000(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
            //Console.WriteLine(result);

            //string result = AddNewAddressToEmployee(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesInPeriod(dbContext);
            //Console.WriteLine(result);

            //string result = GetAddressesByTown(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployee147(dbContext);
            //Console.WriteLine(result);

            //string result = GetDepartmentsWithMoreThan5Employees(dbContext);
            //Console.WriteLine(result);

            //string result = GetLatestProjects(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);
            //Console.WriteLine(result);

            //string result = DeleteProjectById(dbContext);
            //Console.WriteLine(result);

            string result = RemoveTown(dbContext);
            Console.WriteLine(result);
        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd(); 
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee? employee = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee!.Address = newAddress;
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var employeesAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (var employeeAddress in employeesAddresses)
            {
                sb.AppendLine(employeeAddress);
            }

            return sb.ToString().TrimEnd(); 
        }

        //Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithProjects = context
                .Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                     ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var employee in employeesWithProjects)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.AddressText}, {employee.TownName} - {employee.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new 
                        {  
                            ep.Project.Name
                        })
                        .OrderBy(ep => ep.Name)
                        .ToArray()
                })
                .ToArray();

            foreach (var employee in employee147)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"{project.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new 
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName  =d.Manager.LastName,
                    Employees = d.Employees
                        .Select(de => new 
                        {
                            de.FirstName,
                            de.LastName,
                            de.JobTitle
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        { 
            StringBuilder sb = new StringBuilder();

            var latestProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new 
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .ToArray();

            foreach (var department in latestProjects) 
            {
                sb.AppendLine(department.Name)
                    .AppendLine(department.Description)
                    .AppendLine(department.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesToIncreasedSalaries = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" 
                            || e.Department.Name == "Tool Design"
                            || e.Department.Name == "Marketing"
                            || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employeesToIncreasedSalaries)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var employee in employeesToIncreasedSalaries)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSa = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employeesWithSa)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var epToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(epToDelete);

            Project projectToDelete = context.Projects.Find(2)!;
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            string[] projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (var project in projectNames) 
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle")!;

            var referencedAddresses = context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToArray();

            int countOfRemovedAddresses = referencedAddresses.Length;

            foreach (var employee in context.Employees) 
            {
                if (referencedAddresses.Any(a => a.AddressId == employee.AddressId))
                {
                    employee.Address = null;
                }
            }

            context.Addresses.RemoveRange(referencedAddresses);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{countOfRemovedAddresses} addresses in Seattle were deleted";
        }
    }
}