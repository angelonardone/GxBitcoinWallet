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
   public class getbalancefromhistorywithbalance : GXProcedure
   {
      public getbalancefromhistorywithbalance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getbalancefromhistorywithbalance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out decimal aP0_totalBalance )
      {
         this.AV8totalBalance = 0 ;
         initialize();
         executePrivate();
         aP0_totalBalance=this.AV8totalBalance;
      }

      public decimal executeUdp( )
      {
         execute(out aP0_totalBalance);
         return AV8totalBalance ;
      }

      public void executeSubmit( out decimal aP0_totalBalance )
      {
         getbalancefromhistorywithbalance objgetbalancefromhistorywithbalance;
         objgetbalancefromhistorywithbalance = new getbalancefromhistorywithbalance();
         objgetbalancefromhistorywithbalance.AV8totalBalance = 0 ;
         objgetbalancefromhistorywithbalance.context.SetSubmitInitialConfig(context);
         objgetbalancefromhistorywithbalance.initialize();
         Submit( executePrivateCatch,objgetbalancefromhistorywithbalance);
         aP0_totalBalance=this.AV8totalBalance;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getbalancefromhistorywithbalance)stateInfo).executePrivate();
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
         GXt_objcol_SdtSDTAddressHistory1 = AV10historyWithBalance;
         new GeneXus.Programs.wallet.gethistorywithbalance(context ).execute( out  GXt_objcol_SdtSDTAddressHistory1) ;
         AV10historyWithBalance = GXt_objcol_SdtSDTAddressHistory1;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10historyWithBalance.Count )
         {
            AV9oneAddressHistory = ((GeneXus.Programs.wallet.SdtSDTAddressHistory)AV10historyWithBalance.Item(AV13GXV1));
            AV8totalBalance = (decimal)(AV8totalBalance+(AV9oneAddressHistory.gxTpr_Balance));
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV10historyWithBalance = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         GXt_objcol_SdtSDTAddressHistory1 = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory>( context, "SDTAddressHistory", "GxBitcoinWallet");
         AV9oneAddressHistory = new GeneXus.Programs.wallet.SdtSDTAddressHistory(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV13GXV1 ;
      private decimal AV8totalBalance ;
      private decimal aP0_totalBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV10historyWithBalance ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> GXt_objcol_SdtSDTAddressHistory1 ;
      private GeneXus.Programs.wallet.SdtSDTAddressHistory AV9oneAddressHistory ;
   }

}
