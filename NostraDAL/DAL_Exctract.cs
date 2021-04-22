using NostraDAL.NostraSrv;
using NostraDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraDAL
{
    public class DAL_Exctract
    {
        public PersonalRecord GetCompletePersonalDataById(int IdPerson)
        {
            PersonalRecord pr = null;
            try
            {
                using (NostraSrv.NostraSrvClient srv = new NostraSrv.NostraSrvClient())
                {
                    pr = srv.GetCompletePersonalDataById(IdPerson);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return pr;
        }
        public DisplayPersonalRecord GetDisplayPersonalDataById(int IdPerson)
        {
            DisplayPersonalRecord pr = null;
            try
            {
                using (NostraSrv.NostraSrvClient srv = new NostraSrv.NostraSrvClient())
                {
                    pr = srv.GetDisplayPersonalRecordById(IdPerson);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return pr;
        } 
    }
}
