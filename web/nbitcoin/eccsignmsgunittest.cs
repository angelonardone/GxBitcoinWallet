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
   public class eccsignmsgunittest : GXProcedure
   {
      public eccsignmsgunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccsignmsgunittest( IGxContext context )
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
         eccsignmsgunittest objeccsignmsgunittest;
         objeccsignmsgunittest = new eccsignmsgunittest();
         objeccsignmsgunittest.context.SetSubmitInitialConfig(context);
         objeccsignmsgunittest.initialize();
         Submit( executePrivateCatch,objeccsignmsgunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccsignmsgunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdtECCsignMsgUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.eccsignmsgunittestdata(context ).execute( out  GXt_objcol_SdtECCsignMsgUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtECCsignMsgUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_char3 = AV8TestCaseData.gxTpr_Signature;
            new GeneXus.Programs.nbitcoin.eccsignmsg(context ).execute(  AV8TestCaseData.gxTpr_Privatekey,  AV8TestCaseData.gxTpr_Message, out  GXt_char3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Signature = GXt_char3;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedsignature,  AV8TestCaseData.gxTpr_Signature,  StringUtil.Format( "%1.Expectedsignature: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgsignature, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT>( context, "ECCsignMsgUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdtECCsignMsgUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT>( context, "ECCsignMsgUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT(context);
         GXt_char2 = "";
         GXt_char3 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> GXt_objcol_SdtECCsignMsgUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT AV8TestCaseData ;
   }

}
