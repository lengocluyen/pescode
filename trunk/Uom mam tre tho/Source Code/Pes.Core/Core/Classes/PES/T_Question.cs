using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class T_Question
    {
        #region Insert, Delete, Update
        /// <summary>
        /// Insert Questions
        /// </summary>
        /// <param name="ob">QUESTIONS</param>
        /// <returns>1 success or -1 fail</returns>
        
        public static int Insert(Object ob)
        {
            try
            {
                Add(ob as T_Question);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Update Questions
        /// </summary>
        /// <param name="ob">QUESTIONS</param>
        /// <returns>1 success or -1 fail</returns>
        public static int Update(object ob)
        {
            try
            {
                Update(ob as T_Question);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Delete Questions 
        /// </summary>
        /// <param name="ob">QUESTIONS</param>
        /// <returns> 1 success or -1 fail</returns>
        public static int Delete(object ob)
        {
            try
            {
                Delete(ob as T_Question);
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
        /// GetObject Questions
        /// </summary>
        /// <returns>list all Questions</returns>
        public static IQueryable<T_Question> GetObject()
        {
            return T_Question.All();
        }
        /// <summary>
        /// GetQuestions Questions
        /// </summary>
        /// <param name="id">QuestionID</param>
        /// <returns>Question</returns>
        public static T_Question GetQuestions(int id)
        {
            return (from m in GetObject() where m.QuestionID == id select m).FirstOrDefault();
        }
        public static List<T_Question> GetAllQuestionByLevelID(int id)
        {
            return (from i in GetObject() where i.LevelID == id select i).ToList(); ;
        }
        #endregion
    }
}