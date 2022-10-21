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
   public class getwalletalllines : GXProcedure
   {
      public getwalletalllines( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getwalletalllines( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> aP0_walletAllLines )
      {
         this.AV9walletAllLines = new GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine>( context, "WalletLine", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_walletAllLines=this.AV9walletAllLines;
      }

      public GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> executeUdp( )
      {
         execute(out aP0_walletAllLines);
         return AV9walletAllLines ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> aP0_walletAllLines )
      {
         getwalletalllines objgetwalletalllines;
         objgetwalletalllines = new getwalletalllines();
         objgetwalletalllines.AV9walletAllLines = new GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine>( context, "WalletLine", "GxBitcoinWallet") ;
         objgetwalletalllines.context.SetSubmitInitialConfig(context);
         objgetwalletalllines.initialize();
         Submit( executePrivateCatch,objgetwalletalllines);
         aP0_walletAllLines=this.AV9walletAllLines;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getwalletalllines)stateInfo).executePrivate();
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
         AV9walletAllLines.FromJSonString(AV8WebSession.Get("WalletAllLines"), null);
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
         AV9walletAllLines = new GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine>( context, "WalletLine", "GxBitcoinWallet");
         AV8WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV8WebSession ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> aP0_walletAllLines ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtWalletLine> AV9walletAllLines ;
   }

}
