using System;

namespace eviti.data.tracking.Interfaces
{
    public interface ITrackConcurrency
    {
        string RowVersion { get; set; }
    }

    public interface ITrackOrginalValue
    {
       
      //    string OriginalObject { get; set; }
          string OriginalVMObject { get; set; }
    }

    public interface ITrackOrginalDBValue
    {

          string OriginalObject { get; set; }
        //  string OriginalVMObject { get; set; }
    }
}