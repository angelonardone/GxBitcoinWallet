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
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public loadhistoryfromtransactions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                           out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ,
                           out decimal aP2_totalBalance )
      {
         this.AV32StoredTransactions = aP0_StoredTransactions;
         this.AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         this.AV25totalBalance = 0 ;
         initialize();
         ExecuteImpl();
         aP1_SDTAddressHistory=this.AV22SDTAddressHistory;
         aP2_totalBalance=this.AV25totalBalance;
      }

      public decimal executeUdp( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                                 out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory )
      {
         execute(aP0_StoredTransactions, out aP1_SDTAddressHistory, out aP2_totalBalance);
         return AV25totalBalance ;
      }

      public void executeSubmit( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                                 out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ,
                                 out decimal aP2_totalBalance )
      {
         this.AV32StoredTransactions = aP0_StoredTransactions;
         this.AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         this.AV25totalBalance = 0 ;
         SubmitImpl();
         aP1_SDTAddressHistory=this.AV22SDTAddressHistory;
         aP2_totalBalance=this.AV25totalBalance;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtKeyInfo1 = AV33allKeyInfo;
         new GeneXus.Programs.wallet.getallkeys(context ).execute( out  GXt_objcol_SdtKeyInfo1) ;
         AV33allKeyInfo = GXt_objcol_SdtKeyInfo1;
         AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV32StoredTransactions.gxTpr_Transaction.Count )
         {
            AV26TransactionItem = ((GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem)AV32StoredTransactions.gxTpr_Transaction.Item(AV35GXV1));
            AV21oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
            AV21oneAddressHistory.gxTpr_Receiveddatetime = AV26TransactionItem.gxTpr_Datetime;
            AV21oneAddressHistory.gxTpr_Receivedaddress = AV26TransactionItem.gxTpr_Scriptpubkey_address;
            AV21oneAddressHistory.gxTpr_Receivedamount = AV26TransactionItem.gxTpr_Value;
            AV21oneAddressHistory.gxTpr_Receivedtransactionid = AV26TransactionItem.gxTpr_Transactionid;
            AV21oneAddressHistory.gxTpr_Recivedn = AV26TransactionItem.gxTpr_N;
            AV21oneAddressHistory.gxTpr_Confirmations = AV26TransactionItem.gxTpr_Confirmations;
            if ( AV21oneAddressHistory.gxTpr_Confirmations == 0 )
            {
               AV21oneAddressHistory.gxTpr_Receiveddatetime = DateTimeUtil.Now( context);
            }
            AV36GXV2 = 1;
            while ( AV36GXV2 <= AV33allKeyInfo.Count )
            {
               AV34keyInfo = ((GeneXus.Programs.nbitcoin.SdtKeyInfo)AV33allKeyInfo.Item(AV36GXV2));
               if ( StringUtil.StrCmp(StringUtil.Trim( AV21oneAddressHistory.gxTpr_Receivedaddress), StringUtil.Trim( AV34keyInfo.gxTpr_Address)) == 0 )
               {
                  AV21oneAddressHistory.gxTpr_Receivedprivatekey = AV34keyInfo.gxTpr_Privatekey;
                  if (true) break;
               }
               AV36GXV2 = (int)(AV36GXV2+1);
            }
            AV21oneAddressHistory.gxTpr_Addresscreationsequence = AV26TransactionItem.gxTpr_Addresscreationsequence;
            AV21oneAddressHistory.gxTpr_Addressgeneratedtype = AV26TransactionItem.gxTpr_Addressgeneratedtype;
            AV21oneAddressHistory.gxTpr_Sentdatetime = AV26TransactionItem.gxTpr_Usedin.gxTpr_Datetime;
            AV21oneAddressHistory.gxTpr_Senttransactionid = AV26TransactionItem.gxTpr_Usedin.gxTpr_Transactionid;
            AV21oneAddressHistory.gxTpr_Description = AV26TransactionItem.gxTpr_Description;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21oneAddressHistory.gxTpr_Description)) )
            {
               AV21oneAddressHistory.gxTpr_Receivedaddress = AV21oneAddressHistory.gxTpr_Description;
            }
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
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV22SDTAddressHistory = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV33allKeyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         GXt_objcol_SdtKeyInfo1 = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV26TransactionItem = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV21oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         AV34keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV16historyWithBalance = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         /* GeneXus formulas. */
      }

      private int AV35GXV1 ;
      private int AV36GXV2 ;
      private decimal AV25totalBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_SDTAddressHistory ;
      private decimal aP2_totalBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV22SDTAddressHistory ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV16historyWithBalance ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV33allKeyInfo ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> GXt_objcol_SdtKeyInfo1 ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV21oneAddressHistory ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV32StoredTransactions ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV26TransactionItem ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV34keyInfo ;
   }

}
