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
   public class loadhistoryfromtransactions : GXProcedure
   {
      public loadhistoryfromtransactions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public loadhistoryfromtransactions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                           out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ,
                           out long aP2_transactionsCount ,
                           out decimal aP3_totalBalance )
      {
         this.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         this.AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         this.AV27transactionsCount = 0 ;
         this.AV25totalBalance = 0 ;
         initialize();
         executePrivate();
         aP1_SDTAddressHistory=this.AV22SDTAddressHistory;
         aP2_transactionsCount=this.AV27transactionsCount;
         aP3_totalBalance=this.AV25totalBalance;
      }

      public decimal executeUdp( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                                 out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ,
                                 out long aP2_transactionsCount )
      {
         execute(aP0_GxExplorer_services_TxoutFromAddressesOUT, out aP1_SDTAddressHistory, out aP2_transactionsCount, out aP3_totalBalance);
         return AV25totalBalance ;
      }

      public void executeSubmit( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                                 out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ,
                                 out long aP2_transactionsCount ,
                                 out decimal aP3_totalBalance )
      {
         loadhistoryfromtransactions objloadhistoryfromtransactions;
         objloadhistoryfromtransactions = new loadhistoryfromtransactions();
         objloadhistoryfromtransactions.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         objloadhistoryfromtransactions.AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         objloadhistoryfromtransactions.AV27transactionsCount = 0 ;
         objloadhistoryfromtransactions.AV25totalBalance = 0 ;
         objloadhistoryfromtransactions.context.SetSubmitInitialConfig(context);
         objloadhistoryfromtransactions.initialize();
         Submit( executePrivateCatch,objloadhistoryfromtransactions);
         aP1_SDTAddressHistory=this.AV22SDTAddressHistory;
         aP2_transactionsCount=this.AV27transactionsCount;
         aP3_totalBalance=this.AV25totalBalance;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadhistoryfromtransactions)stateInfo).executePrivate();
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
         GXt_SdtWallet1 = AV29wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV29wallet = GXt_SdtWallet1;
         GXt_objcol_SdtKeyInfo2 = AV28allKeyInfo;
         new GeneXus.Programs.wallet.getallkeys(context ).execute( out  GXt_objcol_SdtKeyInfo2) ;
         AV28allKeyInfo = GXt_objcol_SdtKeyInfo2;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Count )
         {
            AV26TransactionItem = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Item(AV35GXV1));
            AV21oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
            AV27transactionsCount = (long)(AV27transactionsCount+1);
            AV21oneAddressHistory.gxTpr_Receiveddatetime = AV26TransactionItem.gxTpr_Datetime;
            AV21oneAddressHistory.gxTpr_Receivedaddress = AV26TransactionItem.gxTpr_Scriptpubkey_address;
            AV21oneAddressHistory.gxTpr_Receivedamount = AV26TransactionItem.gxTpr_Value;
            AV21oneAddressHistory.gxTpr_Receivedtransactionid = AV26TransactionItem.gxTpr_Transactionid;
            AV21oneAddressHistory.gxTpr_Recivedn = AV26TransactionItem.gxTpr_N;
            GXt_boolean3 = AV30found;
            new GeneXus.Programs.wallet.searchkeyinallkeys(context ).execute(  StringUtil.Trim( AV21oneAddressHistory.gxTpr_Receivedaddress),  AV28allKeyInfo, out  AV19keyInfo, out  GXt_boolean3) ;
            AV30found = GXt_boolean3;
            AV21oneAddressHistory.gxTpr_Receivedprivatekey = AV19keyInfo.gxTpr_Privatekey;
            AV21oneAddressHistory.gxTpr_Sentdatetime = AV26TransactionItem.gxTpr_Used.gxTpr_Useddatetime;
            AV21oneAddressHistory.gxTpr_Senttransactionid = AV26TransactionItem.gxTpr_Used.gxTpr_Usedid;
            AV21oneAddressHistory.gxTpr_Balance = ((DateTime.MinValue==AV21oneAddressHistory.gxTpr_Sentdatetime) ? AV21oneAddressHistory.gxTpr_Receivedamount : (decimal)(0));
            AV22SDTAddressHistory.Add(AV21oneAddressHistory, 0);
            AV25totalBalance = (decimal)(AV25totalBalance+(AV21oneAddressHistory.gxTpr_Balance));
            if ( ( AV21oneAddressHistory.gxTpr_Balance > Convert.ToDecimal( 0 )) )
            {
               AV16historyWithBalance.Add(AV21oneAddressHistory, 0);
            }
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         AV22SDTAddressHistory.Sort("[ReceivedDateTime]");
         AV16historyWithBalance.Sort("Balance");
         new GeneXus.Programs.wallet.sethistorywithbalance(context ).execute(  AV16historyWithBalance) ;
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
         AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV29wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV28allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         GXt_objcol_SdtKeyInfo2 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV26TransactionItem = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV21oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         AV19keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV16historyWithBalance = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV35GXV1 ;
      private long AV27transactionsCount ;
      private decimal AV25totalBalance ;
      private bool AV30found ;
      private bool GXt_boolean3 ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ;
      private long aP2_transactionsCount ;
      private decimal aP3_totalBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV22SDTAddressHistory ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV16historyWithBalance ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV28allKeyInfo ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> GXt_objcol_SdtKeyInfo2 ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV26TransactionItem ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV21oneAddressHistory ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV19keyInfo ;
      private GeneXus.Programs.wallet.SdtWallet AV29wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
   }

}
