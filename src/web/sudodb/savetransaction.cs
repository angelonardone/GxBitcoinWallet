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
namespace GeneXus.Programs.sudodb {
   public class savetransaction : GXProcedure
   {
      public savetransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public savetransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId ,
                           out string aP1_error )
      {
         this.AV8electrumRespGetTransactionId = aP0_electrumRespGetTransactionId;
         this.AV11error = "" ;
         initialize();
         ExecuteImpl();
         aP1_error=this.AV11error;
      }

      public string executeUdp( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId )
      {
         execute(aP0_electrumRespGetTransactionId, out aP1_error);
         return AV11error ;
      }

      public void executeSubmit( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId ,
                                 out string aP1_error )
      {
         this.AV8electrumRespGetTransactionId = aP0_electrumRespGetTransactionId;
         this.AV11error = "" ;
         SubmitImpl();
         aP1_error=this.AV11error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9transaction.gxTpr_Transactionid = StringUtil.Trim( AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Txid);
         AV9transaction.gxTpr_Blockid = StringUtil.Trim( AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Blockhash);
         AV9transaction.gxTpr_Confirmations = (long)(Math.Round(AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Confirmations, 18, MidpointRounding.ToEven));
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         new GeneXus.Programs.sudodb.unixtimetolocaldatetime(context ).execute(  (long)(Math.Round(AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Blocktime, 18, MidpointRounding.ToEven)), out  GXt_dtime1) ;
         AV9transaction.gxTpr_Blockdatetime = GXt_dtime1;
         AV9transaction.gxTpr_Hex = StringUtil.Trim( AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Hex);
         AV10transactions.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBTrransaction.db", out  AV11error), null);
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10transactions.Count )
         {
            AV12oneTransaction = ((GeneXus.Programs.sudodb.SdtTransaction)AV10transactions.Item(AV13GXV1));
            if ( StringUtil.StrCmp(AV12oneTransaction.gxTpr_Transactionid, AV9transaction.gxTpr_Transactionid) == 0 )
            {
               AV10transactions.RemoveItem(AV10transactions.IndexOf(AV12oneTransaction));
               if (true) break;
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         AV10transactions.Add(AV9transaction, 0);
         AV10transactions.Sort("TransactionId");
         GXt_char2 = AV11error;
         new GeneXus.Programs.wallet.savejsonencfile(context ).execute(  "DBTrransaction.db",  AV10transactions.ToJSonString(false), out  GXt_char2) ;
         AV11error = GXt_char2;
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
         AV11error = "";
         AV9transaction = new GeneXus.Programs.sudodb.SdtTransaction(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV10transactions = new GXBaseCollection<GeneXus.Programs.sudodb.SdtTransaction>( context, "Transaction", "GxBitcoinWallet");
         AV12oneTransaction = new GeneXus.Programs.sudodb.SdtTransaction(context);
         GXt_char2 = "";
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV11error ;
      private string GXt_char2 ;
      private DateTime GXt_dtime1 ;
      private string aP1_error ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtTransaction> AV10transactions ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId AV8electrumRespGetTransactionId ;
      private GeneXus.Programs.sudodb.SdtTransaction AV9transaction ;
      private GeneXus.Programs.sudodb.SdtTransaction AV12oneTransaction ;
   }

}
