using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.SchoolModel;

namespace EvitiContact.SchoolModel
{
    public partial class OfficeAssignment : ClientChangeTracker, IPKEntity
    {
        public OfficeAssignment()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _InstructorID;  
        public int InstructorID { get { return _InstructorID; } set { SetKeyWithOutNotify(value, ref _InstructorID); } } 


        private string _Location;  
        public string Location { get { return _Location; } set { SetWithNotify(value, ref _Location); } } 


        #endregion
        #region Generated Relationships

        public virtual Instructor Instructor { get; set; }
        #endregion
    }
}
