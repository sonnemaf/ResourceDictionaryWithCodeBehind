namespace SampleApp.Models {

    public class Employee {

        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary) {
            Name = name;
            Salary = salary;
        }
    }
}
