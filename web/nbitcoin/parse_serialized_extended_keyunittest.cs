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
   public class parse_serialized_extended_keyunittest : GXProcedure
   {
      public parse_serialized_extended_keyunittest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public parse_serialized_extended_keyunittest( IGxContext context )
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
         parse_serialized_extended_keyunittest objparse_serialized_extended_keyunittest;
         objparse_serialized_extended_keyunittest = new parse_serialized_extended_keyunittest();
         objparse_serialized_extended_keyunittest.context.SetSubmitInitialConfig(context);
         objparse_serialized_extended_keyunittest.initialize();
         Submit( executePrivateCatch,objparse_serialized_extended_keyunittest);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parse_serialized_extended_keyunittest)stateInfo).executePrivate();
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
         GXt_objcol_Sdtparse_serialized_extended_keyUnitTestSDT1 = AV11GXV1;
         new GeneXus.Programs.nbitcoin.parse_serialized_extended_keyunittestdata(context ).execute( out  GXt_objcol_Sdtparse_serialized_extended_keyUnitTestSDT1) ;
         AV11GXV1 = GXt_objcol_Sdtparse_serialized_extended_keyUnitTestSDT1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV8TestCaseData = ((GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT)AV11GXV1.Item(AV12GXV2));
            GXt_char2 = "";
            GXt_char3 = AV8TestCaseData.gxTpr_Out_extended_key;
            GXt_char4 = AV8TestCaseData.gxTpr_Networktype;
            GXt_char5 = AV8TestCaseData.gxTpr_Extendedkeytype;
            new GeneXus.Programs.nbitcoin.parse_serialized_extended_key(context ).execute(  AV8TestCaseData.gxTpr_In_extended_key, out  GXt_char3, out  GXt_char4, out  GXt_char5, out  GXt_char2) ;
            AV8TestCaseData.gxTpr_Out_extended_key = GXt_char3;
            AV8TestCaseData.gxTpr_Networktype = GXt_char4;
            AV8TestCaseData.gxTpr_Extendedkeytype = GXt_char5;
            AV8TestCaseData.gxTpr_Error = GXt_char2;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedout_extended_key,  AV8TestCaseData.gxTpr_Out_extended_key,  StringUtil.Format( "%1.Expectedout_extended_key: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgout_extended_key, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectednetworktype,  AV8TestCaseData.gxTpr_Networktype,  StringUtil.Format( "%1.ExpectednetworkType: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgnetworktype, "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.gxtest.assertstringequals(context ).execute(  AV8TestCaseData.gxTpr_Expectedextendedkeytype,  AV8TestCaseData.gxTpr_Extendedkeytype,  StringUtil.Format( "%1.ExpectedextendedKeyType: %2", AV8TestCaseData.gxTpr_Testcaseid, AV8TestCaseData.gxTpr_Msgextendedkeytype, "", "", "", "", "", "", "")) ;
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
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT>( context, "parse_serialized_extended_keyUnitTestSDT", "GxBitcoinWallet");
         GXt_objcol_Sdtparse_serialized_extended_keyUnitTestSDT1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT>( context, "parse_serialized_extended_keyUnitTestSDT", "GxBitcoinWallet");
         AV8TestCaseData = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_char4 = "";
         GXt_char5 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV2 ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string GXt_char5 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> GXt_objcol_Sdtparse_serialized_extended_keyUnitTestSDT1 ;
      private GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT AV8TestCaseData ;
   }

}
