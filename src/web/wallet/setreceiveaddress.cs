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
   public class setreceiveaddress : GXProcedure
   {
      public setreceiveaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public setreceiveaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> aP0_sdt_ReturnAddresses )
      {
         this.AV10sdt_ReturnAddresses = aP0_sdt_ReturnAddresses;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> aP0_sdt_ReturnAddresses )
      {
         this.AV10sdt_ReturnAddresses = aP0_sdt_ReturnAddresses;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WebSession.Set("ReceiveAddressess", AV10sdt_ReturnAddresses.ToJSonString(false));
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
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9WebSession ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtSDT_ReturnAddresses_SDT_ReturnAddressesItem> AV10sdt_ReturnAddresses ;
   }

}
