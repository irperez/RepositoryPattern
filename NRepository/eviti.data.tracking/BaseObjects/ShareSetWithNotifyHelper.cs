using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace eviti.Data.Tracking.BaseObjects
{
    public class ShareSetWithNotifyHelper
    {
        /// <summary>
        /// Returns IsDirty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="field"></param>
        /// <param name="PropertyChanged"></param>
        /// <param name="TrackingState"></param>
        /// <param name="ModifiedProperties"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        //public static bool SetWithNotify<T>(T value, ref T field, object myobject, PropertyChangedEventHandler PropertyChanged, TrackingState TrackingState, 
        //    ref ICollection<string> ModifiedProperties,  ref List<TempNV> orginalValues, [CallerMemberName] string propertyName = "")
        public static bool SetWithNotify<T>(T value, ref T field, object myobject, PropertyChangedEventHandler PropertyChanged, TrackingState TrackingState,
      ref ICollection<string> ModifiedProperties, [CallerMemberName] string propertyName = "")
        {
            if (!Equals(field, value))
            {

                //               if (orginalValues!=null)
                //               {
                //TempNV temp = new TempNV
                //               {
                //                   Old = field,
                //                   New = value
                //               };
                //               orginalValues.Add(temp);

                //               }

                field = value;
                PropertyChanged?.Invoke(myobject, new PropertyChangedEventArgs(propertyName));

                // Add prop to modified props, and fire EntityChanged event
                if (TrackingState == TrackingState.Unchanged || TrackingState == TrackingState.Modified)
                {
                    if (ModifiedProperties == null)
                    {
                        ModifiedProperties = new List<string>();
                    }

                    if (!ModifiedProperties.Contains(propertyName))
                    {
                        ModifiedProperties.Add(propertyName);
                        return true;
                        // _isDirty = true;  // maybe not a great spot for this?
                    }

                }
            }
            return false;
        }
    }
}
