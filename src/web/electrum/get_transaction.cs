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
namespace GeneXus.Programs.electrum {
   public class get_transaction : GXProcedure
   {
      public get_transaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public get_transaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_transactionId ,
                           short aP1_messageType ,
                           out string aP2_messageResponse ,
                           out string aP3_error )
      {
         this.AV13transactionId = aP0_transactionId;
         this.AV14messageType = aP1_messageType;
         this.AV15messageResponse = "" ;
         this.AV9error = "" ;
         initialize();
         ExecuteImpl();
         aP2_messageResponse=this.AV15messageResponse;
         aP3_error=this.AV9error;
      }

      public string executeUdp( string aP0_transactionId ,
                                short aP1_messageType ,
                                out string aP2_messageResponse )
      {
         execute(aP0_transactionId, aP1_messageType, out aP2_messageResponse, out aP3_error);
         return AV9error ;
      }

      public void executeSubmit( string aP0_transactionId ,
                                 short aP1_messageType ,
                                 out string aP2_messageResponse ,
                                 out string aP3_error )
      {
         this.AV13transactionId = aP0_transactionId;
         this.AV14messageType = aP1_messageType;
         this.AV15messageResponse = "" ;
         this.AV9error = "" ;
         SubmitImpl();
         aP2_messageResponse=this.AV15messageResponse;
         aP3_error=this.AV9error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12sendMessage = "{\"jsonrpc\": \"2.0\",\"id\": \"blockchain.transaction.get\",\"method\": \"blockchain.transaction.get\",\"params\": [\"" + StringUtil.Trim( AV13transactionId) + "\",true]}";
         GXt_char1 = AV9error;
         new GeneXus.Programs.electrum.sendmessage(context ).execute(  AV12sendMessage,  AV14messageType, out  AV15messageResponse, out  GXt_char1) ;
         AV9error = GXt_char1;
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
         AV15messageResponse = "";
         AV9error = "";
         AV12sendMessage = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private short AV14messageType ;
      private string AV13transactionId ;
      private string AV9error ;
      private string GXt_char1 ;
      private string AV15messageResponse ;
      private string AV12sendMessage ;
      private string aP2_messageResponse ;
      private string aP3_error ;
   }

}
