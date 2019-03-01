using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class CourseAssignment : ClientChangeTracker, IPKEntity
    {
        public CourseAssignment()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _InstructorID;  
        public int InstructorID { get { return _InstructorID; } set { SetKeyWithOutNotify(value, ref _InstructorID); } } 


        private int _CourseID;  
        public int CourseID { get { return _CourseID; } set { SetKeyWithOutNotify(value, ref _CourseID); } } 


        #endregion
        #region Generated Relationships

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        #endregion
    }
}
