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
         context.SetDefaultTheme("Carmine");
      }

      public pulloneaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_listOfAddressType ,
                           out string aP1_oneAddress )
      {
         this.AV16listOfAddressType = aP0_listOfAddressType;
         this.AV12oneAddress = "" ;
         initialize();
         executePrivate();
         aP1_oneAddress=this.AV12oneAddress;
      }

      public string executeUdp( short aP0_listOfAddressType )
      {
         execute(aP0_listOfAddressType, out aP1_oneAddress);
         return AV12oneAddress ;
      }

      public void executeSubmit( short aP0_listOfAddressType ,
                                 out string aP1_oneAddress )
      {
         pulloneaddress objpulloneaddress;
         objpulloneaddress = new pulloneaddress();
         objpulloneaddress.AV16listOfAddressType = aP0_listOfAddressType;
         objpulloneaddress.AV12oneAddress = "" ;
         objpulloneaddress.context.SetSubmitInitialConfig(context);
         objpulloneaddress.initialize();
         Submit( executePrivateCatch,objpulloneaddress);
         aP1_oneAddress=this.AV12oneAddress;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pulloneaddress)stateInfo).executePrivate();
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
         if ( AV16listOfAddressType == 20 )
         {
            GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = AV13sdt_ReturnAddresses;
            new GeneXus.Programs.wallet.getreturnaddressess(context ).execute( out  GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1) ;
            AV13sdt_ReturnAddresses = GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1;
         }
         else
         {
            GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = AV13sdt_ReturnAddresses;
            new GeneXus.Programs.wallet.getreceiveaddressess(context ).execute( out  GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1) ;
            AV13sdt_ReturnAddresses = GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1;
         }
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV13sdt_ReturnAddresses.Count )
         {
            AV14oneReturnAddress = ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV13sdt_ReturnAddresses.Item(AV19GXV1));
            if ( ! AV14oneReturnAddress.gxTpr_Isused )
            {
               AV12oneAddress = AV14oneReturnAddress.gxTpr_Address;
               AV15indexOf = (short)(AV13sdt_ReturnAddresses.IndexOf(AV14oneReturnAddress));
               ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV13sdt_ReturnAddresses.Item(AV15indexOf)).gxTpr_Isused = true;
               if (true) break;
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         if ( AV16listOfAddressType == 20 )
         {
            new GeneXus.Programs.wallet.setretrunaddress(context ).execute(  AV13sdt_ReturnAddresses) ;
         }
         else
         {
            new GeneXus.Programs.wallet.setreceiveaddress(context ).execute(  AV13sdt_ReturnAddresses) ;
         }
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
         AV12oneAddress = "";
         AV13sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         AV14oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16listOfAddressType ;
      private short AV15indexOf ;
      private int AV19GXV1 ;
      private string AV12oneAddress ;
      private string aP1_oneAddress ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV13sdt_ReturnAddresses ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> GXt_objcol_SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem1 ;
      private GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem AV14oneReturnAddress ;
   }

}
