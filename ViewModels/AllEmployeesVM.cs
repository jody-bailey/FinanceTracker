using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
	class AllEmployeesVM : ViewModelBase
	{

		private ObservableCollection<EmployeeVM> _employees;

		public ObservableCollection<EmployeeVM> Employees
		{
			get { return _employees; }
			set 
			{ 
				_employees = value;
				OnPropertyChanged("Employees");
			}
		}

		void Employees_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count > 0)
			{
				foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged += Employee_PropertyChanged;
				}
			}
			if (e.OldItems != null && e.OldItems.Count > 0)
			{
				foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged -= Employee_PropertyChanged;
				}
			}
		}

		void Employee_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			EmployeeVM employee = sender as EmployeeVM;

			employee.UpdateEmployee(employee);
		}

		private List<EmployeeVM> GetAllEmployees()
		{
			List<Employee> employees = DBHelper.GetEmployees();
			List<EmployeeVM> employeeVMs = new List<EmployeeVM>();

			foreach (var emp in employees)
			{
				employeeVMs.Add(new EmployeeVM(emp));
			}

			return employeeVMs;
		}

		public AllEmployeesVM()
		{
			Title = "All Employees";
			Icon = PackIconKind.People;
			_employees = new ObservableCollection<EmployeeVM>(GetAllEmployees());
			_employees.CollectionChanged += Employees_OnCollectionChanged;
		}

	}
}
