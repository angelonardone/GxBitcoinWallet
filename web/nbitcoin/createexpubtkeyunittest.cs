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
   public class createexpubtkeyunittest : GXProcedure
   {
      public createexpubtkeyunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createexpubtkeyunittest( IGxContext context )
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
         createexpubtkeyunittest objcreateexpubtkeyunittest;
         objcreateexpubtkeyunittest = new createexpubtkeyunittest();
         objcreateexpubtkeyunittest.context.SetSubmitInitialConfig(context);
         objcreateexpubtkeyunittest.initialize();
         Submit( executePrivateCatch,objcreateexpubtkeyunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createexpubtkeyunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdtCreateExPubtKeyUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.createexpubtkeyunittestdata(context ).execute( out  GXt_objcol_SdtCreateExPubtKeyUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtCreateExPubtKeyUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_SdtExtPubKeyInfo3 = AV8TestCaseData.gxTpr_Keyinfo;
            new GeneXus.Programs.nbitcoin.createexpubtkey(context ).execute(  AV8TestCaseData.gxTpr_Extendedpublickey,  AV8TestCaseData.gxTpr_Networktype,  AV8TestCaseData.gxTpr_Keypath, out  GXt_SdtExtPubKeyInfo3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Keyinfo = GXt_SdtExtPubKeyInfo3;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedkeyinfo.ToJSonString(false, true),  AV8TestCaseData.gxTpr_Keyinfo.ToJSonString(false, true),  StringUtil.Format( "%1.ExpectedkeyInfo: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgkeyinfo, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT>( context, "CreateExPubtKeyUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdtCreateExPubtKeyUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT>( context, "CreateExPubtKeyUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         GXt_char2 = "";
         GXt_SdtExtPubKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> GXt_objcol_SdtCreateExPubtKeyUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT AV8TestCaseData ;
      private GeneXus.Programs.nbitcoin.SdtExtPubKeyInfo GXt_SdtExtPubKeyInfo3 ;
   }

}
