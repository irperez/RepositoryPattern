using System;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.Interfaces
{
    //public interface IHaveIdentifier
    //{
    //    Guid Id { get; set; }
    //}

    public interface IHaveIdentifier<T>
    {
        T Id { get; set; }
    }


    public interface IHaveIdentifier2<T>
    {
        T GUID { get; set; }
    }
}
