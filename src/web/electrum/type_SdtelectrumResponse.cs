/*
				   File: type_SdtelectrumResponse
			Description: electrumResponse
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
	[XmlRoot(ElementName="electrumResponse")]
	[XmlType(TypeName="electrumResponse" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtelectrumResponse : GxUserType
	{
		public SdtelectrumResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtelectrumResponse_Id = "";

			gxTv_SdtelectrumResponse_Jsonrpc = "";

			gxTv_SdtelectrumResponse_Result = "";

		}

		public SdtelectrumResponse(IGxContext context)
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


			AddObjectProperty("result", gxTpr_Result, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtelectrumResponse_Id; 
			}
			set {
				gxTv_SdtelectrumResponse_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="jsonrpc")]
		[XmlElement(ElementName="jsonrpc")]
		public string gxTpr_Jsonrpc
		{
			get {
				return gxTv_SdtelectrumResponse_Jsonrpc; 
			}
			set {
				gxTv_SdtelectrumResponse_Jsonrpc = value;
				SetDirty("Jsonrpc");
			}
		}




		[SoapElement(ElementName="result")]
		[XmlElement(ElementName="result")]
		public string gxTpr_Result
		{
			get {
				return gxTv_SdtelectrumResponse_Result; 
			}
			set {
				gxTv_SdtelectrumResponse_Result = value;
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
			gxTv_SdtelectrumResponse_Id = "";
			gxTv_SdtelectrumResponse_Jsonrpc = "";
			gxTv_SdtelectrumResponse_Result = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtelectrumResponse_Id;
		 

		protected string gxTv_SdtelectrumResponse_Jsonrpc;
		 

		protected string gxTv_SdtelectrumResponse_Result;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"electrumResponse", Namespace="GxBitcoinWallet")]
	public class SdtelectrumResponse_RESTInterface : GxGenericCollectionItem<SdtelectrumResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtelectrumResponse_RESTInterface( ) : base()
		{	
		}

		public SdtelectrumResponse_RESTInterface( SdtelectrumResponse psdt ) : base(psdt)
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
				return sdt.gxTpr_Result;

			}
			set { 
				 sdt.gxTpr_Result = value;
			}
		}


		#endregion

		public SdtelectrumResponse sdt
		{
			get { 
				return (SdtelectrumResponse)Sdt;
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
				sdt = new SdtelectrumResponse() ;
			}
		}
	}
	#endregion
}