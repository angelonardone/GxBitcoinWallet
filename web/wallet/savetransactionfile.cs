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
namespace GeneXus.Programs.wallet {
   public class savetransactionfile : GXProcedure
   {
      public savetransactionfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public savetransactionfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                           out string aP1_error )
      {
         this.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         this.AV8error = "" ;
         initialize();
         executePrivate();
         aP1_error=this.AV8error;
      }

      public string executeUdp( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT )
      {
         execute(aP0_GxExplorer_services_TxoutFromAddressesOUT, out aP1_error);
         return AV8error ;
      }

      public void executeSubmit( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                                 out string aP1_error )
      {
         savetransactionfile objsavetransactionfile;
         objsavetransactionfile = new savetransactionfile();
         objsavetransactionfile.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         objsavetransactionfile.AV8error = "" ;
         objsavetransactionfile.context.SetSubmitInitialConfig(context);
         objsavetransactionfile.initialize();
         Submit( executePrivateCatch,objsavetransactionfile);
         aP1_error=this.AV8error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((savetransactionfile)stateInfo).executePrivate();
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
         GXt_SdtWallet1 = AV13wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV13wallet = GXt_SdtWallet1;
         if ( ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "ImportedWIF") == 0 ) )
         {
            GXt_SdtKeyInfo2 = AV9keyInfo;
            new GeneXus.Programs.wallet.getkey(context ).execute( out  GXt_SdtKeyInfo2) ;
            AV9keyInfo = GXt_SdtKeyInfo2;
            AV15publicKey = AV9keyInfo.gxTpr_Publickey;
         }
         else
         {
            GXt_SdtExtKeyInfo3 = AV16extKeyInfo;
            new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo3) ;
            AV16extKeyInfo = GXt_SdtExtKeyInfo3;
            AV15publicKey = AV16extKeyInfo.gxTpr_Publickey;
         }
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         GXt_boolean5 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
         AV12transactionsFile.Source = AV13wallet.gxTpr_Walletbasedirectory+(GXt_boolean5 ? "/" : "\\")+"transactions.trn";
         AV10textClear = GxExplorer_services_TxoutFromAddressesOUT.ToJSonString(false, true);
         GXt_char6 = AV8error;
         new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV15publicKey,  AV10textClear, out  AV11textEnc, out  GXt_char6) ;
         AV8error = GXt_char6;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
         {
            if ( AV12transactionsFile.Exists() )
            {
               AV12transactionsFile.WriteAllText(AV11textEnc, "");
            }
            else
            {
               AV12transactionsFile.WriteAllText(AV11textEnc, "");
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
         AV8error = "";
         AV13wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV9keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         GXt_SdtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV15publicKey = "";
         AV16extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtExtKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV12transactionsFile = new GxFile(context.GetPhysicalPath());
         AV10textClear = "";
         GXt_char6 = "";
         AV11textEnc = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8error ;
      private string AV15publicKey ;
      private string GXt_char6 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private string AV10textClear ;
      private string AV11textEnc ;
      private string aP1_error ;
      private GxFile AV12transactionsFile ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV9keyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo GXt_SdtKeyInfo2 ;
      private GeneXus.Programs.wallet.SdtWallet AV13wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV16extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo3 ;
   }

}
