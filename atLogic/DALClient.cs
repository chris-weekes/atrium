using System;
using System.Collections.Generic;
using System.Text;
using atDAL;

namespace atLogic
{
    class DALHandle
    {
        public ObjectDAL ODAL;
        public string Name;
        public DateTime LastAccess;
    }
    public class DALClient
    {
        AppManager myMng;
        public DALClient(AppManager mngr)
        {
            myMng = mngr;
        }

        Dictionary<string, DALHandle> myLoadedDals = new Dictionary<string, DALHandle>();

        internal Dictionary<string, DALHandle> LoadedDals
        {
            get { return myLoadedDals; }

        }

        public void AddDAL(ObjectDAL odal)
        {
            string key = odal.GetType().Name;
            if (!LoadedDals.ContainsKey(key))
            {
                DALHandle dh = new DALHandle();
                dh.LastAccess = DateTime.Now;
                dh.Name = key;
                dh.ODAL = odal;
                LoadedDals.Add(dh.Name, dh);
            }
            else
            {
                LoadedDals[key].ODAL = odal;
            }
        }

        public ObjectDAL ODAL(string name)
        {
            if (LoadedDals.ContainsKey(name))
            {
                LoadedDals[name].LastAccess = DateTime.Now;
                return LoadedDals[name].ODAL;
            }
            else
                return null;
        }

        public void RecoverDALMngr()
        {
            myMng.DAL = myMng.RemoteDAL("", "");
        }

        public atDAL.ObjectDAL RecoverDAL(string name)
        {

            atDAL.ObjectDAL od;
            try
            {
                Type ty = myMng.DAL.GetType();
                System.Reflection.MethodInfo mi = ty.GetMethod("Get" + name);
                od = (atDAL.ObjectDAL)mi.Invoke(myMng.DAL, null);

                return od;
            }
            catch (Exception x1)
            {
                try
                {
                    RecoverDALMngr();
                    Type ty = myMng.DAL.GetType();
                    System.Reflection.MethodInfo mi = ty.GetMethod("Get" + name);
                    od = (atDAL.ObjectDAL)mi.Invoke(myMng.DAL, null);

                    return od;
                }
                catch (Exception x)
                {
                    throw new AtriumException("Could not restore server connection", x);
                }
            }
        }

    }
}
