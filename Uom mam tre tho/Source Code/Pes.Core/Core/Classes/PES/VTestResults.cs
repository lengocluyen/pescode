using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VTestResults
    {
   
        public static VTestResults GetTestResultByID(int id)
        {
            return Single(id);
        }

        public static List<VTestResults> GetListTestResults()
        {
            return All().ToList();
        }

        public static void InsertTestResult(VTestResults trBO)
        {
            Add(trBO);
        }

        public static void DeleteTestResutl(VTestResults trBO)
        {
            Delete(trBO.TestResultID);
        }

        public static void UpdateQuestion(VTestResults trBO)
        {
            Update(trBO);
        }

        public static List<VTestResults> Get(IQueryable<VTestResults> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VTestResults> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }
  
    }
}