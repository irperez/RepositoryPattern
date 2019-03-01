using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class Instructor : ClientChangeTracker, IPKEntity
    {
        public Instructor()
        {
            #region Generated Constructor
            CourseAssignments = new List<CourseAssignment>();
            Departments = new List<Department>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _ID;  
        public int ID { get { return _ID; } set { SetKeyWithOutNotify(value, ref _ID); } } 


        private string _LastName;  
        public string LastName { get { return _LastName; } set { SetWithNotify(value, ref _LastName); } } 


        private string _FirstName;  
        public string FirstName { get { return _FirstName; } set { SetWithNotify(value, ref _FirstName); } } 


        private DateTime _HireDate;  
        public DateTime HireDate { get { return _HireDate; } set { SetWithNotify(value, ref _HireDate); } } 


        #endregion
        #region Generated Relationships

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual IList<CourseAssignment> CourseAssignments { get; set; }
        public virtual IList<Department> Departments { get; set; }
        #endregion
    }
}
