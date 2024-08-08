/*
				   File: type_SdtelectrumRespEstimateFee
			Description: electrumRespEstimateFee
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
	[XmlRoot(ElementName="electrumRespEstimateFee")]
	[XmlType(TypeName="electrumRespEstimateFee" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtelectrumRespEstimateFee : GxUserType
	{
		public SdtelectrumRespEstimateFee( )
		{
			/* Constructor for serialization */
			gxTv_SdtelectrumRespEstimateFee_Id = "";

			gxTv_SdtelectrumRespEstimateFee_Jsonrpc = "";

		}

		public SdtelectrumRespEstimateFee(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("jsonrpc", gxTpr_Jsonrpc, false);


			AddObjectProperty("result", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Result, 16, 8)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtelectrumRespEstimateFee_Id; 
			}
			set {
				gxTv_SdtelectrumRespEstimateFee_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="jsonrpc")]
		[XmlElement(ElementName="jsonrpc")]
		public string gxTpr_Jsonrpc
		{
			get {
				return gxTv_SdtelectrumRespEstimateFee_Jsonrpc; 
			}
			set {
				gxTv_SdtelectrumRespEstimateFee_Jsonrpc = value;
				SetDirty("Jsonrpc");
			}
		}



		[SoapElement(ElementName="result")]
		[XmlElement(ElementName="result")]
		public string gxTpr_Result_double
		{
			get {
				return Convert.ToString(gxTv_SdtelectrumRespEstimateFee_Result, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtelectrumRespEstimateFee_Result = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Result
		{
			get {
				return gxTv_SdtelectrumRespEstimateFee_Result; 
			}
			set {
				gxTv_SdtelectrumRespEstimateFee_Result = value;
				SetDirty("Result");
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
			gxTv_SdtelectrumRespEstimateFee_Id = "";
			gxTv_SdtelectrumRespEstimateFee_Jsonrpc = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtelectrumRespEstimateFee_Id;
		 

		protected string gxTv_SdtelectrumRespEstimateFee_Jsonrpc;
		 

		protected decimal gxTv_SdtelectrumRespEstimateFee_Result;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"electrumRespEstimateFee", Namespace="GxBitcoinWallet")]
	public class SdtelectrumRespEstimateFee_RESTInterface : GxGenericCollectionItem<SdtelectrumRespEstimateFee>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtelectrumRespEstimateFee_RESTInterface( ) : base()
		{	
		}

		public SdtelectrumRespEstimateFee_RESTInterface( SdtelectrumRespEstimateFee psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="jsonrpc", Order=1)]
		public  string gxTpr_Jsonrpc
		{
			get { 
				return sdt.gxTpr_Jsonrpc;

			}
			set { 
				 sdt.gxTpr_Jsonrpc = value;
			}
		}

		[DataMember(Name="result", Order=2)]
		public  string gxTpr_Result
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Result, 16, 8));

			}
			set { 
				sdt.gxTpr_Result =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtelectrumRespEstimateFee sdt
		{
			get { 
				return (SdtelectrumRespEstimateFee)Sdt;
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
				sdt = new SdtelectrumRespEstimateFee() ;
			}
		}
	}
	#endregion
}