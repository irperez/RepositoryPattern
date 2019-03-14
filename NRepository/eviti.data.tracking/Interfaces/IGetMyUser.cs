using eviti.data.tracking.BaseObjects;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.Interfaces
{
    public interface IGetMyUser
    {
        string GetUser();
        ClaimsUser GetPrincipalUser();
    }
}
