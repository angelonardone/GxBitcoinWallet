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
   public class eccverifymsgunittestdata : GXProcedure
   {
      public eccverifymsgunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccverifymsgunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT>( context, "ECCverifyMsgUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> aP0_Gxm2rootcol )
      {
         eccverifymsgunittestdata objeccverifymsgunittestdata;
         objeccverifymsgunittestdata = new eccverifymsgunittestdata();
         objeccverifymsgunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT>( context, "ECCverifyMsgUnitTestSDT", "GxBitcoinWallet") ;
         objeccverifymsgunittestdata.context.SetSubmitInitialConfig(context);
         objeccverifymsgunittestdata.initialize();
         Submit( executePrivateCatch,objeccverifymsgunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccverifymsgunittestdata)stateInfo).executePrivate();
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
         Gxm1eccverifymsgunittestsdt = new GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1eccverifymsgunittestsdt, 0);
         Gxm1eccverifymsgunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1eccverifymsgunittestsdt.gxTpr_Pubkey = "0337bbbb2bad65d525d3aedc932cf95e76b325fd51019143bf1322bd807e7dfeb5";
         Gxm1eccverifymsgunittestsdt.gxTpr_Message = "Hi, this message is from me :-)";
         Gxm1eccverifymsgunittestsdt.gxTpr_Signature = "ICKocrIYM3U5Yilx4ZsNH94E/ajNqEPCXlKbsa7TE8OhL+6Ged8XEeomMm95GTpPfab9lHv/eWixcGmujazci6k=";
         Gxm1eccverifymsgunittestsdt.gxTpr_Expectedverified = true;
         Gxm1eccverifymsgunittestsdt.gxTpr_Msgverified = "";
         Gxm1eccverifymsgunittestsdt.gxTpr_Expectederror = "";
         Gxm1eccverifymsgunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1eccverifymsgunittestsdt = new GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtECCverifyMsgUnitTestSDT Gxm1eccverifymsgunittestsdt ;
   }

}
