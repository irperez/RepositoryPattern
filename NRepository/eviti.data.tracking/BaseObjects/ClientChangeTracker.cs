using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace eviti.Data.Tracking.BaseObjects
{


    [Serializable()]
    public class ClientChangeTracker : INotifyPropertyChanged, IClientChangeTracker
    //, ITrackable, IMergeable , IClientChangeTracker
    {


        //public bool NeedsId()
        //{

        //    return true;
        //}

        //public void GenerateId()
        //{

        //    return true;
        //}


        private bool _isDirty;
        [NotMapped]
        public bool IsDirty
        {
            get { return _isDirty; }
            set { SetWithNotify(value, ref _isDirty); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotMapped]
        public TrackingState TrackingState { get; set; }

        private ICollection<string> _ModifiedProperties;
        [NotMapped]
        public ICollection<string> ModifiedProperties
        {
            get { return _ModifiedProperties; }
            set { SetWithNotify(value, ref _ModifiedProperties); }
        }


        //public void TempReset()
        //{
        //    if (this.ModifiedProperties != null)
        //    {
        //        this.ModifiedProperties.Clear();
        //        //this.tempRecordings.Clear();
        //    }

        //    this._isDirty = false;
        //}
        //[NotMapped]
        //public List<TempNV> tempRecordings = new List<TempNV>();

        [NotMapped]
        public Guid EntityIdentifier { get; set; }

        protected void SetKeyWithOutNotify<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            field = value;

        }
        protected void SetWithNotify<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            _isDirty = ShareSetWithNotifyHelper.SetWithNotify(value, ref field, this, PropertyChanged, TrackingState, ref _ModifiedProperties, propertyName);
           // _isDirty = ShareSetWithNotifyHelper.SetWithNotify(value, ref field, this, PropertyChanged, TrackingState, ref _ModifiedProperties, ref  tempRecordings, propertyName);
          
        }



    }


}
