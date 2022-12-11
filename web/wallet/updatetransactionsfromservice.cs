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
   public class updatetransactionsfromservice : GXProcedure
   {
      public updatetransactionsfromservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public updatetransactionsfromservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGxExplorer_services_TxoutFromAddresses aP0_transactionsFromService ,
                           out SdtGxExplorer_services_TxoutFromAddresses aP1_mixedTransactions )
      {
         this.AV8transactionsFromService = aP0_transactionsFromService;
         this.AV10mixedTransactions = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         initialize();
         executePrivate();
         aP1_mixedTransactions=this.AV10mixedTransactions;
      }

      public SdtGxExplorer_services_TxoutFromAddresses executeUdp( SdtGxExplorer_services_TxoutFromAddresses aP0_transactionsFromService )
      {
         execute(aP0_transactionsFromService, out aP1_mixedTransactions);
         return AV10mixedTransactions ;
      }

      public void executeSubmit( SdtGxExplorer_services_TxoutFromAddresses aP0_transactionsFromService ,
                                 out SdtGxExplorer_services_TxoutFromAddresses aP1_mixedTransactions )
      {
         updatetransactionsfromservice objupdatetransactionsfromservice;
         objupdatetransactionsfromservice = new updatetransactionsfromservice();
         objupdatetransactionsfromservice.AV8transactionsFromService = aP0_transactionsFromService;
         objupdatetransactionsfromservice.AV10mixedTransactions = new SdtGxExplorer_services_TxoutFromAddresses(context) ;
         objupdatetransactionsfromservice.context.SetSubmitInitialConfig(context);
         objupdatetransactionsfromservice.initialize();
         Submit( executePrivateCatch,objupdatetransactionsfromservice);
         aP1_mixedTransactions=this.AV10mixedTransactions;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updatetransactionsfromservice)stateInfo).executePrivate();
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
         GXt_char1 = AV11error;
         new GeneXus.Programs.wallet.readtransactionfile(context ).execute( out  AV9transactionsFromFile, out  GXt_char1) ;
         AV11error = GXt_char1;
         AV9transactionsFromFile.gxTpr_Transaction.Sort("TransactionId");
         AV8transactionsFromService.gxTpr_Transaction.Sort("TransactionId");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV8transactionsFromService.gxTpr_Transaction.Count )
            {
               AV12transaction = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)AV8transactionsFromService.gxTpr_Transaction.Item(AV18GXV1));
               if ( new GeneXus.Programs.wallet.searchtransactiononsdt(context).executeUdp(  AV9transactionsFromFile,  AV12transaction.gxTpr_Transactionid, out  AV13transactionfound) )
               {
                  if ( ! (DateTime.MinValue==AV13transactionfound.gxTpr_Used.gxTpr_Useddatetime) )
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12transaction.gxTpr_Used.gxTpr_Usedid)) )
                     {
                        AV12transaction.gxTpr_Used = AV13transactionfound.gxTpr_Used;
                     }
                     else
                     {
                        AV15time24ofTransaction = DateTimeUtil.TAdd( AV13transactionfound.gxTpr_Used.gxTpr_Useddatetime, 3600*(24));
                        if ( AV15time24ofTransaction > DateTimeUtil.Now( context) )
                        {
                           AV12transaction = AV13transactionfound;
                        }
                     }
                  }
               }
               else
               {
               }
               AV10mixedTransactions.gxTpr_Transaction.Add(AV12transaction, 0);
               AV18GXV1 = (int)(AV18GXV1+1);
            }
            GXt_char1 = AV11error;
            new GeneXus.Programs.wallet.savetransactionfile(context ).execute(  AV10mixedTransactions, out  GXt_char1) ;
            AV11error = GXt_char1;
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
         AV10mixedTransactions = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV11error = "";
         AV9transactionsFromFile = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV12transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV13transactionfound = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV15time24ofTransaction = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV1 ;
      private string AV11error ;
      private string GXt_char1 ;
      private DateTime AV15time24ofTransaction ;
      private SdtGxExplorer_services_TxoutFromAddresses aP1_mixedTransactions ;
      private SdtGxExplorer_services_TxoutFromAddresses AV8transactionsFromService ;
      private SdtGxExplorer_services_TxoutFromAddresses AV10mixedTransactions ;
      private SdtGxExplorer_services_TxoutFromAddresses AV9transactionsFromFile ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV12transaction ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV13transactionfound ;
   }

}
