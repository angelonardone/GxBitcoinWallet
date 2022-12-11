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
   public class updatetransactionsaftercoinsent : GXProcedure
   {
      public updatetransactionsaftercoinsent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public updatetransactionsaftercoinsent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP0_transactionsToSend ,
                           out string aP1_error )
      {
         this.AV14transactionsToSend = aP0_transactionsToSend;
         this.AV11error = "" ;
         initialize();
         executePrivate();
         aP1_error=this.AV11error;
      }

      public string executeUdp( GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP0_transactionsToSend )
      {
         execute(aP0_transactionsToSend, out aP1_error);
         return AV11error ;
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP0_transactionsToSend ,
                                 out string aP1_error )
      {
         updatetransactionsaftercoinsent objupdatetransactionsaftercoinsent;
         objupdatetransactionsaftercoinsent = new updatetransactionsaftercoinsent();
         objupdatetransactionsaftercoinsent.AV14transactionsToSend = aP0_transactionsToSend;
         objupdatetransactionsaftercoinsent.AV11error = "" ;
         objupdatetransactionsaftercoinsent.context.SetSubmitInitialConfig(context);
         objupdatetransactionsaftercoinsent.initialize();
         Submit( executePrivateCatch,objupdatetransactionsaftercoinsent);
         aP1_error=this.AV11error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updatetransactionsaftercoinsent)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV14transactionsToSend.Count )
            {
               AV15oneTransaction = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV14transactionsToSend.Item(AV18GXV1));
               if ( new GeneXus.Programs.wallet.searchtransactiononsdt(context).executeUdp(  AV9transactionsFromFile,  AV15oneTransaction.gxTpr_Receivedtransactionid, out  AV13transactionfound) )
               {
                  AV13transactionfound.gxTpr_Used.gxTpr_Useddatetime = DateTimeUtil.Now( context);
                  AV19GXV2 = 1;
                  while ( AV19GXV2 <= AV9transactionsFromFile.gxTpr_Transaction.Count )
                  {
                     AV12transaction = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)AV9transactionsFromFile.gxTpr_Transaction.Item(AV19GXV2));
                     if ( StringUtil.StrCmp(AV12transaction.gxTpr_Transactionid, AV13transactionfound.gxTpr_Transactionid) == 0 )
                     {
                        AV9transactionsFromFile.gxTpr_Transaction.CurrentItem = AV13transactionfound;
                     }
                     AV19GXV2 = (int)(AV19GXV2+1);
                  }
               }
               else
               {
                  AV11error = "We didn't find the transacion Spent on the Saved Transactions";
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
            {
               GXt_char1 = AV11error;
               new GeneXus.Programs.wallet.savetransactionfile(context ).execute(  AV9transactionsFromFile, out  GXt_char1) ;
               AV11error = GXt_char1;
            }
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
         AV11error = "";
         AV9transactionsFromFile = new SdtGxExplorer_services_TxoutFromAddresses(context);
         AV15oneTransaction = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         AV13transactionfound = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV12transaction = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV1 ;
      private int AV19GXV2 ;
      private string AV11error ;
      private string GXt_char1 ;
      private string aP1_error ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV14transactionsToSend ;
      private SdtGxExplorer_services_TxoutFromAddresses AV9transactionsFromFile ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV13transactionfound ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV12transaction ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV15oneTransaction ;
   }

}
