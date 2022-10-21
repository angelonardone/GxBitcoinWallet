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
   public class testeccencryptanddecryptunittest : GXProcedure
   {
      public testeccencryptanddecryptunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testeccencryptanddecryptunittest( IGxContext context )
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
         testeccencryptanddecryptunittest objtesteccencryptanddecryptunittest;
         objtesteccencryptanddecryptunittest = new testeccencryptanddecryptunittest();
         objtesteccencryptanddecryptunittest.context.SetSubmitInitialConfig(context);
         objtesteccencryptanddecryptunittest.initialize();
         Submit( executePrivateCatch,objtesteccencryptanddecryptunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testeccencryptanddecryptunittest)stateInfo).executePrivate();
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
         GXt_objcol_SdttestECCencryptANDdecryptUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.testeccencryptanddecryptunittestdata(context ).execute( out  GXt_objcol_SdttestECCencryptANDdecryptUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_SdttestECCencryptANDdecryptUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_boolean2 = false;
            new GeneXus.Programs.nbitcoin.testeccencryptanddecrypt(context ).execute(  AV8TestCaseData.gxTpr_Originalcleartext, out  GXt_boolean2) ;
            AV8TestCaseData.gxTpr_Isverified = GXt_boolean2;
            new GeneXus.Programs.gxtest.assertboolequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedisverified,  AV8TestCaseData.gxTpr_Isverified,  StringUtil.Format( "%1.ExpectedisVerified: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgisverified, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT>( context, "testECCencryptANDdecryptUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_SdttestECCencryptANDdecryptUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT>( context, "testECCencryptANDdecryptUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private bool GXt_boolean2 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> GXt_objcol_SdttestECCencryptANDdecryptUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT AV8TestCaseData ;
   }

}
