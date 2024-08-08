/*
				   File: type_SdtExtPubKeyInfo
			Description: ExtPubKeyInfo
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
	[XmlRoot(ElementName="ExtPubKeyInfo")]
	[XmlType(TypeName="ExtPubKeyInfo" , Namespace="GxBitcoinWallet" )]
	[Serializable]
	public class SdtExtPubKeyInfo : GxUserType
	{
		public SdtExtPubKeyInfo( )
		{
			/* Constructor for serialization */
			gxTv_SdtExtPubKeyInfo_Publickey = "";

			gxTv_SdtExtPubKeyInfo_Publickeysegwitp2sh = "";

			gxTv_SdtExtPubKeyInfo_Publickeysegwit = "";

			gxTv_SdtExtPubKeyInfo_Addresslegacy = "";

			gxTv_SdtExtPubKeyInfo_Addresssegwitp2sh = "";

			gxTv_SdtExtPubKeyInfo_Addresssegwit = "";

			gxTv_SdtExtPubKeyInfo_Parentfingerprint = "";

			gxTv_SdtExtPubKeyInfo_Keypath = "";

		}

		public SdtExtPubKeyInfo(IGxContext context)
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
			AddObjectProperty("PublicKey", gxTpr_Publickey, false);


			AddObjectProperty("PublicKeySegwitP2SH", gxTpr_Publickeysegwitp2sh, false);


			AddObjectProperty("PublicKeySegwit", gxTpr_Publickeysegwit, false);


			AddObjectProperty("AddressLegacy", gxTpr_Addresslegacy, false);


			AddObjectProperty("AddressSegwitP2SH", gxTpr_Addresssegwitp2sh, false);


			AddObjectProperty("AddressSegwit", gxTpr_Addresssegwit, false);


			AddObjectProperty("ParentFingerprint", gxTpr_Parentfingerprint, false);


			AddObjectProperty("Depth", gxTpr_Depth, false);


			AddObjectProperty("Child", gxTpr_Child, false);


			AddObjectProperty("isHardended", gxTpr_Ishardended, false);


			AddObjectProperty("keyPath", gxTpr_Keypath, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PublicKey")]
		[XmlElement(ElementName="PublicKey")]
		public string gxTpr_Publickey
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Publickey; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Publickey = value;
				SetDirty("Publickey");
			}
		}




		[SoapElement(ElementName="PublicKeySegwitP2SH")]
		[XmlElement(ElementName="PublicKeySegwitP2SH")]
		public string gxTpr_Publickeysegwitp2sh
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Publickeysegwitp2sh; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Publickeysegwitp2sh = value;
				SetDirty("Publickeysegwitp2sh");
			}
		}




		[SoapElement(ElementName="PublicKeySegwit")]
		[XmlElement(ElementName="PublicKeySegwit")]
		public string gxTpr_Publickeysegwit
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Publickeysegwit; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Publickeysegwit = value;
				SetDirty("Publickeysegwit");
			}
		}




		[SoapElement(ElementName="AddressLegacy")]
		[XmlElement(ElementName="AddressLegacy")]
		public string gxTpr_Addresslegacy
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Addresslegacy; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Addresslegacy = value;
				SetDirty("Addresslegacy");
			}
		}




		[SoapElement(ElementName="AddressSegwitP2SH")]
		[XmlElement(ElementName="AddressSegwitP2SH")]
		public string gxTpr_Addresssegwitp2sh
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Addresssegwitp2sh; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Addresssegwitp2sh = value;
				SetDirty("Addresssegwitp2sh");
			}
		}




		[SoapElement(ElementName="AddressSegwit")]
		[XmlElement(ElementName="AddressSegwit")]
		public string gxTpr_Addresssegwit
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Addresssegwit; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Addresssegwit = value;
				SetDirty("Addresssegwit");
			}
		}




		[SoapElement(ElementName="ParentFingerprint")]
		[XmlElement(ElementName="ParentFingerprint")]
		public string gxTpr_Parentfingerprint
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Parentfingerprint; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Parentfingerprint = value;
				SetDirty("Parentfingerprint");
			}
		}




		[SoapElement(ElementName="Depth")]
		[XmlElement(ElementName="Depth")]
		public short gxTpr_Depth
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Depth; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Depth = value;
				SetDirty("Depth");
			}
		}




		[SoapElement(ElementName="Child")]
		[XmlElement(ElementName="Child")]
		public long gxTpr_Child
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Child; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Child = value;
				SetDirty("Child");
			}
		}




		[SoapElement(ElementName="isHardended")]
		[XmlElement(ElementName="isHardended")]
		public bool gxTpr_Ishardended
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Ishardended; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Ishardended = value;
				SetDirty("Ishardended");
			}
		}




		[SoapElement(ElementName="keyPath")]
		[XmlElement(ElementName="keyPath")]
		public string gxTpr_Keypath
		{
			get {
				return gxTv_SdtExtPubKeyInfo_Keypath; 
			}
			set {
				gxTv_SdtExtPubKeyInfo_Keypath = value;
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
			gxTv_SdtExtPubKeyInfo_Publickey = "";
			gxTv_SdtExtPubKeyInfo_Publickeysegwitp2sh = "";
			gxTv_SdtExtPubKeyInfo_Publickeysegwit = "";
			gxTv_SdtExtPubKeyInfo_Addresslegacy = "";
			gxTv_SdtExtPubKeyInfo_Addresssegwitp2sh = "";
			gxTv_SdtExtPubKeyInfo_Addresssegwit = "";
			gxTv_SdtExtPubKeyInfo_Parentfingerprint = "";



			gxTv_SdtExtPubKeyInfo_Keypath = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtExtPubKeyInfo_Publickey;
		 

		protected string gxTv_SdtExtPubKeyInfo_Publickeysegwitp2sh;
		 

		protected string gxTv_SdtExtPubKeyInfo_Publickeysegwit;
		 

		protected string gxTv_SdtExtPubKeyInfo_Addresslegacy;
		 

		protected string gxTv_SdtExtPubKeyInfo_Addresssegwitp2sh;
		 

		protected string gxTv_SdtExtPubKeyInfo_Addresssegwit;
		 

		protected string gxTv_SdtExtPubKeyInfo_Parentfingerprint;
		 

		protected short gxTv_SdtExtPubKeyInfo_Depth;
		 

		protected long gxTv_SdtExtPubKeyInfo_Child;
		 

		protected bool gxTv_SdtExtPubKeyInfo_Ishardended;
		 

		protected string gxTv_SdtExtPubKeyInfo_Keypath;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"ExtPubKeyInfo", Namespace="GxBitcoinWallet")]
	public class SdtExtPubKeyInfo_RESTInterface : GxGenericCollectionItem<SdtExtPubKeyInfo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtExtPubKeyInfo_RESTInterface( ) : base()
		{	
		}

		public SdtExtPubKeyInfo_RESTInterface( SdtExtPubKeyInfo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PublicKey", Order=0)]
		public  string gxTpr_Publickey
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publickey);

			}
			set { 
				 sdt.gxTpr_Publickey = value;
			}
		}

		[DataMember(Name="PublicKeySegwitP2SH", Order=1)]
		public  string gxTpr_Publickeysegwitp2sh
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publickeysegwitp2sh);

			}
			set { 
				 sdt.gxTpr_Publickeysegwitp2sh = value;
			}
		}

		[DataMember(Name="PublicKeySegwit", Order=2)]
		public  string gxTpr_Publickeysegwit
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publickeysegwit);

			}
			set { 
				 sdt.gxTpr_Publickeysegwit = value;
			}
		}

		[DataMember(Name="AddressLegacy", Order=3)]
		public  string gxTpr_Addresslegacy
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Addresslegacy);

			}
			set { 
				 sdt.gxTpr_Addresslegacy = value;
			}
		}

		[DataMember(Name="AddressSegwitP2SH", Order=4)]
		public  string gxTpr_Addresssegwitp2sh
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Addresssegwitp2sh);

			}
			set { 
				 sdt.gxTpr_Addresssegwitp2sh = value;
			}
		}

		[DataMember(Name="AddressSegwit", Order=5)]
		public  string gxTpr_Addresssegwit
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Addresssegwit);

			}
			set { 
				 sdt.gxTpr_Addresssegwit = value;
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

		public SdtExtPubKeyInfo sdt
		{
			get { 
				return (SdtExtPubKeyInfo)Sdt;
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
				sdt = new SdtExtPubKeyInfo() ;
			}
		}
	}
	#endregion
}