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
   public class createwallet : GXProcedure
   {
      public createwallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public createwallet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wallet.SdtWallet aP0_wallet )
      {
         this.AV9wallet = aP0_wallet;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.wallet.SdtWallet aP0_wallet )
      {
         createwallet objcreatewallet;
         objcreatewallet = new createwallet();
         objcreatewallet.AV9wallet = aP0_wallet;
         objcreatewallet.context.SetSubmitInitialConfig(context);
         objcreatewallet.initialize();
         Submit( executePrivateCatch,objcreatewallet);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((createwallet)stateInfo).executePrivate();
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
         AV8directory.Source = "Wallets";
         if ( ! AV8directory.Exists() )
         {
            AV8directory.Create();
         }
         GXt_boolean1 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean1) ;
         GXt_boolean2 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean2) ;
         AV11walletDirectory.Source = "Wallets"+(GXt_boolean2 ? "/" : "\\")+AV9wallet.gxTpr_Walletname;
         if ( ! AV11walletDirectory.Exists() )
         {
            AV11walletDirectory.Create();
         }
         GXt_boolean2 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean2) ;
         GXt_boolean1 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean1) ;
         GXt_boolean3 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean3) ;
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         AV12walletFileName = AV8directory.Source + (GXt_boolean1 ? "/" : "\\") + AV9wallet.gxTpr_Walletname + (GXt_boolean4 ? "/" : "\\") + AV9wallet.gxTpr_Walletname + ".json";
         AV9wallet.gxTpr_Walletfilename = AV12walletFileName;
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         GXt_boolean3 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean3) ;
         GXt_boolean2 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean2) ;
         GXt_boolean1 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean1) ;
         AV9wallet.gxTpr_Walletbasedirectory = AV8directory.Source+(GXt_boolean3 ? "/" : "\\")+AV9wallet.gxTpr_Walletname+(GXt_boolean1 ? "/" : "\\");
         AV10walletFile.Source = AV12walletFileName;
         if ( AV10walletFile.Exists() )
         {
            GX_msglist.addItem("Wallet already exist");
         }
         else
         {
            AV10walletFile.WriteAllText(AV9wallet.ToJSonString(false, true), "");
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
         AV8directory = new GxDirectory(context.GetPhysicalPath());
         AV11walletDirectory = new GxDirectory(context.GetPhysicalPath());
         AV12walletFileName = "";
         AV10walletFile = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool GXt_boolean4 ;
      private bool GXt_boolean3 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean1 ;
      private string AV12walletFileName ;
      private GxFile AV10walletFile ;
      private GxDirectory AV8directory ;
      private GxDirectory AV11walletDirectory ;
      private GeneXus.Programs.wallet.SdtWallet AV9wallet ;
   }

}
