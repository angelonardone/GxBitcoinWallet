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
   public class createkeyunittestdata : GXProcedure
   {
      public createkeyunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createkeyunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT>( context, "CreateKeyUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> aP0_Gxm2rootcol )
      {
         createkeyunittestdata objcreatekeyunittestdata;
         objcreatekeyunittestdata = new createkeyunittestdata();
         objcreatekeyunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT>( context, "CreateKeyUnitTestSDT", "GxBitcoinWallet") ;
         objcreatekeyunittestdata.context.SetSubmitInitialConfig(context);
         objcreatekeyunittestdata.initialize();
         Submit( executePrivateCatch,objcreatekeyunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createkeyunittestdata)stateInfo).executePrivate();
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
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createkeyunittestsdt, 0);
         Gxm1createkeyunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createkeytype = 20;
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createtext = "Satoshi Nakamoto";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Networktype = "Main";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Addresstype = 0;
         Gxm1createkeyunittestsdt.gxTpr_Password = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "a0dc65ffca799873cbea0ac274015b9526505daaaed385155425f7337704883e";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "020791dc70b75aa995213244ad3f4886d74d61ccd3ef658243fcad14c9ccee2b0a";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeyhash = "47f867e79307f935595d1d2c1ad03313cd399618";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Scriptpublickey = "OP_DUP OP_HASH160 47f867e79307f935595d1d2c1ad03313cd399618 OP_EQUALVERIFY OP_CHECKSIG";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Address = "17ZYZASydeA1xyfNrcYcLyqghmK3eGJpHq";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L2cQMfbGpih4yTTTa3Dx4YHo4CLXqvJ5rKsggs9iswuXQYECC8aK";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createkeyunittestsdt, 0);
         Gxm1createkeyunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createkeytype = 100;
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createtext = "L1H5m1zGo3HQzyKx8xKAr7CnVWWRuc8yTRrJ3CBwKbTfQsbKagws";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Networktype = "Main";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Addresstype = 0;
         Gxm1createkeyunittestsdt.gxTpr_Password = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "7915924b01f364ce8c98bf7a02f103bf4bafccc82ba8b8fd1392d7f68fad2007";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "03e544b6419c99ffc371a82d7ea8e1b00a27f2ad03e19609b38a4cd6434b549cb5";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeyhash = "b558cf1807f651ba7e8172b10b8fb4bc4c41f9eb";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Scriptpublickey = "OP_DUP OP_HASH160 b558cf1807f651ba7e8172b10b8fb4bc4c41f9eb OP_EQUALVERIFY OP_CHECKSIG";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Address = "1HXshH1eUBSqdrUfcCTxzdhgveZ83UTm5w";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L1H5m1zGo3HQzyKx8xKAr7CnVWWRuc8yTRrJ3CBwKbTfQsbKagws";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createkeyunittestsdt, 0);
         Gxm1createkeyunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createkeytype = 30;
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createtext = "7915924b01f364ce8c98bf7a02f103bf4bafccc82ba8b8fd1392d7f68fad2007";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Networktype = "Main";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Addresstype = 0;
         Gxm1createkeyunittestsdt.gxTpr_Password = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "7915924b01f364ce8c98bf7a02f103bf4bafccc82ba8b8fd1392d7f68fad2007";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "03e544b6419c99ffc371a82d7ea8e1b00a27f2ad03e19609b38a4cd6434b549cb5";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeyhash = "b558cf1807f651ba7e8172b10b8fb4bc4c41f9eb";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Scriptpublickey = "OP_DUP OP_HASH160 b558cf1807f651ba7e8172b10b8fb4bc4c41f9eb OP_EQUALVERIFY OP_CHECKSIG";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Address = "1HXshH1eUBSqdrUfcCTxzdhgveZ83UTm5w";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L1H5m1zGo3HQzyKx8xKAr7CnVWWRuc8yTRrJ3CBwKbTfQsbKagws";
         Gxm1createkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createkeyunittestsdt, 0);
         Gxm1createkeyunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createkeytype = 30;
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createtext = "6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Networktype = "Main";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Addresstype = 0;
         Gxm1createkeyunittestsdt.gxTpr_Password = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "03fdf4907810a9f5d9462a1ae09feee5ab205d32798b0ffcc379442021f84c5bbf";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeyhash = "8d4d508f5bf2c28b20a3863405f05d3cd374b045";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Scriptpublickey = "OP_DUP OP_HASH160 8d4d508f5bf2c28b20a3863405f05d3cd374b045 OP_EQUALVERIFY OP_CHECKSIG";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Address = "1Dt8ty59tU9LkrXG2ocWeSzKFAY8fu6jga";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "KzpjABzbCjoxyhxzweCzGG3fqpKgbgJpsJeTqGV37f2KN7RM9eGD";
         Gxm1createkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgerror = "";
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1createkeyunittestsdt, 0);
         Gxm1createkeyunittestsdt.gxTpr_Testcaseid = "5";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createkeytype = 110;
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Createtext = "6PYTuoqm2FzoVyjZJQYFE9U25dfTvg7fTDHvMB1kbtJUNwfVipxkRdZosy";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Networktype = "Main";
         Gxm1createkeyunittestsdt.gxTpr_Keycreate.gxTpr_Addresstype = 0;
         Gxm1createkeyunittestsdt.gxTpr_Password = "hola";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Privatekey = "a0dc65ffca799873cbea0ac274015b9526505daaaed385155425f7337704883e";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickey = "020791dc70b75aa995213244ad3f4886d74d61ccd3ef658243fcad14c9ccee2b0a";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Publickeyhash = "47f867e79307f935595d1d2c1ad03313cd399618";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Scriptpublickey = "OP_DUP OP_HASH160 47f867e79307f935595d1d2c1ad03313cd399618 OP_EQUALVERIFY OP_CHECKSIG";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Address = "17ZYZASydeA1xyfNrcYcLyqghmK3eGJpHq";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Wif = "L2cQMfbGpih4yTTTa3Dx4YHo4CLXqvJ5rKsggs9iswuXQYECC8aK";
         Gxm1createkeyunittestsdt.gxTpr_Expectedkeyinfo.gxTpr_Encryptedwif = "6PYTuoqm2FzoVyjZJQYFE9U25dfTvg7fTDHvMB1kbtJUNwfVipxkRdZosy";
         Gxm1createkeyunittestsdt.gxTpr_Msgkeyinfo = "";
         Gxm1createkeyunittestsdt.gxTpr_Expectederror = "";
         Gxm1createkeyunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1createkeyunittestsdt = new GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.SdtCreateKeyUnitTestSDT Gxm1createkeyunittestsdt ;
   }

}
