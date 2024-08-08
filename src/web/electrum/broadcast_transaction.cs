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
   public class broadcast_transaction : GXProcedure
   {
      public broadcast_transaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public broadcast_transaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_hex ,
                           out string aP1_transactionId ,
                           out string aP2_error )
      {
         this.AV13hex = aP0_hex;
         this.AV10transactionId = "" ;
         this.AV8error = "" ;
         initialize();
         ExecuteImpl();
         aP1_transactionId=this.AV10transactionId;
         aP2_error=this.AV8error;
      }

      public string executeUdp( string aP0_hex ,
                                out string aP1_transactionId )
      {
         execute(aP0_hex, out aP1_transactionId, out aP2_error);
         return AV8error ;
      }

      public void executeSubmit( string aP0_hex ,
                                 out string aP1_transactionId ,
                                 out string aP2_error )
      {
         this.AV13hex = aP0_hex;
         this.AV10transactionId = "" ;
         this.AV8error = "" ;
         SubmitImpl();
         aP1_transactionId=this.AV10transactionId;
         aP2_error=this.AV8error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9sendMessage = "{\"jsonrpc\": \"2.0\",\"id\": \"blockchain.transaction.broadcast\",\"method\": \"blockchain.transaction.broadcast\",\"params\": [\"" + StringUtil.Trim( AV13hex) + "\"]}";
         GXt_char1 = AV8error;
         new GeneXus.Programs.electrum.sendmessage(context ).execute(  AV9sendMessage,  20, out  AV12messageResponse, out  GXt_char1) ;
         AV8error = GXt_char1;
         AV14electrumRespBroadcastTran.FromJSonString(AV12messageResponse, null);
         AV10transactionId = StringUtil.Trim( AV14electrumRespBroadcastTran.gxTpr_Result);
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
         AV10transactionId = "";
         AV8error = "";
         AV9sendMessage = "";
         GXt_char1 = "";
         AV12messageResponse = "";
         AV14electrumRespBroadcastTran = new GeneXus.Programs.electrum.SdtelectrumRespBroadcastTran(context);
         /* GeneXus formulas. */
      }

      private string AV10transactionId ;
      private string AV8error ;
      private string GXt_char1 ;
      private string AV13hex ;
      private string AV9sendMessage ;
      private string AV12messageResponse ;
      private string aP1_transactionId ;
      private string aP2_error ;
      private GeneXus.Programs.electrum.SdtelectrumRespBroadcastTran AV14electrumRespBroadcastTran ;
   }

}
