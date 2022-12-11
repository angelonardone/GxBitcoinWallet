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
   public class sendrawtransaction : GXProcedure
   {
      public sendrawtransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public sendrawtransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_hexTransaction ,
                           out string aP1_error )
      {
         this.AV37hexTransaction = aP0_hexTransaction;
         this.AV38error = "" ;
         initialize();
         executePrivate();
         aP1_error=this.AV38error;
      }

      public string executeUdp( string aP0_hexTransaction )
      {
         execute(aP0_hexTransaction, out aP1_error);
         return AV38error ;
      }

      public void executeSubmit( string aP0_hexTransaction ,
                                 out string aP1_error )
      {
         sendrawtransaction objsendrawtransaction;
         objsendrawtransaction = new sendrawtransaction();
         objsendrawtransaction.AV37hexTransaction = aP0_hexTransaction;
         objsendrawtransaction.AV38error = "" ;
         objsendrawtransaction.context.SetSubmitInitialConfig(context);
         objsendrawtransaction.initialize();
         Submit( executePrivateCatch,objsendrawtransaction);
         aP1_error=this.AV38error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendrawtransaction)stateInfo).executePrivate();
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
         AV36rawTransaction_postInput.gxTpr_Hextransaction = AV37hexTransaction;
         new gxexplorerservicesrestrawtransactionpost(context ).execute(  AV33ServerUrlTemplatingVar,  AV36rawTransaction_postInput, out  AV34RawTransaction__postOutputOUT, out  AV21HttpMessage, out  AV22IsSuccess) ;
         AV38error = AV34RawTransaction__postOutputOUT.gxTpr_Error;
         GX_msglist.addItem(AV34RawTransaction__postOutputOUT.ToJSonString(false, true));
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
         AV38error = "";
         AV36rawTransaction_postInput = new SdtRawTransaction__postInput(context);
         AV33ServerUrlTemplatingVar = new GXProperties();
         AV34RawTransaction__postOutputOUT = new SdtRawTransaction__postOutput(context);
         AV21HttpMessage = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV38error ;
      private bool AV22IsSuccess ;
      private string AV37hexTransaction ;
      private string aP1_error ;
      private GXProperties AV33ServerUrlTemplatingVar ;
      private GeneXus.Utils.SdtMessages_Message AV21HttpMessage ;
      private SdtRawTransaction__postOutput AV34RawTransaction__postOutputOUT ;
      private SdtRawTransaction__postInput AV36rawTransaction_postInput ;
   }

}
