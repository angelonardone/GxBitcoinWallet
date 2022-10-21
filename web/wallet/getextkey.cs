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
   public class getextkey : GXProcedure
   {
      public getextkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getextkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.nbitcoin.SdtExtKeyInfo aP0_extKeyInfo )
      {
         this.AV8extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context) ;
         initialize();
         executePrivate();
         aP0_extKeyInfo=this.AV8extKeyInfo;
      }

      public GeneXus.Programs.nbitcoin.SdtExtKeyInfo executeUdp( )
      {
         execute(out aP0_extKeyInfo);
         return AV8extKeyInfo ;
      }

      public void executeSubmit( out GeneXus.Programs.nbitcoin.SdtExtKeyInfo aP0_extKeyInfo )
      {
         getextkey objgetextkey;
         objgetextkey = new getextkey();
         objgetextkey.AV8extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context) ;
         objgetextkey.context.SetSubmitInitialConfig(context);
         objgetextkey.initialize();
         Submit( executePrivateCatch,objgetextkey);
         aP0_extKeyInfo=this.AV8extKeyInfo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getextkey)stateInfo).executePrivate();
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
         AV8extKeyInfo.FromJSonString(AV9WebSession.Get("ExtendedKey"), null);
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
         AV8extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV9WebSession ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo aP0_extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV8extKeyInfo ;
   }

}
