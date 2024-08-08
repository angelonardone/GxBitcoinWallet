/*
				   File: type_SdtStoredTransactions_TransactionItem_UsedIn
			Description: UsedIn
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
	[XmlRoot(ElementName="StoredTransactions.TransactionItem.UsedIn")]
	[XmlType(TypeName="StoredTransactions.TransactionItem.UsedIn" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtStoredTransactions_TransactionItem_UsedIn : GxUserType
	{
		public SdtStoredTransactions_TransactionItem_UsedIn( )
		{
			/* Constructor for serialization */
			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Transactionid = "";

			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime = (DateTime)(DateTime.MinValue);

		}

		public SdtStoredTransactions_TransactionItem_UsedIn(IGxContext context)
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
			AddObjectProperty("TransactionId", gxTpr_Transactionid, false);


			AddObjectProperty("n", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_N, 18, 0)), false);


			datetime_STZ = gxTpr_Datetime;
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
			AddObjectProperty("datetime", sDateCnv, false);


			if (gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto != null)
			{
				AddObjectProperty("UsedTo", gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TransactionId")]
		[XmlElement(ElementName="TransactionId")]
		public string gxTpr_Transactionid
		{
			get {
				return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Transactionid; 
			}
			set {
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Transactionid = value;
				SetDirty("Transactionid");
			}
		}




		[SoapElement(ElementName="n")]
		[XmlElement(ElementName="n")]
		public long gxTpr_N
		{
			get {
				return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_N; 
			}
			set {
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_N = value;
				SetDirty("N");
			}
		}



		[SoapElement(ElementName="datetime")]
		[XmlElement(ElementName="datetime" , IsNullable=true)]
		public string gxTpr_Datetime_Nullable
		{
			get {
				if ( gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime).value ;
			}
			set {
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Datetime
		{
			get {
				return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime; 
			}
			set {
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime = value;
				SetDirty("Datetime");
			}
		}



		[SoapElement(ElementName="UsedTo" )]
		[XmlArray(ElementName="UsedTo"  )]
		[XmlArrayItemAttribute(ElementName="UsedToItem" , IsNullable=false )]
		public GXBaseCollection<SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem> gxTpr_Usedto
		{
			get {
				if ( gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto == null )
				{
					gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto = new GXBaseCollection<SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem>( context, "StoredTransactions.TransactionItem.UsedIn.UsedToItem", "");
				}
				return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto;
			}
			set {
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_N = false;
				gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto = value;
				SetDirty("Usedto");
			}
		}

		public void gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_SetNull()
		{
			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_N = true;
			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto = null;
		}

		public bool gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_IsNull()
		{
			return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto == null;
		}
		public bool ShouldSerializegxTpr_Usedto_GxSimpleCollection_Json()
		{
			return gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto != null && gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Transactionid = "";

			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime = (DateTime)(DateTime.MinValue);

			gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_N = true;

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

		protected string gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Transactionid;
		 

		protected long gxTv_SdtStoredTransactions_TransactionItem_UsedIn_N;
		 

		protected DateTime gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Datetime;
		 
		protected bool gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto_N;
		protected GXBaseCollection<SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem> gxTv_SdtStoredTransactions_TransactionItem_UsedIn_Usedto = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"StoredTransactions.TransactionItem.UsedIn", Namespace="GxBitcoinWallet")]
	public class SdtStoredTransactions_TransactionItem_UsedIn_RESTInterface : GxGenericCollectionItem<SdtStoredTransactions_TransactionItem_UsedIn>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtStoredTransactions_TransactionItem_UsedIn_RESTInterface( ) : base()
		{	
		}

		public SdtStoredTransactions_TransactionItem_UsedIn_RESTInterface( SdtStoredTransactions_TransactionItem_UsedIn psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TransactionId", Order=0)]
		public  string gxTpr_Transactionid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Transactionid);

			}
			set { 
				 sdt.gxTpr_Transactionid = value;
			}
		}

		[DataMember(Name="n", Order=1)]
		public  string gxTpr_N
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_N, 18, 0));

			}
			set { 
				sdt.gxTpr_N = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="datetime", Order=2)]
		public  string gxTpr_Datetime
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datetime,context);

			}
			set { 
				sdt.gxTpr_Datetime = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="UsedTo", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem_RESTInterface> gxTpr_Usedto
		{
			get {
				if (sdt.ShouldSerializegxTpr_Usedto_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem_RESTInterface>(sdt.gxTpr_Usedto);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Usedto);
			}
		}


		#endregion

		public SdtStoredTransactions_TransactionItem_UsedIn sdt
		{
			get { 
				return (SdtStoredTransactions_TransactionItem_UsedIn)Sdt;
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
				sdt = new SdtStoredTransactions_TransactionItem_UsedIn() ;
			}
		}
	}
	#endregion
}