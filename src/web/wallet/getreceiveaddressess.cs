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
   public class getreceiveaddressess : GXProcedure
   {
      public getreceiveaddressess( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public getreceiveaddressess( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> aP0_sdt_ReturnAddresses )
      {
         this.AV10sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet") ;
         initialize();
         ExecuteImpl();
         aP0_sdt_ReturnAddresses=this.AV10sdt_ReturnAddresses;
      }

      public GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> executeUdp( )
      {
         execute(out aP0_sdt_ReturnAddresses);
         return AV10sdt_ReturnAddresses ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> aP0_sdt_ReturnAddresses )
      {
         this.AV10sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet") ;
         SubmitImpl();
         aP0_sdt_ReturnAddresses=this.AV10sdt_ReturnAddresses;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10sdt_ReturnAddresses.FromJSonString(AV9WebSession.Get("ReceiveAddressess"), null);
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
         AV10sdt_ReturnAddresses = new GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem>( context, "SDT_ReturnAddressesItem", "GxBitcoinWallet");
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9WebSession ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> aP0_sdt_ReturnAddresses ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV10sdt_ReturnAddresses ;
   }

}
