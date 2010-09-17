using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VPart
    {
      
        public static VPart GetPartByID(int id)
        {
            return VPart.Single(id);
        }

        public static List<VPart> GetListParts()
        {
            return All().ToList();
        }

        public static void InsertPart(VPart Part)
        {
            Add(Part);
        }

        public static void DeletePart(VPart pBO)
        {
            Delete(pBO.PartID);
        }

        public static void UpdatePart(VPart pBo)
        {
            Update(pBo);
        }

        public static List<VPart> Get(IQueryable<VPart> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VPart> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }

        public static List<VPart> GetPartsByLessionID(int id)
        {
            var lstParts = (from part in All()
                            where part.PartLessionID == id
                            orderby part.PartPriority
                            select part).ToList();
            return lstParts;

        }
    }
}