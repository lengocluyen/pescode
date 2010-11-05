using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Extensions;
namespace Pes.Core
{
    public partial class T_Answers
    {
        #region Insert, Update, Delete
        /// <summary>
        /// INSERT PAnswers
        /// </summary>
        /// <param name="ob">PAnswers</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Insert(Object ob)
        {
            try
            {
                Add(ob as T_Answers);
                return 1;
            }
            catch
            {
                return -1;
            }

        }
        /// <summary>
        /// Update Answer
        /// </summary>
        /// <param name="ob">Answer</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Update(object ob)
        {
            try
            {
                Update(ob as T_Answers);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Delete Answer
        /// </summary>
        /// <param name="ob">Answer</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Delete(Object ob)
        {
            try
            {
                Delete(ob as T_Answers);
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
        /// GetObject Answer
        /// </summary>
        /// <returns>list all Answer</returns>
        public static IQueryable<T_Answers> GetObject()
        {
            try
            {
                return T_Answers.All();

            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// GetTest
        /// </summary>
        /// <param name="id">TestID</param>
        /// <returns>Test</returns>
        public static T_Answers GetAnswer(int id)
        {
            return (from m in GetObject() where m.AnswersID == id select m).FirstOrDefault();
        }
        public static List<T_Answers> GetAllAnswersByQuestion(int questionID)
        {
            return (from i in GetObject() where i.QuestionID == questionID select i).ToList();
        }
        #endregion

    }
}
