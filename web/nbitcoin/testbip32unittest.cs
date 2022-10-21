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
   public class testbip32unittest : GXProcedure
   {
      public testbip32unittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testbip32unittest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         testbip32unittest objtestbip32unittest;
         objtestbip32unittest = new testbip32unittest();
         objtestbip32unittest.context.SetSubmitInitialConfig(context);
         objtestbip32unittest.initialize();
         Submit( executePrivateCatch,objtestbip32unittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testbip32unittest)stateInfo).executePrivate();
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
         AV12GXV2 = 1;
         GXt_objcol_SdttestBIP32UnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.testbip32unittestdata(context ).execute( out  GXt_objcol_SdttestBIP32UnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdttestBIP32UnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_Sdttest_BIP32_out3 = AV8TestCaseData.gxTpr_Test_bip32_out;
            new GeneXus.Programs.nbitcoin.testbip32(context ).execute(  AV8TestCaseData.gxTpr_Test_bip32_in, out  GXt_Sdttest_BIP32_out3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Test_bip32_out = GXt_Sdttest_BIP32_out3;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedtest_bip32_out.ToJSonString(false, true),  AV8TestCaseData.gxTpr_Test_bip32_out.ToJSonString(false, true),  StringUtil.Format( "%1.Expectedtest_BIP32_out: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgtest_bip32_out, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectederror,  AV8TestCaseData.gxTpr_Error,  StringUtil.Format( "%1.Expectederror: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgerror, "", "", "", "", "", "", "")) ;
            AV12GXV2 = (int)(AV12GXV2+1);
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT>( context, "testBIP32UnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdttestBIP32UnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT>( context, "testBIP32UnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         GXt_char2 = "";
         GXt_Sdttest_BIP32_out3 = new GeneXus.Programs.nbitcoin.Sdttest_BIP32_out(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> GXt_objcol_SdttestBIP32UnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT AV8TestCaseData ;
      private GeneXus.Programs.nbitcoin.Sdttest_BIP32_out GXt_Sdttest_BIP32_out3 ;
   }

}
