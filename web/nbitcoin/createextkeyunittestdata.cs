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
   public class createextkeyunittestdata : GXProcedure
   {
      public createextkeyunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createextkeyunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT>( context, "CreateExtKeyUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         createextkeyunittestdata objcreateextkeyunittestdata;
         objcreateextkeyunittestdata = new createextkeyunittestdata();
         objcreateextkeyunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT>( context, "CreateExtKeyUnitTestSDT", "GxBitcoinWallet") ;
         objcreateextkeyunittestdata.context.SetSubmitInitialConfig(context);
         objcreateextkeyunittestdata.initialize();
         Submit( executePrivateCatch,objcreateextkeyunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createextkeyunittestdata)stateInfo).executePrivate();
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
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 50;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Seed = "fffcf9f6f3f0edeae7e4e1dedbd8d5d2cfccc9c6c3c0bdbab7b4b1aeaba8a5a29f9c999693908d8a8784817e7b7875726f6c696663605d5a5754514e4b484542";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "angelo";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "4b03d6fc340455b363f51020ad3ecca4f0850280cf436c70c727923f6db46c3e";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "03cbcaa9c98c877a26977d00825c956a238e8dddfbd322cce4f74b0b5bd6ace4a7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "YEmfgBuJbYMXmkN0rreCKq6s6qDbH4XuPpBMTe+9lok=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KyjXhyHF9wTphBkfpxjL8hkDXDUSbE3tKANT94kXSyh6vn6nKaoy";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "6PYWNgQ6wgovGsypQSJnq8Mu151JPwKtYn5NPUbvXGCwGypjPBtaBtuj4H";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9s21ZrQH143K31xYSDQpPDxsXRTUcvj2iNHm5NUtrGiGG5e2DtALGdso3pGz6ssrdK4PFmM8NSpSBHNqPqm55Qn3LqFtT2emdEXVYsCzC2U";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvABrGsX5C9jantK9fGaCSbK4NhPbvZYiXdUoyrmNnEH69KBTFUYKtthXw52Ea6nXn2xBC1Ewgq7Az4ZzQ7YB5seTeDAxK2wUFtxb8wWHUEtQ";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAWgYBBk7JR8GjcLn6vz4oQ9ssMkNWAi2YbLCeAGfcHU2NHGUjCVTWmC56ECA6hBhSbHzkiYFHmXXwrbxqEb6ft9F5WejcrHkAgenKzz3sjB";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub661MyMwAqRbcFW31YEwpkMuc5THy2PSt5bDMsktWQcFF8syAmRUapSCGu8ED9W6oDMSgv6Zz8idoc4a6mr8BDzTJY47LJhkJ8UB7WEGuduB";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6QqdH2c5z7966oE8NbjSxT17FRSQy1SNzhjaf9nPncd8BynQ25e9SVrQvLBo9QkiczZVfaAYbNzMVMBfVYYC2E8uQPoktcZnQCEktj3kkN2";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6jftahH18ngZx6RFCxX5AY6cRParudRsupFoSYgHAd11F5bdGjoi4ZWYwY9P9KQe2dgJR3m743LuNdoEDExCpTpWGjWBUXPGfvJQHKojT9s";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "00000000";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "employ churn dance mask stand exact remove address pipe science imitate mom";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "da7a2ef14203e2afe9f44f835a2a3fab0426dc25f5c41759a1219ef252c7b322";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "02058920e26c19f8bc8cd0210d27d409affff8813f468ee5518d55fb6d6a4c8d5f";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "MugeH6/CPIKl4KC6OpRzhkUTGfR3H6NNINGtjQuv+BE=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L4YQH8GCPuM1ACRBqgLKAYMtVkCUXcdfues1AzvubRAHqC4YvjYv";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9s21ZrQH143K2ZkeD2EgF6FTtRVnRdCnDrqsfKq3KGGz1hoDacSfU4NTn9Wr9Gkb7FRp5vnxUPJSNmThJhpUx9Nn9F46Fv6aheKaAYrG5xJ";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub661MyMwAqRbcF3q7K3mgcECCSTLGq5vdb5mUTiEesboxtW8N89kv1rgwdNvqH41QizZ9JM4SFELy1koMD2L76VnUYeV6xEt7dsTyicVGCZX";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvABrGsX5C9jansrwm3P2JTBLy4PeENFCH8yN6SiivhGes4ocSqGcE682boMUS9BQWWtYcqQPWw3ezG45G2QEVkP4P1akWqpv4yNPDZ75kLpb";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAWgYBBk7JR8GjA8ssjovfGSUEMngJsBn45tKE7cp5H2k7uRg5vmniBgjpZS2964RvXfRasz5Pi1Y9Lgpk6eWYcjysvSwRjjZF6Srwgv8wZ7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "00000000";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6QqdH2c5z7966M2E9QZJpKHhcRUimhv8WCHhF78YFcBqwbwbNovUdvM5eatRGxfL8dfx3pezhthWu3Quvik7tjU5QzBXY9hbubXd7BgbqiB";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6jftahH18ngZweDLymLw2QPCnPdAiKudRJov2W2RdcZizhkpdU63Fz1Dfnr1GsKFYGnkoJFZAZ44nL2UeRA8gy9gHKsx84X6BKbGVnKsbh7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "angelo";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "5c7d2a67c0290010fe4ade273a66fffb245db080ad10ea3fdddb4d10df82cf11";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "022598dc6a7b5f4fbe9d3c46c33f96581e25630aca4d251fcee67803998a8b6896";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "yzWFpVbRD7T08beXII32Ve8C3ndm1XGuvW9Pe5hhpEM=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KzKVo5PJiea5Mv3tSZWxU8tG6F9cG2EWAtWhVv5Vn6eFhiBPfFtv";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "6PYLDgs57LTPVKhVSY5TKmFqMnfmmTsotybhUZs2pWwpf3papyGENe1WPY";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9s21ZrQH143K45hZozMRSZFY4ME7aMpVMc9i1GNk4x5sb9gGF5HpMddLjvTWRpcB7fcEh3LiDKkBmWRmVsx3JLFYZR5JKwg2uMmMaVR7xn2";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvABrGsX5C9januNtgeM93eeM3EKNZWyozGifvnfGdSxTkeFVVVjTNyhHUm8R6RjG6XJj3SWwGfz6jeo3LDaN46Zw9RkmiurVXB5pzy97JAPB";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAWgYBBk7JR8Gkg5oUhvfrjSYQHX1TboVBqC9a4AWpxqdhMJikPcwbkwcnLNgRdv1vwqrBzXq8eTHY5etwGn4tockJ6U9VmK1SoteMhC6m8H";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub661MyMwAqRbcGZn2v1tRohCGcP4bypYLiq5JoenMdHcrTx1Qncc4uRwpbB56jUHgktHe1ndB9hjqooaMoY6ttr1zQEXN8Vn6ZGsQUN2ef5g";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6QqdH2c5z7967ry9kNg41nHmnMD3vSXqdwbXb3gF1HzjX3pe3GmdXVbxcP2gjNwcAXQSmGDjcN6Ph6BvXEWuh5hbGaDniQbapzw3rugYXvR";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6jftahH18ngZyAAGajTgDsPGxKMVs4XLZ47kNSa8PJNca9dsHvwC9ZG6dazGjHbXaAXFWjpJ52SwaNoVEvvvVKPC8uvDJKR56izhFV3PPt7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "00000000";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 40;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Privatekey = "1f603cbd62baccb2b1d234e90fd1ba3f9234e266af9338a5460a50c6ff1a670b";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Chaincode = "AreeeiU1A4+pSX7XXCJuJA33/lYHpTk+GaGovOPPnK4=";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "1f603cbd62baccb2b1d234e90fd1ba3f9234e266af9338a5460a50c6ff1a670b";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "023363b5c9f519e1a9361fe3e4b082a3c4560b1c01f58e12fe8ab18a73efad326d";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "AreeeiU1A4+pSX7XXCJuJA33/lYHpTk+GaGovOPPnK4=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KxGheNuzoJMrptGQfbkuMBsz1kutTD2xgz3CCffriCafangEh8zp";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9s21ZrQH143K25vgDtLKU1ppdYDsqQ36BKxrDzXktagMmPcU34nx12HH6oxZy5W4SpTvycmKZbGAYPGzk5p6Qv2zhWXVx9dyXTr1bTFpxPj";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvABrGsX5C9jansP7o4F7wg6vKoWNKn22b6SV51PReGb4EpVRhHixWd5wR81v9xz9yrTajj6Mt2FciRftZTnE7D9ibZrDvY4TToBuez1xkhtt";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAWgYBBk7JR8GigJutbuZtC1pyUWmie261Z1HnnKXebS7sbEvYP85F9bZ9DsjxtouG6hYUZxSUuyGJxW8BUe81PQCSBvM7yGx4uyJNc1vsaJ";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub661MyMwAqRbcEa19KusKq9mZBa4NErkwYYtT2NwNSvDLeBwcac7CYpbkx599dTYTiXM7nku7B8dLfgf9fCVEK1FHud2WWixKVZyaJ58Nqsh";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6QqdH2c5z7965sCGAGex3Es4MYCpBUkSTfQfomqFpvbDhHkqqGGmAtFtyH6jdNCP8ATvYEVfdnytYyGiNtuF7Evtmxiw6dmomJ3DgdGqGTR";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6jftahH18ngZwAPNzdSaFKxZXWMG86jwNmvtbAj9Cvy6kPa55vSKnwv2zV4KdGrJXoajHi6E6TLSSFtH6bKFuUcVeJRMgYbJ326s5DXAtuM";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "00000000";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "5";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 80;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Encryptedwif = "6PYLDgs57LTPVKhVSY5TKmFqMnfmmTsotybhUZs2pWwpf3papyGENe1WPY";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Chaincode = "yzWFpVbRD7T08beXII32Ve8C3ndm1XGuvW9Pe5hhpEM=";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "angelo";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "5c7d2a67c0290010fe4ade273a66fffb245db080ad10ea3fdddb4d10df82cf11";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "022598dc6a7b5f4fbe9d3c46c33f96581e25630aca4d251fcee67803998a8b6896";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "yzWFpVbRD7T08beXII32Ve8C3ndm1XGuvW9Pe5hhpEM=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KzKVo5PJiea5Mv3tSZWxU8tG6F9cG2EWAtWhVv5Vn6eFhiBPfFtv";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "6PYLDgs57LTPVKhVSY5TKmFqMnfmmTsotybhUZs2pWwpf3papyGENe1WPY";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9s21ZrQH143K45hZozMRSZFY4ME7aMpVMc9i1GNk4x5sb9gGF5HpMddLjvTWRpcB7fcEh3LiDKkBmWRmVsx3JLFYZR5JKwg2uMmMaVR7xn2";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvABrGsX5C9januNtgeM93eeM3EKNZWyozGifvnfGdSxTkeFVVVjTNyhHUm8R6RjG6XJj3SWwGfz6jeo3LDaN46Zw9RkmiurVXB5pzy97JAPB";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAWgYBBk7JR8Gkg5oUhvfrjSYQHX1TboVBqC9a4AWpxqdhMJikPcwbkwcnLNgRdv1vwqrBzXq8eTHY5etwGn4tockJ6U9VmK1SoteMhC6m8H";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub661MyMwAqRbcGZn2v1tRohCGcP4bypYLiq5JoenMdHcrTx1Qncc4uRwpbB56jUHgktHe1ndB9hjqooaMoY6ttr1zQEXN8Vn6ZGsQUN2ef5g";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6QqdH2c5z7967ry9kNg41nHmnMD3vSXqdwbXb3gF1HzjX3pe3GmdXVbxcP2gjNwcAXQSmGDjcN6Ph6BvXEWuh5hbGaDniQbapzw3rugYXvR";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6jftahH18ngZyAAGajTgDsPGxKMVs4XLZ47kNSa8PJNca9dsHvwC9ZG6dazGjHbXaAXFWjpJ52SwaNoVEvvvVKPC8uvDJKR56izhFV3PPt7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "00000000";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "6";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Keypath = "m/44'/1'/0'/0/1";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "1c29bf01029cdcfcc7a715922960d8f9cd89726590263d5c333e737b7edbbf41";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "027709aa0e5997adbc04f901c2a8e9ad24fe714bf46101b6e5d96aff37b065586a";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "wNZk6TPzYvfP10N0fe9nCMqtNflkQ1/5AnfsbzfjkDY=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KxATQwpVYqXxwJPYmZNPL9LJ275oQBeJGvxacSATf84oYAVDPp4U";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprvA3PLjciHw9WtUwEwM5auUAu275bc7ix9rppvGn8HiLvGDvb9MebmxK42Y53SeFbVPyM5A9ua9Bstp9o8tca45pPoPFHVFhmntr45RRXATbg";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvANDc3HPD5q4NLES4BSNXgFzXH3k44LwemwM94B2B6MJ9H2QNcJmLaNiAZH12eAFQocTsudW8brEShSQhcJz4t45QFayuqcbHAa7ip3Yaetn";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAh3sLx48EWbrBXdB1oA9tM62T1tVzxw9h3sMqZv4UMg2L8DbrxvuCSNJaUxce4uLDFagf76h4Wazaj2GL1Q5gHm17vgLRXQmSJBNCYc8s3t";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub6GNh98FBmX5BhRKQT77uqJqkf7S6XBg1E3kX5AXuGgTF6ivHuBv2W7NWPLmEMenV6MtpaHgGKEkHp8ZnQv9LNkXWiMaBZ4nuxHGvZF2NkxJ";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6bCxSnv6vCcfYiWXHTuY3PwFq5aYTofW9AGjrZRnegq89pjX9r5b8B2eQYipMZSQW11dKmGpmu6qhRBM8cZMAzD7ahGc8ycQE1LZwqHmHDr";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6v3DkTb24tA9Q1he7phAFV2m13izQRf14GnxdxKg2hD1CvYkQWF9kEgnRkgQMU6Kue8S5EsPEZTPahnurJyMyDtiT2y2itRtVjQDLKdzP1v";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "828bb948";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 5;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 1;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "m/44'/1'/0'/0/1";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "7";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "budget minimum between flower tribe gesture safe cool pioneer hurt blossom tell";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Keypath = "m/44'/1'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "c8222b32a0189e5fa1f46700a9d0438c00feb279f0f2087cafe6f5b5ce9d224a";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "02d5b24f786a03364aea52c033816645a7e2eec3f29f30c3a0575a0d9e059389fc";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "WTf34VrZUU83e7l22AC082K3vK/VslEJPwfZUtY5R/o=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L3vk7jb4iDGduQtyfw2JnPC9RLu7uBDsfPsuojAnKQFRAuiCM8hL";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9yB1GVkGn8iZ23FVqoEzPNjD9YVTgmHQ2S1tikM5Dy9mKaDDkFRbbnPaGyWEq7wEWKPfbAGzKxTctNPJqNLJWULddSYWFeRCs9m6nQi4nd4";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvAJ1GaARBvpG2sLScgA2cbTpiKWdudPGtwYY7W9ExbyXeNg2SzubADr3iJBTpq2b9uxWULdsYncpAmezsZ4kKJi2EVnEvqZEh8spkB14ewC8";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAcqXsq675VoWiddjWWpEoYvDVUnMa1GPrf4LHY8qyyuXRmqgFZkiquhrKPRQpwF5KbdH67U7FHAiewcSGmAL6whqN7wMRU4BQbtPZahuiAj";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub6CAMg1HAcWGrEXKxwpmzkWfwhaKx6E1FPewVX8kgnJgkCNYNHnjr9ai48Edyirmoaqiig3SGJa5NsYLUf5BHkx98WwDE9hC3RyKrpsVjeJF";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6Wzcyfx5mBpL5pX5nBZcxbmSsYUQ2qzkJmTiJXeaAK4dFUMbYSuQmeNC9SbZimRizUqXRX2pmERvkpx3NmbJZBpjPGuejc1XhhPWDXRSTbY";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6qptHLczusMow7iCcYMFAgrx3WcqyTzFDsyw5vYTYKSWJaApo74yPi2LAeZ9ig5eQ7xLAzdPDtnUe7Zc6U1KMRWLFcc5KWq1yRT9c2ekKD2";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "4567db2b";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 3;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 2147483648L;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = true;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "m/44'/1'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "8";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "TestNet";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 70;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Extendedprivatekey = "tprv8fqx3q4cBQYdcrV2WN6VZ2MCTfufvHKQMyw1bAmXhweF7AxJjcmM7Xm2C9ftqVKYskvSbFtkVK3RMDw3xagFKXcEA5kov19FnFWXE6fPozG";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "c8222b32a0189e5fa1f46700a9d0438c00feb279f0f2087cafe6f5b5ce9d224a";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "02d5b24f786a03364aea52c033816645a7e2eec3f29f30c3a0575a0d9e059389fc";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "WTf34VrZUU83e7l22AC082K3vK/VslEJPwfZUtY5R/o=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "cUHjaeav9Gxu4rNF4LqS9hhD3aCXZdKZjS2Nv9dHpWuRRemmaump";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "tprv8fqx3q4cBQYdcrV2WN6VZ2MCTfufvHKQMyw1bAmXhweF7AxJjcmM7Xm2C9ftqVKYskvSbFtkVK3RMDw3xagFKXcEA5kov19FnFWXE6fPozG";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "uprv8zgDMVjXL667U9g9Lit7m7Shde47ruJuH6TENZfR5x28AGmXzGvujbRADMdUqPyUHQ3FLjVJwyPyEWYcgH6G7mHq2RTEVuxk3yaAcdBLJGJ";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "vprv9KWUfAQSUmdbKSsGB5fjyCYCocCZoXJQCCyT9xZJTxQ1DNamEw6UMf5JEZb4qJdPh3A46D5sQdkX7oABPyWGuzyRtm9f5pnEKhdp1J7bQnn";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "tpubDCXzCF6rKnEJWKWpQ1m5xS1K2hRc5cWJwHXnsgoq8DSdwfD5N1awJ2NtNGimFMj3NkFdHcx8qfuRZiq63w2XePbRaXxXqDrH1vvGasz7mb2";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "upub5DfZm1GRATeQgdkcSkR88FPSBftcGN2keKNqAx52eHZ7356gXpFAHPje4cmDj8p3MvNJRceavb1jDgVnVywFNF6Kuv7xPxjaco8vfAUMm38";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "vpub5YVq4fwLK9BtXvwjH7CkLLUwMe34Cz2FZRu3xLxv2Hvz6AuunUQiuTPn5pioj3TxmZV7B6F9PFNH6y7MDgMGAUmvnFpNysZ4tXCa3oSU2GT";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "4567db2b";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 3;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 2147483648L;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = true;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "9";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 70;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Extendedprivatekey = "xprv9s21ZrQH143K24Mfq5zL5MhWK9hUhhGbd45hLXo2Pq2oqzMMo63oStZzFGTQQD3dC4H2D5GBj7vWvSQaaBv5cxi9gafk7NF3pnBju6dwKvH";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 0;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = false;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "Invalid ExtKey";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "10";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Keypath = "m/44'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "fe64af825b5b78554c33a28b23085fc082f691b3c712cc1d4e66e133297da87a";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "03774c910fcf07fa96886ea794f0d5caed9afe30b44b83f7e213bb92930e7df4bd";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "PaS8GQomgBEdMfrf3JBfKn9s53xvEJkZEW8lPUNEUhk=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L5kDcLx1KSd1eJyyVF4qGC9ucBDSmq3qgUTaqyckhDpMtsQQVBbK";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9xpXFhFpqdQK3TmytPBqXtGSwS3DLjojFhTGht8gwAAii8py5X6pxeBnQ6ehJiyJ6nDjWGJfZ95WxByFXVkDxHXrqu53WCRGypk2ttuqncb";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvAHenZMvjzJwntky6ijyTjyMx7QBfHMoEAoyVVH2aKAYbmEeCLBGPahqvRJcHJddDWRLYFjuE1oS4qUapFCAEkXDTiEmU67EmFYogHRVWq5x";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAcV3s2bf8zVGk4ADZ6m5x4TTHNL7Dynj5vViGfvThAvUpLTRaqRxCmW4SWZsJYH8v4TM1DVnUTncimCNxtaFYku4aaTtg24FXGsKg4Tm5fR";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub6BosfCnifzxcFwrSzQiqu2DBVTshkCXacvNsWGYJVVhhawA7d4R5WSWGFNbi8Aw6ZRc1brxMyWMzG3DSSSSoekkudhUd9yLb6qx39T9nMdj";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6We8xsTdpgW67F3ZpmWU77JgfS29gpX5Y2u6HfSBsW5ae2yLsiae8WAQGaZJ85b1y4ipMLYvSAiY9Kq1A8rpSzSWW3B3jtA5Na1gXzZ8iqF";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6qUQGY8YyN3ZxYEgf8J6KCQBqQAbdSWaT9RK54L5FWTTh8na8NkCkZpYHnWt7zEwNhqd6p9Utq562cSZsqGqFE87NNsUKnyZeJ5KvbhfC8E";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "155bca59";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 3;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 2147483648L;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = true;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "m/44'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "11";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Keypath = "m/49'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "880d51752bda4190607e079588d3f644d96bfa03446bce93cddfda3c4a99c7e6";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "02f1f347891b20f7568eae3ec9869fbfb67bcab6f358326f10ecc42356bd55939d";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "bqrjZa4OCgqrhDJc/nzXbDuQkDX4iefT8bhHqaB5fss=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L1nBHqzVZ8Kq41ZKEWWmrcivvPrjYZ93gwYy86ZM5rNuAcSPtx1o";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9y7S1RkggDtZnP1RSzJ7PwUR4MUfF66Wz2jGv9TwJM52WLGmnnrQLLzBSTi7rNtBk4SGeQHBj5G4CuQvPXSn58BmhvX9vk6YzcMm37VuNYD";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvAHwhK6RbpuS3dgCYHM5jc2ZvEKd7Bi61u9FVhYMpgMSuZS613T1xxQeKTffhrHY79hZ5PsskBjcc6C2V7DrnsMsNaGDaWev3GLRQRgV7hxF";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAcmxcm6WyayXUyPf7hsMp7fRQHmZ8L5WpFmiUwFi4MpncXuEJ7BXaUJTUsdHrCC2ZLft9MUJePy9yUe3pvGofbYySbv16ZjXY4V3pG9gv3w";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub6C6nQwHaWbSrzs5tZ1q7m5R9cPK9eYpNMFesiXsYrgc1P8bvLLAet9JfHjYXKjToD8cBRswJXXbbFpXgwsswVPAZzKMa1jUp2kVkGVUaJa7";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6Ww3ibxVfGzLrAH1PNcjyAWenMTbbAosGNB6VvmSEgytSER9azLDWCxoJwW7Ke7icmizBMXrzBx9979FfaHxHcrArf3zbeJJJUZPf663zsP";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6qmK2GdQoxXphTU8DjQNBFc9xKc3XnoNBUhKHKfKchMmVLENqeVn8GcwL9ThKYme2Qqnvq8RSrJh2PkpPGhy5rXmizkRBZ7naCd33hHSpaN";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "3d05ff75";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 3;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 2147483648L;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = true;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "m/49'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createextkeyunittestsdt, 0);
         Gxm1createextkeyunittestsdt.gxTpr_Testcaseid = "12";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Networktype = "Main";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createextkeytype = 30;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Mnemoniclanguage = 10;
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Createtext = "abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about";
         Gxm1createextkeyunittestsdt.gxTpr_Extkeycreate.gxTpr_Keypath = "m/84'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Password = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "e14f274d16ca0d91031b98b162618061d03930fa381af6d4caf44b01819ab6d4";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "02707a62fdacc26ea9b63b1c197906f56ee0180d0bcf1966e1a2da34f5f3a09a9b";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Chaincode = "SlOgqyG53JWGnE6SoWEZTgPA7z/1AUrGkvQzxHZUkPw=";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L4mgYDnGiiFfvg3ioVr1yvtLtT5rzgeZv8vqhAWfDfw1mLBRAfDo";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekey = "xprv9ybY78BftS5UGANki6oSifuQEjkpyAC8ZmBvBNTshQnCBcxnefjHS7buPMkkqhcRzmoGZ5bokx7GuyDAiktd5HemohAU4wV1ZPMDRmLpBMm";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwitp2sh = "yprvAJRoQnrb37cx7TZsYTb4vkzuQhuGunBdUsi8xmMm5RA5Ein1uKtr4BG3QZiLqcGMQQv5JZCNDcTpoFpjSTJdsXLNg2rterJVq7QrpHUxFQt";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Privatekeysegwit = "zprvAdG4iTXWBoARxkkzNpNh8r6Qag3irQB8PzEMkAFeTRXxHpbF9z4QgEvBRmfvqWvGp42t42nvgGpNgYSJA9iefm1yYNZKEm7z6qUWCroSQnE";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickey = "xpub6CatWdiZiodmUeTDp8LT5or8nmbKNcuyvz7WyksVFkKB4RHwCD3XyuvPEbvqAQY3rAPshWcMLoP2fMFMKHPJ4ZeZXYVUhLv1VMrjPC7PW6V";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwitp2sh = "ypub6XR9pJPUsVBFKweLeV85HtwdxjjmKEuUr6djm9mNdkh47X7ASsD6byaXFotRAKByFoWgSzCuoTjaYdrv2yoJroLAPtBuHFjVm5vNmhyNehE";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Nuterpublickeysegwit = "zpub6rFR7y4Q2AijBEqTUquhVz398htDFrtymD9xYYfG1m4wAcvPhXNfE3EfH1r1ADqtfSdVCToUG868RvUUkgDKf31mGDtKsAYz2oz2AGutZYs";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Parentfingerprint = "7ef32bdb";
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Depth = 3;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Child = 2147483648L;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Ishardended = true;
         Gxm1createextkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Extended.gxTpr_Keypath = "m/84'/0'/0'";
         Gxm1createextkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createextkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createextkeyunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1createextkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtCreateExtKeyUnitTestSDT Gxm1createextkeyunittestsdt ;
   }

}
