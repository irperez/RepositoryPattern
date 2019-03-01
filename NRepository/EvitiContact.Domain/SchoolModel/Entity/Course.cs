using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
  

    public partial class Course : ClientChangeTracker, IPKEntity
    {
        public Course()
        {
            #region Generated Constructor
            CourseAssignments = new List<CourseAssignment>();
            Enrollments = new List<Enrollment>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _CourseID;  
        public int CourseID { get { return _CourseID; } set { SetKeyWithOutNotify(value, ref _CourseID); } } 


        private string _Title;  
        public string Title { get { return _Title; } set { SetWithNotify(value, ref _Title); } } 


        private int _Credits;  
        public int Credits { get { return _Credits; } set { SetWithNotify(value, ref _Credits); } } 


        private int _DepartmentID;  
        public int DepartmentID { get { return _DepartmentID; } set { SetWithNotify(value, ref _DepartmentID); } } 


        #endregion
        #region Generated Relationships

        public virtual Department Department { get; set; }
        public virtual IList<CourseAssignment> CourseAssignments { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }
        #endregion
    }
}
