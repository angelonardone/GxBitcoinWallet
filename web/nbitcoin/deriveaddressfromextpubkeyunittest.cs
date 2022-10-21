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
   public class deriveaddressfromextpubkeyunittest : GXProcedure
   {
      public deriveaddressfromextpubkeyunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public deriveaddressfromextpubkeyunittest( IGxContext context )
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
         deriveaddressfromextpubkeyunittest objderiveaddressfromextpubkeyunittest;
         objderiveaddressfromextpubkeyunittest = new deriveaddressfromextpubkeyunittest();
         objderiveaddressfromextpubkeyunittest.context.SetSubmitInitialConfig(context);
         objderiveaddressfromextpubkeyunittest.initialize();
         Submit( executePrivateCatch,objderiveaddressfromextpubkeyunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deriveaddressfromextpubkeyunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdtderiveAddressFromExtPubKeyUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkeyunittestdata(context ).execute( out  GXt_objcol_SdtderiveAddressFromExtPubKeyUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdtderiveAddressFromExtPubKeyUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_SdtSDT_Addressess3 = AV8TestCaseData.gxTpr_Sdt_addressess;
            new GeneXus.Programs.nbitcoin.deriveaddressfromextpubkey(context ).execute(  AV8TestCaseData.gxTpr_Deserializedextpubkey,  AV8TestCaseData.gxTpr_Base,  AV8TestCaseData.gxTpr_Start,  AV8TestCaseData.gxTpr_End, out  GXt_SdtSDT_Addressess3, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Sdt_addressess = GXt_SdtSDT_Addressess3;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedsdt_addressess.ToJSonString(false, true),  AV8TestCaseData.gxTpr_Sdt_addressess.ToJSonString(false, true),  StringUtil.Format( "%1.Expectedsdt_addressess: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgsdt_addressess, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT>( context, "deriveAddressFromExtPubKeyUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdtderiveAddressFromExtPubKeyUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT>( context, "deriveAddressFromExtPubKeyUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         GXt_char2 = "";
         GXt_SdtSDT_Addressess3 = new GeneXus.Programs.nbitcoin.SdtSDT_Addressess(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> GXt_objcol_SdtderiveAddressFromExtPubKeyUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT AV8TestCaseData ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess GXt_SdtSDT_Addressess3 ;
   }

}
