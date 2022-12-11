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
   public class derivekeysfromextkey : GXProcedure
   {
      public derivekeysfromextkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public derivekeysfromextkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_serializedRootExtKey ,
                           long aP1_base ,
                           long aP2_start ,
                           long aP3_end ,
                           out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP4_allKeyInfo ,
                           out string aP5_error )
      {
         this.AV23serializedRootExtKey = aP0_serializedRootExtKey;
         this.AV9base = aP1_base;
         this.AV19start = aP2_start;
         this.AV12end = aP3_end;
         this.AV32allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet") ;
         this.AV13error = "" ;
         initialize();
         executePrivate();
         aP4_allKeyInfo=this.AV32allKeyInfo;
         aP5_error=this.AV13error;
      }

      public string executeUdp( string aP0_serializedRootExtKey ,
                                long aP1_base ,
                                long aP2_start ,
                                long aP3_end ,
                                out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP4_allKeyInfo )
      {
         execute(aP0_serializedRootExtKey, aP1_base, aP2_start, aP3_end, out aP4_allKeyInfo, out aP5_error);
         return AV13error ;
      }

      public void executeSubmit( string aP0_serializedRootExtKey ,
                                 long aP1_base ,
                                 long aP2_start ,
                                 long aP3_end ,
                                 out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP4_allKeyInfo ,
                                 out string aP5_error )
      {
         derivekeysfromextkey objderivekeysfromextkey;
         objderivekeysfromextkey = new derivekeysfromextkey();
         objderivekeysfromextkey.AV23serializedRootExtKey = aP0_serializedRootExtKey;
         objderivekeysfromextkey.AV9base = aP1_base;
         objderivekeysfromextkey.AV19start = aP2_start;
         objderivekeysfromextkey.AV12end = aP3_end;
         objderivekeysfromextkey.AV32allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet") ;
         objderivekeysfromextkey.AV13error = "" ;
         objderivekeysfromextkey.context.SetSubmitInitialConfig(context);
         objderivekeysfromextkey.initialize();
         Submit( executePrivateCatch,objderivekeysfromextkey);
         aP4_allKeyInfo=this.AV32allKeyInfo;
         aP5_error=this.AV13error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((derivekeysfromextkey)stateInfo).executePrivate();
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
         GXt_char1 = AV13error;
         new GeneXus.Programs.nbitcoin.parse_serialized_extended_key(context ).execute(  AV23serializedRootExtKey, out  AV24serializedExtKey, out  AV17networkType, out  AV14extendedKeyType, out  GXt_char1) ;
         AV13error = GXt_char1;
         AV10base_char = "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV9base), 10, 0)) + "/";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13error)) )
         {
            AV26extKeyCreate.gxTpr_Networktype = AV17networkType;
            AV26extKeyCreate.gxTpr_Createextkeytype = 70;
            AV26extKeyCreate.gxTpr_Extendedprivatekey = AV24serializedExtKey;
            AV19start = 0;
            while ( AV19start <= AV12end )
            {
               AV26extKeyCreate.gxTpr_Keypath = AV10base_char+StringUtil.Trim( StringUtil.Str( (decimal)(AV19start), 10, 0));
               GXt_char1 = AV13error;
               new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV26extKeyCreate,  "", out  AV28extKeyInfo, out  GXt_char1) ;
               AV13error = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13error)) )
               {
                  AV30keyCreate.gxTpr_Createkeytype = 30;
                  AV30keyCreate.gxTpr_Createtext = AV28extKeyInfo.gxTpr_Privatekey;
                  AV30keyCreate.gxTpr_Networktype = AV17networkType;
                  if ( StringUtil.StrCmp(AV14extendedKeyType, "x") == 0 )
                  {
                     AV30keyCreate.gxTpr_Addresstype = 0;
                  }
                  else if ( StringUtil.StrCmp(AV14extendedKeyType, "y") == 0 )
                  {
                     AV30keyCreate.gxTpr_Addresstype = 2;
                  }
                  else if ( StringUtil.StrCmp(AV14extendedKeyType, "z") == 0 )
                  {
                     AV30keyCreate.gxTpr_Addresstype = 1;
                  }
                  else
                  {
                     AV13error = "Extended type not found";
                  }
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13error)) )
                  {
                     GXt_char1 = AV13error;
                     new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV30keyCreate,  "", out  AV29keyInfo, out  GXt_char1) ;
                     AV13error = GXt_char1;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13error)) )
                     {
                        AV32allKeyInfo.Add(AV29keyInfo, 0);
                     }
                     else
                     {
                        if (true) break;
                     }
                  }
                  else
                  {
                     if (true) break;
                  }
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
         AV32allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV13error = "";
         AV24serializedExtKey = "";
         AV17networkType = "";
         AV14extendedKeyType = "";
         AV10base_char = "";
         AV26extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV28extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV30keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         GXt_char1 = "";
         AV29keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV9base ;
      private long AV19start ;
      private long AV12end ;
      private string AV23serializedRootExtKey ;
      private string AV13error ;
      private string AV24serializedExtKey ;
      private string AV17networkType ;
      private string AV14extendedKeyType ;
      private string AV10base_char ;
      private string GXt_char1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP4_allKeyInfo ;
      private string aP5_error ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV32allKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV26extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV28extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV30keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV29keyInfo ;
   }

}
