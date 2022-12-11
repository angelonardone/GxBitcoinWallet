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
   public class isaddressvalidunittestdata : GXProcedure
   {
      public isaddressvalidunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public isaddressvalidunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT>( context, "isAddressValidUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT> aP0_Gxm2rootcol )
      {
         isaddressvalidunittestdata objisaddressvalidunittestdata;
         objisaddressvalidunittestdata = new isaddressvalidunittestdata();
         objisaddressvalidunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT>( context, "isAddressValidUnitTestSDT", "GxBitcoinWallet") ;
         objisaddressvalidunittestdata.context.SetSubmitInitialConfig(context);
         objisaddressvalidunittestdata.initialize();
         Submit( executePrivateCatch,objisaddressvalidunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((isaddressvalidunittestdata)stateInfo).executePrivate();
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
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1isaddressvalidunittestsdt, 0);
         Gxm1isaddressvalidunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1isaddressvalidunittestsdt.gxTpr_Address = "mz8SWTfreWP8dePqjwBy4788RPXEwD5mTm";
         Gxm1isaddressvalidunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1isaddressvalidunittestsdt.gxTpr_Expectederror = "";
         Gxm1isaddressvalidunittestsdt.gxTpr_Msgerror = "";
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1isaddressvalidunittestsdt, 0);
         Gxm1isaddressvalidunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1isaddressvalidunittestsdt.gxTpr_Address = "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o";
         Gxm1isaddressvalidunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1isaddressvalidunittestsdt.gxTpr_Expectederror = "";
         Gxm1isaddressvalidunittestsdt.gxTpr_Msgerror = "";
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1isaddressvalidunittestsdt, 0);
         Gxm1isaddressvalidunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1isaddressvalidunittestsdt.gxTpr_Address = "mnCQdLbkZ1s9XmjHn9ahCb9HrAc4X9Rp6m";
         Gxm1isaddressvalidunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1isaddressvalidunittestsdt.gxTpr_Expectederror = "";
         Gxm1isaddressvalidunittestsdt.gxTpr_Msgerror = "";
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1isaddressvalidunittestsdt, 0);
         Gxm1isaddressvalidunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1isaddressvalidunittestsdt.gxTpr_Address = "2MwsPmjaqfvwH815uYAKUctLtXnKCb8j8dJ";
         Gxm1isaddressvalidunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1isaddressvalidunittestsdt.gxTpr_Expectederror = "";
         Gxm1isaddressvalidunittestsdt.gxTpr_Msgerror = "";
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1isaddressvalidunittestsdt, 0);
         Gxm1isaddressvalidunittestsdt.gxTpr_Testcaseid = "5";
         Gxm1isaddressvalidunittestsdt.gxTpr_Address = "tb1q506ljfgkh87emh4hk48rug6mkadjmqfpm7mj7z";
         Gxm1isaddressvalidunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1isaddressvalidunittestsdt.gxTpr_Expectederror = "";
         Gxm1isaddressvalidunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1isaddressvalidunittestsdt = new GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtisAddressValidUnitTestSDT Gxm1isaddressvalidunittestsdt ;
   }

}
