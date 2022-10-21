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
   public class eccverifymsg : GXProcedure
   {
      public eccverifymsg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccverifymsg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_pubKey ,
                           string aP1_message ,
                           string aP2_signature ,
                           out bool aP3_verified ,
                           out string aP4_error )
      {
         this.AV11pubKey = aP0_pubKey;
         this.AV13message = aP1_message;
         this.AV14signature = aP2_signature;
         this.AV15verified = false ;
         this.AV10error = "" ;
         initialize();
         executePrivate();
         aP3_verified=this.AV15verified;
         aP4_error=this.AV10error;
      }

      public string executeUdp( string aP0_pubKey ,
                                string aP1_message ,
                                string aP2_signature ,
                                out bool aP3_verified )
      {
         execute(aP0_pubKey, aP1_message, aP2_signature, out aP3_verified, out aP4_error);
         return AV10error ;
      }

      public void executeSubmit( string aP0_pubKey ,
                                 string aP1_message ,
                                 string aP2_signature ,
                                 out bool aP3_verified ,
                                 out string aP4_error )
      {
         eccverifymsg objeccverifymsg;
         objeccverifymsg = new eccverifymsg();
         objeccverifymsg.AV11pubKey = aP0_pubKey;
         objeccverifymsg.AV13message = aP1_message;
         objeccverifymsg.AV14signature = aP2_signature;
         objeccverifymsg.AV15verified = false ;
         objeccverifymsg.AV10error = "" ;
         objeccverifymsg.context.SetSubmitInitialConfig(context);
         objeccverifymsg.initialize();
         Submit( executePrivateCatch,objeccverifymsg);
         aP3_verified=this.AV15verified;
         aP4_error=this.AV10error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccverifymsg)stateInfo).executePrivate();
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
          string hexPubKey = AV11pubKey;
         /* User Code */
          byte[] bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPubKey);
         /* User Code */
          NBitcoin.PubKey publicKey = new NBitcoin.PubKey(bytes);
         /* User Code */
          bool val = publicKey.VerifyMessage(AV13message,AV14signature);
         /* User Code */
          AV15verified = val;
         /* User Code */
         	}
         /* User Code */
             catch (Exception ex)
         /* User Code */
             {
         /* User Code */
              AV10error = ex.Message.ToString();
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
         AV10error = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV11pubKey ;
      private string AV14signature ;
      private string AV10error ;
      private bool AV15verified ;
      private string AV13message ;
      private bool aP3_verified ;
      private string aP4_error ;
   }

}
