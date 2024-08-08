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
   public class get_history : GXProcedure
   {
      public get_history( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public get_history( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_address ,
                           string aP1_networkType ,
                           short aP2_messageType ,
                           out string aP3_messageResponse ,
                           out string aP4_error )
      {
         this.AV11address = aP0_address;
         this.AV12networkType = aP1_networkType;
         this.AV13messageType = aP2_messageType;
         this.AV14messageResponse = "" ;
         this.AV9error = "" ;
         initialize();
         ExecuteImpl();
         aP3_messageResponse=this.AV14messageResponse;
         aP4_error=this.AV9error;
      }

      public string executeUdp( string aP0_address ,
                                string aP1_networkType ,
                                short aP2_messageType ,
                                out string aP3_messageResponse )
      {
         execute(aP0_address, aP1_networkType, aP2_messageType, out aP3_messageResponse, out aP4_error);
         return AV9error ;
      }

      public void executeSubmit( string aP0_address ,
                                 string aP1_networkType ,
                                 short aP2_messageType ,
                                 out string aP3_messageResponse ,
                                 out string aP4_error )
      {
         this.AV11address = aP0_address;
         this.AV12networkType = aP1_networkType;
         this.AV13messageType = aP2_messageType;
         this.AV14messageResponse = "" ;
         this.AV9error = "" ;
         SubmitImpl();
         aP3_messageResponse=this.AV14messageResponse;
         aP4_error=this.AV9error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV9error;
         new GeneXus.Programs.electrum.retaddresselectrumformat(context ).execute(  AV11address,  AV12networkType, out  AV8scrptHash, out  GXt_char1) ;
         AV9error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            AV10sendMessage = "{\"jsonrpc\": \"2.0\",\"id\": \"blockchain.scripthash.get_history\",\"method\": \"blockchain.scripthash.get_history\",\"params\": [\"" + StringUtil.Trim( AV8scrptHash) + "\"]}";
            GXt_char1 = AV9error;
            new GeneXus.Programs.electrum.sendmessage(context ).execute(  AV10sendMessage,  AV13messageType, out  AV14messageResponse, out  GXt_char1) ;
            AV9error = GXt_char1;
         }
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
         AV14messageResponse = "";
         AV9error = "";
         AV8scrptHash = "";
         AV10sendMessage = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private short AV13messageType ;
      private string AV11address ;
      private string AV12networkType ;
      private string AV9error ;
      private string AV8scrptHash ;
      private string GXt_char1 ;
      private string AV14messageResponse ;
      private string AV10sendMessage ;
      private string aP3_messageResponse ;
      private string aP4_error ;
   }

}
