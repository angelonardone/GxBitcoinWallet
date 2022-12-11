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
   public class selectcoinstosend : GXProcedure
   {
      public selectcoinstosend( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public selectcoinstosend( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( decimal aP0_amountToSend ,
                           out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_transactionsToSend )
      {
         this.AV11amountToSend = aP0_amountToSend;
         this.AV12transactionsToSend = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP1_transactionsToSend=this.AV12transactionsToSend;
      }

      public GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> executeUdp( decimal aP0_amountToSend )
      {
         execute(aP0_amountToSend, out aP1_transactionsToSend);
         return AV12transactionsToSend ;
      }

      public void executeSubmit( decimal aP0_amountToSend ,
                                 out GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_transactionsToSend )
      {
         selectcoinstosend objselectcoinstosend;
         objselectcoinstosend = new selectcoinstosend();
         objselectcoinstosend.AV11amountToSend = aP0_amountToSend;
         objselectcoinstosend.AV12transactionsToSend = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet") ;
         objselectcoinstosend.context.SetSubmitInitialConfig(context);
         objselectcoinstosend.initialize();
         Submit( executePrivateCatch,objselectcoinstosend);
         aP1_transactionsToSend=this.AV12transactionsToSend;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((selectcoinstosend)stateInfo).executePrivate();
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
         AV13feeUsedForEstimate = NumberUtil.Val( "0.00001000", ".");
         GXt_objcol_SdtSDTAddressHistory1 = AV8historyWithBalance;
         new GeneXus.Programs.wallet.gethistorywithbalance(context ).execute( out  GXt_objcol_SdtSDTAddressHistory1) ;
         AV8historyWithBalance = GXt_objcol_SdtSDTAddressHistory1;
         AV8historyWithBalance.Sort("Balance");
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV8historyWithBalance.Count )
         {
            AV9oneAddressHistory = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV8historyWithBalance.Item(AV16GXV1));
            AV10totalBalance = (decimal)(AV10totalBalance+(AV9oneAddressHistory.gxTpr_Balance));
            AV12transactionsToSend.Add(AV9oneAddressHistory, 0);
            if ( AV10totalBalance > AV11amountToSend + AV13feeUsedForEstimate )
            {
               if (true) break;
            }
            AV16GXV1 = (int)(AV16GXV1+1);
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
         AV12transactionsToSend = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV8historyWithBalance = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         GXt_objcol_SdtSDTAddressHistory1 = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV9oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV16GXV1 ;
      private decimal AV11amountToSend ;
      private decimal AV13feeUsedForEstimate ;
      private decimal AV10totalBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP1_transactionsToSend ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV12transactionsToSend ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV8historyWithBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> GXt_objcol_SdtSDTAddressHistory1 ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV9oneAddressHistory ;
   }

}
