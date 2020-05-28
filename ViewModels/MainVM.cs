using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
	public class MainVM : ViewModelBase
	{
		private ObservableCollection<ViewModelBase> _allViewModels;

		public ObservableCollection<ViewModelBase> AllViewModels
		{
			get { return _allViewModels; }
			set 
			{
				_allViewModels = value;
				OnPropertyChanged("AllViewModels");
			}
		}

		private ViewModelBase _selectedViewModel;

		public ViewModelBase SelectedViewModel
		{
			get { return _selectedViewModel; }
			set 
			{
				_selectedViewModel = value;
				OnPropertyChanged("SelectedViewModel");
			}
		}

		public MainVM()
		{
			_allViewModels = new ObservableCollection<ViewModelBase>();
			_allViewModels.Add(new AllClaimsVM());
			_allViewModels.Add(new AllEmployeesVM());
			_allViewModels.Add(new AllPaymentsVM());
			_selectedViewModel = _allViewModels.First();
		}
	}
}
