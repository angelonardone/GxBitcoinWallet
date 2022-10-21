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
   public class setkey : GXProcedure
   {
      public setkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public setkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtKeyInfo aP0_keyInfo )
      {
         this.AV8keyInfo = aP0_keyInfo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtKeyInfo aP0_keyInfo )
      {
         setkey objsetkey;
         objsetkey = new setkey();
         objsetkey.AV8keyInfo = aP0_keyInfo;
         objsetkey.context.SetSubmitInitialConfig(context);
         objsetkey.initialize();
         Submit( executePrivateCatch,objsetkey);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setkey)stateInfo).executePrivate();
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
         AV9WebSession.Set("Key", AV8keyInfo.ToJSonString(false, true));
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
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV9WebSession ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV8keyInfo ;
   }

}
