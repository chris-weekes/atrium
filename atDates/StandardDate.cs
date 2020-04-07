using System;

namespace atDates
{
	/// <summary>
	/// Date Ranges Class
	/// </summary>
	/// 
	public class DateRange
	{
		public DateTime BeginDate;
		public DateTime EndDate;

		public DateRange()
		{
		}
		public DateRange(DateTime BeginDate, DateTime EndDate)
		{
			this.BeginDate = BeginDate;
			this.EndDate = EndDate;
		}

		public override string ToString()
		{
			return(String.Format("{0}  -->  {1}", BeginDate, EndDate));   
		}

	}

	public class StandardDate
	{

        public enum StandardDateType
        {
            LastYear,
            ThisYear,
            NextYear
        }

		static StandardDate()
		{

		}

        //public static DateRange GetRange(StandardDateType dateType)
        //{
        //    switch (dateType)
        //    {
        //        case StandardDateType.LastYear:
        //            return LastYear;
        //            break;
        //    }
        //}
        

		public static DateRange LastYear
		{
			get
			{
				return GetYear(-1);
			}
		}

		public static DateRange ThisYear
		{
			get
			{
				return GetYear(0);
			}
		}

		public static DateRange NextYear
		{
			get
			{
				return GetYear(1);
			}
		}


		public static DateRange LastQuarter
		{
			get
			{
				return GetQuarter(-1);
			}
		}


		public static DateRange ThisQuarter
		{
			get
			{
				return GetQuarter(0);
			}
		}

		public static DateRange NextQuarter
		{
			get
			{
				return GetQuarter(1);
			}
		}


		public static DateRange LastMonth
		{
			get
			{
				return GetMonth(-1);
			}
		}


		public static DateRange ThisMonth
		{
			get
			{
				return GetMonth(0);
			}
		}

		public static DateRange NextMonth
		{
			get
			{
				return GetMonth(1);
			}
		}

		private static DateRange GetQuarter(int whichQuarter)
		{			
			int num = whichQuarter * 3;
			DateTime dateInQ = DateTime.Today.AddMonths(num);

			DateTime firstQ = new DateTime(dateInQ.Year, 1, 1);
			DateTime secondQ = new DateTime(dateInQ.Year, 4, 1);
			DateTime thirdQ = new DateTime(dateInQ.Year, 7, 1);
			DateTime fourthQ = new DateTime(dateInQ.Year, 10, 1);

			DateTime beginD = Convert.ToDateTime(null); 
			DateTime endD = Convert.ToDateTime(null);


			if ((firstQ <= dateInQ) && (dateInQ < secondQ))
			{
				beginD = firstQ;
				endD = secondQ.AddDays(-1);
			}
			else if ((secondQ <= dateInQ) && (dateInQ < thirdQ))
			{
				beginD = secondQ;
				endD = thirdQ.AddDays(-1);
			}
			else if ((thirdQ <= dateInQ) && (dateInQ < fourthQ))
			{
				beginD = thirdQ;
				endD = fourthQ.AddDays(-1);
			}
			else if ((fourthQ <= dateInQ) && (dateInQ < firstQ.AddYears(1)))
			{
				beginD = fourthQ;
				endD = firstQ.AddYears(1).AddDays(-1);
			}

			return GetDateRange(beginD, endD);
		}

		private static DateRange GetYear(int whichYear)
		{
			DateTime newDate = DateTime.Today.AddYears(whichYear);

			DateTime beginD = new DateTime(newDate.Year, 1, 1);
			DateTime endD = new DateTime(newDate.Year, 12, 31);

			return GetDateRange(beginD, endD);
		}


		private static DateRange GetMonth(int whichMonth)
		{
			DateTime newDate = DateTime.Today.AddMonths(whichMonth);

			DateTime beginD = new DateTime(newDate.Year, newDate.Month, 1) ;
			DateTime endD = beginD.AddMonths(1).AddDays(-1);

			return GetDateRange(beginD, endD);
		}



		public static DateRange Yesterday
		{
			get
			{
				return GetDay(-1);
			}
		}

