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
   public class scantxoutset : GXProcedure
   {
      public scantxoutset( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public scantxoutset( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc ,
                           string aP1_extPubKey ,
                           short aP2_begin ,
                           short aP3_end ,
                           ref string aP4_path ,
                           out GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response aP5_rpc_ScanTxOutSet_response )
      {
         this.AV9sdt_rpc = aP0_sdt_rpc;
         this.AV12extPubKey = aP1_extPubKey;
         this.AV13begin = aP2_begin;
         this.AV14end = aP3_end;
         this.AV20path = aP4_path;
         this.AV15rpc_ScanTxOutSet_response = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response(context) ;
         initialize();
         executePrivate();
         aP4_path=this.AV20path;
         aP5_rpc_ScanTxOutSet_response=this.AV15rpc_ScanTxOutSet_response;
      }

      public GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response executeUdp( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc ,
                                                                                string aP1_extPubKey ,
                                                                                short aP2_begin ,
                                                                                short aP3_end ,
                                                                                ref string aP4_path )
      {
         execute(aP0_sdt_rpc, aP1_extPubKey, aP2_begin, aP3_end, ref aP4_path, out aP5_rpc_ScanTxOutSet_response);
         return AV15rpc_ScanTxOutSet_response ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtSDT_rpc aP0_sdt_rpc ,
                                 string aP1_extPubKey ,
                                 short aP2_begin ,
                                 short aP3_end ,
                                 ref string aP4_path ,
                                 out GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response aP5_rpc_ScanTxOutSet_response )
      {
         scantxoutset objscantxoutset;
         objscantxoutset = new scantxoutset();
         objscantxoutset.AV9sdt_rpc = aP0_sdt_rpc;
         objscantxoutset.AV12extPubKey = aP1_extPubKey;
         objscantxoutset.AV13begin = aP2_begin;
         objscantxoutset.AV14end = aP3_end;
         objscantxoutset.AV20path = aP4_path;
         objscantxoutset.AV15rpc_ScanTxOutSet_response = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response(context) ;
         objscantxoutset.context.SetSubmitInitialConfig(context);
         objscantxoutset.initialize();
         Submit( executePrivateCatch,objscantxoutset);
         aP4_path=this.AV20path;
         aP5_rpc_ScanTxOutSet_response=this.AV15rpc_ScanTxOutSet_response;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((scantxoutset)stateInfo).executePrivate();
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
         /* User Code */
          NBitcoin.ExtPubKey pubkey;
         /* User Code */
          NBitcoin.BitcoinExtPubKey extPubK;
         /* User Code */
          NBitcoin.Scripting.OutputDescriptor outputDesc;
         if ( StringUtil.StrCmp(AV9sdt_rpc.gxTpr_Networktype, "Main") == 0 )
         {
            /* User Code */
             pubkey = NBitcoin.ExtPubKey.Parse(AV12extPubKey,NBitcoin.Network.Main);
            /* User Code */
             rpc = new NBitcoin.RPC.RPCClient(AV10tempCredentials, AV11tempServerURI, NBitcoin.Network.Main);
            /* User Code */
             extPubK = new NBitcoin.BitcoinExtPubKey(pubkey, NBitcoin.Network.Main);
            /* User Code */
             outputDesc = NBitcoin.Scripting.OutputDescriptor.NewPKH(NBitcoin.Scripting.PubKeyProvider.NewHD(extPubK, new NBitcoin.KeyPath(AV20path), NBitcoin.Scripting.PubKeyProvider.DeriveType.UNHARDENED), NBitcoin.Network.Main);
         }
         else
         {
            /* User Code */
             pubkey = NBitcoin.ExtPubKey.Parse(AV12extPubKey,NBitcoin.Network.TestNet);
            /* User Code */
             rpc = new NBitcoin.RPC.RPCClient(AV10tempCredentials, AV11tempServerURI, NBitcoin.Network.TestNet);
            /* User Code */
             extPubK = new NBitcoin.BitcoinExtPubKey(pubkey, NBitcoin.Network.TestNet);
            /* User Code */
             outputDesc = NBitcoin.Scripting.OutputDescriptor.NewPKH(NBitcoin.Scripting.PubKeyProvider.NewHD(extPubK, new NBitcoin.KeyPath(AV20path), NBitcoin.Scripting.PubKeyProvider.DeriveType.UNHARDENED), NBitcoin.Network.TestNet);
         }
         /* User Code */
          NBitcoin.RPC.ScanTxoutSetResponse result = rpc.StartScanTxoutSet(new NBitcoin.RPC.ScanTxoutSetParameters(outputDesc, AV13begin, AV14end));
         /* User Code */
          NBitcoin.RPC.ScanTxoutOutput[] txOuts = result.Outputs;
         /* User Code */
          foreach (NBitcoin.RPC.ScanTxoutOutput output in txOuts)
         /* User Code */
          {
         /* User Code */
         		AV16height = (uint)output.Height;
         /* User Code */
         		AV17amount = output.Coin.Amount.ToDecimal(NBitcoin.MoneyUnit.BTC);
         if ( StringUtil.StrCmp(AV9sdt_rpc.gxTpr_Networktype, "Main") == 0 )
         {
            /* User Code */
            		AV18address = output.Coin.TxOut.ScriptPubKey.GetDestinationAddress(NBitcoin.Network.Main).ToString();
         }
         else
         {
            /* User Code */
            		AV18address = output.Coin.TxOut.ScriptPubKey.GetDestinationAddress(NBitcoin.Network.TestNet).ToString();
         }
         AV19rpc_scanTxOutSetItem = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response_addressSubTotalItem(context);
         AV19rpc_scanTxOutSetItem.gxTpr_Address = AV18address;
         AV19rpc_scanTxOutSetItem.gxTpr_Blockhigh = AV16height;
         AV19rpc_scanTxOutSetItem.gxTpr_Amount = AV17amount;
         AV15rpc_ScanTxOutSet_response.gxTpr_Addresssubtotal.Add(AV19rpc_scanTxOutSetItem, 0);
         /* User Code */
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
         AV15rpc_ScanTxOutSet_response = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response(context);
         AV10tempCredentials = "";
         AV11tempServerURI = "";
         AV18address = "";
         AV19rpc_scanTxOutSetItem = new GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response_addressSubTotalItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13begin ;
      private short AV14end ;
      private long AV16height ;
      private long AV8lastBlock ;
      private decimal AV17amount ;
      private string AV12extPubKey ;
      private string AV20path ;
      private string AV10tempCredentials ;
      private string AV11tempServerURI ;
      private string AV18address ;
      private string aP4_path ;
      private GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response aP5_rpc_ScanTxOutSet_response ;
      private GeneXus.Programs.nbitcoin.SdtSDT_rpc AV9sdt_rpc ;
      private GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response AV15rpc_ScanTxOutSet_response ;
      private GeneXus.Programs.nbitcoin.Sdtrpc_ScanTxOutSet_response_addressSubTotalItem AV19rpc_scanTxOutSetItem ;
   }

}
