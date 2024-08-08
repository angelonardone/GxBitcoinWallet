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
   public class savevins : GXProcedure
   {
      public savevins( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public savevins( IGxContext context )
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
         AV13transactionId = StringUtil.Trim( AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Txid);
         AV15DBvINs.FromJSonString(new GeneXus.Programs.wallet.readjsonencfile(context).executeUdp(  "DBvIN.db", out  AV16error), null);
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Vin.Count )
         {
            AV10oneVin = ((GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_vinItem)AV8electrumRespGetTransactionId.gxTpr_Result.gxTpr_Vin.Item(AV18GXV1));
            AV14oneDBvIN = new GeneXus.Programs.sudodb.SdtvIN(context);
            AV14oneDBvIN.gxTpr_Transactionid = AV13transactionId;
            AV14oneDBvIN.gxTpr_Vintransactionid = StringUtil.Trim( AV10oneVin.gxTpr_Txid);
            AV14oneDBvIN.gxTpr_Vinn = (long)(Math.Round(AV10oneVin.gxTpr_Vout, 18, MidpointRounding.ToEven));
            AV19GXV2 = 1;
            while ( AV19GXV2 <= AV15DBvINs.Count )
            {
               AV17tempDBvIN = ((GeneXus.Programs.sudodb.SdtvIN)AV15DBvINs.Item(AV19GXV2));
               if ( ( StringUtil.StrCmp(AV17tempDBvIN.gxTpr_Vintransactionid, AV14oneDBvIN.gxTpr_Vintransactionid) == 0 ) && ( AV17tempDBvIN.gxTpr_Vinn == AV14oneDBvIN.gxTpr_Vinn ) )
               {
                  AV15DBvINs.RemoveItem(AV15DBvINs.IndexOf(AV17tempDBvIN));
                  if (true) break;
               }
               AV19GXV2 = (int)(AV19GXV2+1);
            }
            AV15DBvINs.Add(AV14oneDBvIN, 0);
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV15DBvINs.Sort("vINTransactionId,vINn");
         GXt_char1 = AV16error;
         new GeneXus.Programs.wallet.savejsonencfile(context ).execute(  "DBvIN.db",  AV15DBvINs.ToJSonString(false), out  GXt_char1) ;
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
         AV13transactionId = "";
         AV15DBvINs = new GXBaseCollection<GeneXus.Programs.sudodb.SdtvIN>( context, "vIN", "GxBitcoinWallet");
         AV10oneVin = new GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_vinItem(context);
         AV14oneDBvIN = new GeneXus.Programs.sudodb.SdtvIN(context);
         AV17tempDBvIN = new GeneXus.Programs.sudodb.SdtvIN(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private int AV19GXV2 ;
      private string AV16error ;
      private string AV13transactionId ;
      private string GXt_char1 ;
      private string aP1_error ;
      private GXBaseCollection<GeneXus.Programs.sudodb.SdtvIN> AV15DBvINs ;
      private GeneXus.Programs.sudodb.SdtvIN AV14oneDBvIN ;
      private GeneXus.Programs.sudodb.SdtvIN AV17tempDBvIN ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId AV8electrumRespGetTransactionId ;
      private GeneXus.Programs.electrum.SdtelectrumRespGetTransactionId_result_vinItem AV10oneVin ;
   }

}
