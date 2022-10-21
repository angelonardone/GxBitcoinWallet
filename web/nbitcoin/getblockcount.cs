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
   public class getblockcount : GXProcedure
   {
      public getblockcount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getblockcount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc ,
                           out long aP1_lastBlock )
      {
         this.AV9sdt_rpc = aP0_sdt_rpc;
         this.AV8lastBlock = 0 ;
         initialize();
         executePrivate();
         aP1_lastBlock=this.AV8lastBlock;
      }

      public long executeUdp( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc )
      {
         execute(aP0_sdt_rpc, out aP1_lastBlock);
         return AV8lastBlock ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc ,
                                 out long aP1_lastBlock )
      {
         getblockcount objgetblockcount;
         objgetblockcount = new getblockcount();
         objgetblockcount.AV9sdt_rpc = aP0_sdt_rpc;
         objgetblockcount.AV8lastBlock = 0 ;
         objgetblockcount.context.SetSubmitInitialConfig(context);
         objgetblockcount.initialize();
         Submit( executePrivateCatch,objgetblockcount);
         aP1_lastBlock=this.AV8lastBlock;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getblockcount)stateInfo).executePrivate();
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
         AV10tempCredentials = StringUtil.Trim( AV9sdt_rpc.gxTpr_Credential);
         AV11tempServerURI = StringUtil.Trim( AV9sdt_rpc.gxTpr_Serveruri);
         /* User Code */
          NBitcoin.RPC.RPCClient rpc;
         if ( StringUtil.StrCmp(AV9sdt_rpc.gxTpr_Networktype, "Main") == 0 )
         {
            /* User Code */
             rpc = new NBitcoin.RPC.RPCClient(AV10tempCredentials, AV11tempServerURI, NBitcoin.Network.Main);
         }
         else
         {
            /* User Code */
             rpc = new NBitcoin.RPC.RPCClient(AV10tempCredentials, AV11tempServerURI, NBitcoin.Network.TestNet);
         }
         /* User Code */
          int lastBlock = rpc.GetBlockCount();
         /* User Code */
          AV8lastBlock = lastBlock;
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
         AV10tempCredentials = "";
         AV11tempServerURI = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8lastBlock ;
      private string AV10tempCredentials ;
      private string AV11tempServerURI ;
      private long aP1_lastBlock ;
      private GeneXus.Programs.nbitcoin.SdtSDT_rpc AV9sdt_rpc ;
   }

}
