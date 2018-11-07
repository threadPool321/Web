using System;
using System.Data;
using System.Collections.Generic;
using Lz.Web.Common;
using Lz.Web.Model;
namespace Lz.Web.Bll
{
	/// <summary>
	/// HKSJ_USERS
	/// </summary>
	public partial class HKSJ_USERS
	{


	    public void Delete(Model.HKSJ_USERS user)
	    {
	        this.Delete(user.ID);
	    }

	    public int GetCount()
	    {
	        return this.GetRecordCount(string.Empty);
	    }

	    public List<Model.HKSJ_USERS> GetListUsers(int maxRows, int startRowIndex)
	    {

            var ds = this.GetListByPage(string.Empty, "id", startRowIndex + 1, startRowIndex + maxRows);
	        return this.DataTableToList(ds.Tables[0]);
	    }
	}
}

