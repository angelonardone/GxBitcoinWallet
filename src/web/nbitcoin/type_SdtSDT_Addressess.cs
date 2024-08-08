/*
				   File: type_SdtSDT_Addressess
			Description: SDT_Addressess
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
namespace GeneXus.Programs.nbitcoin
{
	[XmlRoot(ElementName="SDT_Addressess")]
	[XmlType(TypeName="SDT_Addressess" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtSDT_Addressess : GxUserType
	{
		public SdtSDT_Addressess( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_Addressess(IGxContext context)
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
			if (gxTv_SdtSDT_Addressess_Address != null)
			{
				AddObjectProperty("Address", gxTv_SdtSDT_Addressess_Address, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Address" )]
		[XmlArray(ElementName="Address"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Address_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDT_Addressess_Address == null )
				{
					gxTv_SdtSDT_Addressess_Address = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDT_Addressess_Address;
			}
			set {
				gxTv_SdtSDT_Addressess_Address_N = false;
				gxTv_SdtSDT_Addressess_Address = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Address
		{
			get {
				if ( gxTv_SdtSDT_Addressess_Address == null )
				{
					gxTv_SdtSDT_Addressess_Address = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDT_Addressess_Address_N = false;
				return gxTv_SdtSDT_Addressess_Address ;
			}
			set {
				gxTv_SdtSDT_Addressess_Address_N = false;
				gxTv_SdtSDT_Addressess_Address = value;
				SetDirty("Address");
			}
		}

		public void gxTv_SdtSDT_Addressess_Address_SetNull()
		{
			gxTv_SdtSDT_Addressess_Address_N = true;
			gxTv_SdtSDT_Addressess_Address = null;
		}

		public bool gxTv_SdtSDT_Addressess_Address_IsNull()
		{
			return gxTv_SdtSDT_Addressess_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_Addressess_Address != null && gxTv_SdtSDT_Addressess_Address.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Address_GxSimpleCollection_Json()||  
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_Addressess_Address_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_Addressess_Address_N;
		protected GxSimpleCollection<string> gxTv_SdtSDT_Addressess_Address = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDT_Addressess", Namespace="GxBitcoinWallet")]
	public class SdtSDT_Addressess_RESTInterface : GxGenericCollectionItem<SdtSDT_Addressess>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Addressess_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Addressess_RESTInterface( SdtSDT_Addressess psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Address", Order=0, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Address
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Address_GxSimpleCollection_Json())
					return sdt.gxTpr_Address;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Address = value ;
			}
		}


		#endregion

		public SdtSDT_Addressess sdt
		{
			get { 
				return (SdtSDT_Addressess)Sdt;
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
				sdt = new SdtSDT_Addressess() ;
			}
		}
	}
	#endregion
}