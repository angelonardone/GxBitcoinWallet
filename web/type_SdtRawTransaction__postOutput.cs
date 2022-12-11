/*
				   File: type_SdtRawTransaction__postOutput
			Description: RawTransaction__postOutput
				 Author: Nemo 🐠 for C# (.NET) version 17.0.11.163677
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
	[XmlRoot(ElementName="RawTransaction__postOutput")]
	[XmlType(TypeName="RawTransaction__postOutput" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtRawTransaction__postOutput : GxUserType
	{
		public SdtRawTransaction__postOutput( )
		{
			/* Constructor for serialization */
			gxTv_SdtRawTransaction__postOutput_Error = "";

		}

		public SdtRawTransaction__postOutput(IGxContext context)
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
			if (gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result != null)
			{
				AddObjectProperty("sdt_sendBlock_result", gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result, false);
			}

			AddObjectProperty("error", gxTpr_Error, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="sdt_sendBlock_result")]
		[XmlElement(ElementName="sdt_sendBlock_result")]
		public GeneXus.Programs.SdtGxExplorer_SDT_sendBlock_result gxTpr_Sdt_sendblock_result
		{
			get {
				if ( gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result == null )
				{
					gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result = new GeneXus.Programs.SdtGxExplorer_SDT_sendBlock_result(context);
				}
				return gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result; 
			}
			set {
				gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result = value;
				SetDirty("Sdt_sendblock_result");
			}
		}
		public void gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result_SetNull()
		{
			gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result_N = true;
			gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result = null;
		}

		public bool gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result_IsNull()
		{
			return gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result == null;
		}
		public bool ShouldSerializegxTpr_Sdt_sendblock_result_Json()
		{
			return gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result != null;

		}


		[SoapElement(ElementName="error")]
		[XmlElement(ElementName="error")]
		public string gxTpr_Error
		{
			get {
				return gxTv_SdtRawTransaction__postOutput_Error; 
			}
			set {
				gxTv_SdtRawTransaction__postOutput_Error = value;
				SetDirty("Error");
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
			gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result_N = true;

			gxTv_SdtRawTransaction__postOutput_Error = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected GeneXus.Programs.SdtGxExplorer_SDT_sendBlock_result gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result = null;
		protected bool gxTv_SdtRawTransaction__postOutput_Sdt_sendblock_result_N;
		 

		protected string gxTv_SdtRawTransaction__postOutput_Error;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"RawTransaction__postOutput", Namespace="GxBitcoinWallet")]
	public class SdtRawTransaction__postOutput_RESTInterface : GxGenericCollectionItem<SdtRawTransaction__postOutput>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtRawTransaction__postOutput_RESTInterface( ) : base()
		{	
		}

		public SdtRawTransaction__postOutput_RESTInterface( SdtRawTransaction__postOutput psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="sdt_sendBlock_result", Order=0, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtGxExplorer_SDT_sendBlock_result_RESTInterface gxTpr_Sdt_sendblock_result
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_sendblock_result_Json())
					return new GeneXus.Programs.SdtGxExplorer_SDT_sendBlock_result_RESTInterface(sdt.gxTpr_Sdt_sendblock_result);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Sdt_sendblock_result = value.sdt;
			}
		}

		[DataMember(Name="error", Order=1)]
		public  string gxTpr_Error
		{
			get { 
				return sdt.gxTpr_Error;

			}
			set { 
				 sdt.gxTpr_Error = value;
			}
		}


		#endregion

		public SdtRawTransaction__postOutput sdt
		{
			get { 
				return (SdtRawTransaction__postOutput)Sdt;
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
				sdt = new SdtRawTransaction__postOutput() ;
			}
		}
	}
	#endregion
}