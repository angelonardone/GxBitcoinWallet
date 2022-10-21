/*
				   File: type_SdtWalletLine
			Description: WalletLine
				 Author: Nemo 🐠 for C# (.NET) version 17.0.10.160000
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
	[XmlRoot(ElementName="WalletLine")]
	[XmlType(TypeName="WalletLine" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtWalletLine : GxUserType
	{
		public SdtWalletLine( )
		{
			/* Constructor for serialization */
			gxTv_SdtWalletLine_Textaddress = "";

			gxTv_SdtWalletLine_Linktoinspect = "";

		}

		public SdtWalletLine(IGxContext context)
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
			if (gxTv_SdtWalletLine_Keyinfo != null)
			{
				AddObjectProperty("keyInfo", gxTv_SdtWalletLine_Keyinfo, false);
			}
			if (gxTv_SdtWalletLine_Extkeyinfo != null)
			{
				AddObjectProperty("extKeyInfo", gxTv_SdtWalletLine_Extkeyinfo, false);
			}

			AddObjectProperty("transactionsCount", gxTpr_Transactionscount, false);


			AddObjectProperty("totalBalance", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalbalance, 16, 8)), false);


			AddObjectProperty("textAddress", gxTpr_Textaddress, false);


			AddObjectProperty("linkToInspect", gxTpr_Linktoinspect, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="keyInfo")]
		[XmlElement(ElementName="keyInfo")]
		public GeneXus.Programs.nbitcoin.SdtKeyInfo gxTpr_Keyinfo
		{
			get {
				if ( gxTv_SdtWalletLine_Keyinfo == null )
				{
					gxTv_SdtWalletLine_Keyinfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
				}
				return gxTv_SdtWalletLine_Keyinfo; 
			}
			set {
				gxTv_SdtWalletLine_Keyinfo = value;
				SetDirty("Keyinfo");
			}
		}
		public void gxTv_SdtWalletLine_Keyinfo_SetNull()
		{
			gxTv_SdtWalletLine_Keyinfo_N = true;
			gxTv_SdtWalletLine_Keyinfo = null;
		}

		public bool gxTv_SdtWalletLine_Keyinfo_IsNull()
		{
			return gxTv_SdtWalletLine_Keyinfo == null;
		}
		public bool ShouldSerializegxTpr_Keyinfo_Json()
		{
			return gxTv_SdtWalletLine_Keyinfo != null;

		}

		[SoapElement(ElementName="extKeyInfo")]
		[XmlElement(ElementName="extKeyInfo")]
		public GeneXus.Programs.nbitcoin.SdtExtKeyInfo gxTpr_Extkeyinfo
		{
			get {
				if ( gxTv_SdtWalletLine_Extkeyinfo == null )
				{
					gxTv_SdtWalletLine_Extkeyinfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
				}
				return gxTv_SdtWalletLine_Extkeyinfo; 
			}
			set {
				gxTv_SdtWalletLine_Extkeyinfo = value;
				SetDirty("Extkeyinfo");
			}
		}
		public void gxTv_SdtWalletLine_Extkeyinfo_SetNull()
		{
			gxTv_SdtWalletLine_Extkeyinfo_N = true;
			gxTv_SdtWalletLine_Extkeyinfo = null;
		}

		public bool gxTv_SdtWalletLine_Extkeyinfo_IsNull()
		{
			return gxTv_SdtWalletLine_Extkeyinfo == null;
		}
		public bool ShouldSerializegxTpr_Extkeyinfo_Json()
		{
			return gxTv_SdtWalletLine_Extkeyinfo != null;

		}


		[SoapElement(ElementName="transactionsCount")]
		[XmlElement(ElementName="transactionsCount")]
		public long gxTpr_Transactionscount
		{
			get {
				return gxTv_SdtWalletLine_Transactionscount; 
			}
			set {
				gxTv_SdtWalletLine_Transactionscount = value;
				SetDirty("Transactionscount");
			}
		}



		[SoapElement(ElementName="totalBalance")]
		[XmlElement(ElementName="totalBalance")]
		public string gxTpr_Totalbalance_double
		{
			get {
				return Convert.ToString(gxTv_SdtWalletLine_Totalbalance, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWalletLine_Totalbalance = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalbalance
		{
			get {
				return gxTv_SdtWalletLine_Totalbalance; 
			}
			set {
				gxTv_SdtWalletLine_Totalbalance = value;
				SetDirty("Totalbalance");
			}
		}




		[SoapElement(ElementName="textAddress")]
		[XmlElement(ElementName="textAddress")]
		public string gxTpr_Textaddress
		{
			get {
				return gxTv_SdtWalletLine_Textaddress; 
			}
			set {
				gxTv_SdtWalletLine_Textaddress = value;
				SetDirty("Textaddress");
			}
		}




		[SoapElement(ElementName="linkToInspect")]
		[XmlElement(ElementName="linkToInspect")]
		public string gxTpr_Linktoinspect
		{
			get {
				return gxTv_SdtWalletLine_Linktoinspect; 
			}
			set {
				gxTv_SdtWalletLine_Linktoinspect = value;
				SetDirty("Linktoinspect");
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
			gxTv_SdtWalletLine_Keyinfo_N = true;


			gxTv_SdtWalletLine_Extkeyinfo_N = true;



			gxTv_SdtWalletLine_Textaddress = "";
			gxTv_SdtWalletLine_Linktoinspect = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected GeneXus.Programs.nbitcoin.SdtKeyInfo gxTv_SdtWalletLine_Keyinfo = null;
		protected bool gxTv_SdtWalletLine_Keyinfo_N;
		 

		protected GeneXus.Programs.nbitcoin.SdtExtKeyInfo gxTv_SdtWalletLine_Extkeyinfo = null;
		protected bool gxTv_SdtWalletLine_Extkeyinfo_N;
		 

		protected long gxTv_SdtWalletLine_Transactionscount;
		 

		protected decimal gxTv_SdtWalletLine_Totalbalance;
		 

		protected string gxTv_SdtWalletLine_Textaddress;
		 

		protected string gxTv_SdtWalletLine_Linktoinspect;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"WalletLine", Namespace="GxBitcoinWallet")]
	public class SdtWalletLine_RESTInterface : GxGenericCollectionItem<SdtWalletLine>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWalletLine_RESTInterface( ) : base()
		{	
		}

		public SdtWalletLine_RESTInterface( SdtWalletLine psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="keyInfo", Order=0, EmitDefaultValue=false)]
		public GeneXus.Programs.nbitcoin.SdtKeyInfo_RESTInterface gxTpr_Keyinfo
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Keyinfo_Json())
					return new GeneXus.Programs.nbitcoin.SdtKeyInfo_RESTInterface(sdt.gxTpr_Keyinfo);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Keyinfo = value.sdt;
			}
		}

		[DataMember(Name="extKeyInfo", Order=1, EmitDefaultValue=false)]
		public GeneXus.Programs.nbitcoin.SdtExtKeyInfo_RESTInterface gxTpr_Extkeyinfo
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Extkeyinfo_Json())
					return new GeneXus.Programs.nbitcoin.SdtExtKeyInfo_RESTInterface(sdt.gxTpr_Extkeyinfo);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Extkeyinfo = value.sdt;
			}
		}

		[DataMember(Name="transactionsCount", Order=2)]
		public  string gxTpr_Transactionscount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Transactionscount, 10, 0));

			}
			set { 
				sdt.gxTpr_Transactionscount = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="totalBalance", Order=3)]
		public  string gxTpr_Totalbalance
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalbalance, 16, 8));

			}
			set { 
				sdt.gxTpr_Totalbalance =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="textAddress", Order=4)]
		public  string gxTpr_Textaddress
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Textaddress);

			}
			set { 
				 sdt.gxTpr_Textaddress = value;
			}
		}

		[DataMember(Name="linkToInspect", Order=5)]
		public  string gxTpr_Linktoinspect
		{
			get { 
				return sdt.gxTpr_Linktoinspect;

			}
			set { 
				 sdt.gxTpr_Linktoinspect = value;
			}
		}


		#endregion

		public SdtWalletLine sdt
		{
			get { 
				return (SdtWalletLine)Sdt;
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
				sdt = new SdtWalletLine() ;
			}
		}
	}
	#endregion
}