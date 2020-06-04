using SampleApp.Models;
using System.Collections.ObjectModel;

namespace SampleApp.ViewModels {
    public sealed class MainViewModel {

        public static MainViewModel Current { get; } = new MainViewModel();

        private MainViewModel() { // Singleton
        }

        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>
        {
            new Employee("Fons", 2000),
            new Employee("Jim", 4000),
            new Employee("Ellen", 3000),
        };

    }
}
