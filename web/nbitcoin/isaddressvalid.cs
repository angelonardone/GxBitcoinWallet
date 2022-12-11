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
   public class isaddressvalid : GXProcedure
   {
      public isaddressvalid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public isaddressvalid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_address ,
                           string aP1_networkType ,
                           out string aP2_error )
      {
         this.AV8address = aP0_address;
         this.AV10networkType = aP1_networkType;
         this.AV9error = "" ;
         initialize();
         executePrivate();
         aP2_error=this.AV9error;
      }

      public string executeUdp( string aP0_address ,
                                string aP1_networkType )
      {
         execute(aP0_address, aP1_networkType, out aP2_error);
         return AV9error ;
      }

      public void executeSubmit( string aP0_address ,
                                 string aP1_networkType ,
                                 out string aP2_error )
      {
         isaddressvalid objisaddressvalid;
         objisaddressvalid = new isaddressvalid();
         objisaddressvalid.AV8address = aP0_address;
         objisaddressvalid.AV10networkType = aP1_networkType;
         objisaddressvalid.AV9error = "" ;
         objisaddressvalid.context.SetSubmitInitialConfig(context);
         objisaddressvalid.initialize();
         Submit( executePrivateCatch,objisaddressvalid);
         aP2_error=this.AV9error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isaddressvalid)stateInfo).executePrivate();
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
         AV9error = "";
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
         /* User Code */
          try
         /* User Code */
          {
         /* User Code */
          string strPubKey = AV8address;
         /* User Code */
          var result = NBitcoin.BitcoinAddress.Create(strPubKey, network);
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
         AV9error = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8address ;
      private string AV10networkType ;
      private string AV9error ;
      private string aP2_error ;
   }

}
