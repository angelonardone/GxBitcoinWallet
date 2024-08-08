/*
				   File: type_SdtSDTAddressHistory
			Description: SDTAddressHistory
				 Author: Nemo 🐠 for C# (.NET) version 18.0.8.180599
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.wallet
{
	[XmlRoot(ElementName="SDTAddressHistory")]
	[XmlType(TypeName="SDTAddressHistory" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtSDTAddressHistory : GxUserType
	{
		public SdtSDTAddressHistory( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTAddressHistory_Receiveddatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTAddressHistory_Receivedaddress = "";

			gxTv_SdtSDTAddressHistory_Receivedtransactionid = "";

			gxTv_SdtSDTAddressHistory_Receivedprivatekey = "";

			gxTv_SdtSDTAddressHistory_Receivedtransactionhex = "";

			gxTv_SdtSDTAddressHistory_Sentdatetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTAddressHistory_Senttransactionid = "";

			gxTv_SdtSDTAddressHistory_Description = "";

		}

		public SdtSDTAddressHistory(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			datetime_STZ = gxTpr_Receiveddatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ReceivedDateTime", sDateCnv, false);



			AddObjectProperty("ReceivedAddress", gxTpr_Receivedaddress, false);


			AddObjectProperty("AddressGeneratedType", gxTpr_Addressgeneratedtype, false);


			AddObjectProperty("AddressCreationSequence", gxTpr_Addresscreationsequence, false);


			AddObjectProperty("ReceivedAmount", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Receivedamount, 16, 8)), false);


			AddObjectProperty("ReceivedTransactionId", gxTpr_Receivedtransactionid, false);


			AddObjectProperty("RecivedN", gxTpr_Recivedn, false);


			AddObjectProperty("ReceivedPrivateKey", gxTpr_Receivedprivatekey, false);


			AddObjectProperty("ReceivedTransactionHex", gxTpr_Receivedtransactionhex, false);


			datetime_STZ = gxTpr_Sentdatetime;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("SentDateTime", sDateCnv, false);



			AddObjectProperty("SentTransactionId", gxTpr_Senttransactionid, false);


			AddObjectProperty("Balance", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Balance, 16, 8)), false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Confirmations", gxTpr_Confirmations, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceivedDateTime")]
		[XmlElement(ElementName="ReceivedDateTime" , IsNullable=true)]
		public string gxTpr_Receiveddatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDTAddressHistory_Receiveddatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTAddressHistory_Receiveddatetime).value ;
			}
			set {
				gxTv_SdtSDTAddressHistory_Receiveddatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Receiveddatetime
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receiveddatetime; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receiveddatetime = value;
				SetDirty("Receiveddatetime");
			}
		}



		[SoapElement(ElementName="ReceivedAddress")]
		[XmlElement(ElementName="ReceivedAddress")]
		public string gxTpr_Receivedaddress
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receivedaddress; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedaddress = value;
				SetDirty("Receivedaddress");
			}
		}




		[SoapElement(ElementName="AddressGeneratedType")]
		[XmlElement(ElementName="AddressGeneratedType")]
		public short gxTpr_Addressgeneratedtype
		{
			get {
				return gxTv_SdtSDTAddressHistory_Addressgeneratedtype; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Addressgeneratedtype = value;
				SetDirty("Addressgeneratedtype");
			}
		}




		[SoapElement(ElementName="AddressCreationSequence")]
		[XmlElement(ElementName="AddressCreationSequence")]
		public long gxTpr_Addresscreationsequence
		{
			get {
				return gxTv_SdtSDTAddressHistory_Addresscreationsequence; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Addresscreationsequence = value;
				SetDirty("Addresscreationsequence");
			}
		}



		[SoapElement(ElementName="ReceivedAmount")]
		[XmlElement(ElementName="ReceivedAmount")]
		public string gxTpr_Receivedamount_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTAddressHistory_Receivedamount, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedamount = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Receivedamount
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receivedamount; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedamount = value;
				SetDirty("Receivedamount");
			}
		}




		[SoapElement(ElementName="ReceivedTransactionId")]
		[XmlElement(ElementName="ReceivedTransactionId")]
		public string gxTpr_Receivedtransactionid
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receivedtransactionid; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedtransactionid = value;
				SetDirty("Receivedtransactionid");
			}
		}




		[SoapElement(ElementName="RecivedN")]
		[XmlElement(ElementName="RecivedN")]
		public long gxTpr_Recivedn
		{
			get {
				return gxTv_SdtSDTAddressHistory_Recivedn; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Recivedn = value;
				SetDirty("Recivedn");
			}
		}




		[SoapElement(ElementName="ReceivedPrivateKey")]
		[XmlElement(ElementName="ReceivedPrivateKey")]
		public string gxTpr_Receivedprivatekey
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receivedprivatekey; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedprivatekey = value;
				SetDirty("Receivedprivatekey");
			}
		}




		[SoapElement(ElementName="ReceivedTransactionHex")]
		[XmlElement(ElementName="ReceivedTransactionHex")]
		public string gxTpr_Receivedtransactionhex
		{
			get {
				return gxTv_SdtSDTAddressHistory_Receivedtransactionhex; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Receivedtransactionhex = value;
				SetDirty("Receivedtransactionhex");
			}
		}



		[SoapElement(ElementName="SentDateTime")]
		[XmlElement(ElementName="SentDateTime" , IsNullable=true)]
		public string gxTpr_Sentdatetime_Nullable
		{
			get {
				if ( gxTv_SdtSDTAddressHistory_Sentdatetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTAddressHistory_Sentdatetime).value ;
			}
			set {
				gxTv_SdtSDTAddressHistory_Sentdatetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Sentdatetime
		{
			get {
				return gxTv_SdtSDTAddressHistory_Sentdatetime; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Sentdatetime = value;
				SetDirty("Sentdatetime");
			}
		}



		[SoapElement(ElementName="SentTransactionId")]
		[XmlElement(ElementName="SentTransactionId")]
		public string gxTpr_Senttransactionid
		{
			get {
				return gxTv_SdtSDTAddressHistory_Senttransactionid; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Senttransactionid = value;
				SetDirty("Senttransactionid");
			}
		}



		[SoapElement(ElementName="Balance")]
		[XmlElement(ElementName="Balance")]
		public string gxTpr_Balance_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTAddressHistory_Balance, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTAddressHistory_Balance = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Balance
		{
			get {
				return gxTv_SdtSDTAddressHistory_Balance; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Balance = value;
				SetDirty("Balance");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtSDTAddressHistory_Description; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Confirmations")]
		[XmlElement(ElementName="Confirmations")]
		public long gxTpr_Confirmations
		{
			get {
				return gxTv_SdtSDTAddressHistory_Confirmations; 
			}
			set {
				gxTv_SdtSDTAddressHistory_Confirmations = value;
				SetDirty("Confirmations");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTAddressHistory_Receiveddatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTAddressHistory_Receivedaddress = "";



			gxTv_SdtSDTAddressHistory_Receivedtransactionid = "";

			gxTv_SdtSDTAddressHistory_Receivedprivatekey = "";
			gxTv_SdtSDTAddressHistory_Receivedtransactionhex = "";
			gxTv_SdtSDTAddressHistory_Sentdatetime = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTAddressHistory_Senttransactionid = "";

			gxTv_SdtSDTAddressHistory_Description = "";

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected DateTime gxTv_SdtSDTAddressHistory_Receiveddatetime;
		 

		protected string gxTv_SdtSDTAddressHistory_Receivedaddress;
		 

		protected short gxTv_SdtSDTAddressHistory_Addressgeneratedtype;
		 

		protected long gxTv_SdtSDTAddressHistory_Addresscreationsequence;
		 

		protected decimal gxTv_SdtSDTAddressHistory_Receivedamount;
		 

		protected string gxTv_SdtSDTAddressHistory_Receivedtransactionid;
		 

		protected long gxTv_SdtSDTAddressHistory_Recivedn;
		 

		protected string gxTv_SdtSDTAddressHistory_Receivedprivatekey;
		 

		protected string gxTv_SdtSDTAddressHistory_Receivedtransactionhex;
		 

		protected DateTime gxTv_SdtSDTAddressHistory_Sentdatetime;
		 

		protected string gxTv_SdtSDTAddressHistory_Senttransactionid;
		 

		protected decimal gxTv_SdtSDTAddressHistory_Balance;
		 

		protected string gxTv_SdtSDTAddressHistory_Description;
		 

		protected long gxTv_SdtSDTAddressHistory_Confirmations;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTAddressHistory", Namespace="GxBitcoinWallet")]
	public class SdtSDTAddressHistory_RESTInterface : GxGenericCollectionItem<SdtSDTAddressHistory>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTAddressHistory_RESTInterface( ) : base()
		{	
		}

		public SdtSDTAddressHistory_RESTInterface( SdtSDTAddressHistory psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceivedDateTime", Order=0)]
		public  string gxTpr_Receiveddatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Receiveddatetime,context);

			}
			set { 
				sdt.gxTpr_Receiveddatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ReceivedAddress", Order=1)]
		public  string gxTpr_Receivedaddress
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receivedaddress);

			}
			set { 
				 sdt.gxTpr_Receivedaddress = value;
			}
		}

		[DataMember(Name="AddressGeneratedType", Order=2)]
		public short gxTpr_Addressgeneratedtype
		{
			get { 
				return sdt.gxTpr_Addressgeneratedtype;

			}
			set { 
				sdt.gxTpr_Addressgeneratedtype = value;
			}
		}

		[DataMember(Name="AddressCreationSequence", Order=3)]
		public  string gxTpr_Addresscreationsequence
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Addresscreationsequence, 10, 0));

			}
			set { 
				sdt.gxTpr_Addresscreationsequence = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ReceivedAmount", Order=4)]
		public  string gxTpr_Receivedamount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Receivedamount, 16, 8));

			}
			set { 
				sdt.gxTpr_Receivedamount =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ReceivedTransactionId", Order=5)]
		public  string gxTpr_Receivedtransactionid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receivedtransactionid);

			}
			set { 
				 sdt.gxTpr_Receivedtransactionid = value;
			}
		}

		[DataMember(Name="RecivedN", Order=6)]
		public  string gxTpr_Recivedn
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Recivedn, 10, 0));

			}
			set { 
				sdt.gxTpr_Recivedn = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ReceivedPrivateKey", Order=7)]
		public  string gxTpr_Receivedprivatekey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receivedprivatekey);

			}
			set { 
				 sdt.gxTpr_Receivedprivatekey = value;
			}
		}

		[DataMember(Name="ReceivedTransactionHex", Order=8)]
		public  string gxTpr_Receivedtransactionhex
		{
			get { 
				return sdt.gxTpr_Receivedtransactionhex;

			}
			set { 
				 sdt.gxTpr_Receivedtransactionhex = value;
			}
		}

		[DataMember(Name="SentDateTime", Order=9)]
		public  string gxTpr_Sentdatetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Sentdatetime,context);

			}
			set { 
				sdt.gxTpr_Sentdatetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="SentTransactionId", Order=10)]
		public  string gxTpr_Senttransactionid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Senttransactionid);

			}
			set { 
				 sdt.gxTpr_Senttransactionid = value;
			}
		}

		[DataMember(Name="Balance", Order=11)]
		public  string gxTpr_Balance
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Balance, 16, 8));

			}
			set { 
				sdt.gxTpr_Balance =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Description", Order=12)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Confirmations", Order=13)]
		public  string gxTpr_Confirmations
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Confirmations, 10, 0));

			}
			set { 
				sdt.gxTpr_Confirmations = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTAddressHistory sdt
		{
			get { 
				return (SdtSDTAddressHistory)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTAddressHistory() ;
			}
		}
	}
	#endregion
}