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
   public class testbip32unittestdata : GXProcedure
   {
      public testbip32unittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testbip32unittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT>( context, "testBIP32UnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> aP0_Gxm2rootcol )
      {
         testbip32unittestdata objtestbip32unittestdata;
         objtestbip32unittestdata = new testbip32unittestdata();
         objtestbip32unittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT>( context, "testBIP32UnitTestSDT", "GxBitcoinWallet") ;
         objtestbip32unittestdata.context.SetSubmitInitialConfig(context);
         objtestbip32unittestdata.initialize();
         Submit( executePrivateCatch,objtestbip32unittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testbip32unittestdata)stateInfo).executePrivate();
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
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "1";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9s21ZrQH143K3QTDL4LXw2F7HEK3wJUD2nW2nRk4stbPy6cq3jPPqjiChkVvvNKmPGJxWUtg6LnF5kejMRNNU3TGtRBeJgk33yuGBxrMPHi";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub661MyMwAqRbcFtXgS5sYJABqqG9YLmC4Q1Rdap9gSE8NqtwybGhePY2gZ29ESFjqJoCu1Rupje8YtGqsefD265TMg7usUDFdp6W1EGMcet8";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "2";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9uHRZZhk6KAJC1avXpDAp4MDc3sQKNxDiPvvkX8Br5ngLNv1TxvUxt4cV1rGL5hj6KCesnDYUhd7oWgT11eZG7XnxHrnYeSvkzY7d2bhkJ7";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub68Gmy5EdvgibQVfPdqkBBCHxA5htiqg55crXYuXoQRKfDBFA1WEjWgP6LHhwBZeNK1VTsfTFUHCdrfp1bgwQ9xv5ski8PX9rL2dZXvgGDnw";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "3";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'/1";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9wTYmMFdV23N2TdNG573QoEsfRrWKQgWeibmLntzniatZvR9BmLnvSxqu53Kw1UmYPxLgboyZQaXwTCg8MSY3H2EU4pWcQDnRnrVA1xe8fs";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6ASuArnXKPbfEwhqN6e3mwBcDTgzisQN1wXN9BJcM47sSikHjJf3UFHKkNAWbWMiGj7Wf5uMash7SyYq527Hqck2AxYysAA7xmALppuCkwQ";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'/1/2'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9z4pot5VBttmtdRTWfWQmoH1taj2axGVzFqSb8C9xaxKymcFzXBDptWmT7FwuEzG3ryjH4ktypQSAewRiNMjANTtpgP4mLTj34bhnZX7UiM";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6D4BDPcP2GT577Vvch3R8wDkScZWzQzMMUm3PWbmWvVJrZwQY4VUNgqFJPMM3No2dFDFGTsxxpG5uJh7n7epu4trkrX7x7DogT5Uv6fcLW5";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "5";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'/1/2'/2";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprvA2JDeKCSNNZky6uBCviVfJSKyQ1mDYahRjijr5idH2WwLsEd4Hsb2Tyh8RfQMuPh7f7RtyzTtdrbdqqsunu5Mm3wDvUAKRHSC34sJ7in334";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6FHa3pjLCk84BayeJxFW2SP4XRrFd1JYnxeLeU8EqN3vDfZmbqBqaGJAyiLjTAwm6ZLRQUMv1ZACTj37sR62cfN7fe5JnJ7dh8zL4fiyLHV";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "6";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "000102030405060708090a0b0c0d0e0f";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'/1/2'/2/1000000000";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprvA41z7zogVVwxVSgdKUHDy1SKmdb533PjDz7J6N6mV6uS3ze1ai8FHa8kmHScGpWmj4WggLyQjgPie1rFSruoUihUZREPSL39UNdE3BBDu76";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6H1LXWLaKsWFhvm6RVpEL9P4KfRZSW7abD2ttkWP3SSQvnyA8FSVqNTEcYFgJS2UaFcxupHiYkro49S8yGasTvXEYBVPamhGW6cFJodrTHy";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "7";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9s21ZrQH143K31xYSDQpPDxsXRTUcvj2iNHm5NUtrGiGG5e2DtALGdso3pGz6ssrdK4PFmM8NSpSBHNqPqm55Qn3LqFtT2emdEXVYsCzC2U";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub661MyMwAqRbcFW31YEwpkMuc5THy2PSt5bDMsktWQcFF8syAmRUapSCGu8ED9W6oDMSgv6Zz8idoc4a6mr8BDzTJY47LJhkJ8UB7WEGuduB";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "8";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9vHkqa6EV4sPZHYqZznhT2NPtPCjKuDKGY38FBWLvgaDx45zo9WQRUT3dKYnjwih2yJD9mkrocEZXo1ex8G81dwSM1fwqWpWkeS3v86pgKt";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub69H7F5d8KSRgmmdJg2KhpAK8SR3DjMwAdkxj3ZuxV27CprR9LgpeyGmXUbC6wb7ERfvrnKZjXoUmmDznezpbZb7ap6r1D3tgFxHmwMkQTPH";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "9";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0/2147483647'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9wSp6B7kry3Vj9m1zSnLvN3xH8RdsPP1Mh7fAaR7aRLcQMKTR2vidYEeEg2mUCTAwCd6vnxVrcjfy2kRgVsFawNzmjuHc2YmYRmagcEPdU9";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6ASAVgeehLbnwdqV6UKMHVzgqAG8Gr6riv3Fxxpj8ksbH9ebxaEyBLZ85ySDhKiLDBrQSARLq1uNRts8RuJiHjaDMBU4Zn9h8LZNnBC5y4a";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "10";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0/2147483647'/1";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9zFnWC6h2cLgpmSA46vutJzBcfJ8yaJGg8cX1e5StJh45BBciYTRXSd25UEPVuesF9yog62tGAQtHjXajPPdbRCHuWS6T8XA2ECKADdw4Ef";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6DF8uhdarytz3FWdA8TvFSvvAh8dP3283MY7p2V4SeE2wyWmG5mg5EwVvmdMVCQcoNJxGoWaU9DCWh89LojfZ537wTfunKau47EL2dhHKon";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "11";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0/2147483647'/1/2147483646'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprvA1RpRA33e1JQ7ifknakTFpgNXPmW2YvmhqLQYMmrj4xJXXWYpDPS3xz7iAxn8L39njGVyuoseXzU6rcxFLJ8HFsTjSyQbLYnMpCqE2VbFWc";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6ERApfZwUNrhLCkDtcHTcxd75RbzS1ed54G1LkBUHQVHQKqhMkhgbmJbZRkrgZw4koxb5JaHWkY4ALHY2grBGRjaDMzQLcgJvLJuZZvRcEL";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "12";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0/2147483647'/1/2147483646'/2";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprvA2nrNbFZABcdryreWet9Ea4LvTJcGsqrMzxHx98MMrotbir7yrKCEXw7nadnHM8Dq38EGfSh6dqA9QWTyefMLEcBYJUuekgW4BYPJcr9E7j";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6FnCn6nSzZAw5Tw7cgR9bi15UV96gLZhjDstkXXxvCLsUXBGXPdSnLFbdpq8p9HmGsApME5hQTZ3emM2rnY5agb9rXpVGyy3bdW6EEgAtqt";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "13";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "4b381541583be4423346c643850da4b320e46a87ae3d2a4e6da11eba819cd4acba45d239319ac14f863b8d5ab5a0d0c64d2e8a1e7d1457df2e5a3c51c73235be";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9s21ZrQH143K25QhxbucbDDuQ4naNntJRi4KUfWT7xo4EKsHt2QJDu7KXp1A3u7Bi1j8ph3EGsZ9Xvz9dGuVrtHHs7pXeTzjuxBrCmmhgC6";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub661MyMwAqRbcEZVB4dScxMAdx6d4nFc9nvyvH3v4gJL378CSRZiYmhRoP7mBy6gSPSCYk6SzXPTf3ND1cZAceL7SfJ1Z3GC8vBgp2epUt13";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "14";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "4b381541583be4423346c643850da4b320e46a87ae3d2a4e6da11eba819cd4acba45d239319ac14f863b8d5ab5a0d0c64d2e8a1e7d1457df2e5a3c51c73235be";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9uPDJpEQgRQfDcW7BkF7eTya6RPxXeJCqCJGHuCJ4GiRVLzkTXBAJMu2qaMWPrS7AANYqdq6vcBcBUdJCVVFceUvJFjaPdGZ2y9WACViL4L";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub68NZiKmJWnxxS6aaHmn81bvJeTESw724CRDs6HbuccFQN9Ku14VQrADWgqbhhTHBaohPX4CjNLf9fq9MYo6oDaPPLPxSb7gwQN3ih19Zm4Y";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "15";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "3ddd5602285899a946114506157c7997e5444528f3003f6134712147db19b678";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9s21ZrQH143K48vGoLGRPxgo2JNkJ3J3fqkirQC2zVdk5Dgd5w14S7fRDyHH4dWNHUgkvsvNDCkvAwcSHNAQwhwgNMgZhLtQC63zxwhQmRv";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub661MyMwAqRbcGczjuMoRm6dXaLDEhW1u34gKenbeYqAix21mdUKJyuyu5F1rzYGVxyL6tmgBUAEPrEz92mBXjByMRiJdba9wpnN37RLLAXa";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "16";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "3ddd5602285899a946114506157c7997e5444528f3003f6134712147db19b678";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9vB7xEWwNp9kh1wQRfCCQMnZUEG21LpbR9NPCNN1dwhiZkjjeGRnaALmPXCX7SgjFTiCTT6bXes17boXtjq3xLpcDjzEuGLQBM5ohqkao9G";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub69AUMk3qDBi3uW1sXgjCmVjJ2G6WQoYSnNHyzkmdCHEhSZ4tBok37xfFEqHd2AddP56Tqp4o56AePAgCjYdvpW2PU2jbUPFKsav5ut6Ch1m";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1testbip32unittestsdt, 0);
         Gxm1testbip32unittestsdt.gxTpr_Testcaseid = "17";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Seed = "3ddd5602285899a946114506157c7997e5444528f3003f6134712147db19b678";
         Gxm1testbip32unittestsdt.gxTpr_Test_bip32_in.gxTpr_Path = "m/0'/1'";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xprv = "xprv9xJocDuwtYCMNAo3Zw76WENQeAS6WGXQ55RCy7tDJ8oALr4FWkuVoHJeHVAcAqiZLE7Je3vZJHxspZdFHfnBEjHqU5hG1Jaj32dVoS6XLT1";
         Gxm1testbip32unittestsdt.gxTpr_Expectedtest_bip32_out.gxTpr_Xpub = "xpub6BJA1jSqiukeaesWfxe6sNK9CCGaujFFSJLomWHprUL9DePQ4JDkM5d88n49sMGJxrhpjazuXYWdMf17C9T5XnxkopaeS7jGk1GyyVziaMt";
         Gxm1testbip32unittestsdt.gxTpr_Msgtest_bip32_out = "";
         Gxm1testbip32unittestsdt.gxTpr_Expectederror = "";
         Gxm1testbip32unittestsdt.gxTpr_Msgerror = "";
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
         Gxm1testbip32unittestsdt = new GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdttestBIP32UnitTestSDT Gxm1testbip32unittestsdt ;
   }

}
