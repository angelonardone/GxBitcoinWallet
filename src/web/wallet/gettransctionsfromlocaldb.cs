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
   public class gettransctionsfromlocaldb : GXProcedure
   {
      public gettransctionsfromlocaldb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public gettransctionsfromlocaldb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGetTransactions__postInput aP0_transactions__postInput ,
                           out SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService ,
                           out string aP2_error )
      {
         this.AV8transactions__postInput = aP0_transactions__postInput;
         this.AV20transactionsFromService = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         this.AV11error = "" ;
         initialize();
         ExecuteImpl();
         aP1_transactionsFromService=this.AV20transactionsFromService;
         aP2_error=this.AV11error;
      }

      public string executeUdp( SdtGetTransactions__postInput aP0_transactions__postInput ,
                                out SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService )
      {
         execute(aP0_transactions__postInput, out aP1_transactionsFromService, out aP2_error);
         return AV11error ;
      }

      public void executeSubmit( SdtGetTransactions__postInput aP0_transactions__postInput ,
                                 out SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService ,
                                 out string aP2_error )
      {
         this.AV8transactions__postInput = aP0_transactions__postInput;
         this.AV20transactionsFromService = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         this.AV11error = "" ;
         SubmitImpl();
         aP1_transactionsFromService=this.AV20transactionsFromService;
         aP2_error=this.AV11error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWallet1 = AV22wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV22wallet = GXt_SdtWallet1;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV8transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Count )
         {
            AV10one_address = ((string)AV8transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Item(AV23GXV1));
            GXt_char2 = AV11error;
            new GeneXus.Programs.electrum.get_history(context ).execute(  AV10one_address,  AV22wallet.gxTpr_Networktype,  20, out  AV18message, out  GXt_char2) ;
            AV11error = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
            {
               AV16electrumResponse.FromJSonString(AV18message, null);
               if ( StringUtil.StrCmp(AV16electrumResponse.gxTpr_Id, "blockchain.scripthash.get_history") == 0 )
               {
                  AV14electrumRespGetHistory.FromJSonString(AV18message, null);
                  AV24GXV2 = 1;
                  while ( AV24GXV2 <= AV14electrumRespGetHistory.gxTpr_Result.Count )
                  {
                     AV17elecrumOneHistory = ((GeneXus.Programs.electrum.SdtelectrumRespGetHistory_resultItem)AV14electrumRespGetHistory.gxTpr_Result.Item(AV24GXV2));
                     GXt_char2 = AV11error;
                     new GeneXus.Programs.electrum.get_transaction(context ).execute(  AV17elecrumOneHistory.gxTpr_Tx_hash,  20, out  AV18message, out  GXt_char2) ;
                     AV11error = GXt_char2;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
                     {
                        AV16electrumResponse.FromJSonString(AV18message, null);
                        if ( StringUtil.StrCmp(AV16electrumResponse.gxTpr_Id, "blockchain.transaction.get") == 0 )
                        {
                           AV15electrumRespGetTransactionId.FromJSonString(AV18message, null);
                           if ( AV17elecrumOneHistory.gxTpr_Height == 0 )
                           {
                              AV15electrumRespGetTransactionId.gxTpr_Result.gxTpr_Confirmations = (decimal)(0);
                           }
                           GXt_char2 = AV11error;
                           new GeneXus.Programs.sudodb.savetolocaldb(context ).execute(  AV15electrumRespGetTransactionId, out  GXt_char2) ;
                           AV11error = GXt_char2;
                        }
                     }
                     AV24GXV2 = (int)(AV24GXV2+1);
                  }
               }
            }
            else
            {
               if (true) break;
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
         {
            AV25GXV3 = 1;
            while ( AV25GXV3 <= AV8transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Count )
            {
               AV10one_address = ((string)AV8transactions__postInput.gxTpr_Sdt_addressess.gxTpr_Address.Item(AV25GXV3));
               GXt_SdtGxExplorer_services_TxoutFromAddresses3 = AV20transactionsFromService;
               new GeneXus.Programs.sudodb.gettransactionsfromaddress(context ).execute(  AV10one_address, ref  GXt_SdtGxExplorer_services_TxoutFromAddresses3) ;
               AV20transactionsFromService = GXt_SdtGxExplorer_services_TxoutFromAddresses3;
               AV25GXV3 = (int)(AV25GXV3+1);
            }
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
         AV20transactionsFromService = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV11error = "";
         AV22wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV10one_address = "";
         AV18message = "";
         AV16electrumResponse = new GeneXus.Programs.electrum.SdtelectrumResponse(context);
         AV14electrumRespGetHistory = new GeneXus.Programs.electrum.SdtelectrumRespGetHistory(context);
         AV17elecrumOneHistory = new GeneXus.Programs.electrum.SdtelectrumRespGetHistory_resultItem(context);
         AV15electrumRespGetTransactionId = new GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId(context);
         GXt_char2 = "";
         GXt_SdtGxExplorer_services_TxoutFromAddresses3 = new SdtGxExplorer_services_TxoutFromAddresses(context);
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private int AV25GXV3 ;
      private string AV11error ;
      private string AV10one_address ;
      private string GXt_char2 ;
      private string AV18message ;
      private SdtGxExplorer_services_TxoutFromAddresses aP1_transactionsFromService ;
      private string aP2_error ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetHistory AV14electrumRespGetHistory ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetHistory_resultItem AV17elecrumOneHistory ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId AV15electrumRespGetTransactionId ;
      private GeneXus.Programs.electrum.SdtelectrumResponse AV16electrumResponse ;
      private SdtGetTransactions__postInput AV8transactions__postInput ;
      private SdtGxExplorer_services_TxoutFromAddresses AV20transactionsFromService ;
      private SdtGxExplorer_services_TxoutFromAddresses GXt_SdtGxExplorer_services_TxoutFromAddresses3 ;
      private GeneXus.Programs.wallet.SdtWallet AV22wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
   }

}
