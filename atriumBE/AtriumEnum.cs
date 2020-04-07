using System;

namespace atriumBE
{
	/// <summary>
	/// Summary description for CMEnum.
	/// </summary>
	public class AtriumEnum
	{

		/// <summary>Application error codes</summary>
		public enum AppErrorCodes
		{
			FODupsNotAllowed=2109,
			BadFileNumber = 2108,
			UnableToUpdateRowNotFound = 2107,
			UnableToDeleteRowNotFound = 2106,
			MustBeLessThanOrEqual = 2105,
			/// <summary>Venue must belong to Court</summary>
			VenueMustBelongToCourt = 2104,
			MustBeBlank = 2103,
			SINNotFound=2102,
			CANoDelWithDisb=2101,
			DateMustBeStartOfWeek = 2100,
			CannotOpenAccount=2099,
			BadPassword=2098,
			NoCurrentCashBlotterRecord = 2097,
			CannotImpersonate = 2096,
			CannotSetFileNumPKID = 2095,
			OfficerNotAssigned = 2094,
			//			OfficerNotFound = 2093,
			//			RecordNotFound = 2092
			BadOfficeID = 2091,
			BFDateInvalid = 2090,
			OfficerNotCurrent = 2089	,
			MailboxOverflow = 2088	,
			MSOAOverDARS = 2087	,
			OffcrDuplicateCode = 2086	,
			//			TELDetailsRqd = 2085	,
			TELReadOnly = 2084	,
			TaxNoChangeAfterSRP = 2083	,
			SRPDBError = 2082	,
			SRPBadBillingProcess = 2081	,
			SRPDisbAlreadyEntered = 2080	,
			SRPNoMatchCAToDTC = 2079	,
			SRPDTCNotDesignated = 2078	,
			SRPDisbErr = 2077	,
			SRPSubmitted = 2076	,
			SRPNoOnlineBilling = 2075	,
			SRPIRPNotTaxed = 2074	,
			SRPDateChangeNotAllowed = 2073	,
			SRPReadOnly = 2072	,
			CLASMateArchiveFailed = 2071	,
			CLASMateLabels = 2070	,
			OffcrNoFeature = 2069	,
			OffcrPwdLength = 2068	,
			EntryRqd = 2067	,
			LetterOperationCancelled = 2066	,
			LetterInvalidLetter = 2065	,
			JudgInvalidJudgAmt = 2064	,
			JudgInvalidCost = 2063	,
			InsolvDefault = 2062	,
			GroupNameRqd = 2061	,
			DuplicateCode = 2060	,
			FHInvalidFileType = 2059	,
			DisbNoTaxUnlessCommit = 2058	,
			DisbNoEditAfterCommit = 2057	,
			DisbNoDelete = 2056	,
			DebtInvalidSpouseSIN = 2055	,
			DebtSINExists = 2054	,
			InvalidInterestRate = 2053	,
			DebtAddressRqd = 2052	,
			DebtCloseCodeRqd = 2051	,
			DebtDuplicateSIN = 2050	,
			CBOnlyOneCBOpen = 2049	,
			BatchInvalidJobName = 2048	,
			CANoDelOtherOffice = 2047	,
			CANoEntryByOffices = 2046	,
			CACannotTax = 2045	,
			CACannotEditHoursFees = 2044	,
			CANoEntryInOfficeMod = 2043	,
			CANotValid = 2042	,
			IsNotValid = 2041	,
			CACannotEditAnotherOffice = 2040	,
			CANoDeleteCommitted = 2039	,
			BatchImportNotAllowed = 2037	,
			MustBeGreaterThanZero = 2036	,
			ErrorFromOffice = 2034	,
			DateMustBeBefore = 2033	,
			DateMustBeAfter = 2032	,
			DateMustBeBetween = 2031	,
			RelatedDateRequired = 2030	,
			/// <summary>{0} is not a valid date.</summary>
			NotValidDate = 2029	,
			CannotBeBlank = 2028,
			AddressCityNotInProv = 2024	,
			AddressNoDelete = 2022	,
			NoRecordToUpdate = 2021	,
			//			FileNotReturned = 2020	,
			//			FeatureNoMatch = 2019	,
			//			ConfirmOfficerSame = 2018	,
			CBDBadSeries = 2017	,
			NoFile = 2016	,
			//			CancelledByUser = 2015	,
			//			DataChanged = 2014	,
			//			ValidationError = 2013	,
			//			BadClassInitParams = 2012	,
			//			NoParent = 2011	,
			//			InvalidDataType = 2010	,
			BadUserName = 2009	,
			NoCascadeDelete = 2008	,
			BadOfficeCode = 2007	,
			LoginFailed = 2006	,
			ReadOnly = 2005	,
			//			BadAddress = 2004	,
			BadSIN = 2003	,
			//			BadKeyType = 2002	,
			//			BadKeyName = 2001	,
			//			UnexpectedError = 2000
		};

		public enum CLASMateFeaturePermissions
		{
			sfpNoAccess = 0,
			sfpReadOnly = 1,
			sfpReadWrite = 2
		};


		public enum DebtorIndexLists
		{
			dilBigLabel,
			dilsmallLabel
		};

		public enum OfficeCourts
		{
			SupremeCourtOfCanada = 1000,
			FederalCourtOfAppeal,
			FederalCourtTrialDivision,
			PensionAppealBoard,
			ReviewTribunal
		};
	}

	public class ContactTypes
	{
		public const string Lawyer = "LA";
		public const string Preference = "PREF";
		public const string Manager = "MG";
	}

}
