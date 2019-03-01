using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class Student : ClientChangeTracker, IPKEntity
    {
        public Student()
        {
            #region Generated Constructor
            Enrollments = new List<Enrollment>();
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


        private DateTime _EnrollmentDate;  
        public DateTime EnrollmentDate { get { return _EnrollmentDate; } set { SetWithNotify(value, ref _EnrollmentDate); } } 


        #endregion
        #region Generated Relationships

        public virtual IList<Enrollment> Enrollments { get; set; }
        #endregion
    }
}
