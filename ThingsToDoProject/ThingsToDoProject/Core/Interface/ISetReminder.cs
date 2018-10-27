using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThingsToDoProject.Core.Interface
{
    public interface ISetReminder
    {
        void SetReminderForIternary(string phoneNumber, string placeId, string name, string distance, string storeNumber, string GoogleUrl);

        void SetReminderForAll(string phoneNumber);
    }
}
