using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public partial class PartTestType
    {
        public static List<PartTestType> GetPartTestTypeByPartID(int partID)
        {
            return PartTestType.Find(p => p.PartID == partID);
        }
        public static void DeletePartTestType(int idPartTestType)
        {
            Delete(idPartTestType);
        }
        public static void UpdatePartTestType(PartTestType plt)
        {
            Update(plt);
        }
        public static void InsertPartTestType(PartTestType plt)
        {
            Add(plt);
        }
    }
}
