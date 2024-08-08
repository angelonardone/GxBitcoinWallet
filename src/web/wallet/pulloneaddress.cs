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
namespace GeneXus.Programs.wallet {
   public class pulloneaddress : GXProcedure
   {
      public pulloneaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public pulloneaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_listOfAddressType ,
                           out string aP1_oneAddress )
      {
         this.AV12listOfAddressType = aP0_listOfAddressType;
         this.AV8oneAddress = "" ;
         initialize();
         ExecuteImpl();
         aP1_oneAddress=this.AV8oneAddress;
      }

      public string executeUdp( short aP0_listOfAddressType )
      {
         execute(aP0_listOfAddressType, out aP1_oneAddress);
         return AV8oneAddress ;
      }

      public void executeSubmit( short aP0_listOfAddressType ,
                                 out string aP1_oneAddress )
      {
         this.AV12listOfAddressType = aP0_listOfAddressType;
         this.AV8oneAddress = "" ;
         SubmitImpl();
         aP1_oneAddress=this.AV8oneAddress;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV12listOfAddressType == 20 )
         {
            GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = AV10sdt_ReturnAddresses;
            new GeneXus.Programs.wallet.getreturnaddressess(context ).execute( out  GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1) ;
            AV10sdt_ReturnAddresses = GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1;
         }
         else
         {
            GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = AV10sdt_ReturnAddresses;
            new GeneXus.Programs.wallet.getreceiveaddressess(context ).execute( out  GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1) ;
            AV10sdt_ReturnAddresses = GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1;
         }
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10sdt_ReturnAddresses.Count )
         {
            AV9oneReturnAddress = ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV10sdt_ReturnAddresses.Item(AV13GXV1));
            if ( ! AV9oneReturnAddress.gxTpr_Isused )
            {
               AV8oneAddress = AV9oneReturnAddress.gxTpr_Address;
               AV11indexOf = (short)(AV10sdt_ReturnAddresses.IndexOf(AV9oneReturnAddress));
               ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV10sdt_ReturnAddresses.Item(AV11indexOf)).gxTpr_Isused = true;
               if (true) break;
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         if ( AV12listOfAddressType == 20 )
         {
            new GeneXus.Programs.wallet.setretrunaddress(context ).execute(  AV10sdt_ReturnAddresses) ;
         }
         else
         {
            new GeneXus.Programs.wallet.setreceiveaddress(context ).execute(  AV10sdt_ReturnAddresses) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8oneAddress = "";
         AV10sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         AV9oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
         /* GeneXus formulas. */
      }

      private short AV12listOfAddressType ;
      private short AV11indexOf ;
      private int AV13GXV1 ;
      private string AV8oneAddress ;
      private string aP1_oneAddress ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV10sdt_ReturnAddresses ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 ;
      private GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem AV9oneReturnAddress ;
   }

}
