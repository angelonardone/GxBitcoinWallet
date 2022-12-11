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
namespace GeneXus.Programs.openapicommon {
   public class numerictojsonformat : GXProcedure
   {
      public numerictojsonformat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public numerictojsonformat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_Numeric ,
                           out string aP1_JsonString )
      {
         this.AV8Numeric = aP0_Numeric;
         this.AV9JsonString = "" ;
         initialize();
         executePrivate();
         aP1_JsonString=this.AV9JsonString;
      }

      public string executeUdp( short aP0_Numeric )
      {
         execute(aP0_Numeric, out aP1_JsonString);
         return AV9JsonString ;
      }

      public void executeSubmit( short aP0_Numeric ,
                                 out string aP1_JsonString )
      {
         numerictojsonformat objnumerictojsonformat;
         objnumerictojsonformat = new numerictojsonformat();
         objnumerictojsonformat.AV8Numeric = aP0_Numeric;
         objnumerictojsonformat.AV9JsonString = "" ;
         objnumerictojsonformat.context.SetSubmitInitialConfig(context);
         objnumerictojsonformat.initialize();
         Submit( executePrivateCatch,objnumerictojsonformat);
         aP1_JsonString=this.AV9JsonString;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((numerictojsonformat)stateInfo).executePrivate();
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
         AV9JsonString = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Numeric), 4, 0));
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
         AV9JsonString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Numeric ;
      private string AV9JsonString ;
      private string aP1_JsonString ;
   }

}
