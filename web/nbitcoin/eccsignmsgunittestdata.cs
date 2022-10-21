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
   public class eccsignmsgunittestdata : GXProcedure
   {
      public eccsignmsgunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public eccsignmsgunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT>( context, "ECCsignMsgUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> aP0_Gxm2rootcol )
      {
         eccsignmsgunittestdata objeccsignmsgunittestdata;
         objeccsignmsgunittestdata = new eccsignmsgunittestdata();
         objeccsignmsgunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT>( context, "ECCsignMsgUnitTestSDT", "GxBitcoinWallet") ;
         objeccsignmsgunittestdata.context.SetSubmitInitialConfig(context);
         objeccsignmsgunittestdata.initialize();
         Submit( executePrivateCatch,objeccsignmsgunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((eccsignmsgunittestdata)stateInfo).executePrivate();
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
         Gxm1eccsignmsgunittestsdt = new GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1eccsignmsgunittestsdt, 0);
         Gxm1eccsignmsgunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1eccsignmsgunittestsdt.gxTpr_Privatekey = "d0d62eb0e12e2a5c7f8381eaeb8d967fdbcad6f903a3ad3c0ab875beab3eb30c";
         Gxm1eccsignmsgunittestsdt.gxTpr_Message = "Hi, this message is from me :-)";
         Gxm1eccsignmsgunittestsdt.gxTpr_Expectedsignature = "ICKocrIYM3U5Yilx4ZsNH94E/ajNqEPCXlKbsa7TE8OhL+6Ged8XEeomMm95GTpPfab9lHv/eWixcGmujazci6k=";
         Gxm1eccsignmsgunittestsdt.gxTpr_Msgsignature = "";
         Gxm1eccsignmsgunittestsdt.gxTpr_Expectederror = "";
         Gxm1eccsignmsgunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1eccsignmsgunittestsdt = new GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtECCsignMsgUnitTestSDT Gxm1eccsignmsgunittestsdt ;
   }

}
