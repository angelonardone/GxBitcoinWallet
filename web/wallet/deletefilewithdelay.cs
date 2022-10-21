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
   public class deletefilewithdelay : GXProcedure
   {
      public deletefilewithdelay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public deletefilewithdelay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_fileName )
      {
         this.AV9fileName = aP0_fileName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_fileName )
      {
         deletefilewithdelay objdeletefilewithdelay;
         objdeletefilewithdelay = new deletefilewithdelay();
         objdeletefilewithdelay.AV9fileName = aP0_fileName;
         objdeletefilewithdelay.context.SetSubmitInitialConfig(context);
         objdeletefilewithdelay.initialize();
         Submit( executePrivateCatch,objdeletefilewithdelay);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deletefilewithdelay)stateInfo).executePrivate();
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
         /* User Code */
          System.Threading.Thread.Sleep(3000);
         AV8file.Source = AV9fileName;
         AV8file.Delete();
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
         AV8file = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9fileName ;
      private GxFile AV8file ;
   }

}
