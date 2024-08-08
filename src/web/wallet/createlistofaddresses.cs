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
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public createlistofaddresses( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                           GeneXus.Programs.wallet.SdtStoredTransactions aP1_StoredTransactions ,
                           short aP2_listOfAddressType ,
                           out short aP3_numCreated )
      {
         this.AV11sdt_addressessChange = aP0_sdt_addressessChange;
         this.AV18StoredTransactions = aP1_StoredTransactions;
         this.AV16listOfAddressType = aP2_listOfAddressType;
         this.AV9numCreated = 0 ;
         initialize();
         ExecuteImpl();
         aP3_numCreated=this.AV9numCreated;
      }

      public short executeUdp( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                               GeneXus.Programs.wallet.SdtStoredTransactions aP1_StoredTransactions ,
                               short aP2_listOfAddressType )
      {
         execute(aP0_sdt_addressessChange, aP1_StoredTransactions, aP2_listOfAddressType, out aP3_numCreated);
         return AV9numCreated ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtSDT_Addressess aP0_sdt_addressessChange ,
                                 GeneXus.Programs.wallet.SdtStoredTransactions aP1_StoredTransactions ,
                                 short aP2_listOfAddressType ,
                                 out short aP3_numCreated )
      {
         this.AV11sdt_addressessChange = aP0_sdt_addressessChange;
         this.AV18StoredTransactions = aP1_StoredTransactions;
         this.AV16listOfAddressType = aP2_listOfAddressType;
         this.AV9numCreated = 0 ;
         SubmitImpl();
         aP3_numCreated=this.AV9numCreated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9numCreated = 0;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV11sdt_addressessChange.gxTpr_Address.Count )
         {
            AV14one_address = AV11sdt_addressessChange.gxTpr_Address.GetString(AV19GXV1);
            AV10oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
            AV10oneReturnAddress.gxTpr_Address = AV14one_address;
            AV10oneReturnAddress.gxTpr_Isused = false;
            AV12sdt_ReturnAddresses.Add(AV10oneReturnAddress, 0);
            AV9numCreated = (short)(AV9numCreated+1);
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         AV20GXV2 = 1;
         while ( AV20GXV2 <= AV18StoredTransactions.gxTpr_Transaction.Count )
         {
            AV17oneStoreTransaction = ((GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem)AV18StoredTransactions.gxTpr_Transaction.Item(AV20GXV2));
            AV21GXV3 = 1;
            while ( AV21GXV3 <= AV12sdt_ReturnAddresses.Count )
            {
               AV10oneReturnAddress = ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV12sdt_ReturnAddresses.Item(AV21GXV3));
               if ( StringUtil.StrCmp(StringUtil.Trim( AV17oneStoreTransaction.gxTpr_Scriptpubkey_address), StringUtil.Trim( AV10oneReturnAddress.gxTpr_Address)) == 0 )
               {
                  AV15indexOf = (short)(AV12sdt_ReturnAddresses.IndexOf(AV10oneReturnAddress));
                  ((GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem)AV12sdt_ReturnAddresses.Item(AV15indexOf)).gxTpr_Isused = true;
                  AV9numCreated = (short)(AV9numCreated-1);
               }
               AV21GXV3 = (int)(AV21GXV3+1);
            }
            AV20GXV2 = (int)(AV20GXV2+1);
         }
         if ( AV16listOfAddressType == 20 )
         {
            new GeneXus.Programs.wallet.setretrunaddress(context ).execute(  AV12sdt_ReturnAddresses) ;
         }
         else
         {
            new GeneXus.Programs.wallet.setreceiveaddress(context ).execute(  AV12sdt_ReturnAddresses) ;
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
         AV14one_address = "";
         AV10oneReturnAddress = new GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem(context);
         AV12sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         AV17oneStoreTransaction = new GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem(context);
         /* GeneXus formulas. */
      }

      private short AV16listOfAddressType ;
      private short AV9numCreated ;
      private short AV15indexOf ;
      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private int AV21GXV3 ;
      private string AV14one_address ;
      private short aP3_numCreated ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV12sdt_ReturnAddresses ;
      private GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem AV10oneReturnAddress ;
      private GeneXus.Programs.nbitcoin.SdtSDT_Addressess AV11sdt_addressessChange ;
      private GeneXus.Programs.wallet.SdtStoredTransactions AV18StoredTransactions ;
      private GeneXus.Programs.wallet.SdtStoredTransactions_TransactionItem AV17oneStoreTransaction ;
   }

}
