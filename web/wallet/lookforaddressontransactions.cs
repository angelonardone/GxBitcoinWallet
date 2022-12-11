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
         context.SetDefaultTheme("Carmine");
      }

      public lookforaddressontransactions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                           GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                           out short aP2_numFound )
      {
         this.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         this.AV9allKeyInfo = aP1_allKeyInfo;
         this.AV12numFound = 0 ;
         initialize();
         executePrivate();
         aP2_numFound=this.AV12numFound;
      }

      public short executeUdp( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                               GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo )
      {
         execute(aP0_GxExplorer_services_TxoutFromAddressesOUT, aP1_allKeyInfo, out aP2_numFound);
         return AV12numFound ;
      }

      public void executeSubmit( SdtGxExplorer_services_TxoutFromAddresses aP0_GxExplorer_services_TxoutFromAddressesOUT ,
                                 GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                                 out short aP2_numFound )
      {
         lookforaddressontransactions objlookforaddressontransactions;
         objlookforaddressontransactions = new lookforaddressontransactions();
         objlookforaddressontransactions.GxExplorer_services_TxoutFromAddressesOUT = aP0_GxExplorer_services_TxoutFromAddressesOUT;
         objlookforaddressontransactions.AV9allKeyInfo = aP1_allKeyInfo;
         objlookforaddressontransactions.AV12numFound = 0 ;
         objlookforaddressontransactions.context.SetSubmitInitialConfig(context);
         objlookforaddressontransactions.initialize();
         Submit( executePrivateCatch,objlookforaddressontransactions);
         aP2_numFound=this.AV12numFound;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lookforaddressontransactions)stateInfo).executePrivate();
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
         AV12numFound = 0;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Count )
         {
            AV10TransactionItem = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Item(AV15GXV1));
            if ( new GeneXus.Programs.wallet.searchkeyinallkeys(context).executeUdp(  AV10TransactionItem.gxTpr_Scriptpubkey_address,  AV9allKeyInfo, out  AV11oneKeyInfo) )
            {
               AV12numFound = (short)(AV12numFound+1);
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
         AV10TransactionItem = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         AV11oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12numFound ;
      private int AV15GXV1 ;
      private short aP2_numFound ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV9allKeyInfo ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV10TransactionItem ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV11oneKeyInfo ;
   }

}
