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
   public class lookforaddressontransactions : GXProcedure
   {
      public lookforaddressontransactions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public lookforaddressontransactions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                           GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                           out short aP2_numFound )
      {
         this.AV13StoredTransactions = aP0_StoredTransactions;
         this.AV9allKeyInfo = aP1_allKeyInfo;
         this.AV12numFound = 0 ;
         initialize();
         ExecuteImpl();
         aP2_numFound=this.AV12numFound;
      }

      public short executeUdp( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                               GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo )
      {
         execute(aP0_StoredTransactions, aP1_allKeyInfo, out aP2_numFound);
         return AV12numFound ;
      }

      public void executeSubmit( GeneXus.Programs.wallet.SdtStoredTransactions aP0_StoredTransactions ,
                                 GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                                 out short aP2_numFound )
      {
         this.AV13StoredTransactions = aP0_StoredTransactions;
         this.AV9allKeyInfo = aP1_allKeyInfo;
         this.AV12numFound = 0 ;
         SubmitImpl();
         aP2_numFound=this.AV12numFound;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12numFound = 0;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV13StoredTransactions.gxTpr_Transaction.Count )
         {
            AV14oneStoreTransaction = ((GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem)AV13StoredTransactions.gxTpr_Transaction.Item(AV15GXV1));
            if ( new GeneXus.Programs.wallet.searchkeyinallkeys(context).executeUdp(  AV14oneStoreTransaction.gxTpr_Scriptpubkey_address,  AV9allKeyInfo, out  AV11oneKeyInfo) )
            {
               AV12numFound = (short)(AV12numFound+1);
            }
            AV15GXV1 = (int)(AV15GXV1+1);
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
         AV14oneStoreTransaction = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         AV11oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         /* GeneXus formulas. */
      }

      private short AV12numFound ;
      private int AV15GXV1 ;
      private short aP2_numFound ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV9allKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV11oneKeyInfo ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV13StoredTransactions ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV14oneStoreTransaction ;
   }

}
