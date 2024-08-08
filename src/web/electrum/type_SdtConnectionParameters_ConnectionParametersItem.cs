/*
				   File: type_SdtConnectionParameters_ConnectionParametersItem
			Description: ConnectionParameters
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
	[XmlRoot(ElementName="ConnectionParametersItem")]
	[XmlType(TypeName="ConnectionParametersItem" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtConnectionParameters_ConnectionParametersItem : GxUserType
	{
		public SdtConnectionParameters_ConnectionParametersItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtConnectionParameters_ConnectionParametersItem_Connectiontype = "";

			gxTv_SdtConnectionParameters_ConnectionParametersItem_Hostname = "";

			gxTv_SdtConnectionParameters_ConnectionParametersItem_Networktype = "";

		}

		public SdtConnectionParameters_ConnectionParametersItem(IGxContext context)
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
			AddObjectProperty("ConnectionType", gxTpr_Connectiontype, false);


			AddObjectProperty("HostName", gxTpr_Hostname, false);


			AddObjectProperty("Port", gxTpr_Port, false);


			AddObjectProperty("Secure", gxTpr_Secure, false);


			AddObjectProperty("NetworkType", gxTpr_Networktype, false);


			AddObjectProperty("timeOutMiliseconds", gxTpr_Timeoutmiliseconds, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ConnectionType")]
		[XmlElement(ElementName="ConnectionType")]
		public string gxTpr_Connectiontype
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Connectiontype; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Connectiontype = value;
				SetDirty("Connectiontype");
			}
		}




		[SoapElement(ElementName="HostName")]
		[XmlElement(ElementName="HostName")]
		public string gxTpr_Hostname
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Hostname; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Hostname = value;
				SetDirty("Hostname");
			}
		}




		[SoapElement(ElementName="Port")]
		[XmlElement(ElementName="Port")]
		public int gxTpr_Port
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Port; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Port = value;
				SetDirty("Port");
			}
		}




		[SoapElement(ElementName="Secure")]
		[XmlElement(ElementName="Secure")]
		public bool gxTpr_Secure
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Secure; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Secure = value;
				SetDirty("Secure");
			}
		}




		[SoapElement(ElementName="NetworkType")]
		[XmlElement(ElementName="NetworkType")]
		public string gxTpr_Networktype
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Networktype; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Networktype = value;
				SetDirty("Networktype");
			}
		}




		[SoapElement(ElementName="timeOutMiliseconds")]
		[XmlElement(ElementName="timeOutMiliseconds")]
		public int gxTpr_Timeoutmiliseconds
		{
			get {
				return gxTv_SdtConnectionParameters_ConnectionParametersItem_Timeoutmiliseconds; 
			}
			set {
				gxTv_SdtConnectionParameters_ConnectionParametersItem_Timeoutmiliseconds = value;
				SetDirty("Timeoutmiliseconds");
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
			gxTv_SdtConnectionParameters_ConnectionParametersItem_Connectiontype = "";
			gxTv_SdtConnectionParameters_ConnectionParametersItem_Hostname = "";


			gxTv_SdtConnectionParameters_ConnectionParametersItem_Networktype = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtConnectionParameters_ConnectionParametersItem_Connectiontype;
		 

		protected string gxTv_SdtConnectionParameters_ConnectionParametersItem_Hostname;
		 

		protected int gxTv_SdtConnectionParameters_ConnectionParametersItem_Port;
		 

		protected bool gxTv_SdtConnectionParameters_ConnectionParametersItem_Secure;
		 

		protected string gxTv_SdtConnectionParameters_ConnectionParametersItem_Networktype;
		 

		protected int gxTv_SdtConnectionParameters_ConnectionParametersItem_Timeoutmiliseconds;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"ConnectionParametersItem", Namespace="GxBitcoinWallet")]
	public class SdtConnectionParameters_ConnectionParametersItem_RESTInterface : GxGenericCollectionItem<SdtConnectionParameters_ConnectionParametersItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtConnectionParameters_ConnectionParametersItem_RESTInterface( ) : base()
		{	
		}

		public SdtConnectionParameters_ConnectionParametersItem_RESTInterface( SdtConnectionParameters_ConnectionParametersItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ConnectionType", Order=0)]
		public  string gxTpr_Connectiontype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Connectiontype);

			}
			set { 
				 sdt.gxTpr_Connectiontype = value;
			}
		}

		[DataMember(Name="HostName", Order=1)]
		public  string gxTpr_Hostname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Hostname);

			}
			set { 
				 sdt.gxTpr_Hostname = value;
			}
		}

		[DataMember(Name="Port", Order=2)]
		public int gxTpr_Port
		{
			get { 
				return sdt.gxTpr_Port;

			}
			set { 
				sdt.gxTpr_Port = value;
			}
		}

		[DataMember(Name="Secure", Order=3)]
		public bool gxTpr_Secure
		{
			get { 
				return sdt.gxTpr_Secure;

			}
			set { 
				sdt.gxTpr_Secure = value;
			}
		}

		[DataMember(Name="NetworkType", Order=4)]
		public  string gxTpr_Networktype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Networktype);

			}
			set { 
				 sdt.gxTpr_Networktype = value;
			}
		}

		[DataMember(Name="timeOutMiliseconds", Order=5)]
		public int gxTpr_Timeoutmiliseconds
		{
			get { 
				return sdt.gxTpr_Timeoutmiliseconds;

			}
			set { 
				sdt.gxTpr_Timeoutmiliseconds = value;
			}
		}


		#endregion

		public SdtConnectionParameters_ConnectionParametersItem sdt
		{
			get { 
				return (SdtConnectionParameters_ConnectionParametersItem)Sdt;
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
				sdt = new SdtConnectionParameters_ConnectionParametersItem() ;
			}
		}
	}
	#endregion
}