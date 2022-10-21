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
   public class getecdhsharedkey : GXProcedure
   {
      public getecdhsharedkey( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getecdhsharedkey( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_privateKey ,
                           string aP1_pubKey ,
                           out string aP2_sharedKey )
      {
         this.AV8privateKey = aP0_privateKey;
         this.AV9pubKey = aP1_pubKey;
         this.AV10sharedKey = "" ;
         initialize();
         executePrivate();
         aP2_sharedKey=this.AV10sharedKey;
      }

      public string executeUdp( string aP0_privateKey ,
                                string aP1_pubKey )
      {
         execute(aP0_privateKey, aP1_pubKey, out aP2_sharedKey);
         return AV10sharedKey ;
      }

      public void executeSubmit( string aP0_privateKey ,
                                 string aP1_pubKey ,
                                 out string aP2_sharedKey )
      {
         getecdhsharedkey objgetecdhsharedkey;
         objgetecdhsharedkey = new getecdhsharedkey();
         objgetecdhsharedkey.AV8privateKey = aP0_privateKey;
         objgetecdhsharedkey.AV9pubKey = aP1_pubKey;
         objgetecdhsharedkey.AV10sharedKey = "" ;
         objgetecdhsharedkey.context.SetSubmitInitialConfig(context);
         objgetecdhsharedkey.initialize();
         Submit( executePrivateCatch,objgetecdhsharedkey);
         aP2_sharedKey=this.AV10sharedKey;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getecdhsharedkey)stateInfo).executePrivate();
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
         	NBitcoin.Key privateKey;
         /* User Code */
          string hexPrivateKey = AV8privateKey;
         /* User Code */
          byte[] bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPrivateKey);
         /* User Code */
          privateKey = new NBitcoin.Key(bytes);
         /* User Code */
          string hexPubKey = AV9pubKey;
         /* User Code */
          bytes = NBitcoin.DataEncoders.Encoders.Hex.DecodeData(hexPubKey);
         /* User Code */
          NBitcoin.PubKey publicKey = new NBitcoin.PubKey(bytes);
         /* User Code */
          var sharedKey = publicKey.GetSharedPubkey(privateKey);
         /* User Code */
          string val = sharedKey.ToString();
         /* User Code */
          AV12val = val;
         AV10sharedKey = AV12val;
         /* User Code */
         	}
         /* User Code */
             catch (Exception ex)
         /* User Code */
             {
         /* User Code */
              AV11error = ex.Message.ToString();
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
         AV10sharedKey = "";
         AV12val = "";
         AV11error = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8privateKey ;
      private string AV9pubKey ;
      private string AV10sharedKey ;
      private string AV12val ;
      private string AV11error ;
      private string aP2_sharedKey ;
   }

}
