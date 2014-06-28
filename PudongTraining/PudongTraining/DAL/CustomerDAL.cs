using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PudongTraining.Model;
using PudongTraining.Utility;
using System.Data;

namespace PudongTraining.DAL
{
    public class CustomerDAL
    {

        public DataTable GetAll()
        {
            string cmd = "select * from Customer";
            return SQLHelper.ExecuteDatatable(cmd);

        }
    }
}
