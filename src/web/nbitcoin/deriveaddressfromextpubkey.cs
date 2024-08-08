using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.nbitcoin {
   public class deriveaddressfromextpubkey : GXProcedure
   {
      public deriveaddressfromextpubkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public deriveaddressfromextpubkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_deserializedExtPubKey ,
                           long aP1_base ,
                           long aP2_start ,
                           long aP3_end ,
                           out GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess ,
                           out string aP5_error )
      {
         this.AV11deserializedExtPubKey = aP0_deserializedExtPubKey;
         this.AV9base = aP1_base;
         this.AV19start = aP2_start;
         this.AV17end = aP3_end;
         this.AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context) ;
         this.AV12error = "" ;
         initialize();
         ExecuteImpl();
         aP4_sdt_addressess=this.AV20sdt_addressess;
         aP5_error=this.AV12error;
      }

      public string executeUdp( string aP0_deserializedExtPubKey ,
                                long aP1_base ,
                                long aP2_start ,
                                long aP3_end ,
                                out GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess )
      {
         execute(aP0_deserializedExtPubKey, aP1_base, aP2_start, aP3_end, out aP4_sdt_addressess, out aP5_error);
         return AV12error ;
      }

      public void executeSubmit( string aP0_deserializedExtPubKey ,
                                 long aP1_base ,
                                 long aP2_start ,
                                 long aP3_end ,
                                 out GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess ,
                                 out string aP5_error )
      {
         this.AV11deserializedExtPubKey = aP0_deserializedExtPubKey;
         this.AV9base = aP1_base;
         this.AV19start = aP2_start;
         this.AV17end = aP3_end;
         this.AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context) ;
         this.AV12error = "" ;
         SubmitImpl();
         aP4_sdt_addressess=this.AV20sdt_addressess;
         aP5_error=this.AV12error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV12error;
         new GeneXus.Programs.nbitcoin.parse_serialized_extended_key(context ).execute(  AV11deserializedExtPubKey, out  AV14extendedPublicKey, out  AV16networkType, out  AV13extendedKeyType, out  GXt_char1) ;
         AV12error = GXt_char1;
         AV10base_char = "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV9base), 10, 0)) + "/";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
         {
            AV19start = 0;
            while ( AV19start <= AV17end )
            {
               GXt_char1 = AV12error;
               new GeneXus.Programs.nbitcoin.createexpubtkey(context ).execute(  AV14extendedPublicKey,  AV16networkType,  AV10base_char+StringUtil.Trim( StringUtil.Str( (decimal)(AV19start), 10, 0)), out  AV15extPubKeyInfo, out  GXt_char1) ;
               AV12error = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
               {
                  if ( StringUtil.StrCmp(AV13extendedKeyType, "x") == 0 )
                  {
                     AV18one_address = AV15extPubKeyInfo.gxTpr_Addresslegacy;
                  }
                  else if ( StringUtil.StrCmp(AV13extendedKeyType, "y") == 0 )
                  {
                     AV18one_address = AV15extPubKeyInfo.gxTpr_Addresssegwitp2sh;
                  }
                  else if ( StringUtil.StrCmp(AV13extendedKeyType, "z") == 0 )
                  {
                     AV18one_address = AV15extPubKeyInfo.gxTpr_Addresssegwit;
                  }
                  else
                  {
                     AV12error = "Extended type not found";
                  }
                  AV20sdt_addressess.gxTpr_Address.Add(AV18one_address, 0);
               }
               else
               {
                  if (true) break;
               }
               AV19start = (long)(AV19start+1);
            }
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV12error = "";
         AV14extendedPublicKey = "";
         AV16networkType = "";
         AV13extendedKeyType = "";
         AV10base_char = "";
         GXt_char1 = "";
         AV15extPubKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo(context);
         AV18one_address = "";
         /* GeneXus formulas. */
      }

      private long AV9base ;
      private long AV19start ;
      private long AV17end ;
      private string AV11deserializedExtPubKey ;
      private string AV12error ;
      private string AV14extendedPublicKey ;
      private string AV16networkType ;
      private string AV13extendedKeyType ;
      private string AV10base_char ;
      private string GXt_char1 ;
      private string AV18one_address ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess ;
      private string aP5_error ;
      private GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo AV15extPubKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV20sdt_addressess ;
   }

}
