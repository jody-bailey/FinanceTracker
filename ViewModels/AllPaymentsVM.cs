using FinanceTracker.DataAccess;
using FinanceTracker.Models;
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
    class AllPaymentsVM : ViewModelBase
    {
		private ObservableCollection<PaymentVM> _payments;

		public ObservableCollection<PaymentVM> Payments
		{
			get { return _payments; }
			set 
			{
				_payments = value;
				OnPropertyChanged("Payments");
			}
		}

		void Payments_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count > 0)
			{
				foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged += Payment_PropertyChanged;
				}
			}
			if (e.OldItems != null && e.OldItems.Count > 0)
			{
				foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
				{
					item.PropertyChanged -= Payment_PropertyChanged;
				}
			}
		}

		void Payment_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			PaymentVM payment = sender as PaymentVM;

			payment.UpdatePayment(payment);
		}

		private List<PaymentVM> GetAllPayments()
		{
			List<Payment> payments = DBHelper.GetPayments();
			List<PaymentVM> paymentVMs = new List<PaymentVM>();

			foreach (var pay in payments)
			{
				paymentVMs.Add(new PaymentVM(pay));
			}

			return paymentVMs;
		}

		public AllPaymentsVM()
		{
			Title = "All Payments";
			Icon = MaterialDesignThemes.Wpf.PackIconKind.Money;
			_payments = new ObservableCollection<PaymentVM>(GetAllPayments());
			_payments.CollectionChanged += Payments_OnCollectionChanged;
		}

	}
}
