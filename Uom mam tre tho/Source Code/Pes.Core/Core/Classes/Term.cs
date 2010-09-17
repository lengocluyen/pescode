using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Term
    {

        public static Term GetCurrentTerm()
        {
            var terms = (from t in Term.All()
                         orderby t.CreateDate descending
                         select t).Take(1).ToList();
            return terms.Count == 1 ? terms[0] : null;
        }
    }
}