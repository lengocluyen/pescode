using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class T_Test_Result
    {
        #region Insert, Update, Delete
        /// <summary>
        /// INSERT Test_Result
        /// </summary>
        /// <param name="ob">Test_Result</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Insert(Object ob)
        {
            try
            {
                Add(ob as T_Test_Result);
                return 1;
            }
            catch
            {
                return -1;
            }

        }
        /// <summary>
        /// Update TEST_RESULTS
        /// </summary>
        /// <param name="ob">TEST_RESULTS</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Update(object ob)
        {
            try
            {
                Update(ob as T_Test_Result);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Delete TEST_RESULTS
        /// </summary>
        /// <param name="ob">TEST_RESULTS</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Delete(Object ob)
        {
            try
            {
                Delete(ob as T_Test_Result);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Ultility
        /// <summary>
        /// GetObject Test_Result
        /// </summary>
        /// <returns>list all TEST_RESULTS</returns>
        public IQueryable<T_Test_Result> GetObject()
        {
            try
            {
                return T_Test_Result.All();

            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// GetTestResult
        /// </summary>
        /// <param name="id">TestResultID</param>
        /// <returns>TEST_RESULTS</returns>
        public T_Test_Result GetTest_Result(int id)
        {
            return (from m in GetObject() where m.TestResultID == id select m).FirstOrDefault();
        }
        #endregion
    }
}
