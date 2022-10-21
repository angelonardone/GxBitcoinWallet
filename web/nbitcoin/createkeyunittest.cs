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
   public class createkeyunittest : GXProcedure
   {
      public createkeyunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createkeyunittest( IGxContext context )
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
         createkeyunittest objcreatekeyunittest;
         objcreatekeyunittest = new createkeyunittest();
         objcreatekeyunittest.context.SetSubmitInitialConfig(context);
         objcreatekeyunittest.initialize();
         Submit( executePrivateCatch,objcreatekeyunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createkeyunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdtCreateKeyUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.createkeyunittestdata(context ).execute( out  GXt_objcol_SdtCreateKeyUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtCreateKeyUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_SdtKeyInfo3 = AV8TestCaseData.gxTpr_Keyinfo;
            new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV8TestCaseData.gxTpr_Keycreate,  AV8TestCaseData.gxTpr_Password, out  GXt_SdtKeyInfo3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Keyinfo = GXt_SdtKeyInfo3;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT>( context, "CreateKeyUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdtCreateKeyUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT>( context, "CreateKeyUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         GXt_char2 = "";
         GXt_SdtKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> GXt_objcol_SdtCreateKeyUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT AV8TestCaseData ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo GXt_SdtKeyInfo3 ;
   }

}
