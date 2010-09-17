using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Test
    {
        public static List<Test> GetTestByTestID(int testID)
        {
            return Test.Find(p => p.TestID == testID);
        }
        public static void InsertTest(Test test)
        {
            Add(test);
        }
        public static void UpdateTest(Test test)
        {
            Update(test);
        }
        public static void DeleteTest(int testID)
        {
            Delete(testID);
        }
    }
}