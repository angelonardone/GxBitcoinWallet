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
   public class retaddresselectrumformat : GXProcedure
   {
      public retaddresselectrumformat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public retaddresselectrumformat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_address ,
                           string aP1_networkType ,
                           out string aP2_electrumAddress ,
                           out string aP3_error )
      {
         this.AV8address = aP0_address;
         this.AV10networkType = aP1_networkType;
         this.AV9electrumAddress = "" ;
         this.AV11error = "" ;
         initialize();
         ExecuteImpl();
         aP2_electrumAddress=this.AV9electrumAddress;
         aP3_error=this.AV11error;
      }

      public string executeUdp( string aP0_address ,
                                string aP1_networkType ,
                                out string aP2_electrumAddress )
      {
         execute(aP0_address, aP1_networkType, out aP2_electrumAddress, out aP3_error);
         return AV11error ;
      }

      public void executeSubmit( string aP0_address ,
                                 string aP1_networkType ,
                                 out string aP2_electrumAddress ,
                                 out string aP3_error )
      {
         this.AV8address = aP0_address;
         this.AV10networkType = aP1_networkType;
         this.AV9electrumAddress = "" ;
         this.AV11error = "" ;
         SubmitImpl();
         aP2_electrumAddress=this.AV9electrumAddress;
         aP3_error=this.AV11error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* User Code */
          NBitcoin.Network network;
         /* User Code */
          network = NBitcoin.Network.Main;
         if ( StringUtil.StrCmp(AV10networkType, "MainNet") == 0 )
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
            AV11error = "Network Type not sopported";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11error)) )
         {
            /* User Code */
             try
            /* User Code */
             {
            /* User Code */
             string strAddress = AV8address;
            /* User Code */
             var netAddress = NBitcoin.BitcoinAddress.Create(strAddress, network);
            /* User Code */
             AV12netAddress = netAddress.ScriptPubKey.WitHash.ToString();
            GXt_char1 = AV11error;
            new GeneXus.Programs.electrum.reversehexstring(context ).execute(  AV12netAddress, out  AV9electrumAddress, out  GXt_char1) ;
            AV11error = GXt_char1;
            /* User Code */
            	}
            /* User Code */
            	catch (Exception ex)
            /* User Code */
            	{
            /* User Code */
            		AV11error = ex.Message.ToString();
            AV11error += ":" + AV8address;
            /* User Code */
            	}
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
         AV9electrumAddress = "";
         AV11error = "";
         AV12netAddress = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string AV8address ;
      private string AV10networkType ;
      private string AV9electrumAddress ;
      private string AV11error ;
      private string AV12netAddress ;
      private string GXt_char1 ;
      private string aP2_electrumAddress ;
      private string aP3_error ;
   }

}
