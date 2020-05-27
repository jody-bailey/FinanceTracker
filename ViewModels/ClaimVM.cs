using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    class ClaimVM : ViewModelBase
    {
        private Claim modelObject;

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
        public int EmployeeId 
        { 
            get { return modelObject.EmployeeId; }
            set
            {
                if (modelObject.EmployeeId == value)
                {
                    return;
                }
                modelObject.EmployeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }
        public Employee Employee 
        { 
            get { return modelObject.Employee; }
            set
            {
                if (modelObject.Employee == value)
                {
                    return;
                }
                modelObject.Employee = value;
                OnPropertyChanged("Employee");
            }
        }
        public int ReferenceNum 
        { 
            get { return modelObject.ReferenceNum; }
            set
            {
                if (modelObject.ReferenceNum == value)
                {
                    return;
                }
                modelObject.ReferenceNum = value;
                OnPropertyChanged("ReferenceNum");
            }
        }
        public string RequestType 
        { 
            get { return modelObject.RequestType; }
            set
            {
                if (modelObject.RequestType == value)
                {
                    return;
                }
                modelObject.RequestType = value;
                OnPropertyChanged("RequestType");
            }
        }
        public string WorkLocation 
        { 
            get { return modelObject.WorkLocation; }
            set
            {
                if (modelObject.WorkLocation == value)
                {
                    return;
                }
                modelObject.WorkLocation = value;
                OnPropertyChanged("WorkLocation");
            }
        }
        public DateTime StatusDate 
        {
            get { return modelObject.StatusDate; }
            set
            {
                if (modelObject.StatusDate == value)
                {
                    return;
                }
                modelObject.StatusDate = value;
                OnPropertyChanged("StatusDate");
            }
        }
        public DateTime ClaimDate 
        { 
            get { return modelObject.ClaimDate; }
            set
            {
                if (modelObject.ClaimDate == value)
                {
                    return;
                }
                modelObject.ClaimDate = value;
                OnPropertyChanged("ClaimDate");
            }
        }
        public bool ClaimantLiable 
        { 
            get { return modelObject.ClaimantLiable; }
            set
            {
                if (modelObject.ClaimantLiable == value)
                {
                    return;
                }
                modelObject.ClaimantLiable = value;
                OnPropertyChanged("ClaimantLiable");
            }
        }

        public void UpdateClaim(ClaimVM claimVM)
        {
            DBHelper.UpdateClaim(claimVM.modelObject);
        }

        public ClaimVM(Claim claim)
        {
            this.modelObject = claim;
        }
    }
}
