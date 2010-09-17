using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VQuestions
    {
        public static VQuestions GetQuestionByID(int id)
        {
            return All().Where(q => q.QuestionID == id).SingleOrDefault();
        }
        /*-----------------------------*/
        public static List<VQuestions> GetListQuestionByLevel(int levelID)
        {
            return All().Where(q => q.LevelID == levelID).ToList();
        }
        public static int CountQuestionByLevelID(int levelID)
        {
            return All().Where(q => q.LevelID == levelID).Count();
        }
        public static IQueryable<VQuestions> QueryGetQuestionByLevelID(int levelID)
        {
            return All().Where(q => q.LevelID == levelID);
        }
        public static int CountQuestionsBySeach(int levelID)
        {
            return QueryGetQuestionBySearch(levelID).Count();
        }
        public static IQueryable<VQuestions> QueryGetQuestionBySearch(int levelID)
        {
            IQueryable<VQuestions> query = All();
            if (levelID > 0)
                query = query.Where(q => q.LevelID == levelID);

            return query;
        }
        /*----------------------------------*/
        public static VQuestions GetQuestionBySoundFile(string soundFile)
        {
            return All().SingleOrDefault(q => q.SoundFile == soundFile);
        }
        public static List<VQuestions> GetListQuestions()
        {
            return All().ToList();
        }

        public static void InsertQuestion(VQuestions qBO)
        {
            Add(qBO);
        }

        public static void DeleteQuestion(VQuestions qBO)
        {
            Delete(qBO);
        }

        public static void UpdateQuestion(VQuestions qBO)
        {
            Update(qBO);
        }

        public static List<VQuestions> Get(IQueryable<VQuestions> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VQuestions> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }

        //Lay dap an cho 1 cau hoi.
        public static VAnswers GetTrueAnswerForQuestion(VQuestions qBO)
        {
            VAnswers aBO = (from answer in qBO.GetForeignList<VAnswers>(a => a.QuestionID == qBO.QuestionID)
                          where answer.IsTrue == true
                          select answer).Single<VAnswers>();
            return aBO;
        }
        public static VAnswers GetTrueAnswerForQuestion(int questionID)
        {
            VAnswers aBO = (from question in All()
                          where question.QuestionID == questionID
                          from answer in question.GetForeignList<VAnswers>(a=>a.QuestionID==questionID)
                          where answer.IsTrue == true
                          select answer).SingleOrDefault();
            return aBO;
        }
    }
}