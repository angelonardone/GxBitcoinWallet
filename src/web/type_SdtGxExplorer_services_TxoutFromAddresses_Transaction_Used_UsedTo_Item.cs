/*
				   File: type_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item
			Description: GxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item
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


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="GxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item")]
	[XmlType(TypeName="GxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item : GxUserType
	{
		public SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Scriptpubkey_address = "";

		}

		public SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item(IGxContext context)
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
			AddObjectProperty("scriptPubKey_address", gxTpr_Scriptpubkey_address, false);


			AddObjectProperty("n", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_N, 18, 0)), false);


			AddObjectProperty("value", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Value, 16, 8)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="scriptPubKey_address")]
		[XmlElement(ElementName="scriptPubKey_address")]
		public string gxTpr_Scriptpubkey_address
		{
			get {
				return gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Scriptpubkey_address; 
			}
			set {
				gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Scriptpubkey_address = value;
				SetDirty("Scriptpubkey_address");
			}
		}




		[SoapElement(ElementName="n")]
		[XmlElement(ElementName="n")]
		public long gxTpr_N
		{
			get {
				return gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_N; 
			}
			set {
				gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_N = value;
				SetDirty("N");
			}
		}



		[SoapElement(ElementName="value")]
		[XmlElement(ElementName="value")]
		public string gxTpr_Value_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Value, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Value = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Value
		{
			get {
				return gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Value; 
			}
			set {
				gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Value = value;
				SetDirty("Value");
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
			gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Scriptpubkey_address = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Scriptpubkey_address;
		 

		protected long gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_N;
		 

		protected decimal gxTv_SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_Value;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"GxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item", Namespace="GxBitcoinWallet")]
	public class SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_RESTInterface : GxGenericCollectionItem<SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_RESTInterface( ) : base()
		{	
		}

		public SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item_RESTInterface( SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="scriptPubKey_address", Order=0)]
		public  string gxTpr_Scriptpubkey_address
		{
			get { 
				return sdt.gxTpr_Scriptpubkey_address;

			}
			set { 
				 sdt.gxTpr_Scriptpubkey_address = value;
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


		#endregion

		public SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item sdt
		{
			get { 
				return (SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item)Sdt;
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
				sdt = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item() ;
			}
		}
	}
	#endregion
}