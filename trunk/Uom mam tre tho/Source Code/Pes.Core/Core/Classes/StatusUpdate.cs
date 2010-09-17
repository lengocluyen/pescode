using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using System.Linq.Dynamic;

namespace Pes.Core
{
    public partial class StatusUpdate
    {
        public static StatusUpdate GetStatusUpdateByID(Int32 StatusUpdateID)
        {
            return StatusUpdate.Single(StatusUpdateID);
        }

        public static List<StatusUpdate> GetTopNStatusUpdatesByAccountID(Int32 AccountID, Int32 Number)
        {
            return StatusUpdate.GetTop(Number, "CreateDate descending", "AccountID=" + AccountID).ToList();
        }

        public static List<StatusUpdate> GetStatusUpdatesByAccountID(Int32 AccountID)
        {
            IEnumerable<StatusUpdate> statusUpdates = from su in StatusUpdate.All()
                                                      where su.AccountID == AccountID
                                                      orderby su.CreateDate descending
                                                      select su;
            return statusUpdates.ToList();
        }

        public static void SaveStatusUpdate(StatusUpdate statusUpdate)
        {
            if (statusUpdate.StatusUpdateID > 0)
            {
                StatusUpdate.Update(statusUpdate);
            }
            else
            {
                statusUpdate.CreateDate = DateTime.Now;
                StatusUpdate.Add(statusUpdate);
            }
        }
    }
}