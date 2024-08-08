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
namespace GeneXus.Programs.sudodb {
   public class savevouts : GXProcedure
   {
      public savevouts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public savevouts( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId ,
                           out string aP1_error )
      {
         this.AV8electrumRespGetTransactionId = aP0_electrumRespGetTransactionId;
         this.AV16error = "" ;
         initialize();
         ExecuteImpl();
         aP1_error=this.AV16error;
      }

      public string executeUdp( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId )
      {
         execute(aP0_electrumRespGetTransactionId, out aP1_error);
         return AV16error ;
      }

      public void executeSubmit( GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId aP0_electrumRespGetTransactionId ,
                                 out string aP1_error )
      {
         this.AV8electrumRespGetTransactionId = aP0_electrumRespGetTransactionId;
         this.AV16error = "" ;
         SubmitImpl();
         aP1_error=this.AV16error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15transactionId = StringUtil.Trim( AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Txid);
         AV14DBvOUTs.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBvOUT.db", out  AV16error), null);
         AV14DBvOUTs.Sort("TransactionId,n");
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Vout.Count )
         {
            AV11oneVout = ((GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_voutItem)AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Vout.Item(AV18GXV1));
            AV13oneDBvOUT = new GeneXus.Programs.sudodb.SdtvOUT(context);
            AV13oneDBvOUT.gxTpr_Transactionid = AV15transactionId;
            AV13oneDBvOUT.gxTpr_N = (long)(Math.Round(AV11oneVout.gxTpr_N, 18, MidpointRounding.ToEven));
            AV13oneDBvOUT.gxTpr_Value = AV11oneVout.gxTpr_Value;
            AV13oneDBvOUT.gxTpr_Scriptpubkey_address = StringUtil.Trim( AV11oneVout.gxTpr_Scriptpubkey.gxTpr_Address);
            AV13oneDBvOUT.gxTpr_Type = StringUtil.Trim( AV11oneVout.gxTpr_Scriptpubkey.gxTpr_Type);
            AV19GXV2 = 1;
            while ( AV19GXV2 <= AV14DBvOUTs.Count )
            {
               AV17tempDBvOUT = ((GeneXus.Programs.sudodb.SdtvOUT)AV14DBvOUTs.Item(AV19GXV2));
               if ( ( StringUtil.StrCmp(AV17tempDBvOUT.gxTpr_Transactionid, AV13oneDBvOUT.gxTpr_Transactionid) == 0 ) && ( AV17tempDBvOUT.gxTpr_N == AV13oneDBvOUT.gxTpr_N ) )
               {
                  AV14DBvOUTs.RemoveItem(AV14DBvOUTs.IndexOf(AV17tempDBvOUT));
                  if (true) break;
               }
               AV19GXV2 = (int)(AV19GXV2+1);
            }
            AV14DBvOUTs.Add(AV13oneDBvOUT, 0);
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV14DBvOUTs.Sort("scriptPubKey_address");
         GXt_char1 = AV16error;
         new GeneXus.Programs.wallet.savejsonencfile(context ).execute(  "DBvOUT.db",  AV14DBvOUTs.ToJSonString(false), out  GXt_char1) ;
         AV16error = GXt_char1;
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
         AV16error = "";
         AV15transactionId = "";
         AV14DBvOUTs = new GXBaseCollection<GeneXus.Programs.sudodb.SdtvOUT>( context, "vOUT", "GxBitcoinWallet");
         AV11oneVout = new GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_voutItem(context);
         AV13oneDBvOUT = new GeneXus.Programs.sudodb.SdtvOUT(context);
         AV17tempDBvOUT = new GeneXus.Programs.sudodb.SdtvOUT(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private int AV19GXV2 ;
      private string AV16error ;
      private string AV15transactionId ;
      private string GXt_char1 ;
      private string aP1_error ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtvOUT> AV14DBvOUTs ;
      private GeneXus.Programs.sudodb.SdtvOUT AV13oneDBvOUT ;
      private GeneXus.Programs.sudodb.SdtvOUT AV17tempDBvOUT ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId AV8electrumRespGetTransactionId ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_voutItem AV11oneVout ;
   }

}
