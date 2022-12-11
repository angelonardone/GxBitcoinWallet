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
namespace GeneXus.Programs.wallet {
   public class getestimatesmartfee : GXProcedure
   {
      public getestimatesmartfee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public getestimatesmartfee( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_virtualSize ,
                           short aP1_numBlocks ,
                           string aP2_estimateSmartFeeType ,
                           out decimal aP3_estimatedFee ,
                           out short aP4_returnNumBlocks ,
                           out string aP5_error )
      {
         this.AV19virtualSize = aP0_virtualSize;
         this.AV18numBlocks = aP1_numBlocks;
         this.AV16estimateSmartFeeType = aP2_estimateSmartFeeType;
         this.AV22estimatedFee = 0 ;
         this.AV21returnNumBlocks = 0 ;
         this.AV15error = "" ;
         initialize();
         executePrivate();
         aP3_estimatedFee=this.AV22estimatedFee;
         aP4_returnNumBlocks=this.AV21returnNumBlocks;
         aP5_error=this.AV15error;
      }

      public string executeUdp( long aP0_virtualSize ,
                                short aP1_numBlocks ,
                                string aP2_estimateSmartFeeType ,
                                out decimal aP3_estimatedFee ,
                                out short aP4_returnNumBlocks )
      {
         execute(aP0_virtualSize, aP1_numBlocks, aP2_estimateSmartFeeType, out aP3_estimatedFee, out aP4_returnNumBlocks, out aP5_error);
         return AV15error ;
      }

      public void executeSubmit( long aP0_virtualSize ,
                                 short aP1_numBlocks ,
                                 string aP2_estimateSmartFeeType ,
                                 out decimal aP3_estimatedFee ,
                                 out short aP4_returnNumBlocks ,
                                 out string aP5_error )
      {
         getestimatesmartfee objgetestimatesmartfee;
         objgetestimatesmartfee = new getestimatesmartfee();
         objgetestimatesmartfee.AV19virtualSize = aP0_virtualSize;
         objgetestimatesmartfee.AV18numBlocks = aP1_numBlocks;
         objgetestimatesmartfee.AV16estimateSmartFeeType = aP2_estimateSmartFeeType;
         objgetestimatesmartfee.AV22estimatedFee = 0 ;
         objgetestimatesmartfee.AV21returnNumBlocks = 0 ;
         objgetestimatesmartfee.AV15error = "" ;
         objgetestimatesmartfee.context.SetSubmitInitialConfig(context);
         objgetestimatesmartfee.initialize();
         Submit( executePrivateCatch,objgetestimatesmartfee);
         aP3_estimatedFee=this.AV22estimatedFee;
         aP4_returnNumBlocks=this.AV21returnNumBlocks;
         aP5_error=this.AV15error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getestimatesmartfee)stateInfo).executePrivate();
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
         new gxexplorerservicesrestestimatesmartfeeget(context ).execute(  AV11ServerUrlTemplatingVar,  AV18numBlocks,  StringUtil.Trim( AV16estimateSmartFeeType), out  AV17EstimateSmartFee__getOutputOUT, out  AV13HttpMessage, out  AV14IsSuccess) ;
         AV20feeRate = AV17EstimateSmartFee__getOutputOUT.gxTpr_Sdt_estimatesmartfee_result.gxTpr_Result.gxTpr_Feerate;
         AV21returnNumBlocks = (short)(AV17EstimateSmartFee__getOutputOUT.gxTpr_Sdt_estimatesmartfee_result.gxTpr_Result.gxTpr_Blocks);
         AV22estimatedFee = (decimal)(AV20feeRate/ (decimal)(1000)*AV19virtualSize);
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
         AV15error = "";
         AV11ServerUrlTemplatingVar = new GXProperties();
         AV17EstimateSmartFee__getOutputOUT = new SdtEstimateSmartFee__getOutput(context);
         AV13HttpMessage = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18numBlocks ;
      private short AV21returnNumBlocks ;
      private long AV19virtualSize ;
      private decimal AV22estimatedFee ;
      private decimal AV20feeRate ;
      private string AV16estimateSmartFeeType ;
      private string AV15error ;
      private bool AV14IsSuccess ;
      private decimal aP3_estimatedFee ;
      private short aP4_returnNumBlocks ;
      private string aP5_error ;
      private GXProperties AV11ServerUrlTemplatingVar ;
      private GeneXus.Utils.SdtMessages_Message AV13HttpMessage ;
      private SdtEstimateSmartFee__getOutput AV17EstimateSmartFee__getOutputOUT ;
   }

}
