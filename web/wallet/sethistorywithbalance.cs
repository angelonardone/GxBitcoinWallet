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
   public class sethistorywithbalance : GXProcedure
   {
      public sethistorywithbalance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public sethistorywithbalance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP0_historyWithBalance )
      {
         this.AV10historyWithBalance = aP0_historyWithBalance;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> aP0_historyWithBalance )
      {
         sethistorywithbalance objsethistorywithbalance;
         objsethistorywithbalance = new sethistorywithbalance();
         objsethistorywithbalance.AV10historyWithBalance = aP0_historyWithBalance;
         objsethistorywithbalance.context.SetSubmitInitialConfig(context);
         objsethistorywithbalance.initialize();
         Submit( executePrivateCatch,objsethistorywithbalance);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sethistorywithbalance)stateInfo).executePrivate();
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
         AV8WebSession.Set("HistoryWithBalance", AV10historyWithBalance.ToJSonString(false));
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
         AV8WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV8WebSession ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDTAddressHistory> AV10historyWithBalance ;
   }

}
