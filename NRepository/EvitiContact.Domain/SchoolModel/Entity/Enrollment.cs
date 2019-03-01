using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class Enrollment : ClientChangeTracker, IPKEntity
    {
        public Enrollment()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        public Grade? GradeAsEnum
        {
            get
            {

                if (_Grade.HasValue)
                {
                    return (SchoolModel.Grade)_Grade;
                }
                else
                {
                    return SchoolModel.Grade.F;
                }

            }
            set
            {
                int something = (int)value;
                _Grade = something;

            }

        }
        #region Generated Properties
        private int _EnrollmentID;  
        public int EnrollmentID { get { return _EnrollmentID; } set { SetKeyWithOutNotify(value, ref _EnrollmentID); } } 


        private int _CourseID;  
        public int CourseID { get { return _CourseID; } set { SetWithNotify(value, ref _CourseID); } } 


        private int _StudentID;  
        public int StudentID { get { return _StudentID; } set { SetWithNotify(value, ref _StudentID); } } 


        private int? _Grade;  
        public int? Grade { get { return _Grade; } set { SetWithNotify(value, ref _Grade); } } 


        #endregion
        #region Generated Relationships

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        #endregion
    }
}
