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
   public class createexpubtkeyunittestdata : GXProcedure
   {
      public createexpubtkeyunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createexpubtkeyunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT>( context, "CreateExPubtKeyUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         createexpubtkeyunittestdata objcreateexpubtkeyunittestdata;
         objcreateexpubtkeyunittestdata = new createexpubtkeyunittestdata();
         objcreateexpubtkeyunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT>( context, "CreateExPubtKeyUnitTestSDT", "GxBitcoinWallet") ;
         objcreateexpubtkeyunittestdata.context.SetSubmitInitialConfig(context);
         objcreateexpubtkeyunittestdata.initialize();
         Submit( executePrivateCatch,objcreateexpubtkeyunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createexpubtkeyunittestdata)stateInfo).executePrivate();
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
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createexpubtkeyunittestsdt, 0);
         Gxm1createexpubtkeyunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Extendedpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Keypath = "/0/0";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "tpubDGkKfN4sUo2dv6WKDwWUX4QxgmF2HSM9CsfC9UHfWG8tktEJ3j43ohWn8c9JWjXoaaBMNJAkpJM2pkqavf8K6hmmTWGxvXkPAqPe4B7eb3A";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwitp2sh = "upub5HsuE8ESKUSk6Qk7GgAWgso5qji2UBsauuWESjYs2LFMrJ7uDXiGo4sXpxBkzWcoZkJ2WHsCuDTLUiWHNi32pZGfntSPVGdgmhcJ8VjRCcS";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwit = "vpub5ciAXnuMU9zDwhwE72x8txtb1hrUQos5q22TE8SkQLdEuPw8UBsqR8XfrA9LzRGiyPQqFmTmMsotN17r6QT3cnxGfE8p5BTB3RfwX2ezDpp";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresslegacy = "mzawn7T5K4JVs9nDphnWuqvWq9ruRBz6a7";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwitp2sh = "2Mzfij1JyGznxXofWpydvj6KC9ywRRYRXuC";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwit = "tb1q6y4e7mlhlju5zuv3x4yk7aryxjghm8ncj5gv8e";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Depth = 5;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Child = 0;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Ishardended = false;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Keypath = "/0/0";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createexpubtkeyunittestsdt, 0);
         Gxm1createexpubtkeyunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Extendedpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Keypath = "/0/1";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "tpubDGkKfN4sUo2dyDWFuJ713EB7zEXkWaB4mgLpRib3cbD8r1azyQm7eZ3LdNr1t9jitGRjBsC8rLaLWK4PomzaGByomxKVEbT9YEsLKHXyTok";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwitp2sh = "upub5HsuE8ESKUSk9Xk3x2m3D3ZF9CzkhKhWUiBriyrF8fKbwRUc9DRLdvQ6KitUMvpisSYQKrtawFgeAGj6FpuHz3Ui7LUuoLLT975zPWuE26S";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwit = "vpub5ciAXnuMU9zDzpwAnPYfR8ekKB9Cdwh1Ppi5WNk8WfhUzXHqPsauFz4ELvr4MqUeH5fD5LV9Pv3C3ZLeyXKJnHAJygBLPF9wQq9dn6APD7d";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresslegacy = "mnsn4M8xu2KWBAsVwXmnSoA8MJjutoNFaD";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwitp2sh = "2MwPkXpFPG85i1oRm9TpSfWXtSXrmcMbRyA";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwit = "tb1q2zu3yg4cah0xmdrkfpptcpd87qgzkxte03jal7";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Depth = 5;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Child = 1;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Ishardended = false;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Keypath = "/0/1";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createexpubtkeyunittestsdt, 0);
         Gxm1createexpubtkeyunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Extendedpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Keypath = "/0/2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "tpubDGkKfN4sUo2dyr5zNxJBjgGYmApJP56RpYPA3Q4SZQn9ReZMSJYtnb4yVfVWf5EBy6rm3hvdedoqxAVK4W86rYiWU9wn7Jx7VqntPjvMrYx";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwitp2sh = "upub5HsuE8ESKUSkAAKnRgxDuVefv9HJZpcsXaECLfKe5UtcX4Sxc7D7mxRjC1Xy8rKBxGySBhd5jYv9c8A1WZ2paQDQoY7Cg3qR6i1YU4ku52A";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwit = "vpub5ciAXnuMU9zE1TWuG3jr7akB67RkWScNSgkR84DXTVGVaAGBrmNgQ25sDDVZ8ky7Mv6EwBDeCDGhVQmaEFSqNdu1fsodFxeuNS5BreHroQh";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresslegacy = "mgrRM7EEpCagEY4ULp6jgxWS9i9CjHre93";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwitp2sh = "2NGNLucF1uA86quSioRdsEpYAMSqbUs6Hdc";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwit = "tb1qp6nfez0wrl7cjxh6fl3q9glx242hdrndcj6hc5";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Depth = 5;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Child = 2;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Ishardended = false;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Keypath = "/0/2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createexpubtkeyunittestsdt, 0);
         Gxm1createexpubtkeyunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Extendedpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Keypath = "/0/3";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "tpubDGkKfN4sUo2e2mVhw5xNthww3ZXFa8KMdv66Co5QX8dRuyXTSbRbADYZEMSi3XxHVAmaNddyUiqmNjUVre1TPH1BGvNk3EWhUx5qvg3W2h6";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwitp2sh = "upub5HsuE8ESKUSkD5jVypcR4XL4CXzFksqoLww8W4Lc3Cju1PR4cQ5p9auJvhVAXK3HULtFWdLRZdx52h9CJgvB78W5cJYAbyQ15pJVzuUZafJ";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwit = "vpub5ciAXnuMU9zE4NvcpBQ3GcRZNW8hhVqJG4TMHTEVRD7n4VEHs4FNmeZSwuSkXDhCsz14G6vz2JJcuykm2PLBuNBgUeEbBtDVMYN9PWbfWuF";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresslegacy = "n3RgG38YzXTswDMhVmHTCfn58wSydnFfFX";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwitp2sh = "2N3D2bN2gSJ8TfXf9xQmjFxMGRZU9T5muZ9";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwit = "tb1q7pf56c52nek7wgcqc8jrrscxgayhamawgxuv4g";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Depth = 5;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Child = 3;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Ishardended = false;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Keypath = "/0/3";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createexpubtkeyunittestsdt, 0);
         Gxm1createexpubtkeyunittestsdt.gxTpr_Testcaseid = "5";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Extendedpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Networktype = "TestNet";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Keypath = "/0/4";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "tpubDGkKfN4sUo2e5fKtZs1xWzKFQJZnLQPYWRqDZVGf2od5voVJZhHEVwSMPtp8Qeu17zYb13MLXirqz49Rsk8xJqhFoarmoULoc9uoyL4zftH";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwitp2sh = "upub5HsuE8ESKUSkFyZgcbfzgohNZH2nX9uzDTgFrkXrYsjZ2DNujVwTVJo76EratRz17AfG933ncdy9e1p8Ko3g2hCA8y2CNDE7D28U3YC7rnC";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeysegwit = "vpub5ciAXnuMU9zE7GkoSxTcttnsjFBETmuV8aCUe9Rjvt7S5KC8zA727NTF7SpAtLdvWon4tWeM5JKhXJRh3VTgpvsm1Jicx83bUkC7S6FJ6Gg";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresslegacy = "mo7oyq1mJ2mJTi5Qy673ANJ8zUssmCDu1o";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwitp2sh = "2N6Ne5iGiFTb4XEABx99b1iN6ajGEmVpHhV";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Addresssegwit = "tb1q2ds8ltl4q3rlk3xj2m70mur6phc2lyj2u3ysf8";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Depth = 5;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Child = 4;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Ishardended = false;
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Keypath = "/0/4";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createexpubtkeyunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1createexpubtkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtCreateExPubtKeyUnitTestSDT Gxm1createexpubtkeyunittestsdt ;
   }

}
