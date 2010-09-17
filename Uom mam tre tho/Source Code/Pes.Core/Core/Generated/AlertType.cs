using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("AlertTypes")]
    public partial class AlertType : EntityBase<AlertType>
    {
        #region Properties

		
        public override object Id
        {

            get { return AlertTypeID; }
            set { AlertTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int AlertTypeID { get; set; }
		public string Name { get; set; }

        #endregion

        public AlertType()
        {

        }

        public AlertType(object id)
        {
			if (id != null)
            {
				AlertType entity = Single(id);
				if (entity != null)
					entity.CopyTo<AlertType>(this);
				else
					this.AlertTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (AlertTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}