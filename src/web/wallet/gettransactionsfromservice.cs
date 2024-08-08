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
   public class gettransactionsfromservice : GXProcedure
   {
      public gettransactionsfromservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public gettransactionsfromservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_transactionFileName ,
                           SdtGetTransactions__postInput aP1_transactions__postInput ,
                           out GeneXus.Programs.wallet.SdtStoredTransactions aP2_StoredTransactions ,
                           out string aP3_error )
      {
         this.AV23transactionFileName = aP0_transactionFileName;
         this.AV24transactions__postInput = aP1_transactions__postInput;
         this.AV19StoredTransactions = new GeneXus.Programs.wallet.SdtStoredTransactions(context) ;
         this.AV8error = "" ;
         initialize();
         ExecuteImpl();
         aP2_StoredTransactions=this.AV19StoredTransactions;
         aP3_error=this.AV8error;
      }

      public string executeUdp( string aP0_transactionFileName ,
                                SdtGetTransactions__postInput aP1_transactions__postInput ,
                                out GeneXus.Programs.wallet.SdtStoredTransactions aP2_StoredTransactions )
      {
         execute(aP0_transactionFileName, aP1_transactions__postInput, out aP2_StoredTransactions, out aP3_error);
         return AV8error ;
      }

      public void executeSubmit( string aP0_transactionFileName ,
                                 SdtGetTransactions__postInput aP1_transactions__postInput ,
                                 out GeneXus.Programs.wallet.SdtStoredTransactions aP2_StoredTransactions ,
                                 out string aP3_error )
      {
         this.AV23transactionFileName = aP0_transactionFileName;
         this.AV24transactions__postInput = aP1_transactions__postInput;
         this.AV19StoredTransactions = new GeneXus.Programs.wallet.SdtStoredTransactions(context) ;
         this.AV8error = "" ;
         SubmitImpl();
         aP2_StoredTransactions=this.AV19StoredTransactions;
         aP3_error=this.AV8error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV8error;
         new GeneXus.Programs.wallet.gettransctionsfromlocaldb(context ).execute(  AV24transactions__postInput, out  AV26transactionsFromService, out  GXt_char1) ;
         AV8error = GXt_char1;
         AV11IsSuccess = true;
         if ( AV11IsSuccess )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
            {
               AV19StoredTransactions = new GeneXus.Programs.wallet.SdtStoredTransactions(context);
               AV25transactionsFromFile.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  AV23transactionFileName, out  AV8error), null);
               AV27GXV1 = 1;
               while ( AV27GXV1 <= AV25transactionsFromFile.gxTpr_Transaction.Count )
               {
                  AV14oneTempTransactionFromFile = ((GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem)AV25transactionsFromFile.gxTpr_Transaction.Item(AV27GXV1));
                  AV9found = false;
                  AV28GXV2 = 1;
                  while ( AV28GXV2 <= AV26transactionsFromService.gxTpr_Transaction.Count )
                  {
                     AV22transaction = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)AV26transactionsFromService.gxTpr_Transaction.Item(AV28GXV2));
                     if ( ( StringUtil.StrCmp(AV14oneTempTransactionFromFile.gxTpr_Transactionid, AV22transaction.gxTpr_Transactionid) == 0 ) && ( AV14oneTempTransactionFromFile.gxTpr_N == AV22transaction.gxTpr_N ) )
                     {
                        AV9found = true;
                        if (true) break;
                     }
                     AV28GXV2 = (int)(AV28GXV2+1);
                  }
                  if ( ! AV9found )
                  {
                     AV19StoredTransactions.gxTpr_Transaction.Add(AV14oneTempTransactionFromFile, 0);
                  }
                  AV27GXV1 = (int)(AV27GXV1+1);
               }
               AV29GXV3 = 1;
               while ( AV29GXV3 <= AV26transactionsFromService.gxTpr_Transaction.Count )
               {
                  AV22transaction = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)AV26transactionsFromService.gxTpr_Transaction.Item(AV29GXV3));
                  AV30GXV4 = 1;
                  while ( AV30GXV4 <= AV25transactionsFromFile.gxTpr_Transaction.Count )
                  {
                     AV14oneTempTransactionFromFile = ((GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem)AV25transactionsFromFile.gxTpr_Transaction.Item(AV30GXV4));
                     AV9found = false;
                     AV20tempDesctiption = "";
                     if ( ( StringUtil.StrCmp(AV14oneTempTransactionFromFile.gxTpr_Transactionid, AV22transaction.gxTpr_Transactionid) == 0 ) && ( AV14oneTempTransactionFromFile.gxTpr_N == AV22transaction.gxTpr_N ) )
                     {
                        AV13oneFoundTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
                        AV13oneFoundTransactionFromFile = AV14oneTempTransactionFromFile;
                        AV13oneFoundTransactionFromFile.gxTpr_Confirmations = AV22transaction.gxTpr_Confirmations;
                        AV13oneFoundTransactionFromFile.gxTpr_Datetime = AV22transaction.gxTpr_Datetime;
                        AV21tempUsedTransactionId = StringUtil.Trim( AV22transaction.gxTpr_Used.gxTpr_Usedid);
                        AV20tempDesctiption = AV14oneTempTransactionFromFile.gxTpr_Description;
                        AV9found = true;
                        if (true) break;
                     }
                     AV30GXV4 = (int)(AV30GXV4+1);
                  }
                  if ( AV9found )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21tempUsedTransactionId)) )
                     {
                        AV19StoredTransactions.gxTpr_Transaction.Add(AV13oneFoundTransactionFromFile, 0);
                     }
                     else
                     {
                        /* Execute user subroutine: 'CREATE FROM SERVICE' */
                        S111 ();
                        if ( returnInSub )
                        {
                           this.cleanup();
                           if (true) return;
                        }
                     }
                  }
                  else
                  {
                     /* Execute user subroutine: 'CREATE FROM SERVICE' */
                     S111 ();
                     if ( returnInSub )
                     {
                        this.cleanup();
                        if (true) return;
                     }
                  }
                  AV29GXV3 = (int)(AV29GXV3+1);
               }
               GXt_char1 = AV8error;
               new GeneXus.Programs.wallet.savejsonencfile(context ).execute(  AV23transactionFileName,  AV19StoredTransactions.ToJSonString(false, true), out  GXt_char1) ;
               AV8error = GXt_char1;
            }
         }
         else
         {
            AV8error = AV10HttpMessage.ToJSonString(false, true);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CREATE FROM SERVICE' Routine */
         returnInSub = false;
         AV15oneTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV15oneTransactionFromFile.gxTpr_Description = StringUtil.Trim( AV20tempDesctiption);
         AV15oneTransactionFromFile.gxTpr_Transactionid = AV22transaction.gxTpr_Transactionid;
         AV15oneTransactionFromFile.gxTpr_N = AV22transaction.gxTpr_N;
         AV15oneTransactionFromFile.gxTpr_Value = AV22transaction.gxTpr_Value;
         AV15oneTransactionFromFile.gxTpr_Scriptpubkey_address = AV22transaction.gxTpr_Scriptpubkey_address;
         AV15oneTransactionFromFile.gxTpr_Datetime = AV22transaction.gxTpr_Datetime;
         AV15oneTransactionFromFile.gxTpr_Confirmations = AV22transaction.gxTpr_Confirmations;
         AV15oneTransactionFromFile.gxTpr_Usedin.gxTpr_Transactionid = AV22transaction.gxTpr_Used.gxTpr_Usedid;
         AV15oneTransactionFromFile.gxTpr_Usedin.gxTpr_N = AV22transaction.gxTpr_Used.gxTpr_Usedn;
         AV15oneTransactionFromFile.gxTpr_Usedin.gxTpr_Datetime = AV22transaction.gxTpr_Used.gxTpr_Useddatetime;
         AV31GXV5 = 1;
         while ( AV31GXV5 <= AV22transaction.gxTpr_Used.gxTpr_Usedto.Count )
         {
            AV16oneUsedServiceAddress = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item)AV22transaction.gxTpr_Used.gxTpr_Usedto.Item(AV31GXV5));
            AV17oneUsedTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem(context);
            AV17oneUsedTransactionFromFile.gxTpr_Scriptpubkey_address = AV16oneUsedServiceAddress.gxTpr_Scriptpubkey_address;
            AV17oneUsedTransactionFromFile.gxTpr_N = AV16oneUsedServiceAddress.gxTpr_N;
            AV17oneUsedTransactionFromFile.gxTpr_Value = AV16oneUsedServiceAddress.gxTpr_Value;
            AV15oneTransactionFromFile.gxTpr_Usedin.gxTpr_Usedto.Add(AV17oneUsedTransactionFromFile, 0);
            AV31GXV5 = (int)(AV31GXV5+1);
         }
         AV19StoredTransactions.gxTpr_Transaction.Add(AV15oneTransactionFromFile, 0);
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
         AV19StoredTransactions = new GeneXus.Programs.wallet.SdtStoredTransactions(context);
         AV8error = "";
         AV26transactionsFromService = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV25transactionsFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions(context);
         AV14oneTempTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV22transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV20tempDesctiption = "";
         AV13oneFoundTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV21tempUsedTransactionId = "";
         GXt_char1 = "";
         AV10HttpMessage = new GeneXus.Utils.SdtMessages_Message(context);
         AV15oneTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV16oneUsedServiceAddress = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item(context);
         AV17oneUsedTransactionFromFile = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem(context);
         /* GeneXus formulas. */
      }

      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private int AV29GXV3 ;
      private int AV30GXV4 ;
      private int AV31GXV5 ;
      private string AV23transactionFileName ;
      private string AV8error ;
      private string AV21tempUsedTransactionId ;
      private string GXt_char1 ;
      private bool AV11IsSuccess ;
      private bool AV9found ;
      private bool returnInSub ;
      private string AV20tempDesctiption ;
      private GeneXus.Utils.SdtMessages_Message AV10HttpMessage ;
      private GeneXus.Programs.wallet.SdtStoredTransactions aP2_StoredTransactions ;
      private string aP3_error ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV19StoredTransactions ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV25transactionsFromFile ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV14oneTempTransactionFromFile ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV13oneFoundTransactionFromFile ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV15oneTransactionFromFile ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem_UsedIn_UsedToItem AV17oneUsedTransactionFromFile ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_Used_UsedTo_Item AV16oneUsedServiceAddress ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV22transaction ;
      private SdtGetTransactions__postInput AV24transactions__postInput ;
      private SdtGxExplorer_services_TxoutFromAddresses AV26transactionsFromService ;
   }

}
