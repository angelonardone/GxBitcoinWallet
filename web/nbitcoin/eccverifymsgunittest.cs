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
   public class eccverifymsgunittest : GXProcedure
   {
      public eccverifymsgunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccverifymsgunittest( IGxContext context )
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
         eccverifymsgunittest objeccverifymsgunittest;
         objeccverifymsgunittest = new eccverifymsgunittest();
         objeccverifymsgunittest.context.SetSubmitInitialConfig(context);
         objeccverifymsgunittest.initialize();
         Submit( executePrivateCatch,objeccverifymsgunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccverifymsgunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdtECCverifyMsgUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.eccverifymsgunittestdata(context ).execute( out  GXt_objcol_SdtECCverifyMsgUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtECCverifyMsgUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_boolean3 = AV8TestCaseData.gxTpr_Verified;
            new GeneXus.Programs.nbitcoin.eccverifymsg(context ).execute(  AV8TestCaseData.gxTpr_Pubkey,  AV8TestCaseData.gxTpr_Message,  AV8TestCaseData.gxTpr_Signature, out  GXt_boolean3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Verified = GXt_boolean3;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedverified,  AV8TestCaseData.gxTpr_Verified,  StringUtil.Format( "%1.Expectedverified: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgverified, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT>( context, "ECCverifyMsgUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdtECCverifyMsgUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT>( context, "ECCverifyMsgUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT(context);
         GXt_char2 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private bool GXt_boolean3 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> GXt_objcol_SdtECCverifyMsgUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT AV8TestCaseData ;
   }

}
