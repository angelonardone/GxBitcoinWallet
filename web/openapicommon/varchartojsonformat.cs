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
   public class varchartojsonformat : GXProcedure
   {
      public varchartojsonformat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public varchartojsonformat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Character ,
                           out string aP1_JsonString )
      {
         this.AV8Character = aP0_Character;
         this.AV9JsonString = "" ;
         initialize();
         executePrivate();
         aP1_JsonString=this.AV9JsonString;
      }

      public string executeUdp( string aP0_Character )
      {
         execute(aP0_Character, out aP1_JsonString);
         return AV9JsonString ;
      }

      public void executeSubmit( string aP0_Character ,
                                 out string aP1_JsonString )
      {
         varchartojsonformat objvarchartojsonformat;
         objvarchartojsonformat = new varchartojsonformat();
         objvarchartojsonformat.AV8Character = aP0_Character;
         objvarchartojsonformat.AV9JsonString = "" ;
         objvarchartojsonformat.context.SetSubmitInitialConfig(context);
         objvarchartojsonformat.initialize();
         Submit( executePrivateCatch,objvarchartojsonformat);
         aP1_JsonString=this.AV9JsonString;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((varchartojsonformat)stateInfo).executePrivate();
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
         AV9JsonString = AV8Character;
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

      private string AV8Character ;
      private string AV9JsonString ;
      private string aP1_JsonString ;
   }

}
