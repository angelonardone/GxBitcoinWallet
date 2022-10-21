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
   public class verifycreatedaddressfrompasscode : GXProcedure
   {
      public verifycreatedaddressfrompasscode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public verifycreatedaddressfrompasscode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_password ,
                           string aP1_networkType ,
                           GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ,
                           out bool aP3_isVerified ,
                           out string aP4_error )
      {
         this.AV11password = aP0_password;
         this.AV10networkType = aP1_networkType;
         this.AV12fromPassphraseCode = aP2_fromPassphraseCode;
         this.AV13isVerified = false ;
         this.AV9error = "" ;
         initialize();
         executePrivate();
         aP3_isVerified=this.AV13isVerified;
         aP4_error=this.AV9error;
      }

      public string executeUdp( string aP0_password ,
                                string aP1_networkType ,
                                GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ,
                                out bool aP3_isVerified )
      {
         execute(aP0_password, aP1_networkType, aP2_fromPassphraseCode, out aP3_isVerified, out aP4_error);
         return AV9error ;
      }

      public void executeSubmit( string aP0_password ,
                                 string aP1_networkType ,
                                 GeneXus.Programs.nbitcoin.SdtFromPassphraseCode aP2_fromPassphraseCode ,
                                 out bool aP3_isVerified ,
                                 out string aP4_error )
      {
         verifycreatedaddressfrompasscode objverifycreatedaddressfrompasscode;
         objverifycreatedaddressfrompasscode = new verifycreatedaddressfrompasscode();
         objverifycreatedaddressfrompasscode.AV11password = aP0_password;
         objverifycreatedaddressfrompasscode.AV10networkType = aP1_networkType;
         objverifycreatedaddressfrompasscode.AV12fromPassphraseCode = aP2_fromPassphraseCode;
         objverifycreatedaddressfrompasscode.AV13isVerified = false ;
         objverifycreatedaddressfrompasscode.AV9error = "" ;
         objverifycreatedaddressfrompasscode.context.SetSubmitInitialConfig(context);
         objverifycreatedaddressfrompasscode.initialize();
         Submit( executePrivateCatch,objverifycreatedaddressfrompasscode);
         aP3_isVerified=this.AV13isVerified;
         aP4_error=this.AV9error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((verifycreatedaddressfrompasscode)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV10networkType, "Main") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.Main;
         }
         else if ( StringUtil.StrCmp(AV10networkType, "TestNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.TestNet;
         }
         else if ( StringUtil.StrCmp(AV10networkType, "RegTest") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.RegTest;
         }
         else
         {
            AV9error = "Network Type not sopported";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            /* User Code */
             try
            /* User Code */
             {
            AV14address = AV12fromPassphraseCode.gxTpr_Address;
            AV15confirmationCode = AV12fromPassphraseCode.gxTpr_Confirmationcode;
            /* User Code */
             string address = AV14address;
            /* User Code */
             string password = AV11password;
            /* User Code */
             string confirmationCode = AV15confirmationCode;
            /* User Code */
             var generatedAddress = NBitcoin.BitcoinAddress.Create(address, network);
            /* User Code */
             NBitcoin.BitcoinConfirmationCode confCode = new NBitcoin.BitcoinConfirmationCode(confirmationCode, network);
            /* User Code */
             Boolean confirmed = confCode.Check(password, generatedAddress);
            /* User Code */
             AV13isVerified = confirmed;
            /* User Code */
            	}
            /* User Code */
            	catch (Exception ex)
            /* User Code */
            	{
            /* User Code */
            		AV9error = ex.Message.ToString();
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
         AV9error = "";
         AV14address = "";
         AV15confirmationCode = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV11password ;
      private string AV10networkType ;
      private string AV9error ;
      private string AV14address ;
      private string AV15confirmationCode ;
      private bool AV13isVerified ;
      private bool aP3_isVerified ;
      private string aP4_error ;
      private GeneXus.Programs.nbitcoin.SdtFromPassphraseCode AV12fromPassphraseCode ;
   }

}
