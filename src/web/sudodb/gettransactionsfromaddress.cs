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
   public class gettransactionsfromaddress : GXProcedure
   {
      public gettransactionsfromaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public gettransactionsfromaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_address ,
                           ref SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService )
      {
         this.AV9address = aP0_address;
         this.AV13transactionsFromService = aP1_transactionsFromService;
         initialize();
         ExecuteImpl();
         aP1_transactionsFromService=this.AV13transactionsFromService;
      }

      public SdtGxExplorer_services_TxoutFromAddresses executeUdp( string aP0_address )
      {
         execute(aP0_address, ref aP1_transactionsFromService);
         return AV13transactionsFromService ;
      }

      public void executeSubmit( string aP0_address ,
                                 ref SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService )
      {
         this.AV9address = aP0_address;
         this.AV13transactionsFromService = aP1_transactionsFromService;
         SubmitImpl();
         aP1_transactionsFromService=this.AV13transactionsFromService;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14transactions.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBTrransaction.db", out  AV29error), null);
         AV12DBvOUTs.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBvOUT.db", out  AV29error), null);
         AV16DBvINs.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBvIN.db", out  AV29error), null);
         AV12DBvOUTs.Sort("scriptPubKey_address");
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV12DBvOUTs.Count )
         {
            AV11oneDBvOUT = ((GeneXus.Programs.sudodb.SdtvOUT)AV12DBvOUTs.Item(AV31GXV1));
            if ( StringUtil.StrCmp(StringUtil.Trim( AV11oneDBvOUT.gxTpr_Scriptpubkey_address), StringUtil.Trim( AV9address)) == 0 )
            {
               AV8oneTransactionFromService = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
               AV8oneTransactionFromService.gxTpr_Transactionid = StringUtil.Trim( AV11oneDBvOUT.gxTpr_Transactionid);
               AV8oneTransactionFromService.gxTpr_N = AV11oneDBvOUT.gxTpr_N;
               AV8oneTransactionFromService.gxTpr_Value = AV11oneDBvOUT.gxTpr_Value;
               AV8oneTransactionFromService.gxTpr_Scriptpubkey_address = StringUtil.Trim( AV11oneDBvOUT.gxTpr_Scriptpubkey_address);
               AV18TransactionId = StringUtil.Trim( AV11oneDBvOUT.gxTpr_Transactionid);
               /* Execute user subroutine: 'GET DATETIME AND CONFIRMATIONS FROM TRANSACTIONID' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV8oneTransactionFromService.gxTpr_Datetime = AV19transactionDateTime;
               AV8oneTransactionFromService.gxTpr_Confirmations = AV30confirmations;
               AV32GXV2 = 1;
               while ( AV32GXV2 <= AV16DBvINs.Count )
               {
                  AV17oneDBvIN = ((GeneXus.Programs.sudodb.SdtvIN)AV16DBvINs.Item(AV32GXV2));
                  if ( ( StringUtil.StrCmp(AV17oneDBvIN.gxTpr_Vintransactionid, StringUtil.Trim( AV11oneDBvOUT.gxTpr_Transactionid)) == 0 ) && ( AV17oneDBvIN.gxTpr_Vinn == AV11oneDBvOUT.gxTpr_N ) )
                  {
                     AV21transactionFromServiceUsed = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used(context);
                     AV21transactionFromServiceUsed.gxTpr_Usedid = StringUtil.Trim( AV17oneDBvIN.gxTpr_Transactionid);
                     AV21transactionFromServiceUsed.gxTpr_Usedn = AV17oneDBvIN.gxTpr_Vinn;
                     AV18TransactionId = StringUtil.Trim( AV17oneDBvIN.gxTpr_Transactionid);
                     /* Execute user subroutine: 'GET DATETIME AND CONFIRMATIONS FROM TRANSACTIONID' */
                     S111 ();
                     if ( returnInSub )
                     {
                        this.cleanup();
                        if (true) return;
                     }
                     AV21transactionFromServiceUsed.gxTpr_Useddatetime = AV19transactionDateTime;
                     AV33GXV3 = 1;
                     while ( AV33GXV3 <= AV12DBvOUTs.Count )
                     {
                        AV28oneDBvOUT1 = ((GeneXus.Programs.sudodb.SdtvOUT)AV12DBvOUTs.Item(AV33GXV3));
                        if ( StringUtil.StrCmp(AV28oneDBvOUT1.gxTpr_Transactionid, StringUtil.Trim( AV17oneDBvIN.gxTpr_Transactionid)) == 0 )
                        {
                           AV22transactionFromServiceUsedItem = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item(context);
                           AV22transactionFromServiceUsedItem.gxTpr_N = AV28oneDBvOUT1.gxTpr_N;
                           AV22transactionFromServiceUsedItem.gxTpr_Value = AV28oneDBvOUT1.gxTpr_Value;
                           AV22transactionFromServiceUsedItem.gxTpr_Scriptpubkey_address = StringUtil.Trim( AV28oneDBvOUT1.gxTpr_Scriptpubkey_address);
                           AV21transactionFromServiceUsed.gxTpr_Usedto.Add(AV22transactionFromServiceUsedItem, 0);
                        }
                        AV33GXV3 = (int)(AV33GXV3+1);
                     }
                     AV8oneTransactionFromService.gxTpr_Used = AV21transactionFromServiceUsed;
                  }
                  AV32GXV2 = (int)(AV32GXV2+1);
               }
               AV13transactionsFromService.gxTpr_Transaction.Add(AV8oneTransactionFromService, 0);
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GET DATETIME AND CONFIRMATIONS FROM TRANSACTIONID' Routine */
         returnInSub = false;
         AV34GXV4 = 1;
         while ( AV34GXV4 <= AV14transactions.Count )
         {
            AV20oneTransaction = ((GeneXus.Programs.sudodb.SdtTransaction)AV14transactions.Item(AV34GXV4));
            if ( StringUtil.StrCmp(AV20oneTransaction.gxTpr_Transactionid, StringUtil.Trim( AV18TransactionId)) == 0 )
            {
               AV30confirmations = AV20oneTransaction.gxTpr_Confirmations;
               if ( AV20oneTransaction.gxTpr_Confirmations > 0 )
               {
                  AV19transactionDateTime = AV20oneTransaction.gxTpr_Blockdatetime;
               }
               if (true) break;
            }
            AV34GXV4 = (int)(AV34GXV4+1);
         }
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
         AV14transactions = new GXBaseCollection<GeneXus.Programs.sudodb.SdtTransaction>( context, "Transaction", "GxBitcoinWallet");
         AV29error = "";
         AV12DBvOUTs = new GXBaseCollection<GeneXus.Programs.sudodb.SdtvOUT>( context, "vOUT", "GxBitcoinWallet");
         AV16DBvINs = new GXBaseCollection<GeneXus.Programs.sudodb.SdtvIN>( context, "vIN", "GxBitcoinWallet");
         AV11oneDBvOUT = new GeneXus.Programs.sudodb.SdtvOUT(context);
         AV8oneTransactionFromService = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV18TransactionId = "";
         AV19transactionDateTime = (DateTime)(DateTime.MinValue);
         AV17oneDBvIN = new GeneXus.Programs.sudodb.SdtvIN(context);
         AV21transactionFromServiceUsed = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used(context);
         AV28oneDBvOUT1 = new GeneXus.Programs.sudodb.SdtvOUT(context);
         AV22transactionFromServiceUsedItem = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item(context);
         AV20oneTransaction = new GeneXus.Programs.sudodb.SdtTransaction(context);
         /* GeneXus formulas. */
      }

      private int AV31GXV1 ;
      private int AV32GXV2 ;
      private int AV33GXV3 ;
      private int AV34GXV4 ;
      private long AV30confirmations ;
      private string AV9address ;
      private string AV29error ;
      private string AV18TransactionId ;
      private DateTime AV19transactionDateTime ;
      private bool returnInSub ;
      private SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtvIN> AV16DBvINs ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtvOUT> AV12DBvOUTs ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtTransaction> AV14transactions ;
      private GeneXus.Programs.sudodb.SdtvIN AV17oneDBvIN ;
      private GeneXus.Programs.sudodb.SdtvOUT AV11oneDBvOUT ;
      private GeneXus.Programs.sudodb.SdtvOUT AV28oneDBvOUT1 ;
      private GeneXus.Programs.sudodb.SdtTransaction AV20oneTransaction ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV8oneTransactionFromService ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used AV21transactionFromServiceUsed ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item AV22transactionFromServiceUsedItem ;
      private SdtGxExplorer_services_TxoutFromAddresses AV13transactionsFromService ;
   }

}