		public static DateRange Today
		{
			get
			{
				return GetDay(0);
			}
		}

		public static DateRange Tomorrow
		{
			get
			{
				return GetDay(1);
			}
		}

		private static DateRange GetDay(int whichDay)
		{
			DateTime beginD = DateTime.Today.AddDays(whichDay);
			DateTime endD = DateTime.Today.AddDays(whichDay);

			return GetDateRange(beginD, endD);
		}


		public static DateRange LastWeek
		{
			get
			{
				return GetWeek(-1);
			}
		}


		public static DateRange ThisWeek
		{
			get
			{
				return GetWeek(0);
			}
		}


		public static DateRange NextWeek
		{
			get
			{
				return GetWeek(1);
			}
		}

		private static DateRange GetWeek(int whichWeek)
		{
			int num = whichWeek * 7;
			DateTime beginD = Convert.ToDateTime(null); 
			DateTime endD = Convert.ToDateTime(null);

			int dayOfWeek = (int) DateTime.Today.DayOfWeek;
			switch (dayOfWeek)
			{
				case 0:
					beginD = DateTime.Today.AddDays(num-6);
					endD = DateTime.Today.AddDays(num+0);
					break;
				case 1:
					beginD = DateTime.Today.AddDays(num-0);
					endD = DateTime.Today.AddDays(num+6);
					break;
				case 2:
					beginD = DateTime.Today.AddDays(num-1);
					endD = DateTime.Today.AddDays(num+5);
					break;
				case 3:
					beginD = DateTime.Today.AddDays(num-2);
					endD = DateTime.Today.AddDays(num+4);
					break;
				case 4:
					beginD = DateTime.Today.AddDays(num-3);
					endD = DateTime.Today.AddDays(num+3);
					break;
				case 5:
					beginD = DateTime.Today.AddDays(num-4);
					endD = DateTime.Today.AddDays(num+2);
					break;
				case 6:
					beginD = DateTime.Today.AddDays(num-5);
					endD = DateTime.Today.AddDays(num+1);
					break;
			}

			return GetDateRange(beginD, endD);
		}


		public static DateRange LastYearToDate
		{
			get
			{
				return GetYearToDate(-1);
			}
		}

		public static DateRange ThisYearToDate
		{
			get
			{
				return GetYearToDate(0);
			}
		}

		public static DateRange NextYearToDate
		{
			get
			{
				return GetYearToDate(1);
			}
		}

		private static DateRange GetYearToDate(int whichYear)
		{
			DateTime today =DateTime.Today;
			DateTime newDate = today.AddYears(whichYear);
			
			DateTime beginD = new DateTime(newDate.Year, 1, 1);
			DateTime endD = new DateTime(newDate.Year, today.Month, today.Day);

			return GetDateRange(beginD, endD);
		}

		public static DateRange LastMonthToDate
		{
			get
			{
				return GetMonthToDate(-1);
			}
		}

		public static DateRange ThisMonthToDate
		{
			get
			{
				return GetMonthToDate(0);
			}
		}

		public static DateRange NextMonthToDate
		{
			get
			{
				return GetMonthToDate(1);
			}
		}

		private static DateRange GetMonthToDate(int whichMonth)
		{
			DateTime today = DateTime.Today;
			DateTime newDate = today.AddMonths(whichMonth);
			
			DateTime beginD = new DateTime(newDate.Year, newDate.Month, 1);
			DateTime endD = new DateTime( newDate.Year, newDate.Month, today.Day);

			return GetDateRange(beginD, endD);
		}

		private static DateRange GetDateRange(DateTime beginDate, DateTime endDate)
		{
			DateTime endD = endDate.AddDays(1).AddSeconds(-1);
			DateRange ly =new DateRange();
			ly.BeginDate = beginDate;
			ly.EndDate = endD;
				
			return ly;
		}

		public static DateRange Custom
		{
			get
			{
				DateRange ly =new DateRange();
				ly.BeginDate = DateTime.Parse("2004/1/1");
				ly.EndDate = DateTime.Parse("2004/2/1");
				
				return ly;
			}
		}
	}
}
