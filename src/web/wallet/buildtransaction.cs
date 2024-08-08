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
   public class buildtransaction : GXProcedure
   {
      public buildtransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public buildtransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( bool aP0_sendAllCoins ,
                           decimal aP1_transactionFee ,
                           string aP2_networkType ,
                           GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP3_transactionsToSend ,
                           decimal aP4_inSendCoins ,
                           string aP5_sendTo ,
                           string aP6_returnTo ,
                           out long aP7_virtualSize ,
                           out string aP8_hexTransaction ,
                           out string aP9_error )
      {
         this.AV28sendAllCoins = aP0_sendAllCoins;
         this.AV10transactionFee = aP1_transactionFee;
         this.AV13networkType = aP2_networkType;
         this.AV8transactionsToSend = aP3_transactionsToSend;
         this.AV29inSendCoins = aP4_inSendCoins;
         this.AV21sendTo = aP5_sendTo;
         this.AV23returnTo = aP6_returnTo;
         this.AV11virtualSize = 0 ;
         this.AV12hexTransaction = "" ;
         this.AV9error = "" ;
         initialize();
         ExecuteImpl();
         aP7_virtualSize=this.AV11virtualSize;
         aP8_hexTransaction=this.AV12hexTransaction;
         aP9_error=this.AV9error;
      }

      public string executeUdp( bool aP0_sendAllCoins ,
                                decimal aP1_transactionFee ,
                                string aP2_networkType ,
                                GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP3_transactionsToSend ,
                                decimal aP4_inSendCoins ,
                                string aP5_sendTo ,
                                string aP6_returnTo ,
                                out long aP7_virtualSize ,
                                out string aP8_hexTransaction )
      {
         execute(aP0_sendAllCoins, aP1_transactionFee, aP2_networkType, aP3_transactionsToSend, aP4_inSendCoins, aP5_sendTo, aP6_returnTo, out aP7_virtualSize, out aP8_hexTransaction, out aP9_error);
         return AV9error ;
      }

      public void executeSubmit( bool aP0_sendAllCoins ,
                                 decimal aP1_transactionFee ,
                                 string aP2_networkType ,
                                 GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP3_transactionsToSend ,
                                 decimal aP4_inSendCoins ,
                                 string aP5_sendTo ,
                                 string aP6_returnTo ,
                                 out long aP7_virtualSize ,
                                 out string aP8_hexTransaction ,
                                 out string aP9_error )
      {
         this.AV28sendAllCoins = aP0_sendAllCoins;
         this.AV10transactionFee = aP1_transactionFee;
         this.AV13networkType = aP2_networkType;
         this.AV8transactionsToSend = aP3_transactionsToSend;
         this.AV29inSendCoins = aP4_inSendCoins;
         this.AV21sendTo = aP5_sendTo;
         this.AV23returnTo = aP6_returnTo;
         this.AV11virtualSize = 0 ;
         this.AV12hexTransaction = "" ;
         this.AV9error = "" ;
         SubmitImpl();
         aP7_virtualSize=this.AV11virtualSize;
         aP8_hexTransaction=this.AV12hexTransaction;
         aP9_error=this.AV9error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* User Code */
          NBitcoin.Network network;
         /* User Code */
          network = NBitcoin.Network.Main;
         /* User Code */
          string tx_hex;
         /* User Code */
          NBitcoin.Key privateKey;
         /* User Code */
          NBitcoin.Transaction tx_coin;
         /* User Code */
          System.Collections.Generic.IEnumerable<NBitcoin.Coin> rec_coin;
         /* User Code */
          var all_coins = new System.Collections.Generic.List<NBitcoin.Coin>();
         /* User Code */
          var all_script_coins = new System.Collections.Generic.List<NBitcoin.ScriptCoin>();
         /* User Code */
          var all_keys = new System.Collections.Generic.List<NBitcoin.Key>();
         if ( AV28sendAllCoins )
         {
            AV22sendCoins = (decimal)(AV29inSendCoins-AV10transactionFee);
         }
         else
         {
            AV22sendCoins = AV29inSendCoins;
         }
         /* User Code */
          try
         /* User Code */
          {
         if ( StringUtil.StrCmp(AV13networkType, "MainNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.Main;
         }
         else if ( StringUtil.StrCmp(AV13networkType, "TestNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.TestNet;
         }
         else if ( StringUtil.StrCmp(AV13networkType, "RegTest") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.RegTest;
         }
         else
         {
            AV9error = "Network Type not sopported";
         }
         /* User Code */
          var destination = NBitcoin.BitcoinAddress.Create(AV21sendTo, network);
         /* User Code */
          var returnto = NBitcoin.BitcoinAddress.Create(AV23returnTo, network);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            AV30GXV1 = 1;
            while ( AV30GXV1 <= AV8transactionsToSend.Count )
            {
               AV15oneAddressHistory = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV8transactionsToSend.Item(AV30GXV1));
               AV20privateKey = AV15oneAddressHistory.gxTpr_Receivedprivatekey;
               /* User Code */
                string hexPrivateKey = AV20privateKey;
               /* User Code */
                byte[] bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPrivateKey);
               /* User Code */
               	privateKey = new NBitcoin.Key(bytes);
               /* User Code */
                all_keys.Add(privateKey);
               AV12hexTransaction = AV15oneAddressHistory.gxTpr_Receivedtransactionhex;
               /* User Code */
                tx_hex = AV12hexTransaction;
               /* User Code */
                tx_coin = NBitcoin.Transaction.Parse(tx_hex, network);
               /* User Code */
                rec_coin = tx_coin.Outputs.AsCoins();
               AV26receivedIn = 0;
               /* User Code */
                foreach (NBitcoin.Coin one_coin in rec_coin)
               /* User Code */
                {
               if ( AV26receivedIn == AV15oneAddressHistory.gxTpr_Recivedn )
               {
                  /* User Code */
                  		all_coins.Add(one_coin);
               }
               AV26receivedIn = (long)(AV26receivedIn+1);
               /* User Code */
                }
               AV30GXV1 = (int)(AV30GXV1+1);
            }
            /* User Code */
             var allkeysarray = all_keys.ToArray();
            if ( AV28sendAllCoins )
            {
               /* User Code */
                var builder = network.CreateTransactionBuilder();
               /* User Code */
                NBitcoin.Transaction send_tx = builder
               /* User Code */
               			.AddCoins(all_coins)
               /* User Code */
               			.AddKeys(allkeysarray)
               /* User Code */
               			.Send(destination, NBitcoin.Money.Coins(AV22sendCoins))
               /* User Code */
               			.SendFees(NBitcoin.Money.Coins(AV10transactionFee))
               /* User Code */
               			.BuildTransaction(sign: true);
               /* User Code */
                AV25verified = builder.Verify(send_tx);
               /* User Code */
                AV11virtualSize = send_tx.GetVirtualSize();
               /* User Code */
                AV12hexTransaction = send_tx.ToHex();
               if ( ! AV25verified )
               {
                  AV9error = "Transaction is not Verified";
               }
            }
            else
            {
               /* User Code */
                var builder = network.CreateTransactionBuilder();
               /* User Code */
                NBitcoin.Transaction send_tx = builder
               /* User Code */
               			.AddCoins(all_coins)
               /* User Code */
               			.AddKeys(allkeysarray)
               /* User Code */
               			.Send(destination, NBitcoin.Money.Coins(AV22sendCoins))
               /* User Code */
               			.SetChange(returnto)
               /* User Code */
               			.SendFees(NBitcoin.Money.Coins(AV10transactionFee))
               /* User Code */
               			.BuildTransaction(sign: true);
               /* User Code */
                AV25verified = builder.Verify(send_tx);
               /* User Code */
                AV11virtualSize = send_tx.GetVirtualSize();
               /* User Code */
                AV12hexTransaction = send_tx.ToHex();
               if ( ! AV25verified )
               {
                  AV9error = "Transaction is not Verified";
               }
            }
         }
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
         AV12hexTransaction = "";
         AV9error = "";
         AV15oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         AV20privateKey = "";
         /* GeneXus formulas. */
      }

      private int AV30GXV1 ;
      private long AV11virtualSize ;
      private long AV26receivedIn ;
      private decimal AV10transactionFee ;
      private decimal AV29inSendCoins ;
      private decimal AV22sendCoins ;
      private string AV13networkType ;
      private string AV21sendTo ;
      private string AV23returnTo ;
      private string AV9error ;
      private string AV20privateKey ;
      private bool AV28sendAllCoins ;
      private bool AV25verified ;
      private string AV12hexTransaction ;
      private long aP7_virtualSize ;
      private string aP8_hexTransaction ;
      private string aP9_error ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV8transactionsToSend ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV15oneAddressHistory ;
   }

}
