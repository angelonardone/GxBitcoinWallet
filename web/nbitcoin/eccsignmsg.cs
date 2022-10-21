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
namespace GeneXus.Programs.nbitcoin {
   public class eccsignmsg : GXProcedure
   {
      public eccsignmsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccsignmsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_privateKey ,
                           string aP1_message ,
                           out string aP2_signature ,
                           out string aP3_error )
      {
         this.AV9privateKey = aP0_privateKey;
         this.AV11message = aP1_message;
         this.AV12signature = "" ;
         this.AV8error = "" ;
         initialize();
         executePrivate();
         aP2_signature=this.AV12signature;
         aP3_error=this.AV8error;
      }

      public string executeUdp( string aP0_privateKey ,
                                string aP1_message ,
                                out string aP2_signature )
      {
         execute(aP0_privateKey, aP1_message, out aP2_signature, out aP3_error);
         return AV8error ;
      }

      public void executeSubmit( string aP0_privateKey ,
                                 string aP1_message ,
                                 out string aP2_signature ,
                                 out string aP3_error )
      {
         eccsignmsg objeccsignmsg;
         objeccsignmsg = new eccsignmsg();
         objeccsignmsg.AV9privateKey = aP0_privateKey;
         objeccsignmsg.AV11message = aP1_message;
         objeccsignmsg.AV12signature = "" ;
         objeccsignmsg.AV8error = "" ;
         objeccsignmsg.context.SetSubmitInitialConfig(context);
         objeccsignmsg.initialize();
         Submit( executePrivateCatch,objeccsignmsg);
         aP2_signature=this.AV12signature;
         aP3_error=this.AV8error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccsignmsg)stateInfo).executePrivate();
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
          try
         /* User Code */
          {
         /* User Code */
          string hexPrivateKey = AV9privateKey;
         /* User Code */
          byte[] bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPrivateKey);
         /* User Code */
          NBitcoin.Key privateKey = new NBitcoin.Key(bytes);
         /* User Code */
          string val = privateKey.SignMessage(AV11message);
         /* User Code */
          AV10val = val;
         AV12signature = AV10val;
         /* User Code */
         	}
         /* User Code */
             catch (Exception ex)
         /* User Code */
             {
         /* User Code */
              AV8error = ex.Message.ToString();
         /* User Code */
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
         AV12signature = "";
         AV8error = "";
         AV10val = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9privateKey ;
      private string AV12signature ;
      private string AV8error ;
      private string AV10val ;
      private string AV11message ;
      private string aP2_signature ;
      private string aP3_error ;
   }

}
