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
         context.SetDefaultTheme("Carmine");
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
         this.AV10deserializedExtPubKey = aP0_deserializedExtPubKey;
         this.AV9base = aP1_base;
         this.AV18start = aP2_start;
         this.AV16end = aP3_end;
         this.AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context) ;
         this.AV11error = "" ;
         initialize();
         executePrivate();
         aP4_sdt_addressess=this.AV20sdt_addressess;
         aP5_error=this.AV11error;
      }

      public string executeUdp( string aP0_deserializedExtPubKey ,
                                long aP1_base ,
                                long aP2_start ,
                                long aP3_end ,
                                out GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess )
      {
         execute(aP0_deserializedExtPubKey, aP1_base, aP2_start, aP3_end, out aP4_sdt_addressess, out aP5_error);
         return AV11error ;
      }

      public void executeSubmit( string aP0_deserializedExtPubKey ,
                                 long aP1_base ,
                                 long aP2_start ,
                                 long aP3_end ,
                                 out GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess ,
                                 out string aP5_error )
      {
         deriveaddressfromextpubkey objderiveaddressfromextpubkey;
         objderiveaddressfromextpubkey = new deriveaddressfromextpubkey();
         objderiveaddressfromextpubkey.AV10deserializedExtPubKey = aP0_deserializedExtPubKey;
         objderiveaddressfromextpubkey.AV9base = aP1_base;
         objderiveaddressfromextpubkey.AV18start = aP2_start;
         objderiveaddressfromextpubkey.AV16end = aP3_end;
         objderiveaddressfromextpubkey.AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context) ;
         objderiveaddressfromextpubkey.AV11error = "" ;
         objderiveaddressfromextpubkey.context.SetSubmitInitialConfig(context);
         objderiveaddressfromextpubkey.initialize();
         Submit( executePrivateCatch,objderiveaddressfromextpubkey);
         aP4_sdt_addressess=this.AV20sdt_addressess;
         aP5_error=this.AV11error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deriveaddressfromextpubkey)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV11error;
         new GeneXus.Programs.nbitcoin.parse_serialized_extended_key(context ).execute(  AV10deserializedExtPubKey, out  AV13extendedPublicKey, out  AV15networkType, out  AV12extendedKeyType, out  GXt_char1) ;
         AV11error = GXt_char1;
         AV19base_char = "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV9base), 10, 0)) + "/";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
         {
            AV18start = 0;
            while ( AV18start <= AV16end )
            {
               GXt_char1 = AV11error;
               new GeneXus.Programs.nbitcoin.createexpubtkey(context ).execute(  AV13extendedPublicKey,  AV15networkType,  AV19base_char+StringUtil.Trim( StringUtil.Str( (decimal)(AV18start), 10, 0)), out  AV14extPubKeyInfo, out  GXt_char1) ;
               AV11error = GXt_char1;
               if ( StringUtil.StrCmp(AV12extendedKeyType, "x") == 0 )
               {
                  AV17one_address = AV14extPubKeyInfo.gxTpr_Addresslegacy;
               }
               else if ( StringUtil.StrCmp(AV12extendedKeyType, "y") == 0 )
               {
                  AV17one_address = AV14extPubKeyInfo.gxTpr_Addresssegwitp2sh;
               }
               else if ( StringUtil.StrCmp(AV12extendedKeyType, "z") == 0 )
               {
                  AV17one_address = AV14extPubKeyInfo.gxTpr_Addresssegwit;
               }
               else
               {
                  AV11error = "Extended type not found";
               }
               AV20sdt_addressess.gxTpr_Address.Add(AV17one_address, 0);
               AV18start = (long)(AV18start+1);
            }
         }
         else
         {
            GX_msglist.addItem(AV11error);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV20sdt_addressess = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         AV11error = "";
         AV13extendedPublicKey = "";
         AV15networkType = "";
         AV12extendedKeyType = "";
         AV19base_char = "";
         GXt_char1 = "";
         AV14extPubKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo(context);
         AV17one_address = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV9base ;
      private long AV18start ;
      private long AV16end ;
      private string AV10deserializedExtPubKey ;
      private string AV11error ;
      private string AV13extendedPublicKey ;
      private string AV15networkType ;
      private string AV12extendedKeyType ;
      private string AV19base_char ;
      private string GXt_char1 ;
      private string AV17one_address ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP4_sdt_addressess ;
      private string aP5_error ;
      private GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo AV14extPubKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV20sdt_addressess ;
   }

}
