using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDMasterViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="MDMasterViewModel"/> class.
    /// Based on <see cref="MDMaster"/> class.
    /// </summary>
    public MDMasterViewModel()
     {
     }
    #region Generated  ViewModel
    public Guid MasterId { get; set; }
    public string Name { get; set; }
    public decimal? TotalDollars { get; set; }
    public decimal NewRequired { get; set; }
    //public string Version { get; set; }
    //public DateTime CreatedDate { get; set; }
    //public string CreatedBy { get; set; }
    //public DateTime ModifiedDate { get; set; }
    //public string ModifiedBy { get; set; }
    //public byte[] RowVersion { get; set; }
    #endregion
     }
    /*
    #region Generated Reference Class
    public partial class MDMaster
    {
        public MDMaster()
        {
            MDDetails = new HashSet<MDDetail>();
        }

        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public decimal? TotalDollars { get; set; }
        public decimal NewRequired { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<MDDetail> MDDetails { get; set; }
    }
    #endregion
    */
}
