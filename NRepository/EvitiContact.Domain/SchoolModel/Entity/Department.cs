using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class Department : ClientChangeTracker, IPKEntity
    {
        public Department()
        {
            #region Generated Constructor
            Courses = new List<Course>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _DepartmentID;  
        public int DepartmentID { get { return _DepartmentID; } set { SetKeyWithOutNotify(value, ref _DepartmentID); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private decimal _Budget;  
        public decimal Budget { get { return _Budget; } set { SetWithNotify(value, ref _Budget); } } 


        private DateTime _StartDate;  
        public DateTime StartDate { get { return _StartDate; } set { SetWithNotify(value, ref _StartDate); } } 


        private int? _InstructorID;  
        public int? InstructorID { get { return _InstructorID; } set { SetWithNotify(value, ref _InstructorID); } } 


        #endregion
        #region Generated Relationships

        public virtual Instructor Instructor { get; set; }
        public virtual IList<Course> Courses { get; set; }
        #endregion
    }
}
