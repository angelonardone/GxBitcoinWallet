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
   public class setwallet : GXProcedure
   {
      public setwallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public setwallet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wallet.SdtWallet aP0_wallet )
      {
         this.AV9wallet = aP0_wallet;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.wallet.SdtWallet aP0_wallet )
      {
         setwallet objsetwallet;
         objsetwallet = new setwallet();
         objsetwallet.AV9wallet = aP0_wallet;
         objsetwallet.context.SetSubmitInitialConfig(context);
         objsetwallet.initialize();
         Submit( executePrivateCatch,objsetwallet);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setwallet)stateInfo).executePrivate();
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
         AV8WebSession.Set("Wallet", AV9wallet.ToJSonString(false, true));
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
      private GeneXus.Programs.wallet.SdtWallet AV9wallet ;
   }

}
