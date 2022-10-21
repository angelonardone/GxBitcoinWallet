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
   public class testslip0132unittestdata : GXProcedure
   {
      public testslip0132unittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testslip0132unittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT>( context, "testSLIP0132UnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT> aP0_Gxm2rootcol )
      {
         testslip0132unittestdata objtestslip0132unittestdata;
         objtestslip0132unittestdata = new testslip0132unittestdata();
         objtestslip0132unittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT>( context, "testSLIP0132UnitTestSDT", "GxBitcoinWallet") ;
         objtestslip0132unittestdata.context.SetSubmitInitialConfig(context);
         objtestslip0132unittestdata.initialize();
         Submit( executePrivateCatch,objtestslip0132unittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testslip0132unittestdata)stateInfo).executePrivate();
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
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "1";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/44'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 0;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "m/44'/0'/0'/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 1;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "xprv9xpXFhFpqdQK3TmytPBqXtGSwS3DLjojFhTGht8gwAAii8py5X6pxeBnQ6ehJiyJ6nDjWGJfZ95WxByFXVkDxHXrqu53WCRGypk2ttuqncb";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "xpub6BosfCnifzxcFwrSzQiqu2DBVTshkCXacvNsWGYJVVhhawA7d4R5WSWGFNbi8Aw6ZRc1brxMyWMzG3DSSSSoekkudhUd9yLb6qx39T9nMdj";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "1LqBGSKuX5yYUonjxT5qGfpUsXKYYWeabA";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "2";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/49'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 2;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "m/49'/0'/0'/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 1;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "yprvAHwhK6RbpuS3dgCYHM5jc2ZvEKd7Bi61u9FVhYMpgMSuZS613T1xxQeKTffhrHY79hZ5PsskBjcc6C2V7DrnsMsNaGDaWev3GLRQRgV7hxF";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "ypub6Ww3ibxVfGzLrAH1PNcjyAWenMTbbAosGNB6VvmSEgytSER9azLDWCxoJwW7Ke7icmizBMXrzBx9979FfaHxHcrArf3zbeJJJUZPf663zsP";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "37VucYSaXLCAsxYyAPfbSi9eh4iEcbShgf";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "3";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/84'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 1;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "m/84'/0'/0'/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 1;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "zprvAdG4iTXWBoARxkkzNpNh8r6Qag3irQB8PzEMkAFeTRXxHpbF9z4QgEvBRmfvqWvGp42t42nvgGpNgYSJA9iefm1yYNZKEm7z6qUWCroSQnE";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "zpub6rFR7y4Q2AijBEqTUquhVz398htDFrtymD9xYYfG1m4wAcvPhXNfE3EfH1r1ADqtfSdVCToUG868RvUUkgDKf31mGDtKsAYz2oz2AGutZYs";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "bc1qcr8te4kr609gcawutmrza0j4xv80jy8z306fyu";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "4";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/44'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 0;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 2;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "xprv9xpXFhFpqdQK3TmytPBqXtGSwS3DLjojFhTGht8gwAAii8py5X6pxeBnQ6ehJiyJ6nDjWGJfZ95WxByFXVkDxHXrqu53WCRGypk2ttuqncb";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "xpub6BosfCnifzxcFwrSzQiqu2DBVTshkCXacvNsWGYJVVhhawA7d4R5WSWGFNbi8Aw6ZRc1brxMyWMzG3DSSSSoekkudhUd9yLb6qx39T9nMdj";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "1LqBGSKuX5yYUonjxT5qGfpUsXKYYWeabA";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "5";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/49'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 2;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 2;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "yprvAHwhK6RbpuS3dgCYHM5jc2ZvEKd7Bi61u9FVhYMpgMSuZS613T1xxQeKTffhrHY79hZ5PsskBjcc6C2V7DrnsMsNaGDaWev3GLRQRgV7hxF";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "ypub6Ww3ibxVfGzLrAH1PNcjyAWenMTbbAosGNB6VvmSEgytSER9azLDWCxoJwW7Ke7icmizBMXrzBx9979FfaHxHcrArf3zbeJJJUZPf663zsP";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "37VucYSaXLCAsxYyAPfbSi9eh4iEcbShgf";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testslip0132unittestsdt, 0);
         Gxm1testslip0132unittestsdt.gxTpr_Testcaseid = "6";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Mnemonic = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Networktype = "Main";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Rootpath = "m/84'/0'/0'";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Addresstype = 1;
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Derivepathaddress = "/0/0";
         Gxm1testslip0132unittestsdt.gxTpr_Test_slip0132_in.gxTpr_Testmethod = 2;
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extprivatekey = "zprvAdG4iTXWBoARxkkzNpNh8r6Qag3irQB8PzEMkAFeTRXxHpbF9z4QgEvBRmfvqWvGp42t42nvgGpNgYSJA9iefm1yYNZKEm7z6qUWCroSQnE";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Extpublickey = "zpub6rFR7y4Q2AijBEqTUquhVz398htDFrtymD9xYYfG1m4wAcvPhXNfE3EfH1r1ADqtfSdVCToUG868RvUUkgDKf31mGDtKsAYz2oz2AGutZYs";
         Gxm1testslip0132unittestsdt.gxTpr_Expectedtest_slip0132_out.gxTpr_Derivedaddress = "bc1qcr8te4kr609gcawutmrza0j4xv80jy8z306fyu";
         Gxm1testslip0132unittestsdt.gxTpr_Msgtest_slip0132_out = "";
         Gxm1testslip0132unittestsdt.gxTpr_Expectederror = "";
         Gxm1testslip0132unittestsdt.gxTpr_Msgerror = "";
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
         Gxm1testslip0132unittestsdt = new GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdttestSLIP0132UnitTestSDT Gxm1testslip0132unittestsdt ;
   }

}
