/*
				   File: type_SdtTransactions__postInput
			Description: Transactions__postInput
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

using GeneXus.Programs;
namespace GeneXus.Programs.gxexplorer
{
	[XmlRoot(ElementName="Transactions__postInput")]
	[XmlType(TypeName="Transactions__postInput" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtTransactions__postInput : GxUserType
	{
		public SdtTransactions__postInput( )
		{
			/* Constructor for serialization */
		}

		public SdtTransactions__postInput(IGxContext context)
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
			if (gxTv_SdtTransactions__postInput_Sdt_addressess != null)
			{
				AddObjectProperty("SDT_Addressess", gxTv_SdtTransactions__postInput_Sdt_addressess, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SDT_Addressess")]
		[XmlElement(ElementName="SDT_Addressess")]
		public GeneXus.Programs.gxexplorer.SdtNBitcoin_SDT_Addressess gxTpr_Sdt_addressess
		{
			get {
				if ( gxTv_SdtTransactions__postInput_Sdt_addressess == null )
				{
					gxTv_SdtTransactions__postInput_Sdt_addressess = new GeneXus.Programs.gxexplorer.SdtNBitcoin_SDT_Addressess(context);
				}
				return gxTv_SdtTransactions__postInput_Sdt_addressess; 
			}
			set {
				gxTv_SdtTransactions__postInput_Sdt_addressess = value;
				SetDirty("Sdt_addressess");
			}
		}
		public void gxTv_SdtTransactions__postInput_Sdt_addressess_SetNull()
		{
			gxTv_SdtTransactions__postInput_Sdt_addressess_N = true;
			gxTv_SdtTransactions__postInput_Sdt_addressess = null;
		}

		public bool gxTv_SdtTransactions__postInput_Sdt_addressess_IsNull()
		{
			return gxTv_SdtTransactions__postInput_Sdt_addressess == null;
		}
		public bool ShouldSerializegxTpr_Sdt_addressess_Json()
		{
			return gxTv_SdtTransactions__postInput_Sdt_addressess != null;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Sdt_addressess_Json()||  
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTransactions__postInput_Sdt_addressess_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected GeneXus.Programs.gxexplorer.SdtNBitcoin_SDT_Addressess gxTv_SdtTransactions__postInput_Sdt_addressess = null;
		protected bool gxTv_SdtTransactions__postInput_Sdt_addressess_N;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"Transactions__postInput", Namespace="GxBitcoinWallet")]
	public class SdtTransactions__postInput_RESTInterface : GxGenericCollectionItem<SdtTransactions__postInput>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTransactions__postInput_RESTInterface( ) : base()
		{	
		}

		public SdtTransactions__postInput_RESTInterface( SdtTransactions__postInput psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SDT_Addressess", Order=0, EmitDefaultValue=false)]
		public GeneXus.Programs.gxexplorer.SdtNBitcoin_SDT_Addressess_RESTInterface gxTpr_Sdt_addressess
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_addressess_Json())
					return new GeneXus.Programs.gxexplorer.SdtNBitcoin_SDT_Addressess_RESTInterface(sdt.gxTpr_Sdt_addressess);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Sdt_addressess = value.sdt;
			}
		}


		#endregion

		public SdtTransactions__postInput sdt
		{
			get { 
				return (SdtTransactions__postInput)Sdt;
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
				sdt = new SdtTransactions__postInput() ;
			}
		}
	}
	#endregion
}