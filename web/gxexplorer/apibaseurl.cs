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
namespace GeneXus.Programs.gxexplorer {
   public class apibaseurl : GXProcedure
   {
      public apibaseurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public apibaseurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PathAndMethod ,
                           out string aP1_BaseURL )
      {
         this.AV9PathAndMethod = aP0_PathAndMethod;
         this.AV8BaseURL = "" ;
         initialize();
         executePrivate();
         aP1_BaseURL=this.AV8BaseURL;
      }

      public string executeUdp( string aP0_PathAndMethod )
      {
         execute(aP0_PathAndMethod, out aP1_BaseURL);
         return AV8BaseURL ;
      }

      public void executeSubmit( string aP0_PathAndMethod ,
                                 out string aP1_BaseURL )
      {
         apibaseurl objapibaseurl;
         objapibaseurl = new apibaseurl();
         objapibaseurl.AV9PathAndMethod = aP0_PathAndMethod;
         objapibaseurl.AV8BaseURL = "" ;
         objapibaseurl.context.SetSubmitInitialConfig(context);
         objapibaseurl.initialize();
         Submit( executePrivateCatch,objapibaseurl);
         aP1_BaseURL=this.AV8BaseURL;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apibaseurl)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV9PathAndMethod, "/Transactions - POST") == 0 )
         {
            AV8BaseURL = "http://localhost:8083/GxBitcoinExplorer.NETCoreEnvironment/GxExplorer/services/TansactionsFromAddresses";
         }
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
         AV8BaseURL = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9PathAndMethod ;
      private string AV8BaseURL ;
      private string aP1_BaseURL ;
   }

}
