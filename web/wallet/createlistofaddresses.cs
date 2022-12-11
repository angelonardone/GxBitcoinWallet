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
   public class createlistofaddresses : GXProcedure
   {
      public createlistofaddresses( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createlistofaddresses( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                           SdtGxExplorer_services_TxoutFromAddresses aP1_GxExplorer_services_TxoutFromAddressesOUT ,
                           short aP2_listOfAddressType ,
                           out short aP3_numCreated )
      {
         this.AV8sdt_addressessChange = aP0_sdt_addressessChange;
         this.GxExplorer_services_TxoutFromAddressesOUT = aP1_GxExplorer_services_TxoutFromAddressesOUT;
         this.AV19listOfAddressType = aP2_listOfAddressType;
         this.AV10numCreated = 0 ;
         initialize();
         executePrivate();
         aP3_numCreated=this.AV10numCreated;
      }

      public short executeUdp( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                               SdtGxExplorer_services_TxoutFromAddresses aP1_GxExplorer_services_TxoutFromAddressesOUT ,
                               short aP2_listOfAddressType )
      {
         execute(aP0_sdt_addressessChange, aP1_GxExplorer_services_TxoutFromAddressesOUT, aP2_listOfAddressType, out aP3_numCreated);
         return AV10numCreated ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                                 SdtGxExplorer_services_TxoutFromAddresses aP1_GxExplorer_services_TxoutFromAddressesOUT ,
                                 short aP2_listOfAddressType ,
                                 out short aP3_numCreated )
      {
         createlistofaddresses objcreatelistofaddresses;
         objcreatelistofaddresses = new createlistofaddresses();
         objcreatelistofaddresses.AV8sdt_addressessChange = aP0_sdt_addressessChange;
         objcreatelistofaddresses.GxExplorer_services_TxoutFromAddressesOUT = aP1_GxExplorer_services_TxoutFromAddressesOUT;
         objcreatelistofaddresses.AV19listOfAddressType = aP2_listOfAddressType;
         objcreatelistofaddresses.AV10numCreated = 0 ;
         objcreatelistofaddresses.context.SetSubmitInitialConfig(context);
         objcreatelistofaddresses.initialize();
         Submit( executePrivateCatch,objcreatelistofaddresses);
         aP3_numCreated=this.AV10numCreated;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createlistofaddresses)stateInfo).executePrivate();
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
         AV10numCreated = 0;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV8sdt_addressessChange.gxTpr_Address.Count )
         {
            AV17one_address = AV8sdt_addressessChange.gxTpr_Address.GetString(AV22GXV1);
            AV14oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
            AV14oneReturnAddress.gxTpr_Address = AV17one_address;
            AV14oneReturnAddress.gxTpr_Isused = false;
            AV13sdt_ReturnAddresses.Add(AV14oneReturnAddress, 0);
            AV10numCreated = (short)(AV10numCreated+1);
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         AV23GXV2 = 1;
         while ( AV23GXV2 <= GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Count )
         {
            AV11TransactionItem = ((SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem)GxExplorer_services_TxoutFromAddressesOUT.gxTpr_Transaction.Item(AV23GXV2));
            AV24GXV3 = 1;
            while ( AV24GXV3 <= AV13sdt_ReturnAddresses.Count )
            {
               AV14oneReturnAddress = ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV13sdt_ReturnAddresses.Item(AV24GXV3));
               if ( StringUtil.StrCmp(StringUtil.Trim( AV11TransactionItem.gxTpr_Scriptpubkey_address), StringUtil.Trim( AV14oneReturnAddress.gxTpr_Address)) == 0 )
               {
                  AV18indexOf = (short)(AV13sdt_ReturnAddresses.IndexOf(AV14oneReturnAddress));
                  ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV13sdt_ReturnAddresses.Item(AV18indexOf)).gxTpr_Isused = true;
                  AV10numCreated = (short)(AV10numCreated-1);
               }
               AV24GXV3 = (int)(AV24GXV3+1);
            }
            AV23GXV2 = (int)(AV23GXV2+1);
         }
         if ( AV19listOfAddressType == 20 )
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
         AV17one_address = "";
         AV14oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
         AV13sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         AV11TransactionItem = new SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19listOfAddressType ;
      private short AV10numCreated ;
      private short AV18indexOf ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private int AV24GXV3 ;
      private string AV17one_address ;
      private short aP3_numCreated ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV13sdt_ReturnAddresses ;
      private SdtGxExplorer_services_TxoutFromAddresses GxExplorer_services_TxoutFromAddressesOUT ;
      private SdtGxExplorer_services_TxoutFromAddresses_Transaction_TransactionItem AV11TransactionItem ;
      private GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem AV14oneReturnAddress ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV8sdt_addressessChange ;
   }

}
