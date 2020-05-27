using FinanceTracker.DataAccess;
using FinanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.ViewModels
{
    class EmployeeVM : ViewModelBase
    {
        private Employee modelObject;

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

        public string FirstName
        {
            get { return modelObject.FirstName; }
            set
            {
                if (modelObject.FirstName == value)
                {
                    return;
                }
                modelObject.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return modelObject.LastName; }
            set
            {
                if (modelObject.LastName == value)
                {
                    return;
                }
                modelObject.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FullName
        {
            get { return modelObject.FullName; }
            set
            {
                if (modelObject.FullName == value)
                {
                    return;
                }
                modelObject.FullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public int CenterId 
        { 
            get { return modelObject.CenterId; }
            set
            {
                if (modelObject.CenterId == value)
                {
                    return;
                }
                modelObject.CenterId = value;
                OnPropertyChanged("CenterId");
            }
        }

        internal void UpdateEmployee(EmployeeVM employee)
        {
            DBHelper.UpdatedEmployee(employee.modelObject);
        }

        public Center Center 
        { 
            get { return modelObject.Center; }
            set
            {
                if (modelObject.Center == value)
                {
                    return;
                }
                modelObject.Center = value;
                OnPropertyChanged("Center");
            }
        }
        public string SSN 
        {
            get { return modelObject.SSN; }
            set
            {
                if (modelObject.SSN == value)
                {
                    return;
                }
                modelObject.SSN = value;
                OnPropertyChanged("SSN");
            }
        }

        public EmployeeVM(Employee employee)
        {
            this.modelObject = employee;
        }
    }
}
