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
   public class setwalletalllines : GXProcedure
   {
      public setwalletalllines( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public setwalletalllines( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> aP0_walletAllLines )
      {
         this.AV9walletAllLines = aP0_walletAllLines;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> aP0_walletAllLines )
      {
         setwalletalllines objsetwalletalllines;
         objsetwalletalllines = new setwalletalllines();
         objsetwalletalllines.AV9walletAllLines = aP0_walletAllLines;
         objsetwalletalllines.context.SetSubmitInitialConfig(context);
         objsetwalletalllines.initialize();
         Submit( executePrivateCatch,objsetwalletalllines);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setwalletalllines)stateInfo).executePrivate();
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
         AV8WebSession.Set("WalletAllLines", AV9walletAllLines.ToJSonString(false));
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
      private GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> AV9walletAllLines ;
   }

}
