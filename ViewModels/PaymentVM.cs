using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    class PaymentVM : ViewModelBase
    {
        private Payment modelObject;

        public int PaymentId 
        { 
            get { return modelObject.PaymentId; }
            set
            {
                if (modelObject.PaymentId == value)
                {
                    return;
                }
                modelObject.PaymentId = value;
                OnPropertyChanged("PaymentId");
            }
        }
        public int ClaimId 
        { 
            get { return modelObject.ClaimId; }
            set
            {
                if (modelObject.ClaimId == value)
                {
                    return;
                }
                modelObject.ClaimId = value;
                OnPropertyChanged("ClaimId");
            }
        }
        public Claim Claim
        {
            get { return modelObject.Claim; }
            set
            {
                if (modelObject.Claim == value)
                {
                    return;
                }
                modelObject.Claim = value;
                OnPropertyChanged("Claim");
            }
        }
        public DateTime DueDate 
        { 
            get { return modelObject.DueDate; }
            set
            {
                if (modelObject.DueDate == value)
                {
                    return;
                }
                modelObject.DueDate = value;
                OnPropertyChanged("DueDate");
            }
        }
        public decimal AmountPaid 
        {
            get { return modelObject.AmountPaid; }
            set
            {
                if (modelObject.AmountPaid == value)
                {
                    return;
                }
                modelObject.AmountPaid = value;
                OnPropertyChanged("AmountPaid");
            }
        }
        public int Quarter 
        { 
            get { return modelObject.Quarter; }
            set
            {
                if (modelObject.Quarter == value)
                {
                    return;
                }
                modelObject.Quarter = value;
                OnPropertyChanged("Quarter");
            }
        }

        public void UpdatePayment(PaymentVM payment)
        {
            DBHelper.UpdatePayment(payment.modelObject);
        }

        public PaymentVM(Payment payment)
        {
            modelObject = payment;
        }
    }
}
