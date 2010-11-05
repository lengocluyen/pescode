using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("T_Reply")]
    public partial class T_Reply : EntityBase<T_Reply>
    {
        #region Properties

        public override object Id
        {
            get { return ReplyID; }
            set { ReplyID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int ReplyID { get; set; }
        public int QuestionID { get; set; }
        public string Contents { get; set; }
        public string MediaFile { get; set; }

        #endregion

        public T_Reply()
        {

        }

        public T_Reply(object id)
        {
            if (id != null)
            {
                T_Reply entity = Single(id);
                if (entity != null)
                    entity.CopyTo<T_Reply>(this);
                else
                    this.ReplyID = 0;
            }
        }
    }
}
