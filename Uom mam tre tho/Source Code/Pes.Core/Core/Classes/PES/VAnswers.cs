using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VAnswers
    {
        public static List<VAnswers> GetListAnserForQuestion(int questionID)
        {
            return All().Where(a=>a.QuestionID==questionID).ToList<VAnswers>();
        }
        public static VAnswers GetAnswerByID(int id)
        {
            return VAnswers.Single(id);
        }

        public static List<VAnswers> GetListAnswers()
        {
            return All().ToList();
        }

        public static void InsertAnswer(VAnswers asBO)
        {
            VAnswers.Add(asBO);
        }

        public static void DeleteAnswer(VAnswers asBO)
        {
            VAnswers.Delete(asBO.AnswerID);
        }

        public static void UpdateAnswer(VAnswers asBo)
        {
            VAnswers.Update(asBo);
        }

        public static List<VAnswers> Get(IQueryable<VAnswers> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VAnswers> l = table.Skip(start - 1).Take(end - start + 1).ToList<VAnswers>();

            return l;
        }

    }
}