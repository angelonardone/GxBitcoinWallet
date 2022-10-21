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
   public class testeccencryptanddecryptunittestdata : GXProcedure
   {
      public testeccencryptanddecryptunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testeccencryptanddecryptunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT>( context, "testECCencryptANDdecryptUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> aP0_Gxm2rootcol )
      {
         testeccencryptanddecryptunittestdata objtesteccencryptanddecryptunittestdata;
         objtesteccencryptanddecryptunittestdata = new testeccencryptanddecryptunittestdata();
         objtesteccencryptanddecryptunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT>( context, "testECCencryptANDdecryptUnitTestSDT", "GxBitcoinWallet") ;
         objtesteccencryptanddecryptunittestdata.context.SetSubmitInitialConfig(context);
         objtesteccencryptanddecryptunittestdata.initialize();
         Submit( executePrivateCatch,objtesteccencryptanddecryptunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testeccencryptanddecryptunittestdata)stateInfo).executePrivate();
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
         Gxm1testeccencryptanddecryptunittestsdt = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testeccencryptanddecryptunittestsdt, 0);
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Originalcleartext = "Hi this is the First Message to ecrypt";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Expectedisverified = true;
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Msgisverified = "";
         Gxm1testeccencryptanddecryptunittestsdt = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testeccencryptanddecryptunittestsdt, 0);
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Originalcleartext = "654480861303078049569655795217915232786138815662";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Expectedisverified = true;
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Msgisverified = "";
         Gxm1testeccencryptanddecryptunittestsdt = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testeccencryptanddecryptunittestsdt, 0);
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Originalcleartext = "";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Expectedisverified = true;
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Msgisverified = "";
         Gxm1testeccencryptanddecryptunittestsdt = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testeccencryptanddecryptunittestsdt, 0);
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Originalcleartext = "&*@^%!@#)(*^#&%-";
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Expectedisverified = true;
         Gxm1testeccencryptanddecryptunittestsdt.gxTpr_Msgisverified = "";
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
         Gxm1testeccencryptanddecryptunittestsdt = new GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdttestECCencryptANDdecryptUnitTestSDT Gxm1testeccencryptanddecryptunittestsdt ;
   }

}
