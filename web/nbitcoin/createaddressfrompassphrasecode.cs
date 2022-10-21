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
   public class createaddressfrompassphrasecode : GXProcedure
   {
      public createaddressfrompassphrasecode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createaddressfrompassphrasecode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_passphrase ,
                           string aP1_networkType ,
                           out GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ,
                           out string aP3_error )
      {
         this.AV10passphrase = aP0_passphrase;
         this.AV11networkType = aP1_networkType;
         this.AV9fromPassphraseCode = new GeneXus.Programs.nbitcoin.SdtFromPassphraseCode(context) ;
         this.AV12error = "" ;
         initialize();
         executePrivate();
         aP2_fromPassphraseCode=this.AV9fromPassphraseCode;
         aP3_error=this.AV12error;
      }

      public string executeUdp( string aP0_passphrase ,
                                string aP1_networkType ,
                                out GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode )
      {
         execute(aP0_passphrase, aP1_networkType, out aP2_fromPassphraseCode, out aP3_error);
         return AV12error ;
      }

      public void executeSubmit( string aP0_passphrase ,
                                 string aP1_networkType ,
                                 out GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ,
                                 out string aP3_error )
      {
         createaddressfrompassphrasecode objcreateaddressfrompassphrasecode;
         objcreateaddressfrompassphrasecode = new createaddressfrompassphrasecode();
         objcreateaddressfrompassphrasecode.AV10passphrase = aP0_passphrase;
         objcreateaddressfrompassphrasecode.AV11networkType = aP1_networkType;
         objcreateaddressfrompassphrasecode.AV9fromPassphraseCode = new GeneXus.Programs.nbitcoin.SdtFromPassphraseCode(context) ;
         objcreateaddressfrompassphrasecode.AV12error = "" ;
         objcreateaddressfrompassphrasecode.context.SetSubmitInitialConfig(context);
         objcreateaddressfrompassphrasecode.initialize();
         Submit( executePrivateCatch,objcreateaddressfrompassphrasecode);
         aP2_fromPassphraseCode=this.AV9fromPassphraseCode;
         aP3_error=this.AV12error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createaddressfrompassphrasecode)stateInfo).executePrivate();
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
         /* User Code */
          NBitcoin.Network network;
         /* User Code */
          network = NBitcoin.Network.Main;
         if ( StringUtil.StrCmp(AV11networkType, "Main") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.Main;
         }
         else if ( StringUtil.StrCmp(AV11networkType, "TestNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.TestNet;
         }
         else if ( StringUtil.StrCmp(AV11networkType, "RegTest") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.RegTest;
         }
         else
         {
            AV12error = "Network Type not sopported";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
         {
            /* User Code */
             try
            /* User Code */
             {
            /* User Code */
             string code = AV10passphrase;
            /* User Code */
             var passphraseCodeGeneratedMain = new NBitcoin.BitcoinPassphraseCode(code , network);
            /* User Code */
             NBitcoin.EncryptedKeyResult encryptedKeyResult = passphraseCodeGeneratedMain.GenerateEncryptedSecret();
            /* User Code */
             AV8Code = encryptedKeyResult.GeneratedAddress.ToString();
            AV9fromPassphraseCode.gxTpr_Address = AV8Code;
            /* User Code */
             AV8Code = encryptedKeyResult.EncryptedKey.ToString();
            AV9fromPassphraseCode.gxTpr_Encriptedkey = AV8Code;
            /* User Code */
             AV8Code = encryptedKeyResult.ConfirmationCode.ToString();
            AV9fromPassphraseCode.gxTpr_Confirmationcode = AV8Code;
            /* User Code */
            	}
            /* User Code */
            	catch (Exception ex)
            /* User Code */
            	{
            /* User Code */
            		AV12error = ex.Message.ToString();
            /* User Code */
            	}
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
         AV9fromPassphraseCode = new GeneXus.Programs.nbitcoin.SdtFromPassphraseCode(context);
         AV12error = "";
         AV8Code = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV10passphrase ;
      private string AV11networkType ;
      private string AV12error ;
      private string AV8Code ;
      private GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ;
      private string aP3_error ;
      private GeneXus.Programs.nbitcoin.SdtFromPassphraseCode AV9fromPassphraseCode ;
   }

}
