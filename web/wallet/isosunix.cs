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
   public class isosunix : GXProcedure
   {
      public isosunix( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public isosunix( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_isUnix )
      {
         this.AV8isUnix = false ;
         initialize();
         executePrivate();
         aP0_isUnix=this.AV8isUnix;
      }

      public bool executeUdp( )
      {
         execute(out aP0_isUnix);
         return AV8isUnix ;
      }

      public void executeSubmit( out bool aP0_isUnix )
      {
         isosunix objisosunix;
         objisosunix = new isosunix();
         objisosunix.AV8isUnix = false ;
         objisosunix.context.SetSubmitInitialConfig(context);
         objisosunix.initialize();
         Submit( executePrivateCatch,objisosunix);
         aP0_isUnix=this.AV8isUnix;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isosunix)stateInfo).executePrivate();
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
          OperatingSystem os = Environment.OSVersion;
         /* User Code */
          PlatformID     pid = os.Platform;
         /* User Code */
          bool isUnix = pid == PlatformID.Unix;
         /* User Code */
          AV8isUnix = isUnix;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV8isUnix ;
      private bool aP0_isUnix ;
   }

}
