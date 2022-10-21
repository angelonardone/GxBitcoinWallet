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
   public class testslip0132 : GXProcedure
   {
      public testslip0132( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testslip0132( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_in aP0_test_SLIP0132_in ,
                           out GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out aP1_test_SLIP0132_out ,
                           out string aP2_error )
      {
         this.AV12test_SLIP0132_in = aP0_test_SLIP0132_in;
         this.AV13test_SLIP0132_out = new GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out(context) ;
         this.AV8error = "" ;
         initialize();
         executePrivate();
         aP1_test_SLIP0132_out=this.AV13test_SLIP0132_out;
         aP2_error=this.AV8error;
      }

      public string executeUdp( GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_in aP0_test_SLIP0132_in ,
                                out GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out aP1_test_SLIP0132_out )
      {
         execute(aP0_test_SLIP0132_in, out aP1_test_SLIP0132_out, out aP2_error);
         return AV8error ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_in aP0_test_SLIP0132_in ,
                                 out GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out aP1_test_SLIP0132_out ,
                                 out string aP2_error )
      {
         testslip0132 objtestslip0132;
         objtestslip0132 = new testslip0132();
         objtestslip0132.AV12test_SLIP0132_in = aP0_test_SLIP0132_in;
         objtestslip0132.AV13test_SLIP0132_out = new GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out(context) ;
         objtestslip0132.AV8error = "" ;
         objtestslip0132.context.SetSubmitInitialConfig(context);
         objtestslip0132.initialize();
         Submit( executePrivateCatch,objtestslip0132);
         aP1_test_SLIP0132_out=this.AV13test_SLIP0132_out;
         aP2_error=this.AV8error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testslip0132)stateInfo).executePrivate();
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
         if ( AV12test_SLIP0132_in.gxTpr_Testmethod == 1 )
         {
            AV9extKeyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
            AV9extKeyCreate.gxTpr_Keypath = "";
            AV9extKeyCreate.gxTpr_Createextkeytype = 30;
            AV9extKeyCreate.gxTpr_Mnemoniclanguage = 10;
            AV9extKeyCreate.gxTpr_Createtext = AV12test_SLIP0132_in.gxTpr_Mnemonic;
            GXt_char1 = AV8error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV9extKeyCreate,  "", out  AV11rootExtKeyInfo, out  GXt_char1) ;
            AV8error = GXt_char1;
            AV9extKeyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
            AV9extKeyCreate.gxTpr_Keypath = AV12test_SLIP0132_in.gxTpr_Rootpath;
            AV9extKeyCreate.gxTpr_Createextkeytype = 70;
            AV9extKeyCreate.gxTpr_Extendedprivatekey = AV11rootExtKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
            GXt_char1 = AV8error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV9extKeyCreate,  "", out  AV10extKeyInfo, out  GXt_char1) ;
            AV8error = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
            {
               if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 0 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickey;
               }
               else if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 2 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh;
               }
               else if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 1 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekeysegwit;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit;
               }
               else
               {
                  AV8error = "Address Type not sopported";
               }
               AV9extKeyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
               AV9extKeyCreate.gxTpr_Keypath = AV12test_SLIP0132_in.gxTpr_Derivepathaddress;
               AV9extKeyCreate.gxTpr_Createextkeytype = 70;
               AV9extKeyCreate.gxTpr_Extendedprivatekey = AV11rootExtKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
               GXt_char1 = AV8error;
               new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV9extKeyCreate,  "", out  AV10extKeyInfo, out  GXt_char1) ;
               AV8error = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
               {
                  AV14keyCreate.gxTpr_Createkeytype = 30;
                  AV14keyCreate.gxTpr_Createtext = AV10extKeyInfo.gxTpr_Privatekey;
                  AV14keyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
                  AV14keyCreate.gxTpr_Addresstype = AV12test_SLIP0132_in.gxTpr_Addresstype;
                  GXt_char1 = AV8error;
                  new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV14keyCreate,  "", out  AV15keyInfo, out  GXt_char1) ;
                  AV8error = GXt_char1;
                  AV13test_SLIP0132_out.gxTpr_Derivedaddress = AV15keyInfo.gxTpr_Address;
               }
            }
         }
         else if ( AV12test_SLIP0132_in.gxTpr_Testmethod == 2 )
         {
            AV9extKeyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
            AV9extKeyCreate.gxTpr_Keypath = AV12test_SLIP0132_in.gxTpr_Rootpath;
            AV9extKeyCreate.gxTpr_Createextkeytype = 30;
            AV9extKeyCreate.gxTpr_Mnemoniclanguage = 10;
            AV9extKeyCreate.gxTpr_Createtext = AV12test_SLIP0132_in.gxTpr_Mnemonic;
            GXt_char1 = AV8error;
            new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV9extKeyCreate,  "", out  AV10extKeyInfo, out  GXt_char1) ;
            AV8error = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
            {
               if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 0 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickey;
               }
               else if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 2 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh;
               }
               else if ( AV12test_SLIP0132_in.gxTpr_Addresstype == 1 )
               {
                  AV13test_SLIP0132_out.gxTpr_Extprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekeysegwit;
                  AV13test_SLIP0132_out.gxTpr_Extpublickey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit;
               }
               else
               {
                  AV8error = "Address Type not sopported";
               }
               AV9extKeyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
               AV9extKeyCreate.gxTpr_Keypath = AV12test_SLIP0132_in.gxTpr_Derivepathaddress;
               AV9extKeyCreate.gxTpr_Createextkeytype = 70;
               AV9extKeyCreate.gxTpr_Extendedprivatekey = AV10extKeyInfo.gxTpr_Extended.gxTpr_Privatekey;
               GXt_char1 = AV8error;
               new GeneXus.Programs.nbitcoin.createextkey(context ).execute(  AV9extKeyCreate,  "", out  AV10extKeyInfo, out  GXt_char1) ;
               AV8error = GXt_char1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
               {
                  AV14keyCreate.gxTpr_Createkeytype = 30;
                  AV14keyCreate.gxTpr_Createtext = AV10extKeyInfo.gxTpr_Privatekey;
                  AV14keyCreate.gxTpr_Networktype = AV12test_SLIP0132_in.gxTpr_Networktype;
                  AV14keyCreate.gxTpr_Addresstype = AV12test_SLIP0132_in.gxTpr_Addresstype;
                  GXt_char1 = AV8error;
                  new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV14keyCreate,  "", out  AV15keyInfo, out  GXt_char1) ;
                  AV8error = GXt_char1;
                  AV13test_SLIP0132_out.gxTpr_Derivedaddress = AV15keyInfo.gxTpr_Address;
               }
            }
         }
         else
         {
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
         AV13test_SLIP0132_out = new GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out(context);
         AV8error = "";
         AV9extKeyCreate = new GeneXus.Programs.nbitcoin.SdtExtKeyCreate(context);
         AV11rootExtKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV10extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV14keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         AV15keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8error ;
      private string GXt_char1 ;
      private GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out aP1_test_SLIP0132_out ;
      private string aP2_error ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyCreate AV9extKeyCreate ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV11rootExtKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV10extKeyInfo ;
      private GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_in AV12test_SLIP0132_in ;
      private GeneXus.Programs.nbitcoin.Sdttest_SLIP0132_out AV13test_SLIP0132_out ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV14keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV15keyInfo ;
   }

}
