/*
				   File: type_SdtRawTransaction__postInput
			Description: RawTransaction__postInput
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
	[XmlRoot(ElementName="RawTransaction__postInput")]
	[XmlType(TypeName="RawTransaction__postInput" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtRawTransaction__postInput : GxUserType
	{
		public SdtRawTransaction__postInput( )
		{
			/* Constructor for serialization */
			gxTv_SdtRawTransaction__postInput_Hextransaction = "";

		}

		public SdtRawTransaction__postInput(IGxContext context)
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
			AddObjectProperty("hexTransaction", gxTpr_Hextransaction, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="hexTransaction")]
		[XmlElement(ElementName="hexTransaction")]
		public string gxTpr_Hextransaction
		{
			get {
				return gxTv_SdtRawTransaction__postInput_Hextransaction; 
			}
			set {
				gxTv_SdtRawTransaction__postInput_Hextransaction = value;
				SetDirty("Hextransaction");
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
			gxTv_SdtRawTransaction__postInput_Hextransaction = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtRawTransaction__postInput_Hextransaction;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"RawTransaction__postInput", Namespace="GxBitcoinWallet")]
	public class SdtRawTransaction__postInput_RESTInterface : GxGenericCollectionItem<SdtRawTransaction__postInput>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtRawTransaction__postInput_RESTInterface( ) : base()
		{	
		}

		public SdtRawTransaction__postInput_RESTInterface( SdtRawTransaction__postInput psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="hexTransaction", Order=0)]
		public  string gxTpr_Hextransaction
		{
			get { 
				return sdt.gxTpr_Hextransaction;

			}
			set { 
				 sdt.gxTpr_Hextransaction = value;
			}
		}


		#endregion

		public SdtRawTransaction__postInput sdt
		{
			get { 
				return (SdtRawTransaction__postInput)Sdt;
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
				sdt = new SdtRawTransaction__postInput() ;
			}
		}
	}
	#endregion
}