using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    public class ClaimVM : ViewModelBase
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

        public string EmployeeFullName
        {
            get { return modelObject.Employee.FullName; }
            set
            {
                if (modelObject.Employee.FullName == value)
                {
                    return;
                }
                modelObject.Employee.FullName = value;
                OnPropertyChanged("EmployeeFullName");
            }
        }

        public string EmployeeSSN
        {
            get { return modelObject.Employee.SSN; }
            set
            {
                if (modelObject.Employee.SSN == value)
                {
                    return;
                }
                modelObject.Employee.SSN = value;
                OnPropertyChanged("EmployeeSSN");
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

        private ObservableCollection<Center> _centers;

        public ObservableCollection<Center> Centers
        {
            get { return _centers; }
            set
            {
                if (_centers == value)
                {
                    return;
                }
                _centers = value;
                OnPropertyChanged("Centers");
            }
        }

        private Center _selectedCenter;

        public Center SelectedCenter
        {
            get { return _selectedCenter; }
            set
            {
                if (_selectedCenter == value)
                {
                    return;
                }
                _selectedCenter = value;
                modelObject.Employee.Center = value;
                modelObject.Employee.CenterId = value.CenterId;
                OnPropertyChanged("SelectedCenter");
            }
        }

        public void UpdateClaim()
        {
            DBHelper.UpdateClaim(this.modelObject);
        }

        public ClaimVM(Claim claim)
        {
            this.modelObject = claim;
            this._centers = new ObservableCollection<Center>(DBHelper.GetCenters());
            this._selectedCenter = _centers.Where(c => c.CenterId == claim.Employee.CenterId).SingleOrDefault();
        }

        public ClaimVM()
        {
            this.modelObject = new Claim();
            this.modelObject.Employee = new Employee();
            this.modelObject.StatusDate = DateTime.Now.Date;
            this.modelObject.ClaimDate = DateTime.Now.Date;
            this._centers = new ObservableCollection<Center>(DBHelper.GetCenters());
        }
    }
}
