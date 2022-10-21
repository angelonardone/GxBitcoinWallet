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
   public class testbip32 : GXProcedure
   {
      public testbip32( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testbip32( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.Sdttest_BIP32_in aP0_test_BIP32_in ,
                           out GeneXus.Programs.nbitcoin.Sdttest_BIP32_out aP1_test_BIP32_out ,
                           out string aP2_error )
      {
         this.AV8test_BIP32_in = aP0_test_BIP32_in;
         this.AV9test_BIP32_out = new GeneXus.Programs.nbitcoin.Sdttest_BIP32_out(context) ;
         this.AV10error = "" ;
         initialize();
         executePrivate();
         aP1_test_BIP32_out=this.AV9test_BIP32_out;
         aP2_error=this.AV10error;
      }

      public string executeUdp( GeneXus.Programs.nbitcoin.Sdttest_BIP32_in aP0_test_BIP32_in ,
                                out GeneXus.Programs.nbitcoin.Sdttest_BIP32_out aP1_test_BIP32_out )
      {
         execute(aP0_test_BIP32_in, out aP1_test_BIP32_out, out aP2_error);
         return AV10error ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.Sdttest_BIP32_in aP0_test_BIP32_in ,
                                 out GeneXus.Programs.nbitcoin.Sdttest_BIP32_out aP1_test_BIP32_out ,
                                 out string aP2_error )
      {
         testbip32 objtestbip32;
         objtestbip32 = new testbip32();
         objtestbip32.AV8test_BIP32_in = aP0_test_BIP32_in;
         objtestbip32.AV9test_BIP32_out = new GeneXus.Programs.nbitcoin.Sdttest_BIP32_out(context) ;
         objtestbip32.AV10error = "" ;
         objtestbip32.context.SetSubmitInitialConfig(context);
         objtestbip32.initialize();
         Submit( executePrivateCatch,objtestbip32);
         aP1_test_BIP32_out=this.AV9test_BIP32_out;
         aP2_error=this.AV10error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testbip32)stateInfo).executePrivate();
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
         AV11extKeyCreate.gxTpr_Networktype = "Main";
         AV11extKeyCreate.gxTpr_Createextkeytype = 50;
         AV11extKeyCreate.gxTpr_Seed = StringUtil.Trim( AV8test_BIP32_in.gxTpr_Seed);
         AV11extKeyCreate.gxTpr_Keypath = StringUtil.Trim( AV8test_BIP32_in.gxTpr_Path);
         GXt_char1 = AV10error;
         new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV11extKeyCreate,  "", out  AV12extKeyInfo, out  GXt_char1) ;
         AV10error = GXt_char1;
         AV9test_BIP32_out.gxTpr_Xprv = AV12extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
         AV9test_BIP32_out.gxTpr_Xpub = AV12extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickey;
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
         AV9test_BIP32_out = new GeneXus.Programs.nbitcoin.Sdttest_BIP32_out(context);
         AV10error = "";
         AV11extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         GXt_char1 = "";
         AV12extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV10error ;
      private string GXt_char1 ;
      private GeneXus.Programs.nbitcoin.Sdttest_BIP32_out aP1_test_BIP32_out ;
      private string aP2_error ;
      private GeneXus.Programs.nbitcoin.Sdttest_BIP32_in AV8test_BIP32_in ;
      private GeneXus.Programs.nbitcoin.Sdttest_BIP32_out AV9test_BIP32_out ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV11extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV12extKeyInfo ;
   }

}
