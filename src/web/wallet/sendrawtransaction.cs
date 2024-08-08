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
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public sendrawtransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_hexTransaction ,
                           out string aP1_transactionId ,
                           out string aP2_error )
      {
         this.AV13hexTransaction = aP0_hexTransaction;
         this.AV15transactionId = "" ;
         this.AV14error = "" ;
         initialize();
         ExecuteImpl();
         aP1_transactionId=this.AV15transactionId;
         aP2_error=this.AV14error;
      }

      public string executeUdp( string aP0_hexTransaction ,
                                out string aP1_transactionId )
      {
         execute(aP0_hexTransaction, out aP1_transactionId, out aP2_error);
         return AV14error ;
      }

      public void executeSubmit( string aP0_hexTransaction ,
                                 out string aP1_transactionId ,
                                 out string aP2_error )
      {
         this.AV13hexTransaction = aP0_hexTransaction;
         this.AV15transactionId = "" ;
         this.AV14error = "" ;
         SubmitImpl();
         aP1_transactionId=this.AV15transactionId;
         aP2_error=this.AV14error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV14error;
         new GeneXus.Programs.electrum.broadcast_transaction(context ).execute(  AV13hexTransaction, out  AV15transactionId, out  GXt_char1) ;
         AV14error = GXt_char1;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV15transactionId = "";
         AV14error = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string AV15transactionId ;
      private string AV14error ;
      private string GXt_char1 ;
      private string AV13hexTransaction ;
      private string aP1_transactionId ;
      private string aP2_error ;
   }

}
