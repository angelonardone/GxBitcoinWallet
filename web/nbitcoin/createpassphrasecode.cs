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
   public class createpassphrasecode : GXProcedure
   {
      public createpassphrasecode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createpassphrasecode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_password ,
                           string aP1_networkType ,
                           out string aP2_Code ,
                           out string aP3_error )
      {
         this.AV11password = aP0_password;
         this.AV10networkType = aP1_networkType;
         this.AV8Code = "" ;
         this.AV9error = "" ;
         initialize();
         executePrivate();
         aP2_Code=this.AV8Code;
         aP3_error=this.AV9error;
      }

      public string executeUdp( string aP0_password ,
                                string aP1_networkType ,
                                out string aP2_Code )
      {
         execute(aP0_password, aP1_networkType, out aP2_Code, out aP3_error);
         return AV9error ;
      }

      public void executeSubmit( string aP0_password ,
                                 string aP1_networkType ,
                                 out string aP2_Code ,
                                 out string aP3_error )
      {
         createpassphrasecode objcreatepassphrasecode;
         objcreatepassphrasecode = new createpassphrasecode();
         objcreatepassphrasecode.AV11password = aP0_password;
         objcreatepassphrasecode.AV10networkType = aP1_networkType;
         objcreatepassphrasecode.AV8Code = "" ;
         objcreatepassphrasecode.AV9error = "" ;
         objcreatepassphrasecode.context.SetSubmitInitialConfig(context);
         objcreatepassphrasecode.initialize();
         Submit( executePrivateCatch,objcreatepassphrasecode);
         aP2_Code=this.AV8Code;
         aP3_error=this.AV9error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createpassphrasecode)stateInfo).executePrivate();
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
          NBitcoin.Network network;
         /* User Code */
          network = NBitcoin.Network.Main;
         if ( StringUtil.StrCmp(AV10networkType, "Main") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.Main;
         }
         else if ( StringUtil.StrCmp(AV10networkType, "TestNet") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.TestNet;
         }
         else if ( StringUtil.StrCmp(AV10networkType, "RegTest") == 0 )
         {
            /* User Code */
             network = NBitcoin.Network.RegTest;
         }
         else
         {
            AV9error = "Network Type not sopported";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9error)) )
         {
            /* User Code */
             try
            /* User Code */
             {
            /* User Code */
             string password = AV11password;
            /* User Code */
             var passphraseCode = new NBitcoin.BitcoinPassphraseCode(password, network, null);
            /* User Code */
             AV8Code = passphraseCode.ToString();
            /* User Code */
            	}
            /* User Code */
            	catch (Exception ex)
            /* User Code */
            	{
            /* User Code */
            		AV9error = ex.Message.ToString();
            /* User Code */
            	}
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
         AV8Code = "";
         AV9error = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV11password ;
      private string AV10networkType ;
      private string AV8Code ;
      private string AV9error ;
      private string aP2_Code ;
      private string aP3_error ;
   }

}
