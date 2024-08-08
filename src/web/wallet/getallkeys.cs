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
   public class getallkeys : GXProcedure
   {
      public getallkeys( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public getallkeys( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP0_keyInfo )
      {
         this.AV8keyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet") ;
         initialize();
         ExecuteImpl();
         aP0_keyInfo=this.AV8keyInfo;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> executeUdp( )
      {
         execute(out aP0_keyInfo);
         return AV8keyInfo ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP0_keyInfo )
      {
         this.AV8keyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet") ;
         SubmitImpl();
         aP0_keyInfo=this.AV8keyInfo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8keyInfo.FromJSonString(AV9WebSession.Get("AllKeys"), null);
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
         AV8keyInfo = new GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo>( context, "KeyInfo", "GxBitcoinWallet");
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9WebSession ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP0_keyInfo ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV8keyInfo ;
   }

}
