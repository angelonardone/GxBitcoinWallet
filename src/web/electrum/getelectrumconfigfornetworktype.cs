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
namespace GeneXus.Programs.electrum {
   public class getelectrumconfigfornetworktype : GXProcedure
   {
      public getelectrumconfigfornetworktype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public getelectrumconfigfornetworktype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem aP0_walletConnParameter )
      {
         this.AV18walletConnParameter = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context) ;
         initialize();
         ExecuteImpl();
         aP0_walletConnParameter=this.AV18walletConnParameter;
      }

      public GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem executeUdp( )
      {
         execute(out aP0_walletConnParameter);
         return AV18walletConnParameter ;
      }

      public void executeSubmit( out GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem aP0_walletConnParameter )
      {
         this.AV18walletConnParameter = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context) ;
         SubmitImpl();
         aP0_walletConnParameter=this.AV18walletConnParameter;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtConnectionParameters_ConnectionParametersItem1 = AV12ConnectionParameters;
         new GeneXus.Programs.electrum.getelectrumconfigservers(context ).execute( out  GXt_objcol_SdtConnectionParameters_ConnectionParametersItem1) ;
         AV12ConnectionParameters = GXt_objcol_SdtConnectionParameters_ConnectionParametersItem1;
         GXt_SdtWallet2 = AV11wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet2) ;
         AV11wallet = GXt_SdtWallet2;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV12ConnectionParameters.Count )
         {
            AV16oneConnParameter = ((GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem)AV12ConnectionParameters.Item(AV19GXV1));
            if ( StringUtil.StrCmp(AV16oneConnParameter.gxTpr_Networktype, AV11wallet.gxTpr_Networktype) == 0 )
            {
               AV18walletConnParameter = (GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem)(AV16oneConnParameter.Clone());
               if (true) break;
            }
            AV19GXV1 = (int)(AV19GXV1+1);
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
         AV18walletConnParameter = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context);
         AV12ConnectionParameters = new GXBaseCollection<GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem>( context, "ConnectionParametersItem", "GxBitcoinWallet");
         GXt_objcol_SdtConnectionParameters_ConnectionParametersItem1 = new GXBaseCollection<GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem>( context, "ConnectionParametersItem", "GxBitcoinWallet");
         AV11wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet2 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV16oneConnParameter = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context);
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem aP0_walletConnParameter ;
      private GXBaseCollection<GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem> AV12ConnectionParameters ;
      private GXBaseCollection<GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem> GXt_objcol_SdtConnectionParameters_ConnectionParametersItem1 ;
      private GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem AV18walletConnParameter ;
      private GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem AV16oneConnParameter ;
      private GeneXus.Programs.wallet.SdtWallet AV11wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet2 ;
   }

}
