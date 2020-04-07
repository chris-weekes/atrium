using System;
namespace atriumBE
{
	public class SeriesFields
	{
		
		public const string SeriesId="SeriesId";
		public const string ParentSeriesId="ParentSeriesId";
		public const string SeriesDescEng="SeriesDescEng";
		public const string SeriesDescFre="SeriesDescFre";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACBFFields
	{
		
		public const string ACBFId="ACBFId";
		public const string ActivityCodeID="ActivityCodeID";
		public const string BFCode="BFCode";
        public const string BFType = "BFType";
		public const string BFDate="BFDate";
		public const string BFDescriptionEng="BFDescriptionEng";
		public const string BFDescriptionFre="BFDescriptionFre";
		public const string DefaultBFOfficer="DefaultBFOfficer";
		public const string DefaultForOffice="DefaultForOffice";
		public const string RoleCode="RoleCode";
		public const string MonitorIncomplete="MonitorIncomplete";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACBFCompletedFields
	{
		
		public const string ACBFCompletedId="ACBFCompletedId";
		public const string ACBFId="ACBFId";
		public const string ActivityCodeId="ActivityCodeId";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACDependencyFields
	{
		
		public const string ACDependencyId="ACDependencyId";
		public const string ActivityCodeId="ActivityCodeId";
		public const string AvailableACId="AvailableACId";
        public const string LinkType = "LinkType";
		public const string Enable="Enable";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACDisbFields
	{
		
		public const string ACDisbId="ACDisbId";
		public const string ActivityCodeId="ActivityCodeId";
		public const string DisbType="DisbType";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACMandateFields
	{
		
		public const string Id="Id";
		public const string ActivityCodeId="ActivityCodeId";
		public const string MandateId="MandateId";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ACSeriesFields
	{
		
		public const string ACSeriesId="ACSeriesId";
		public const string ActivityCodeID="ActivityCodeID";
		public const string SeriesId="SeriesId";
		public const string Seq="Seq";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityBFFields
	{
		
		public const string ActivityBFId="ActivityBFId";
		public const string ActivityId="ActivityId";
		public const string ACBFId="ACBFId";
		public const string ForOfficeId="ForOfficeId";
		public const string Priority="Priority";
		public const string BFOfficerID="BFOfficerID";
		public const string BFComment="BFComment";
		public const string BFDate="BFDate";
		public const string Completed="Completed";
		public const string CompletedByID="CompletedByID";
		public const string CompletedDate="CompletedDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityCodeFields
	{
		
		public const string ActivityCodeID="ActivityCodeID";
		public const string ActivityCode="ActivityCode";
		public const string ActivityNameEng="ActivityNameEng";
		public const string ActivityNameFre="ActivityNameFre";
		public const string AssociatedObject="AssociatedObject";
		public const string AssociatedField="AssociatedField";
		public const string Record="Record";
		public const string DefaultHours="DefaultHours";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string Milestone="Milestone";
		public const string Communication="Communication";
		public const string SkipRelatedFields="SkipRelatedFields";
		public const string GoToDisbursements="GoToDisbursements";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityCodeFileTypeFields
	{
		
		public const string ActivityCodeFileTypeID="ActivityCodeFileTypeID";
		public const string ActivityCodeID="ActivityCodeID";
		public const string FileTypeCode="FileTypeCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}


	public class ActivityDetailFields
	{
		
		public const string ActivityDetailID="ActivityDetailID";
		public const string ActivityId="ActivityId";
		public const string Details="Details";
		public const string ConversationInitiator="ConversationInitiator";
		public const string ConversationWithCode="ConversationWithCode";
		public const string PersonCalled="PersonCalled";
		public const string ContactCalledId="ContactCalledId";
		public const string SendasEmail="SendasEmail";
		public const string IsDraft="IsDraft";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityFieldFields
	{
		
		public const string ActivityFieldID="ActivityFieldID";
		public const string ActivityCodeID="ActivityCodeID";
		public const string TaskType="TaskType";
		public const string TaskName="TaskName";
		public const string ObjectName="ObjectName";
		public const string FieldName="FieldName";
		public const string LookUp="LookUp";
		public const string FieldType="FieldType";
		public const string DefaultValue="DefaultValue";
		public const string DefaultObjectName="DefaultObjectName";
		public const string DefaultFieldName="DefaultFieldName";
		public const string LabelEng="LabelEng";
		public const string LabelFre="LabelFre";
		public const string Step="Step";
		public const string Seq="Seq";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityTimeFields
	{
		
		public const string ActivityTimeId="ActivityTimeId";
		public const string ActivityId="ActivityId";
		public const string IRPId="IRPId";
		public const string OfficerId="OfficerId";
		public const string OfficeId="OfficeId";
		public const string Taxed="Taxed";
		public const string Final="Final";
		public const string Posted="Posted";
		public const string Hours="Hours";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string SRPDate="SRPDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class MandateFields
	{
		
		public const string MandateId="MandateId";
		public const string MandateCode="MandateCode";
		public const string MandateDescEng="MandateDescEng";
		public const string MandateDescFre="MandateDescFre";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}


	public class AccessTypeFields
	{
		
		public const string AccessTypeCode="AccessTypeCode";
		public const string AccessTypeDescEng="AccessTypeDescEng";
		public const string AccessTypeDescFre="AccessTypeDescFre";
		public const string IsOwner="IsOwner";
		public const string IsLead="IsLead";
		public const string IsClient="IsClient";
		public const string AllAccounts="AllAccounts";
		public const string AssignedAccount="AssignedAccount";
		public const string EntryUser="EntryUser";
		public const string EntryDate="EntryDate";
		public const string UpdateUser="UpdateUser";
		public const string UpdateDate="UpdateDate";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string ts="ts";
	}

	public class AccountHistoryFields
	{
		
		public const string AccountHistoryId="AccountHistoryId";
		public const string FileHistoryId="FileHistoryId";
		public const string FileId="FileId";
		public const string OfficeId="OfficeId";
		public const string FileAccountId="FileAccountId";
		public const string SubFileType="SubFileType";
		public const string SentToOfficeDate="SentToOfficeDate";
		public const string ReceivedByOfficeDate="ReceivedByOfficeDate";
		public const string ReturnedByOfficeDate="ReturnedByOfficeDate";
		public const string ReceivedFromOfficeDate="ReceivedFromOfficeDate";
		public const string StatusCode="StatusCode";
		public const string ReturnCode="ReturnCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class AccountTypeFields
	{
		
		public const string AccountTypeId="AccountTypeId";
		public const string AccountTypeCode="AccountTypeCode";
		public const string AccountTypeDescEng="AccountTypeDescEng";
		public const string AccountTypeDescFre="AccountTypeDescFre";
		public const string ProgramID="ProgramID";
		public const string ReadOnly="ReadOnly";
		public const string DARSAccountType="DARSAccountType";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityFields
	{
		
		public const string Details="Details";
		public const string ActivityCode="ActivityCode";
		public const string ActivityId="ActivityId";
		public const string FileId="FileId";
		public const string IRPId="IRPId";
		public const string OfficeId="OfficeId";
		public const string ForOfficeId="ForOfficeId";
		public const string Priority="Priority";
		public const string LinkTable="LinkTable";
		public const string LinkID="LinkID";
		public const string ActivityCodeID="ActivityCodeID";
		public const string ActivityDate="ActivityDate";
		public const string ActivityEntryDate="ActivityEntryDate";
		public const string ActivityComment="ActivityComment";
		public const string OfficerId="OfficerId";
		public const string BFOfficerID="BFOfficerID";
		public const string BFComment="BFComment";
		public const string BFDate="BFDate";
		public const string Completed="Completed";
		public const string CompletedByID="CompletedByID";
		public const string CompletedDate="CompletedDate";
		public const string Taxed="Taxed";
		public const string Final="Final";
		public const string Posted="Posted";
		public const string Hours="Hours";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string SRPDate="SRPDate";
		public const string FileStatusCode="FileStatusCode";
		public const string ConversationInitiator="ConversationInitiator";
		public const string ConversationWithCode="ConversationWithCode";
		public const string PersonCalled="PersonCalled";
		public const string ContactCalledId="ContactCalledId";
		public const string SendasEmail="SendasEmail";
		public const string IsDraft="IsDraft";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ActivityAuditFields
	{
		
		public const string ActivityId="ActivityId";
		public const string FileId="FileId";
		public const string IRPId="IRPId";
		public const string OfficeId="OfficeId";
		public const string ForOfficeId="ForOfficeId";
		public const string Priority="Priority";
		public const string LinkTable="LinkTable";
		public const string LinkID="LinkID";
		public const string ActivityCodeID="ActivityCodeID";
		public const string ActivityDate="ActivityDate";
		public const string ActivityEntryDate="ActivityEntryDate";
		public const string ActivityComment="ActivityComment";
		public const string OfficerId="OfficerId";
		public const string BFOfficerID="BFOfficerID";
		public const string BFComment="BFComment";
		public const string BFDate="BFDate";
		public const string Completed="Completed";
		public const string CompletedByID="CompletedByID";
		public const string CompletedDate="CompletedDate";
		public const string Taxed="Taxed";
		public const string Final="Final";
		public const string Posted="Posted";
		public const string Hours="Hours";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string SRPDate="SRPDate";
		public const string FileStatusCode="FileStatusCode";
		public const string ConversationInitiator="ConversationInitiator";
		public const string ConversationWithCode="ConversationWithCode";
		public const string PersonCalled="PersonCalled";
		public const string ContactCalledId="ContactCalledId";
		public const string SendasEmail="SendasEmail";
		public const string IsDraft="IsDraft";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}



	public class AddressFields
	{
		
		public const string AddressId="AddressId";
		public const string ContactId="ContactId";
		public const string Address1="Address1";
		public const string Address2="Address2";
		public const string Address3="Address3";
		public const string City="City";
		public const string ProvinceCode="ProvinceCode";
		public const string PostalCode="PostalCode";
		public const string CountryCode="CountryCode";
		public const string EmailAddress="EmailAddress";
		public const string HomePhone="HomePhone";
		public const string WorkPhone="WorkPhone";
		public const string WorkExtension="WorkExtension";
		public const string MobilePhone="MobilePhone";
		public const string FaxNumber="FaxNumber";
		public const string AddressSourceCode="AddressSourceCode";
		public const string JDCode="JDCode";
		public const string AddressType="AddressType";
		public const string EffectiveTo="EffectiveTo";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class AddressSourceFields
	{
		
		public const string AddressSourceCode="AddressSourceCode";
		public const string AddressSourceDescEng="AddressSourceDescEng";
		public const string AddressSourceDescFre="AddressSourceDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class AddressTypeFields
	{
		
		public const string AddressType="AddressType";
		public const string AddressTypeDescEng="AddressTypeDescEng";
		public const string AddressTypeDescFre="AddressTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class AKAFields
	{
		
		public const string AKAID="AKAID";
		public const string ContactId="ContactId";
		public const string SIN="SIN";
		public const string FirstName="FirstName";
		public const string LastName="LastName";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class AppointmentTypeFields
	{
		
		public const string AppointmentTypeCode="AppointmentTypeCode";
		public const string AppointmentTypeDescEng="AppointmentTypeDescEng";
		public const string AppointmentTypeDescFre="AppointmentTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ArchiveBatchFields
	{
		
		public const string ArchiveId="ArchiveId";
		public const string ArchiveDate="ArchiveDate";
		public const string AccessionNumber="AccessionNumber";
		public const string Room="Room";
		public const string Bay="Bay";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class BankruptcyFields
	{
		
		public const string BankruptcyID="BankruptcyID";
		public const string FileID="FileID";
		public const string OfficeID="OfficeID";
		public const string PreviousBankruptcyDate="PreviousBankruptcyDate";
		public const string StayOfProceeding="StayOfProceeding";
		public const string BankruptcyDate="BankruptcyDate";
		public const string ProvenClaimAmount="ProvenClaimAmount";
		public const string DateofOrder="DateofOrder";
		public const string CSLEligibleForDischargeDate="CSLEligibleForDischargeDate";
		public const string JudgmentObtained="JudgmentObtained";
		public const string BankruptcyOrderType="BankruptcyOrderType";
		public const string ConditionalOrderAmount="ConditionalOrderAmount";
		public const string JudgmentinFavourofCrown="JudgmentinFavourofCrown";
		public const string JudgmentAssignedtoCrownDate="JudgmentAssignedtoCrownDate";
		public const string DateofTrusteeDischarge="DateofTrusteeDischarge";
		public const string DebtorDischargeNonCSLDebtDate="DebtorDischargeNonCSLDebtDate";
		public const string CSLNonDischargeable="CSLNonDischargeable";
		public const string ConditionalOrderFufilled="ConditionalOrderFufilled";
		public const string SigningJudgmentATerm="SigningJudgmentATerm";
		public const string MisrepEligibleforDischarge="MisrepEligibleforDischarge";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class BankruptcyOrderTypeFields
	{
		
		public const string BankruptcyOrderType="BankruptcyOrderType";
		public const string OrderTypeDescEng="OrderTypeDescEng";
		public const string OrderTypeDescFre="OrderTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class BatchFields
	{
		
		public const string BatchID="BatchID";
		public const string OfficerID="OfficerID";
		public const string OfficeCode="OfficeCode";
		public const string UserName="UserName";
		public const string Password="Password";
		public const string BatchDate="BatchDate";
		public const string Priority="Priority";
		public const string RunAfterDate="RunAfterDate";
		public const string JobName="JobName";
		public const string Parameters="Parameters";
		public const string StartRunDate="StartRunDate";
		public const string EndRunDate="EndRunDate";
		public const string Completed="Completed";
		public const string Status="Status";
		public const string Message="Message";
		public const string OutputFile="OutputFile";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class BFListFields
	{
		
		public const string OfficerID="OfficerID";
		public const string ActivityID="ActivityID";
		public const string Type="Type";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class BillingCodeFields
	{
		
		public const string BillingCode="BillingCode";
		public const string BillingDescEng="BillingDescEng";
		public const string BillingDescFre="BillingDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CashBlotterFields
	{
		
		public const string CashBlotterID="CashBlotterID";
		public const string FileId="FileId";
		public const string OfficeID="OfficeID";
		public const string RemittedDate="RemittedDate";
		public const string Status="Status";
		public const string FirstConfirm="FirstConfirm";
		public const string SecondConfirm="SecondConfirm";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CBDetailFields
	{
		
		public const string CashBlotterDetailID="CashBlotterDetailID";
		public const string CashBlotterID="CashBlotterID";
		public const string ReceivedDate="ReceivedDate";
		public const string FileID="FileID";
		public const string PaymentSource="PaymentSource";
		public const string ValuableType="ValuableType";
		public const string ValuableAmount="ValuableAmount";
		public const string ValuableDate="ValuableDate";
		public const string NatureOfPayment="NatureOfPayment";
		public const string StatusCode="StatusCode";
		public const string CurrencyCode="CurrencyCode";
		public const string OfficeID="OfficeID";
		public const string Comments="Comments";
		public const string SIN="SIN";
		public const string FirstName="FirstName";
		public const string LastName="LastName";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CBInstrumentTypeFields
	{
		
		public const string CBInstrumentType="CBInstrumentType";
		public const string CBInstrumentTypeDescEng="CBInstrumentTypeDescEng";
		public const string CBInstrumentTypeDescFre="CBInstrumentTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CBNatureOfPaymentFields
	{
		
		public const string CBNatureOfPayment="CBNatureOfPayment";
		public const string CBNatureOfPaymentDescEng="CBNatureOfPaymentDescEng";
		public const string CBNatureOfPaymentDescFre="CBNatureOfPaymentDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CBPaymentSourceFields
	{
		
		public const string CBPaymentSource="CBPaymentSource";
		public const string CBPaymentSourceDescEng="CBPaymentSourceDescEng";
		public const string CBPaymentSourceDescFre="CBPaymentSourceDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CBStatusFields
	{
		
		public const string CBStatus="CBStatus";
		public const string CBStatusDescEng="CBStatusDescEng";
		public const string CBStatusDescFre="CBStatusDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CityFields
	{
		
		public const string CityID="CityID";
		public const string ProvinceCode="ProvinceCode";
		public const string JDCode="JDCode";
		public const string City="City";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ContactFields
	{
		
		public const string ContactId="ContactId";
		public const string SIN="SIN";
		public const string LastName="LastName";
		public const string FirstName="FirstName";
		public const string AddressCurrentID="AddressCurrentID";
		public const string TelephoneNumber="TelephoneNumber";
		public const string TelephoneExtension="TelephoneExtension";
		public const string CellPhone="CellPhone";
		public const string FaxNumber="FaxNumber";
		public const string EmailAddress="EmailAddress";
		public const string SexCode="SexCode";
		public const string BirthDate="BirthDate";
		public const string LanguageCode="LanguageCode";
		public const string AddressNotCurrent="AddressNotCurrent";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ContactTypeFields
	{
		
		public const string ContactTypeCode="ContactTypeCode";
		public const string ContactTypeDescEng="ContactTypeDescEng";
		public const string ContactTypeDescFre="ContactTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ContactTypePositionCodeFields
	{
		
		public const string ContactTypePositionCodeID="ContactTypePositionCodeID";
		public const string ContactTypeCode="ContactTypeCode";
		public const string PositionCode="PositionCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ConversationWithCodeFields
	{
		
		public const string ConversationWithCode="ConversationWithCode";
		public const string ConversationWithDescEng="ConversationWithDescEng";
		public const string ConversationWithDescFre="ConversationWithDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CostFields
	{
		
		public const string CostID="CostID";
		public const string JudgmentID="JudgmentID";
		public const string FileID="FileID";
		public const string CostAmount="CostAmount";
		public const string CostDate="CostDate";
		public const string InterestRate="InterestRate";
		public const string RateType="RateType";
		public const string PostJudgmentActivityCode="PostJudgmentActivityCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CountryFields
	{
		
		public const string CountryCode="CountryCode";
		public const string CountryName="CountryName";
		public const string CSPCountryCode="CSPCountryCode";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class CurrencyCodeFields
	{
		
		public const string CurrencyCode="CurrencyCode";
		public const string CurrencyDescEng="CurrencyDescEng";
		public const string CurrencyDescFre="CurrencyDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ddFieldFields
	{
		
		public const string FieldId="FieldId";
		public const string TableId="TableId";
		public const string FieldName="FieldName";
		public const string LeftEng="LeftEng";
		public const string LeftFre="LeftFre";
		public const string DataType="DataType";
		public const string FieldType="FieldType";
		public const string Lookup="Lookup";
		public const string TopEng="TopEng";
		public const string TopFre="TopFre";
		public const string DescEng="DescEng";
		public const string DescFre="DescFre";
		public const string ToolEng="ToolEng";
		public const string ToolFre="ToolFre";
		public const string HelpEng="HelpEng";
		public const string HelpFre="HelpFre";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ddTableFields
	{
		
		public const string TableId="TableId";
		public const string TableName="TableName";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class DebtFields
	{
		
		public const string DebtId="DebtId";
		public const string PrincipalAmount="PrincipalAmount";
		public const string InterestRate="InterestRate";
		public const string InterestFromDate="InterestFromDate";
		public const string RateType="RateType";
		public const string InterestAmount="InterestAmount";
		public const string LPCode="LPCode";
		public const string LPDate="LPDate";
		public const string LPExpires="LPExpires";
		public const string CurrentTo="CurrentTo";
		public const string DARSOccurenceDate="DARSOccurenceDate";
		public const string MostRecentPCACode="MostRecentPCACode";
		public const string MSOAOverDARS="MSOAOverDARS";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class DebtorFields
	{
		
		public const string DebtorId="DebtorId";
		public const string CeasedToBeStudentDate="CeasedToBeStudentDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class DepartmentFields
	{
		
		public const string DepartmentID="DepartmentID";
		public const string DepartmentCode="DepartmentCode";
		public const string DepartmentNameEng="DepartmentNameEng";
		public const string DepartmentNameFre="DepartmentNameFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class DisbursementFields
	{
		
		public const string DisbId="DisbId";
		public const string ActivityID="ActivityID";
		public const string FileID="FileID";
		public const string IRPId="IRPId";
		public const string OfficeId="OfficeId";
		public const string DisbDate="DisbDate";
		public const string DisbTaxExempt="DisbTaxExempt";
		public const string DisbTaxable="DisbTaxable";
		public const string DisbTax="DisbTax";
		public const string Taxed="Taxed";
		public const string Final="Final";
		public const string Posted="Posted";
		public const string Comment="Comment";
		public const string DisbType="DisbType";
		public const string SRPDate="SRPDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class DisbursementAuditFields
	{
		
		public const string DisbId="DisbId";
		public const string ActivityID="ActivityID";
		public const string FileID="FileID";
		public const string IRPId="IRPId";
		public const string OfficeId="OfficeId";
		public const string DisbDate="DisbDate";
		public const string DisbTaxExempt="DisbTaxExempt";
		public const string DisbTaxable="DisbTaxable";
		public const string DisbTax="DisbTax";
		public const string Taxed="Taxed";
		public const string Final="Final";
		public const string Posted="Posted";
		public const string Comment="Comment";
		public const string DisbType="DisbType";
		public const string SRPDate="SRPDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class DisbursementTypeFields
	{
		
		public const string DisbursementType="DisbursementType";
		public const string DisbursementDescEng="DisbursementDescEng";
		public const string DisbursementDescFre="DisbursementDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class EFileFields
	{
		
		public const string FileId="FileId";
		public const string Guid="Guid";
		public const string StatusCode="StatusCode";
		public const string ArchiveId="ArchiveId";
		public const string TemporarilyRecalled="TemporarilyRecalled";
        public const string BoxAlpha="BoxAlpha";
		public const string FileStructXml="FileStructXml";
		public const string FileNumber="FileNumber";
		public const string OwnerOfficeId="OwnerOfficeId";
		public const string LeadOfficeId="LeadOfficeId";
		public const string LeadParalegalID="LeadParalegalID";
		public const string LeadLawyerID="LeadLawyerID";
		public const string OpponentID="OpponentID";
		public const string ParentFileId="ParentFileId";
		public const string OpenedDate="OpenedDate";
		public const string ClosedDate="ClosedDate";
		public const string CloseCode="CloseCode";
		public const string FileType="FileType";
		public const string DescriptionE="DescriptionE";
		public const string DescriptionF="DescriptionF";
		public const string HaveSubFolder="HaveSubFolder";
		public const string HaveFile="HaveFile";
		public const string FullPath="FullPath";
		public const string FullFileNumber="FullFileNumber";
		public const string SubFileNumSize="SubFileNumSize";
		public const string SubFileAutoNumber="SubFileAutoNumber";
		public const string SubFileNumIncrement="SubFileNumIncrement";
		public const string SubFileNumInitial="SubFileNumInitial";
		public const string RiskManage="RiskManage";
		public const string RiskManageChildren="RiskManageChildren";
		public const string NameE="NameE";
		public const string NameF="NameF";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class EFileAuditFields
	{
		
		public const string FileId="FileId";
		public const string Guid="Guid";
		public const string StatusCode="StatusCode";
		public const string ArchiveId="ArchiveId";
		public const string TemporarilyRecalled="TemporarilyRecalled";
		public const string BoxNumber="BoxNumber";
		public const string FileNumber="FileNumber";
		public const string OwnerOfficeId="OwnerOfficeId";
		public const string LeadOfficeId="LeadOfficeId";
		public const string LeadParalegalID="LeadParalegalID";
		public const string LeadLawyerID="LeadLawyerID";
		public const string OpponentID="OpponentID";
		public const string ParentFileId="ParentFileId";
		public const string OpenedDate="OpenedDate";
		public const string ClosedDate="ClosedDate";
		public const string CloseCode="CloseCode";
		public const string FileType="FileType";
		public const string DescriptionE="DescriptionE";
		public const string DescriptionF="DescriptionF";
		public const string HaveSubFolder="HaveSubFolder";
		public const string HaveFile="HaveFile";
		public const string FullPath="FullPath";
		public const string FullFileNumber="FullFileNumber";
		public const string SubFileNumSize="SubFileNumSize";
		public const string SubFileAutoNumber="SubFileAutoNumber";
		public const string SubFileNumIncrement="SubFileNumIncrement";
		public const string SubFileNumInitial="SubFileNumInitial";
		public const string RiskManage="RiskManage";
		public const string RiskManageChildren="RiskManageChildren";
		public const string NameE="NameE";
		public const string NameF="NameF";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class FileAccountFields
	{
		
		public const string FileAccountId="FileAccountId";
		public const string FileId="FileId";
		public const string AccountTypeId="AccountTypeId";
		public const string OfficeID="OfficeID";
		public const string ActiveWithJustice="ActiveWithJustice";
		public const string StatusCode="StatusCode";
		public const string ReceivedByJusticeDate="ReceivedByJusticeDate";
		public const string ClosureDate="ClosureDate";
		public const string ClosureCode="ClosureCode";
		public const string StatementRequest="StatementRequest";
		public const string MSOARequest="MSOARequest";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class FileAccountAuditFields
	{
		
		public const string FileAccountId="FileAccountId";
		public const string FileId="FileId";
		public const string AccountTypeId="AccountTypeId";
		public const string OfficeID="OfficeID";
		public const string ActiveWithJustice="ActiveWithJustice";
		public const string StatusCode="StatusCode";
		public const string ReceivedByJusticeDate="ReceivedByJusticeDate";
		public const string ClosureDate="ClosureDate";
		public const string ClosureCode="ClosureCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class FileContactFields
	{
		
		public const string FileContactid="FileContactid";
		public const string FileId="FileId";
		public const string ContactId="ContactId";
		public const string ContactType="ContactType";
		public const string StartDate="StartDate";
		public const string EndDate="EndDate";
		public const string Active="Active";
		public const string NoReassign="NoReassign";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class FileHistoryFields
	{
		
		public const string HistoryId="HistoryId";
		public const string FileId="FileId";
		public const string OfficeId="OfficeId";
		public const string SentToOfficeDate="SentToOfficeDate";
		public const string ReceivedByOfficeDate="ReceivedByOfficeDate";
		public const string ReturnedByOfficeDate="ReturnedByOfficeDate";
		public const string ReceivedFromOfficeDate="ReceivedFromOfficeDate";
		public const string StatusCode="StatusCode";
		public const string ReturnCode="ReturnCode";
		public const string BillingCode="BillingCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class FileIndexFields
	{
		
		public const string FileIndexID="FileIndexID";
		public const string SIN="SIN";
		public const string List="List";
		public const string JobNumber="JobNumber";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class FileOfficeFields
	{
		
		public const string FileOfficeId="FileOfficeId";
		public const string FileId="FileId";
		public const string OfficeId="OfficeId";
		public const string StartDate="StartDate";
		public const string EndDate="EndDate";
		public const string IsOwner="IsOwner";
		public const string IsLead="IsLead";
		public const string AccessType="AccessType";
		public const string OfficeFileNum="OfficeFileNum";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class FileTypeFields
	{
		
		public const string FileTypeCode="FileTypeCode";
		public const string FileTypeDescEng="FileTypeDescEng";
		public const string FileTypeDescFre="FileTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class HearingFields
	{
		
		public const string HearingID="HearingID";
		public const string PanelID="PanelID";
		public const string FileID="FileID";
		public const string LanguageCode="LanguageCode";
		public const string HearingDate="HearingDate";
		public const string LeadLawyerID="LeadLawyerID";
		public const string Notes="Notes";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class HearingContactFields
	{
		
		public const string HearingContactID="HearingContactID";
		public const string HearingID="HearingID";
		public const string ContactID="ContactID";
		public const string ContactTypeCode="ContactTypeCode";
		public const string StartDate="StartDate";
		public const string EndDate="EndDate";
		public const string Active="Active";
		public const string NoReassign="NoReassign";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class HearingSetFields
	{
		
		public const string HearingSetID="HearingSetID";
		public const string FileId="FileId";
		public const string CourtID="CourtID";
		public const string StartOfWeekDate="StartOfWeekDate";
		public const string CityID="CityID";
		public const string NumberOfPanels="NumberOfPanels";
		public const string Notes="Notes";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class HistoryTypeFields
	{
		
		public const string FileTypeCode="FileTypeCode";
		public const string FileTypeDescEng="FileTypeDescEng";
		public const string FileTypeDescFre="FileTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class InsolvencyFields
	{
		
		public const string InsolvencyID="InsolvencyID";
		public const string FileID="FileID";
		public const string OfficeID="OfficeID";
		public const string InsolvencyType="InsolvencyType";
		public const string PreviousInsolvencyDate="PreviousInsolvencyDate";
		public const string StayOfProceeding="StayOfProceeding";
		public const string InsolvencyFiledDate="InsolvencyFiledDate";
		public const string AcceptanceDate="AcceptanceDate";
		public const string InsolvencyFulfilledDate="InsolvencyFulfilledDate";
		public const string ProvenClaimAmount="ProvenClaimAmount";
		public const string DefaultDate="DefaultDate";
		public const string CSLEligibleForDischargeDate="CSLEligibleForDischargeDate";
		public const string DateofTrusteeDischarge="DateofTrusteeDischarge";
		public const string DebtorDischargeNonCSLDebtDate="DebtorDischargeNonCSLDebtDate";
		public const string CSLNonDischargeable="CSLNonDischargeable";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class InsolvencyTypeFields
	{
		
		public const string InsolvencyType="InsolvencyType";
		public const string InsolvencyTypeDescEng="InsolvencyTypeDescEng";
		public const string InsolvencyTypeDescFre="InsolvencyTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class InterestRateTypeFields
	{
		
		public const string InterestRateCode="InterestRateCode";
		public const string InterestRateNameEng="InterestRateNameEng";
		public const string InterestRateNameFre="InterestRateNameFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class IRPFields
	{
		
		public const string IRPId="IRPId";
		public const string OfficeID="OfficeID";
		public const string FileID="FileID";
		public const string SRPID="SRPID";
		public const string SRPDate="SRPDate";
		public const string OfficerID="OfficerID";
		public const string DateTaxed="DateTaxed";
		public const string MilestoneCode="MilestoneCode";
		public const string ProvStateTaxRate="ProvStateTaxRate";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string DisbursementTaxExemptClaimed="DisbursementTaxExemptClaimed";
		public const string DisbursementClaimed="DisbursementClaimed";
		public const string DisbursementClaimedTax="DisbursementClaimedTax";
		public const string FeesTaxed="FeesTaxed";
		public const string FeesTaxedTax="FeesTaxedTax";
		public const string DisbursementTaxExemptTaxed="DisbursementTaxExemptTaxed";
		public const string DisbursementTaxed="DisbursementTaxed";
		public const string DisbursementTaxedTax="DisbursementTaxedTax";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class IRPAuditFields
	{
		
		public const string IRPId="IRPId";
		public const string OfficeID="OfficeID";
		public const string FileID="FileID";
		public const string SRPID="SRPID";
		public const string SRPDate="SRPDate";
		public const string OfficerID="OfficerID";
		public const string DateTaxed="DateTaxed";
		public const string MilestoneCode="MilestoneCode";
		public const string ProvStateTaxRate="ProvStateTaxRate";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string DisbursementTaxExemptClaimed="DisbursementTaxExemptClaimed";
		public const string DisbursementClaimed="DisbursementClaimed";
		public const string DisbursementClaimedTax="DisbursementClaimedTax";
		public const string FeesTaxed="FeesTaxed";
		public const string FeesTaxedTax="FeesTaxedTax";
		public const string DisbursementTaxExemptTaxed="DisbursementTaxExemptTaxed";
		public const string DisbursementTaxed="DisbursementTaxed";
		public const string DisbursementTaxedTax="DisbursementTaxedTax";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class JudgmentFields
	{
		
		public const string JudgmentID="JudgmentID";
		public const string FileID="FileID";
		public const string OfficeID="OfficeID";
		public const string ActionNumber="ActionNumber";
		public const string DefenceDate="DefenceDate";
		public const string StatementofClaimServedDate="StatementofClaimServedDate";
		public const string StatementofClaimIssuedDate="StatementofClaimIssuedDate";
		public const string JudgmentCourtLevelCode="JudgmentCourtLevelCode";
		public const string JudgmentDate="JudgmentDate";
		public const string JudgmentTypeCode="JudgmentTypeCode";
		public const string ClaimAgainstCrown="ClaimAgainstCrown";
		public const string JudgmentLPDate="JudgmentLPDate";
		public const string ProcessTypeCode="ProcessTypeCode";
		public const string CombineAccountsAfterJudgment="CombineAccountsAfterJudgment";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class JudgmentAccountFields
	{
		
		public const string JudgmentAccountID="JudgmentAccountID";
		public const string FileAccountID="FileAccountID";
		public const string JudgmentID="JudgmentID";
		public const string PostJudgmentInterestRate="PostJudgmentInterestRate";
		public const string PostJudgmentRateType="PostJudgmentRateType";
		public const string PostJIntRateOnCost="PostJIntRateOnCost";
		public const string PostJRateTypeOnCost="PostJRateTypeOnCost";
		public const string AccruedFromDate="AccruedFromDate";
		public const string PrincipalAmountBeforeJudgment="PrincipalAmountBeforeJudgment";
		public const string PreJudgmentInterestFrom="PreJudgmentInterestFrom";
		public const string PreJudgmentInterestTo="PreJudgmentInterestTo";
		public const string PreJudgmentInterestRate="PreJudgmentInterestRate";
		public const string PreJudgmentRateType="PreJudgmentRateType";
		public const string PreJudgmentInterestAmount="PreJudgmentInterestAmount";
		public const string JudgmentAmount="JudgmentAmount";
		public const string CostIncluded="CostIncluded";
		public const string InterestIncluded="InterestIncluded";
		public const string CostAmount="CostAmount";
		public const string CostDate="CostDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class JudgmentCourtLevelFields
	{
		
		public const string JudgmentCourtLevelCode="JudgmentCourtLevelCode";
		public const string JudgmentCourtLevelDescEng="JudgmentCourtLevelDescEng";
		public const string JudgmentCourtLevelDescFre="JudgmentCourtLevelDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class JudgmentTypeFields
	{
		
		public const string JudgmentTypeCode="JudgmentTypeCode";
		public const string JudgmentTypeDescEng="JudgmentTypeDescEng";
		public const string JudgmentTypeDescFre="JudgmentTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class JudicialDistrictFields
	{
		
		public const string JDCode="JDCode";
		public const string JDDescEng="JDDescEng";
		public const string JDDescFre="JDDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string ProvinceCode="ProvinceCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class LanguageCodeFields
	{
		
		public const string LanguageCode="LanguageCode";
		public const string LanguageDescEng="LanguageDescEng";
		public const string LanguageDescFre="LanguageDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class LegalProcessFields
	{
		
		public const string LegalProcessID="LegalProcessID";
		public const string FileID="FileID";
		public const string CourtID="CourtID";
		public const string ApplicantIsAppelant="ApplicantIsAppelant";
		public const string FiledDate="FiledDate";
		public const string HearingDate="HearingDate";
		public const string LeadLawyerID="LeadLawyerID";
		public const string DecisionDate="DecisionDate";
		public const string DecisionForCrown="DecisionForCrown";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class LPFields
	{
		
		public const string LPCode="LPCode";
		public const string LPDescEng="LPDescEng";
		public const string LPDescFre="LPDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class MailFields
	{
		
		public const string MailID="MailID";
		public const string ActivityID="ActivityID";
		public const string FileID="FileID";
		public const string MailFolderID="MailFolderID";
		public const string MailDate="MailDate";
		public const string MailPriority="MailPriority";
		public const string FromOfficeID="FromOfficeID";
		public const string FromOfficerID="FromOfficerID";
		public const string ToOfficeID="ToOfficeID";
		public const string ToOfficerID="ToOfficerID";
		public const string BFDate="BFDate";
		public const string Subject="Subject";
		public const string Message="Message";
		public const string NewMail="NewMail";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class MailAuditFields
	{
		
		public const string MailID="MailID";
		public const string ActivityID="ActivityID";
		public const string FileID="FileID";
		public const string MailFolderID="MailFolderID";
		public const string MailDate="MailDate";
		public const string MailPriority="MailPriority";
		public const string FromOfficeID="FromOfficeID";
		public const string FromOfficerID="FromOfficerID";
		public const string ToOfficeID="ToOfficeID";
		public const string ToOfficerID="ToOfficerID";
		public const string BFDate="BFDate";
		public const string Subject="Subject";
		public const string NewMail="NewMail";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class MailFolderFields
	{
		
		public const string MailFolderID="MailFolderID";
		public const string OfficeID="OfficeID";
		public const string OfficerID="OfficerID";
		public const string NewMail="NewMail";
		public const string AnyMail="AnyMail";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class MilestoneCodeFields
	{
		
		public const string MilestoneCode="MilestoneCode";
		public const string MilestoneNameEng="MilestoneNameEng";
		public const string MilestoneNameFre="MilestoneNameFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class MotionFields
	{
		
		public const string MotionID="MotionID";
		public const string HearingID="HearingID";
		public const string ActivityID="ActivityID";
		public const string FiledDate="FiledDate";
		public const string HearingDate="HearingDate";
		public const string DecisionForCrown="DecisionForCrown";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class NatureofPropertyFields
	{
		
		public const string NatureofPropertyCode="NatureofPropertyCode";
		public const string PropertyDescEng="PropertyDescEng";
		public const string PropertyDescFre="PropertyDescFre";
		public const string RealProperty="RealProperty";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficeFields
	{
		
		public const string OfficeId="OfficeId";
		public const string ParentOfficeId="ParentOfficeId";
		public const string AddressId="AddressId";
		public const string OfficeCode="OfficeCode";
		public const string DARSOfficeCode="DARSOfficeCode";
		public const string OfficeName="OfficeName";
		public const string OfficeNameFre="OfficeNameFre";
		public const string Retainer="Retainer";
		public const string LetterSignatory="LetterSignatory";
		public const string AttentionAdministrator="AttentionAdministrator";
		public const string AttentionBilling="AttentionBilling";
		public const string OfficeTypeCode="OfficeTypeCode";
		public const string ReappointedDate="ReappointedDate";
		public const string AppointmentTypeCode="AppointmentTypeCode";
		public const string HourlyRate="HourlyRate";
		public const string CurrencyCode="CurrencyCode";
		public const string Active="Active";
		public const string Even="Even";
		public const string DefaultGroup="DefaultGroup";
		public const string IsOnLine="IsOnLine";
		public const string UsesBilling="UsesBilling";
		public const string LastMail="LastMail";
		public const string IsMail="IsMail";
		public const string DepartmentID="DepartmentID";
		public const string IsLrmOffice="IsLrmOffice";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class Office2JDFields
	{
		
		public const string OfficeId="OfficeId";
		public const string JDCode="JDCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficeAccountFields
	{
		
		public const string OfficeAccountID="OfficeAccountID";
		public const string FileId="FileId";
		public const string OfficeID="OfficeID";
		public const string SRPID="SRPID";
		public const string Type="Type";
		public const string TransactionDate="TransactionDate";
		public const string PostingDate="PostingDate";
		public const string Amount="Amount";
		public const string Reason="Reason";
		public const string Description="Description";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficeAccountAuditFields
	{
		
		public const string OfficeAccountID="OfficeAccountID";
		public const string FileId="FileId";
		public const string OfficeID="OfficeID";
		public const string SRPID="SRPID";
		public const string Type="Type";
		public const string TransactionDate="TransactionDate";
		public const string PostingDate="PostingDate";
		public const string Amount="Amount";
		public const string Reason="Reason";
		public const string Description="Description";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class OfficeAccountTypeFields
	{
		
		public const string OfficeAccountTypeCode="OfficeAccountTypeCode";
		public const string OfficeAccountTypeDescEng="OfficeAccountTypeDescEng";
		public const string OfficeAccountTypeDescFre="OfficeAccountTypeDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficerFields
	{
		
		public const string OfficerId="OfficerId";
		public const string OfficeId="OfficeId";
		public const string OfficerCode="OfficerCode";
		public const string UserName="UserName";
		public const string CurrentEmployee="CurrentEmployee";
		public const string PositionCode="PositionCode";
		public const string PositionTitle="PositionTitle";
		public const string BFListOfficerID="BFListOfficerID";
		public const string ReverseBFOfficerID="ReverseBFOfficerID";
		public const string LastMail="LastMail";
		public const string IsMail="IsMail";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficerRoleFields
	{
		
		public const string OfficerRoleID="OfficerRoleID";
		public const string OfficerID="OfficerID";
		public const string RoleCode="RoleCode";
		public const string Mod="Mod";
		public const string ModResult="ModResult";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class OfficeTypeFields
	{
		
		public const string OfficeTypeCode="OfficeTypeCode";
		public const string OfficeTypeDescEng="OfficeTypeDescEng";
		public const string OfficeTypeDescFre="OfficeTypeDescFre";
		public const string OfficerBF="OfficerBF";
		public const string OfficerMail="OfficerMail";
		public const string Billing="Billing";
		public const string Batch="Batch";
		public const string AllDebtors="AllDebtors";
		public const string AllAgents="AllAgents";
		public const string BFList="BFList";
		public const string Mail="Mail";
		public const string CA="CA";
		public const string CB="CB";
		public const string Documents="Documents";
		public const string EntryUser="EntryUser";
		public const string EntryDate="EntryDate";
		public const string UpdateUser="UpdateUser";
		public const string UpdateDate="UpdateDate";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string ts="ts";
	}

	public class PanelFields
	{
		
		public const string PanelID="PanelID";
		public const string HearingSetID="HearingSetID";
		public const string ParentPanelID="ParentPanelID";
		public const string PanelNumber="PanelNumber";
		public const string DaysOfWeek="DaysOfWeek";
		public const string OfficeID="OfficeID";
		public const string RoomDesc="RoomDesc";
		public const string HearingsPerDay="HearingsPerDay";
		public const string LanguageCode="LanguageCode";
		public const string LeadLawyerID="LeadLawyerID";
		public const string PrepRoomRequired="PrepRoomRequired";
		public const string Notes="Notes";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class PanelContactFields
	{
		
		public const string PanelContactID="PanelContactID";
		public const string PanelID="PanelID";
		public const string ContactID="ContactID";
		public const string ContactTypeCode="ContactTypeCode";
		public const string StartDate="StartDate";
		public const string EndDate="EndDate";
		public const string Active="Active";
		public const string NoReassign="NoReassign";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class PKIDFields
	{
		
		public const string ObjectName="ObjectName";
		public const string PKID="PKID";
		public const string EntryUser="EntryUser";
		public const string EntryDate="EntryDate";
		public const string UpdateUser="UpdateUser";
		public const string UpdateDate="UpdateDate";
		public const string ts="ts";
	}

	public class PLOfficeFields
	{
		
		public const string PLOfficeID="PLOfficeID";
		public const string OfficerID="OfficerID";
		public const string OfficeID="OfficeID";
		public const string OwnerOfficeID="OwnerOfficeID";
		public const string FileTypeCode="FileTypeCode";
		public const string OfficeTypeCode="OfficeTypeCode";
		public const string FileStatus="FileStatus";
		public const string StartLetter="StartLetter";
		public const string EndLetter="EndLetter";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class PositionCodeFields
	{
		
		public const string PositionCode="PositionCode";
		public const string PositionNameEng="PositionNameEng";
		public const string PositionNameFre="PositionNameFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class PostJudgmentActivityFields
	{
		
		public const string PostJudgmentActivityCode="PostJudgmentActivityCode";
		public const string PostJudgmentActivityDescEng="PostJudgmentActivityDescEng";
		public const string PostJudgmentActivityDescFre="PostJudgmentActivityDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ProcessTypeFields
	{
		
		public const string ProcessTypeCode="ProcessTypeCode";
		public const string ProcessTypeDescriptionEng="ProcessTypeDescriptionEng";
		public const string ProcessTypeDescriptionFre="ProcessTypeDescriptionFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ProgramFields
	{
		
		public const string ProgramID="ProgramID";
		public const string ProgramCode="ProgramCode";
		public const string ProgramDescriptionEng="ProgramDescriptionEng";
		public const string ProgramDescriptionFre="ProgramDescriptionFre";
		public const string ResponsibleDeptID="ResponsibleDeptID";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class PropertyFields
	{
		
		public const string PropertyID="PropertyID";
		public const string WritID="WritID";
		public const string FileID="FileID";
		public const string NatureofPropertyCode="NatureofPropertyCode";
		public const string RealProperty="RealProperty";
		public const string EstimatedValueofProperty="EstimatedValueofProperty";
		public const string AmountofMortgage="AmountofMortgage";
		public const string LegalDescription="LegalDescription";
		public const string AddressID="AddressID";
		public const string ExecutedAgainstDate="ExecutedAgainstDate";
		public const string PPSARegistrationNumber="PPSARegistrationNumber";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ProvinceFields
	{
		
		public const string ProvinceCode="ProvinceCode";
		public const string ProvinceDescriptionEng="ProvinceDescriptionEng";
		public const string ProvinceDescriptionFre="ProvinceDescriptionFre";
		public const string CountryCode="CountryCode";
		public const string TaxName="TaxName";
		public const string TaxRate="TaxRate";
		public const string TypeOfWritCode="TypeOfWritCode";
		public const string NameofSmallClaimsCourt="NameofSmallClaimsCourt";
		public const string NameofSuperiorCourt="NameofSuperiorCourt";
		public const string CosttoIssueSofC="CosttoIssueSofC";
		public const string SimpleContractDebtLP="SimpleContractDebtLP";
		public const string JudgmentLP="JudgmentLP";
		public const string WritofExecutionLP="WritofExecutionLP";
		public const string PostJdgmntInterestRateType="PostJdgmntInterestRateType";
		public const string RateonCostsDiffers="RateonCostsDiffers";
		public const string InterestRateonCost="InterestRateonCost";
		public const string PostJdgmntInterestRate="PostJdgmntInterestRate";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RAClientImpactFields
	{
		
		public const string RAClientImpactId="RAClientImpactId";
		public const string RiskAssessId="RiskAssessId";
		public const string ClientImpactType="ClientImpactType";
		public const string Checked="Checked";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RAClientImpactTypeFields
	{
		
		public const string RAClientImpactTypeId="RAClientImpactTypeId";
		public const string RAClientImpactEng="RAClientImpactEng";
		public const string RAClientImpactFre="RAClientImpactFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RAComplexityFields
	{
		
		public const string RAComplexityId="RAComplexityId";
		public const string ComplexityEng="ComplexityEng";
		public const string ComplexityFre="ComplexityFre";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RAImpactFields
	{
		
		public const string RAImpactId="RAImpactId";
		public const string RAImpactEng="RAImpactEng";
		public const string RAImpactFre="RAImpactFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RALikelihoodFields
	{
		
		public const string RALikelihoodId="RALikelihoodId";
		public const string RALikelihoodEng="RALikelihoodEng";
		public const string RALikelihoodFre="RALikelihoodFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RARiskLevelFields
	{
		
		public const string RARiskLevelId="RARiskLevelId";
		public const string RARiskLevelEng="RARiskLevelEng";
		public const string RARiskLevelFre="RARiskLevelFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RASettlementPossibilityFields
	{
		
		public const string RASettlementPossibilityId="RASettlementPossibilityId";
		public const string RASettlementPossibilityEng="RASettlementPossibilityEng";
		public const string RASettlementPossibilityFre="RASettlementPossibilityFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RAStatusFields
	{
		
		public const string RAStatus="RAStatus";
		public const string RAStatusEng="RAStatusEng";
		public const string RAStatusFre="RAStatusFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ReasonCodeFields
	{
		
		public const string ReasonCode="ReasonCode";
		public const string ReasonDescEng="ReasonDescEng";
		public const string ReasonDescFre="ReasonDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class ReturnCodeFields
	{
		
		public const string ReturnCode="ReturnCode";
		public const string ReturnDescEng="ReturnDescEng";
		public const string ReturnDescFre="ReturnDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RiskAssessmentFields
	{
		
		public const string RiskAssessId="RiskAssessId";
		public const string FileId="FileId";
		public const string AssessmentDate="AssessmentDate";
		public const string AssessedById="AssessedById";
		public const string ContingentLiability="ContingentLiability";
		public const string Complexity="Complexity";
		public const string Status="Status";
		public const string PossibilityOfSettlement="PossibilityOfSettlement";
		public const string SettlementEst="SettlementEst";
		public const string AmountClaimed="AmountClaimed";
		public const string Likelihood="Likelihood";
		public const string Impact="Impact";
		public const string RiskLevel="RiskLevel";
		public const string BackgroundDetail="BackgroundDetail";
		public const string AssessmentDetail="AssessmentDetail";
		public const string PreDecImpactPlan="PreDecImpactPlan";
		public const string PostFavorableDec="PostFavorableDec";
		public const string PostAdverseDec="PostAdverseDec";
		public const string CourtName="CourtName";
		public const string HearingDate="HearingDate";
		public const string DecisionDate="DecisionDate";
		public const string StatusComment="StatusComment";
		public const string AmountClaimedND="AmountClaimedND";
		public const string AmountClaimedComment="AmountClaimedComment";
		public const string ContigentLiabilityND="ContigentLiabilityND";
		public const string ContigentLiabilityComment="ContigentLiabilityComment";
		public const string ReferredToCommittee="ReferredToCommittee";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class RoleCodeFields
	{
		
		public const string RoleCode="RoleCode";
		public const string RoleEng="RoleEng";
		public const string RoleFre="RoleFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class secFeatureFields
	{
		
		public const string FeatureGuid="FeatureGuid";
		public const string FeatureName="FeatureName";
		public const string DescE="DescE";
		public const string DescF="DescF";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
		public const string featureid="featureid";
	}

	public class secGroupFields
	{
		
		public const string GroupId="GroupId";
		public const string GroupName="GroupName";
		public const string DescE="DescE";
		public const string DescF="DescF";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class secMembershipFields
	{
		
		public const string MembershipId="MembershipId";
		public const string UserId="UserId";
		public const string GroupId="GroupId";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class secPermissionFields
	{
		
		public const string PermId="PermId";
		public const string FeatureGuid="FeatureGuid";
		public const string PermLevel="PermLevel";
		public const string GroupId="GroupId";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class secUserFields
	{
		
		public const string UserId="UserId";
		public const string UserName="UserName";
		public const string Password="Password";
		public const string Active="Active";
		public const string LockedOut="LockedOut";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class SexFields
	{
		
		public const string SexCode="SexCode";
		public const string SexDescEng="SexDescEng";
		public const string SexDescFre="SexDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class SRPFields
	{
		
		public const string SRPID="SRPID";
		public const string FileId="FileId";
		public const string OfficeID="OfficeID";
		public const string SRPDate="SRPDate";
		public const string SRPSubmittedDate="SRPSubmittedDate";
		public const string SRPReceivedDate="SRPReceivedDate";
		public const string TaxationBegan="TaxationBegan";
		public const string TaxationCompleted="TaxationCompleted";
		public const string CountOfTaxation="CountOfTaxation";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string DisbursementTaxExemptClaimed="DisbursementTaxExemptClaimed";
		public const string DisbursementClaimed="DisbursementClaimed";
		public const string DisbursementClaimedTax="DisbursementClaimedTax";
		public const string FeesTaxed="FeesTaxed";
		public const string FeesTaxedTax="FeesTaxedTax";
		public const string DisbursementTaxExemptTaxed="DisbursementTaxExemptTaxed";
		public const string DisbursementTaxed="DisbursementTaxed";
		public const string DisbursementTaxedTax="DisbursementTaxedTax";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class SRPAuditFields
	{
		
		public const string SRPID="SRPID";
		public const string FileId="FileId";
		public const string OfficeID="OfficeID";
		public const string SRPDate="SRPDate";
		public const string SRPSubmittedDate="SRPSubmittedDate";
		public const string SRPReceivedDate="SRPReceivedDate";
		public const string TaxationBegan="TaxationBegan";
		public const string TaxationCompleted="TaxationCompleted";
		public const string CountOfTaxation="CountOfTaxation";
		public const string FeesClaimed="FeesClaimed";
		public const string FeesClaimedTax="FeesClaimedTax";
		public const string DisbursementTaxExemptClaimed="DisbursementTaxExemptClaimed";
		public const string DisbursementClaimed="DisbursementClaimed";
		public const string DisbursementClaimedTax="DisbursementClaimedTax";
		public const string FeesTaxed="FeesTaxed";
		public const string FeesTaxedTax="FeesTaxedTax";
		public const string DisbursementTaxExemptTaxed="DisbursementTaxExemptTaxed";
		public const string DisbursementTaxed="DisbursementTaxed";
		public const string DisbursementTaxedTax="DisbursementTaxedTax";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string AuditType="AuditType";
		public const string AuditUserId="AuditUserId";
		public const string AuditEventTime="AuditEventTime";
		public const string AuditEventId="AuditEventId";
		public const string AuditLogId="AuditLogId";
	}

	public class StatusFields
	{
		
		public const string StatusCode="StatusCode";
		public const string StatusDescEng="StatusDescEng";
		public const string StatusDescFre="StatusDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class TaxingFields
	{
		
		public const string TaxingID="TaxingID";
		public const string TaxingDate="TaxingDate";
		public const string ActivityId="ActivityId";
		public const string OfficeID="OfficeID";
		public const string FileID="FileID";
		public const string OfficerID="OfficerID";
		public const string IRPId="IRPId";
		public const string ReasonCode="ReasonCode";
		public const string PrevInstructed="PrevInstructed";
		public const string TaxDownHours="TaxDownHours";
		public const string TaxDownDisb="TaxDownDisb";
		public const string Comment="Comment";
		public const string Closed="Closed";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class TemplateFields
	{
		
		public const string LetterName="LetterName";
		public const string LetterDescEng="LetterDescEng";
		public const string LetterDescFre="LetterDescFre";
		public const string Filename="Filename";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string HQ="HQ";
		public const string Agent="Agent";
		public const string AboutDebtor="AboutDebtor";
		public const string AboutAgent="AboutAgent";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class TypeofWritFields
	{
		
		public const string TypeofWritCode="TypeofWritCode";
		public const string TypeofWritDescEng="TypeofWritDescEng";
		public const string TypeofWritDescFre="TypeofWritDescFre";
		public const string ReadOnly="ReadOnly";
		public const string Obsolete="Obsolete";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class UnmatchedCorrespondenceFields
	{
		
		public const string UnmatchedCorrespondenceID="UnmatchedCorrespondenceID";
		public const string FileID="FileID";
		public const string ReceivedDate="ReceivedDate";
		public const string FiledDate="FiledDate";
		public const string Description="Description";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class WritFields
	{
		
		public const string WritID="WritID";
		public const string OfficeID="OfficeID";
		public const string JudgmentID="JudgmentID";
		public const string FileID="FileID";
		public const string IssueRenewalDate="IssueRenewalDate";
		public const string ExecutionorRegistrationNumber="ExecutionorRegistrationNumber";
		public const string SheriffJurisdiction="SheriffJurisdiction";
		public const string ExpiryDate="ExpiryDate";
		public const string TypeofWritCode="TypeofWritCode";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}

	public class WritHistoryFields
	{
		
		public const string WritHistoryID="WritHistoryID";
		public const string WritID="WritID";
		public const string OfficeID="OfficeID";
		public const string FileID="FileID";
		public const string IssueRenewalDate="IssueRenewalDate";
		public const string ExpiryDate="ExpiryDate";
		public const string entryUser="entryUser";
		public const string entryDate="entryDate";
		public const string updateUser="updateUser";
		public const string updateDate="updateDate";
		public const string ts="ts";
	}


}