using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("T_Test_Result")]
    public partial class T_Test_Result : EntityBase<T_Test_Result>
    {
        #region Properties

        public override object Id
        {
            get;
            set;
        }

        [SubSonicPrimaryKey]
        public int TestResultID { get; set; }
        public int Level { get; set; }
        public int UserID { get; set; }
        public double Mark { get; set; }
        public DateTime TestDate { get; set; }

        #endregion

        public T_Test_Result()
        {

        }

        public T_Test_Result(object id)
        {
            if (id != null)
            {
                T_Test_Result entity = Single(id);
                if (entity != null)
                    entity.CopyTo<T_Test_Result>(this);
                else
                    this.TestResultID = 0;
            }
        }
    }
}
