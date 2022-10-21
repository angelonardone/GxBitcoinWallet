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
   public class deriveaddressfromextpubkeyunittestdata : GXProcedure
   {
      public deriveaddressfromextpubkeyunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public deriveaddressfromextpubkeyunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT>( context, "deriveAddressFromExtPubKeyUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         deriveaddressfromextpubkeyunittestdata objderiveaddressfromextpubkeyunittestdata;
         objderiveaddressfromextpubkeyunittestdata = new deriveaddressfromextpubkeyunittestdata();
         objderiveaddressfromextpubkeyunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT>( context, "deriveAddressFromExtPubKeyUnitTestSDT", "GxBitcoinWallet") ;
         objderiveaddressfromextpubkeyunittestdata.context.SetSubmitInitialConfig(context);
         objderiveaddressfromextpubkeyunittestdata.initialize();
         Submit( executePrivateCatch,objderiveaddressfromextpubkeyunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deriveaddressfromextpubkeyunittestdata)stateInfo).executePrivate();
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
         Gxm1deriveaddressfromextpubkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1deriveaddressfromextpubkeyunittestsdt, 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Deserializedextpubkey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Base = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Start = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_End = 4;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgsdt_addressess = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1deriveaddressfromextpubkeyunittestsdt, 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Deserializedextpubkey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Base = 1;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Start = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_End = 4;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mnCQdLbkZ1s9XmjHn9ahCb9HrAc4X9Rp6m", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mhCc4X7TtScn4BTkFreodBxJnZQzqGPqhd", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("msYoupHLPEhVmQ7JUFsGJTwpRctBgmEgEM", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mh7Uy2rz923QcajuRAL1EXFUT5GCbHAACZ", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("mwk6kyEvFyy97CRsYM5XLg9dpY9gE36hHy", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgsdt_addressess = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1deriveaddressfromextpubkeyunittestsdt, 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Deserializedextpubkey = "vpub5UzmHJe4YPMzYL3MXiy4dvv5YPAGRU9iii8EHrfwLw2nfdMG9wVUfKi4pFeeuHbDhQqvdAh1gUZt9e6UbNfM8VrNaja2XsEd3MZfHRqDSSV";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Base = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Start = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_End = 4;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qlaw8k07ryjywrt5q2msrkwx9gj8v4xg039tsjn", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qcvmrqyaaj4gvtcxfl32cl9d4x55g4m8nm4jyt5", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qs7c2anth68qnh63w09398m555n39x399tuqwpw", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qfjzhjv3hy65xvav3500fvrjlcfsz6dn9ptv3gl", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qtr3pjh3fstxzsducyrtlmvsg5udsh0t2vtdvsp", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgsdt_addressess = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1deriveaddressfromextpubkeyunittestsdt, 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Deserializedextpubkey = "vpub5UzmHJe4YPMzYL3MXiy4dvv5YPAGRU9iii8EHrfwLw2nfdMG9wVUfKi4pFeeuHbDhQqvdAh1gUZt9e6UbNfM8VrNaja2XsEd3MZfHRqDSSV";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Base = 1;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Start = 0;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_End = 4;
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qpuyahzvqhdl80f34w5dcnhvyttayyz8tj0yrt9", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qeyrng5xteyfv7czz3d89w27hmy4mxsl56szhfz", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qpa54dj4485grefwww4ncwet5ymm45l4fp09txc", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qd4fwkfnfye9gd9gtnghcmy907kt76zwqdg96t5", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectedsdt_addressess.gxTpr_Address.Add("tb1qxxjz5d8lx6ldmc67pfxtx0wmuksrgymk2t52kz", 0);
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgsdt_addressess = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1deriveaddressfromextpubkeyunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1deriveaddressfromextpubkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtderiveAddressFromExtPubKeyUnitTestSDT Gxm1deriveaddressfromextpubkeyunittestsdt ;
   }

}
