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
         context.SetDefaultTheme("Carmine");
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
                           decimal aP4_sendCoins ,
                           string aP5_sendTo ,
                           string aP6_returnTo ,
                           out long aP7_virtualSize ,
                           out string aP8_hexTransaction ,
                           out string aP9_error )
      {
         this.AV33sendAllCoins = aP0_sendAllCoins;
         this.AV10transactionFee = aP1_transactionFee;
         this.AV15networkType = aP2_networkType;
         this.AV8transactionsToSend = aP3_transactionsToSend;
         this.AV27sendCoins = aP4_sendCoins;
         this.AV26sendTo = aP5_sendTo;
         this.AV28returnTo = aP6_returnTo;
         this.AV12virtualSize = 0 ;
         this.AV13hexTransaction = "" ;
         this.AV9error = "" ;
         initialize();
         executePrivate();
         aP7_virtualSize=this.AV12virtualSize;
         aP8_hexTransaction=this.AV13hexTransaction;
         aP9_error=this.AV9error;
      }

      public string executeUdp( bool aP0_sendAllCoins ,
                                decimal aP1_transactionFee ,
                                string aP2_networkType ,
                                GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP3_transactionsToSend ,
                                decimal aP4_sendCoins ,
                                string aP5_sendTo ,
                                string aP6_returnTo ,
                                out long aP7_virtualSize ,
                                out string aP8_hexTransaction )
      {
         execute(aP0_sendAllCoins, aP1_transactionFee, aP2_networkType, aP3_transactionsToSend, aP4_sendCoins, aP5_sendTo, aP6_returnTo, out aP7_virtualSize, out aP8_hexTransaction, out aP9_error);
         return AV9error ;
      }

      public void executeSubmit( bool aP0_sendAllCoins ,
                                 decimal aP1_transactionFee ,
                                 string aP2_networkType ,
                                 GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP3_transactionsToSend ,
                                 decimal aP4_sendCoins ,
                                 string aP5_sendTo ,
                                 string aP6_returnTo ,
                                 out long aP7_virtualSize ,
                                 out string aP8_hexTransaction ,
                                 out string aP9_error )
      {
         buildtransaction objbuildtransaction;
         objbuildtransaction = new buildtransaction();
         objbuildtransaction.AV33sendAllCoins = aP0_sendAllCoins;
         objbuildtransaction.AV10transactionFee = aP1_transactionFee;
         objbuildtransaction.AV15networkType = aP2_networkType;
         objbuildtransaction.AV8transactionsToSend = aP3_transactionsToSend;
         objbuildtransaction.AV27sendCoins = aP4_sendCoins;
         objbuildtransaction.AV26sendTo = aP5_sendTo;
         objbuildtransaction.AV28returnTo = aP6_returnTo;
         objbuildtransaction.AV12virtualSize = 0 ;
         objbuildtransaction.AV13hexTransaction = "" ;
         objbuildtransaction.AV9error = "" ;
         objbuildtransaction.context.SetSubmitInitialConfig(context);
         objbuildtransaction.initialize();
         Submit( executePrivateCatch,objbuildtransaction);
         aP7_virtualSize=this.AV12virtualSize;
         aP8_hexTransaction=this.AV13hexTransaction;
         aP9_error=this.AV9error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buildtransaction)stateInfo).executePrivate();
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
         if ( AV33sendAllCoins )
         {
            AV27sendCoins = (decimal)(AV27sendCoins-AV10transactionFee);
         }
         /* User Code */
          try
         /* User Code */
          {
         if ( StringUtil.StrCmp(AV15networkType, "Main") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.Main;
         }
         else if ( StringUtil.StrCmp(AV15networkType, "TestNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.TestNet;
         }
         else if ( StringUtil.StrCmp(AV15networkType, "RegTest") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.RegTest;
         }
         else
         {
            AV9error = "Network Type not sopported";
         }
         /* User Code */
          var destination = NBitcoin.BitcoinAddress.Create(AV26sendTo, network);
         /* User Code */
          var returnto = NBitcoin.BitcoinAddress.Create(AV28returnTo, network);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV8transactionsToSend.Count )
            {
               AV20oneAddressHistory = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV8transactionsToSend.Item(AV36GXV1));
               AV25privateKey = AV20oneAddressHistory.gxTpr_Receivedprivatekey;
               /* User Code */
                string hexPrivateKey = AV25privateKey;
               /* User Code */
                byte[] bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPrivateKey);
               /* User Code */
               	privateKey = new NBitcoin.Key(bytes);
               /* User Code */
                all_keys.Add(privateKey);
               AV13hexTransaction = AV20oneAddressHistory.gxTpr_Receivedtransactionhex;
               /* User Code */
                tx_hex = AV13hexTransaction;
               /* User Code */
                tx_coin = NBitcoin.Transaction.Parse(tx_hex, network);
               /* User Code */
                rec_coin = tx_coin.Outputs.AsCoins();
               AV31receivedIn = 0;
               /* User Code */
                foreach (NBitcoin.Coin one_coin in rec_coin)
               /* User Code */
                {
               if ( AV31receivedIn == AV20oneAddressHistory.gxTpr_Recivedn )
               {
                  /* User Code */
                  		all_coins.Add(one_coin);
               }
               AV31receivedIn = (long)(AV31receivedIn+1);
               /* User Code */
                }
               AV36GXV1 = (int)(AV36GXV1+1);
            }
            /* User Code */
             var allkeysarray = all_keys.ToArray();
            if ( AV33sendAllCoins )
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
               			.Send(destination, NBitcoin.Money.Coins(AV27sendCoins))
               /* User Code */
               			.SendFees(NBitcoin.Money.Coins(AV10transactionFee))
               /* User Code */
               			.BuildTransaction(sign: true);
               /* User Code */
                AV30verified = builder.Verify(send_tx);
               /* User Code */
                AV12virtualSize = send_tx.GetVirtualSize();
               /* User Code */
                AV13hexTransaction = send_tx.ToHex();
               if ( ! AV30verified )
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
               			.Send(destination, NBitcoin.Money.Coins(AV27sendCoins))
               /* User Code */
               			.SetChange(returnto)
               /* User Code */
               			.SendFees(NBitcoin.Money.Coins(AV10transactionFee))
               /* User Code */
               			.BuildTransaction(sign: true);
               /* User Code */
                AV30verified = builder.Verify(send_tx);
               /* User Code */
                AV12virtualSize = send_tx.GetVirtualSize();
               /* User Code */
                AV13hexTransaction = send_tx.ToHex();
               if ( ! AV30verified )
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
         AV13hexTransaction = "";
         AV9error = "";
         AV20oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         AV25privateKey = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV36GXV1 ;
      private long AV12virtualSize ;
      private long AV31receivedIn ;
      private decimal AV10transactionFee ;
      private decimal AV27sendCoins ;
      private string AV15networkType ;
      private string AV26sendTo ;
      private string AV28returnTo ;
      private string AV9error ;
      private string AV25privateKey ;
      private bool AV33sendAllCoins ;
      private bool AV30verified ;
      private string AV13hexTransaction ;
      private long aP7_virtualSize ;
      private string aP8_hexTransaction ;
      private string aP9_error ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV8transactionsToSend ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV20oneAddressHistory ;
   }

}
