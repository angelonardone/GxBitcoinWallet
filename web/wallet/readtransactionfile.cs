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
   public class readtransactionfile : GXProcedure
   {
      public readtransactionfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public readtransactionfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                           out string aP1_error )
      {
         this.GxExplorer_services_TxoutFromAddressesOUT = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         this.AV19error = "" ;
         initialize();
         executePrivate();
         aP0_GxExplorer_services_TxoutFromAddressesOUT=this.GxExplorer_services_TxoutFromAddressesOUT;
         aP1_error=this.AV19error;
      }

      public string executeUdp( out SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT )
      {
         execute(out aP0_GxExplorer_services_TxoutFromAddressesOUT, out aP1_error);
         return AV19error ;
      }

      public void executeSubmit( out SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                                 out string aP1_error )
      {
         readtransactionfile objreadtransactionfile;
         objreadtransactionfile = new readtransactionfile();
         objreadtransactionfile.GxExplorer_services_TxoutFromAddressesOUT = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         objreadtransactionfile.AV19error = "" ;
         objreadtransactionfile.context.SetSubmitInitialConfig(context);
         objreadtransactionfile.initialize();
         Submit( executePrivateCatch,objreadtransactionfile);
         aP0_GxExplorer_services_TxoutFromAddressesOUT=this.GxExplorer_services_TxoutFromAddressesOUT;
         aP1_error=this.AV19error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((readtransactionfile)stateInfo).executePrivate();
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
         AV19error = "";
         if ( ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV13wallet.gxTpr_Wallettype, "ImportedWIF") == 0 ) )
         {
            GXt_SdtKeyInfo2 = AV16keyInfo;
            new GeneXus.Programs.wallet.getkey(context ).execute( out  GXt_SdtKeyInfo2) ;
            AV16keyInfo = GXt_SdtKeyInfo2;
            AV22privateKey = AV16keyInfo.gxTpr_Privatekey;
         }
         else
         {
            GXt_SdtExtKeyInfo3 = AV23extKeyInfo;
            new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo3) ;
            AV23extKeyInfo = GXt_SdtExtKeyInfo3;
            AV22privateKey = AV23extKeyInfo.gxTpr_Privatekey;
         }
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         GXt_boolean5 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
         AV14transactionsFile.Source = AV13wallet.gxTpr_Walletbasedirectory+(GXt_boolean5 ? "/" : "\\")+"transactions.trn";
         if ( AV14transactionsFile.Exists() )
         {
            AV18textEnc = AV14transactionsFile.ReadAllText("");
            GXt_char6 = AV19error;
            new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV22privateKey,  AV18textEnc, out  AV17textClear, out  GXt_char6) ;
            AV19error = GXt_char6;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19error)) )
            {
               GxExplorer_services_TxoutFromAddressesOUT.FromJSonString(AV17textClear, null);
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
         GxExplorer_services_TxoutFromAddressesOUT = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV19error = "";
         AV13wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV16keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         GXt_SdtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV22privateKey = "";
         AV23extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtExtKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV14transactionsFile = new GxFile(context.GetPhysicalPath());
         AV18textEnc = "";
         GXt_char6 = "";
         AV17textClear = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV19error ;
      private string AV22privateKey ;
      private string GXt_char6 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private string AV18textEnc ;
      private string AV17textClear ;
      private SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ;
      private string aP1_error ;
      private GxFile AV14transactionsFile ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV16keyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo GXt_SdtKeyInfo2 ;
      private GeneXus.Programs.wallet.SdtWallet AV13wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV23extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo3 ;
   }

}
