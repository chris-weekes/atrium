using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// This class will be used to calculate distances between 2 postal code locations
    /// This will determine which Service Canada Cetre is most convenient for Hearings
	/// </summary>
	public class PostalCodeLocationBE:atLogic.ObjectBE
	{

        atriumManager myA;
		appDB.PostalCodeLocationDataTable myPostalCodeLocationDT;

        const int earthRadiusKM = 6371; // km
        double distance;

		internal PostalCodeLocationBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.PostalCodeLocation)
		{
			myA=pBEMng;
            myPostalCodeLocationDT = (appDB.PostalCodeLocationDataTable)myDT;
            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetPostalCodeLocation();
		}
		
		public atriumDAL.PostalCodeLocationDAL myDAL
        {
            get
            {
                return (atriumDAL.PostalCodeLocationDAL)myODAL;
            }
        }

		public appDB.PostalCodeLocationRow Load(string PostalCode)
		{
		    try
            {
				Fill(myDAL.Load(PostalCode));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(PostalCode));
            }

			return myPostalCodeLocationDT.FindByPostalCode(PostalCode);
		}

        protected override void AfterAdd(DataRow row)
        {
            appDB.PostalCodeLocationRow dr = (appDB.PostalCodeLocationRow)row;
            string ObjectName = this.myPostalCodeLocationDT.TableName;

        }

        public double CalculateDistance(string PostalCodeStart, string PostalCodeEnd)
        {
            // using the Spherical Law of Cosines formula
            
            
            distance = -1; // in kilometres

            appDB.PostalCodeLocationRow StartPoint = this.Load(PostalCodeStart);
            appDB.PostalCodeLocationRow EndPoint = this.Load(PostalCodeEnd);

            if (StartPoint != null && EndPoint != null)
            {
                distance = CalculateDistance((double)StartPoint.Latitude, (double)StartPoint.Longitude, (double)EndPoint.Latitude, (double)EndPoint.Longitude);
            }

            return distance;

        }

        public double CalculateDistance(string PostalCodeStart, double EndLatitude, double EndLongitude)
        {
            
            distance = -1;

            appDB.PostalCodeLocationRow StartPoint = myPostalCodeLocationDT.FindByPostalCode(PostalCodeStart);
            if(StartPoint==null)
                StartPoint=this.Load(PostalCodeStart);

            if (StartPoint != null)
            {
                distance = CalculateDistance((double)StartPoint.Latitude, (double)StartPoint.Longitude, EndLatitude, EndLongitude);
            }

            return distance;

        }

        public double CalculateDistance(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {

            // calculate shortest distance between 2 latitude and longitude values
            double startLatitudeInRad = startLatitude * (Math.PI / 180.0);
            double startLongitudeInRad = startLongitude * (Math.PI / 180.0);
            double endLatitudeInRad = endLatitude * (Math.PI / 180.0);
            double endLongitudeInRad = endLongitude * (Math.PI / 180.0);

            double longitude = endLongitudeInRad - startLongitudeInRad;
            double latitude = endLatitudeInRad - startLatitudeInRad;

            // intermediate result a
            double a = Math.Pow(Math.Sin(latitude / 2.0), 2.0) +
                       Math.Cos(startLatitudeInRad) * Math.Cos(endLatitudeInRad) *
                       Math.Pow(Math.Sin(longitude / 2.0), 2.0);

            // intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance

            distance = earthRadiusKM * c;

            return distance;

        }

	}

}