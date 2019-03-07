using System;

namespace Common
{
    public class DateService : IDateService
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }

    public interface IDateService
    {
        DateTime GetDate();
    }
}
