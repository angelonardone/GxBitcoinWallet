/*
				   File: type_SdtelectrumRespGetTransactionId_result_vinItem
			Description: vin
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
namespace GeneXus.Programs.electrum
{
	[XmlRoot(ElementName="electrumRespGetTransactionId.result.vinItem")]
	[XmlType(TypeName="electrumRespGetTransactionId.result.vinItem" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtelectrumRespGetTransactionId_result_vinItem : GxUserType
	{
		public SdtelectrumRespGetTransactionId_result_vinItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txid = "";

		}

		public SdtelectrumRespGetTransactionId_result_vinItem(IGxContext context)
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
			if (gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig != null)
			{
				AddObjectProperty("scriptSig", gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig, false);
			}

			AddObjectProperty("sequence", gxTpr_Sequence, false);


			AddObjectProperty("txid", gxTpr_Txid, false);

			if (gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness != null)
			{
				AddObjectProperty("txinwitness", gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness, false);
			}

			AddObjectProperty("vout", gxTpr_Vout, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="scriptSig" )]
		[XmlElement(ElementName="scriptSig" )]
		public SdtelectrumRespGetTransactionId_result_vinItem_scriptSig gxTpr_Scriptsig
		{
			get {
				if ( gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig == null )
				{
					gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig = new SdtelectrumRespGetTransactionId_result_vinItem_scriptSig(context);
				}
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_N = false;
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig;
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_N = false;
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig = value;
				SetDirty("Scriptsig");
			}

		}

		public void gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_SetNull()
		{
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_N = true;
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig = null;
		}

		public bool gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_IsNull()
		{
			return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig == null;
		}
		public bool ShouldSerializegxTpr_Scriptsig_Json()
		{
				return (gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig != null && gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="sequence")]
		[XmlElement(ElementName="sequence")]
		public string gxTpr_Sequence_double
		{
			get {
				return Convert.ToString(gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Sequence, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Sequence = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Sequence
		{
			get {
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Sequence; 
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Sequence = value;
				SetDirty("Sequence");
			}
		}




		[SoapElement(ElementName="txid")]
		[XmlElement(ElementName="txid")]
		public string gxTpr_Txid
		{
			get {
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txid; 
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txid = value;
				SetDirty("Txid");
			}
		}




		[SoapElement(ElementName="txinwitness" )]
		[XmlArray(ElementName="txinwitness"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Txinwitness_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness == null )
				{
					gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness;
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N = false;
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Txinwitness
		{
			get {
				if ( gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness == null )
				{
					gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = new GxSimpleCollection<string>();
				}
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N = false;
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness ;
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N = false;
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = value;
				SetDirty("Txinwitness");
			}
		}

		public void gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_SetNull()
		{
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N = true;
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = null;
		}

		public bool gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_IsNull()
		{
			return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness == null;
		}
		public bool ShouldSerializegxTpr_Txinwitness_GxSimpleCollection_Json()
		{
			return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness != null && gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness.Count > 0;

		}

		[SoapElement(ElementName="vout")]
		[XmlElement(ElementName="vout")]
		public string gxTpr_Vout_double
		{
			get {
				return Convert.ToString(gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Vout, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Vout = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Vout
		{
			get {
				return gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Vout; 
			}
			set {
				gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Vout = value;
				SetDirty("Vout");
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
			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_N = true;


			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txid = "";

			gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig_N;
		protected SdtelectrumRespGetTransactionId_result_vinItem_scriptSig gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Scriptsig = null; 


		protected decimal gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Sequence;
		 

		protected string gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txid;
		 
		protected bool gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness_N;
		protected GxSimpleCollection<string> gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Txinwitness = null;  

		protected decimal gxTv_SdtelectrumRespGetTransactionId_result_vinItem_Vout;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"electrumRespGetTransactionId.result.vinItem", Namespace="GxBitcoinWallet")]
	public class SdtelectrumRespGetTransactionId_result_vinItem_RESTInterface : GxGenericCollectionItem<SdtelectrumRespGetTransactionId_result_vinItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtelectrumRespGetTransactionId_result_vinItem_RESTInterface( ) : base()
		{	
		}

		public SdtelectrumRespGetTransactionId_result_vinItem_RESTInterface( SdtelectrumRespGetTransactionId_result_vinItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="scriptSig", Order=0, EmitDefaultValue=false)]
		public SdtelectrumRespGetTransactionId_result_vinItem_scriptSig_RESTInterface gxTpr_Scriptsig
		{
			get {
				if (sdt.ShouldSerializegxTpr_Scriptsig_Json())
					return new SdtelectrumRespGetTransactionId_result_vinItem_scriptSig_RESTInterface(sdt.gxTpr_Scriptsig);
				else
					return null;

			}

			set {
				sdt.gxTpr_Scriptsig = value.sdt;
			}

		}

		[DataMember(Name="sequence", Order=1)]
		public  string gxTpr_Sequence
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Sequence, 10, 5));

			}
			set { 
				sdt.gxTpr_Sequence =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="txid", Order=2)]
		public  string gxTpr_Txid
		{
			get { 
				return sdt.gxTpr_Txid;

			}
			set { 
				 sdt.gxTpr_Txid = value;
			}
		}

		[DataMember(Name="txinwitness", Order=3, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Txinwitness
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Txinwitness_GxSimpleCollection_Json())
					return sdt.gxTpr_Txinwitness;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Txinwitness = value ;
			}
		}

		[DataMember(Name="vout", Order=4)]
		public  string gxTpr_Vout
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Vout, 10, 5));

			}
			set { 
				sdt.gxTpr_Vout =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtelectrumRespGetTransactionId_result_vinItem sdt
		{
			get { 
				return (SdtelectrumRespGetTransactionId_result_vinItem)Sdt;
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
				sdt = new SdtelectrumRespGetTransactionId_result_vinItem() ;
			}
		}
	}
	#endregion
}