/*
				   File: type_SdtvOUT
			Description: vOUT
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
namespace GeneXus.Programs.sudodb
{
	[XmlRoot(ElementName="vOUT")]
	[XmlType(TypeName="vOUT" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtvOUT : GxUserType
	{
		public SdtvOUT( )
		{
			/* Constructor for serialization */
			gxTv_SdtvOUT_Transactionid = "";

			gxTv_SdtvOUT_Scriptpubkey_address = "";

			gxTv_SdtvOUT_Type = "";

		}

		public SdtvOUT(IGxContext context)
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


			AddObjectProperty("n", gxTpr_N, false);


			AddObjectProperty("value", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Value, 16, 8)), false);


			AddObjectProperty("scriptPubKey_address", gxTpr_Scriptpubkey_address, false);


			AddObjectProperty("type", gxTpr_Type, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TransactionId")]
		[XmlElement(ElementName="TransactionId")]
		public string gxTpr_Transactionid
		{
			get {
				return gxTv_SdtvOUT_Transactionid; 
			}
			set {
				gxTv_SdtvOUT_Transactionid = value;
				SetDirty("Transactionid");
			}
		}




		[SoapElement(ElementName="n")]
		[XmlElement(ElementName="n")]
		public long gxTpr_N
		{
			get {
				return gxTv_SdtvOUT_N; 
			}
			set {
				gxTv_SdtvOUT_N = value;
				SetDirty("N");
			}
		}



		[SoapElement(ElementName="value")]
		[XmlElement(ElementName="value")]
		public string gxTpr_Value_double
		{
			get {
				return Convert.ToString(gxTv_SdtvOUT_Value, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtvOUT_Value = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Value
		{
			get {
				return gxTv_SdtvOUT_Value; 
			}
			set {
				gxTv_SdtvOUT_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="scriptPubKey_address")]
		[XmlElement(ElementName="scriptPubKey_address")]
		public string gxTpr_Scriptpubkey_address
		{
			get {
				return gxTv_SdtvOUT_Scriptpubkey_address; 
			}
			set {
				gxTv_SdtvOUT_Scriptpubkey_address = value;
				SetDirty("Scriptpubkey_address");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtvOUT_Type; 
			}
			set {
				gxTv_SdtvOUT_Type = value;
				SetDirty("Type");
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
			gxTv_SdtvOUT_Transactionid = "";


			gxTv_SdtvOUT_Scriptpubkey_address = "";
			gxTv_SdtvOUT_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtvOUT_Transactionid;
		 

		protected long gxTv_SdtvOUT_N;
		 

		protected decimal gxTv_SdtvOUT_Value;
		 

		protected string gxTv_SdtvOUT_Scriptpubkey_address;
		 

		protected string gxTv_SdtvOUT_Type;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"vOUT", Namespace="GxBitcoinWallet")]
	public class SdtvOUT_RESTInterface : GxGenericCollectionItem<SdtvOUT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtvOUT_RESTInterface( ) : base()
		{	
		}

		public SdtvOUT_RESTInterface( SdtvOUT psdt ) : base(psdt)
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
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_N, 10, 0));

			}
			set { 
				sdt.gxTpr_N = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="value", Order=2)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Value, 16, 8));

			}
			set { 
				sdt.gxTpr_Value =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="scriptPubKey_address", Order=3)]
		public  string gxTpr_Scriptpubkey_address
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Scriptpubkey_address);

			}
			set { 
				 sdt.gxTpr_Scriptpubkey_address = value;
			}
		}

		[DataMember(Name="type", Order=4)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}


		#endregion

		public SdtvOUT sdt
		{
			get { 
				return (SdtvOUT)Sdt;
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
				sdt = new SdtvOUT() ;
			}
		}
	}
	#endregion
}