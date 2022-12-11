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
   public class searchtransactiononsdt : GXProcedure
   {
      public searchtransactiononsdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public searchtransactiononsdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGxExplorer_services_TxoutFromAddresses aP0_transactions ,
                           string aP1_transactionId ,
                           out SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem aP2_transaction ,
                           out bool aP3_found )
      {
         this.AV9transactions = aP0_transactions;
         this.AV12transactionId = aP1_transactionId;
         this.AV8transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context) ;
         this.AV11found = false ;
         initialize();
         executePrivate();
         aP2_transaction=this.AV8transaction;
         aP3_found=this.AV11found;
      }

      public bool executeUdp( SdtGxExplorer_services_TxoutFromAddresses aP0_transactions ,
                              string aP1_transactionId ,
                              out SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem aP2_transaction )
      {
         execute(aP0_transactions, aP1_transactionId, out aP2_transaction, out aP3_found);
         return AV11found ;
      }

      public void executeSubmit( SdtGxExplorer_services_TxoutFromAddresses aP0_transactions ,
                                 string aP1_transactionId ,
                                 out SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem aP2_transaction ,
                                 out bool aP3_found )
      {
         searchtransactiononsdt objsearchtransactiononsdt;
         objsearchtransactiononsdt = new searchtransactiononsdt();
         objsearchtransactiononsdt.AV9transactions = aP0_transactions;
         objsearchtransactiononsdt.AV12transactionId = aP1_transactionId;
         objsearchtransactiononsdt.AV8transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context) ;
         objsearchtransactiononsdt.AV11found = false ;
         objsearchtransactiononsdt.context.SetSubmitInitialConfig(context);
         objsearchtransactiononsdt.initialize();
         Submit( executePrivateCatch,objsearchtransactiononsdt);
         aP2_transaction=this.AV8transaction;
         aP3_found=this.AV11found;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((searchtransactiononsdt)stateInfo).executePrivate();
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
         AV11found = false;
         AV9transactions.gxTpr_Transaction.Sort("TransactionId");
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV9transactions.gxTpr_Transaction.Count )
         {
            AV8transaction = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)AV9transactions.gxTpr_Transaction.Item(AV15GXV1));
            if ( StringUtil.StrCmp(AV8transaction.gxTpr_Transactionid, AV12transactionId) == 0 )
            {
               AV11found = true;
               this.cleanup();
               if (true) return;
            }
            AV15GXV1 = (int)(AV15GXV1+1);
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
         AV8transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV15GXV1 ;
      private string AV12transactionId ;
      private bool AV11found ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem aP2_transaction ;
      private bool aP3_found ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV8transaction ;
      private SdtGxExplorer_services_TxoutFromAddresses AV9transactions ;
   }

}
