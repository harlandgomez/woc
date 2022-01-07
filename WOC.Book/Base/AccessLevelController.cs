using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;

namespace Woc.Book.Base
{
    public class AccessLevelController 
    {
        public List<AccessLevels> GetData()
        {
            AccessLevelService accessLevelService = new AccessLevelService();
            List<AccessLevels> ListAccessLevels = new List<AccessLevels>();
            DataTable table = new DataTable();
            table = accessLevelService.GetAccessLevel();
            AccessLevels accessLevels;
            foreach (DataRow row in table.Rows)
            {
                accessLevels = new AccessLevels();
                accessLevels.AccessLevelID = (Guid)row["AccessLevelID"];
                accessLevels.AccessLevel = row["AccessLevel"].ToString();
                ListAccessLevels.Add(accessLevels);
            }
            return ListAccessLevels;


        }
        
    }
}
