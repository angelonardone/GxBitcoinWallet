/*
				   File: type_SdtExtKeyInfo_Extended
			Description: Extended
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
	[XmlRoot(ElementName="ExtKeyInfo.Extended")]
	[XmlType(TypeName="ExtKeyInfo.Extended" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtExtKeyInfo_Extended : GxUserType
	{
		public SdtExtKeyInfo_Extended( )
		{
			/* Constructor for serialization */
			gxTv_SdtExtKeyInfo_Extended_Privatekey = "";

			gxTv_SdtExtKeyInfo_Extended_Privatekeysegwitp2sh = "";

			gxTv_SdtExtKeyInfo_Extended_Privatekeysegwit = "";

			gxTv_SdtExtKeyInfo_Extended_Nuterpublickey = "";

			gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwitp2sh = "";

			gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwit = "";

			gxTv_SdtExtKeyInfo_Extended_Parentfingerprint = "";

			gxTv_SdtExtKeyInfo_Extended_Keypath = "";

		}

		public SdtExtKeyInfo_Extended(IGxContext context)
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
			AddObjectProperty("PrivateKey", gxTpr_Privatekey, false);


			AddObjectProperty("PrivateKeySegwitP2SH", gxTpr_Privatekeysegwitp2sh, false);


			AddObjectProperty("PrivateKeySegwit", gxTpr_Privatekeysegwit, false);


			AddObjectProperty("NuterPublicKey", gxTpr_Nuterpublickey, false);


			AddObjectProperty("NuterPublicKeySegwitP2SH", gxTpr_Nuterpublickeysegwitp2sh, false);


			AddObjectProperty("NuterPublicKeySegwit", gxTpr_Nuterpublickeysegwit, false);


			AddObjectProperty("ParentFingerprint", gxTpr_Parentfingerprint, false);


			AddObjectProperty("Depth", gxTpr_Depth, false);


			AddObjectProperty("Child", gxTpr_Child, false);


			AddObjectProperty("isHardended", gxTpr_Ishardended, false);


			AddObjectProperty("keyPath", gxTpr_Keypath, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrivateKey")]
		[XmlElement(ElementName="PrivateKey")]
		public string gxTpr_Privatekey
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Privatekey; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Privatekey = value;
				SetDirty("Privatekey");
			}
		}




		[SoapElement(ElementName="PrivateKeySegwitP2SH")]
		[XmlElement(ElementName="PrivateKeySegwitP2SH")]
		public string gxTpr_Privatekeysegwitp2sh
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Privatekeysegwitp2sh; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Privatekeysegwitp2sh = value;
				SetDirty("Privatekeysegwitp2sh");
			}
		}




		[SoapElement(ElementName="PrivateKeySegwit")]
		[XmlElement(ElementName="PrivateKeySegwit")]
		public string gxTpr_Privatekeysegwit
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Privatekeysegwit; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Privatekeysegwit = value;
				SetDirty("Privatekeysegwit");
			}
		}




		[SoapElement(ElementName="NuterPublicKey")]
		[XmlElement(ElementName="NuterPublicKey")]
		public string gxTpr_Nuterpublickey
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Nuterpublickey; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Nuterpublickey = value;
				SetDirty("Nuterpublickey");
			}
		}




		[SoapElement(ElementName="NuterPublicKeySegwitP2SH")]
		[XmlElement(ElementName="NuterPublicKeySegwitP2SH")]
		public string gxTpr_Nuterpublickeysegwitp2sh
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwitp2sh; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwitp2sh = value;
				SetDirty("Nuterpublickeysegwitp2sh");
			}
		}




		[SoapElement(ElementName="NuterPublicKeySegwit")]
		[XmlElement(ElementName="NuterPublicKeySegwit")]
		public string gxTpr_Nuterpublickeysegwit
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwit; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwit = value;
				SetDirty("Nuterpublickeysegwit");
			}
		}




		[SoapElement(ElementName="ParentFingerprint")]
		[XmlElement(ElementName="ParentFingerprint")]
		public string gxTpr_Parentfingerprint
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Parentfingerprint; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Parentfingerprint = value;
				SetDirty("Parentfingerprint");
			}
		}




		[SoapElement(ElementName="Depth")]
		[XmlElement(ElementName="Depth")]
		public short gxTpr_Depth
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Depth; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Depth = value;
				SetDirty("Depth");
			}
		}




		[SoapElement(ElementName="Child")]
		[XmlElement(ElementName="Child")]
		public long gxTpr_Child
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Child; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Child = value;
				SetDirty("Child");
			}
		}




		[SoapElement(ElementName="isHardended")]
		[XmlElement(ElementName="isHardended")]
		public bool gxTpr_Ishardended
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Ishardended; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Ishardended = value;
				SetDirty("Ishardended");
			}
		}




		[SoapElement(ElementName="keyPath")]
		[XmlElement(ElementName="keyPath")]
		public string gxTpr_Keypath
		{
			get {
				return gxTv_SdtExtKeyInfo_Extended_Keypath; 
			}
			set {
				gxTv_SdtExtKeyInfo_Extended_Keypath = value;
				SetDirty("Keypath");
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
			gxTv_SdtExtKeyInfo_Extended_Privatekey = "";
			gxTv_SdtExtKeyInfo_Extended_Privatekeysegwitp2sh = "";
			gxTv_SdtExtKeyInfo_Extended_Privatekeysegwit = "";
			gxTv_SdtExtKeyInfo_Extended_Nuterpublickey = "";
			gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwitp2sh = "";
			gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwit = "";
			gxTv_SdtExtKeyInfo_Extended_Parentfingerprint = "";



			gxTv_SdtExtKeyInfo_Extended_Keypath = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtExtKeyInfo_Extended_Privatekey;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Privatekeysegwitp2sh;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Privatekeysegwit;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Nuterpublickey;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwitp2sh;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Nuterpublickeysegwit;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Parentfingerprint;
		 

		protected short gxTv_SdtExtKeyInfo_Extended_Depth;
		 

		protected long gxTv_SdtExtKeyInfo_Extended_Child;
		 

		protected bool gxTv_SdtExtKeyInfo_Extended_Ishardended;
		 

		protected string gxTv_SdtExtKeyInfo_Extended_Keypath;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"ExtKeyInfo.Extended", Namespace="GxBitcoinWallet")]
	public class SdtExtKeyInfo_Extended_RESTInterface : GxGenericCollectionItem<SdtExtKeyInfo_Extended>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtExtKeyInfo_Extended_RESTInterface( ) : base()
		{	
		}

		public SdtExtKeyInfo_Extended_RESTInterface( SdtExtKeyInfo_Extended psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PrivateKey", Order=0)]
		public  string gxTpr_Privatekey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Privatekey);

			}
			set { 
				 sdt.gxTpr_Privatekey = value;
			}
		}

		[DataMember(Name="PrivateKeySegwitP2SH", Order=1)]
		public  string gxTpr_Privatekeysegwitp2sh
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Privatekeysegwitp2sh);

			}
			set { 
				 sdt.gxTpr_Privatekeysegwitp2sh = value;
			}
		}

		[DataMember(Name="PrivateKeySegwit", Order=2)]
		public  string gxTpr_Privatekeysegwit
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Privatekeysegwit);

			}
			set { 
				 sdt.gxTpr_Privatekeysegwit = value;
			}
		}

		[DataMember(Name="NuterPublicKey", Order=3)]
		public  string gxTpr_Nuterpublickey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nuterpublickey);

			}
			set { 
				 sdt.gxTpr_Nuterpublickey = value;
			}
		}

		[DataMember(Name="NuterPublicKeySegwitP2SH", Order=4)]
		public  string gxTpr_Nuterpublickeysegwitp2sh
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nuterpublickeysegwitp2sh);

			}
			set { 
				 sdt.gxTpr_Nuterpublickeysegwitp2sh = value;
			}
		}

		[DataMember(Name="NuterPublicKeySegwit", Order=5)]
		public  string gxTpr_Nuterpublickeysegwit
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nuterpublickeysegwit);

			}
			set { 
				 sdt.gxTpr_Nuterpublickeysegwit = value;
			}
		}

		[DataMember(Name="ParentFingerprint", Order=6)]
		public  string gxTpr_Parentfingerprint
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Parentfingerprint);

			}
			set { 
				 sdt.gxTpr_Parentfingerprint = value;
			}
		}

		[DataMember(Name="Depth", Order=7)]
		public short gxTpr_Depth
		{
			get { 
				return sdt.gxTpr_Depth;

			}
			set { 
				sdt.gxTpr_Depth = value;
			}
		}

		[DataMember(Name="Child", Order=8)]
		public  string gxTpr_Child
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Child, 10, 0));

			}
			set { 
				sdt.gxTpr_Child = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="isHardended", Order=9)]
		public bool gxTpr_Ishardended
		{
			get { 
				return sdt.gxTpr_Ishardended;

			}
			set { 
				sdt.gxTpr_Ishardended = value;
			}
		}

		[DataMember(Name="keyPath", Order=10)]
		public  string gxTpr_Keypath
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Keypath);

			}
			set { 
				 sdt.gxTpr_Keypath = value;
			}
		}


		#endregion

		public SdtExtKeyInfo_Extended sdt
		{
			get { 
				return (SdtExtKeyInfo_Extended)Sdt;
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
				sdt = new SdtExtKeyInfo_Extended() ;
			}
		}
	}
	#endregion
}