using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using FinanceTracker.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceTracker.ViewModels
{
	public class AllClaimsVM : ViewModelBase
	{

		private ObservableCollection<ClaimVM> _claims;

		public ObservableCollection<ClaimVM> Claims
		{
			get { return _claims; }
			set 
			{ 
				if (_claims == value)
				{
					return;
				}
				_claims = value;
				OnPropertyChanged("Claims");
			}
		}

		private bool _isChanged;

		public bool IsChanged
		{
			get { return _isChanged; }
			set 
			{ 
				_isChanged = value;
				OnPropertyChanged("IsChanged");
			}
		}


		void Claims_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count > 0)
			{
				foreach(INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged += Claim_PropertyChanged;
				}
			}
			if (e.OldItems != null && e.OldItems.Count > 0)
			{
				foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged -= Claim_PropertyChanged;
				}
			}
		}

		void Claim_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			IsChanged = true;
			ClaimVM claim = sender as ClaimVM;

			//claim.UpdateClaim(claim);
		}

		private List<ClaimVM> GetAllClaims()
		{
			List<Claim> claims = DBHelper.GetClaims();
			List<ClaimVM> claimVMs = new List<ClaimVM>();

			foreach(var claim in claims)
			{
				claimVMs.Add(new ClaimVM(claim));
			}

			return claimVMs;
		}

		private ICommand _saveCommand;

		public ICommand SaveCommand
		{
			get 
			{
				return new RelayCommand(c =>
				{
					foreach(var claim in _claims)
					{
						claim.UpdateClaim();
					}
					IsChanged = false;
				});
			}
		}

		private ICommand _addNewClaim;

		public ICommand AddNewClaim
		{
			get 
			{
				return new RelayCommand(c =>
				{
					_claims.Add(new ClaimVM());
				});
			}
		}

		public AllClaimsVM()
		{
			this.Title = "All Claims";
			Icon = MaterialDesignThemes.Wpf.PackIconKind.Plus;
			_claims = new ObservableCollection<ClaimVM>();
			_claims.CollectionChanged += Claims_OnCollectionChanged;
			GetAllClaims().ForEach(c => _claims.Add(c));
		}

	}
}
