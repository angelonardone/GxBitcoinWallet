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
   public class readallfiles : GXProcedure
   {
      public readallfiles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public readallfiles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> aP0_encryptedFiles )
      {
         this.AV13encryptedFiles = new GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile>( context, "EncryptedFile", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_encryptedFiles=this.AV13encryptedFiles;
      }

      public GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> executeUdp( )
      {
         execute(out aP0_encryptedFiles);
         return AV13encryptedFiles ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> aP0_encryptedFiles )
      {
         readallfiles objreadallfiles;
         objreadallfiles = new readallfiles();
         objreadallfiles.AV13encryptedFiles = new GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile>( context, "EncryptedFile", "GxBitcoinWallet") ;
         objreadallfiles.context.SetSubmitInitialConfig(context);
         objreadallfiles.initialize();
         Submit( executePrivateCatch,objreadallfiles);
         aP0_encryptedFiles=this.AV13encryptedFiles;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((readallfiles)stateInfo).executePrivate();
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
         GXt_SdtWallet1 = AV11wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV11wallet = GXt_SdtWallet1;
         AV9directory.Source = AV11wallet.gxTpr_Walletbasedirectory+"Files";
         if ( ! AV9directory.Exists() )
         {
            AV9directory.Create();
         }
         AV17GXV2 = 1;
         AV16GXV1 = AV9directory.GetFiles("*.enc");
         while ( AV17GXV2 <= AV16GXV1.ItemCount )
         {
            AV8auxFile = AV16GXV1.Item(AV17GXV2);
            GXt_boolean2 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean2) ;
            GXt_boolean3 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean3) ;
            AV10fileName = AV8auxFile.GetPath() + (GXt_boolean3 ? "/" : "\\") + AV8auxFile.GetName();
            GXt_SdtEncryptedFile4 = AV12encryptedFile;
            new GeneXus.Programs.wallet.readfile(context ).execute(  AV10fileName, out  GXt_SdtEncryptedFile4) ;
            AV12encryptedFile = GXt_SdtEncryptedFile4;
            AV13encryptedFiles.Add(AV12encryptedFile, 0);
            AV17GXV2 = (int)(AV17GXV2+1);
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
         AV13encryptedFiles = new GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile>( context, "EncryptedFile", "GxBitcoinWallet");
         AV11wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV9directory = new GxDirectory(context.GetPhysicalPath());
         AV16GXV1 = new GxFileCollection();
         AV8auxFile = new GxFile(context.GetPhysicalPath());
         AV10fileName = "";
         AV12encryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context);
         GXt_SdtEncryptedFile4 = new GeneXus.Programs.wallet.SdtEncryptedFile(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV17GXV2 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean3 ;
      private string AV10fileName ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> aP0_encryptedFiles ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtEncryptedFile> AV13encryptedFiles ;
      private GxFile AV8auxFile ;
      private GxDirectory AV9directory ;
      private GxFileCollection AV16GXV1 ;
      private GeneXus.Programs.wallet.SdtWallet AV11wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.wallet.SdtEncryptedFile AV12encryptedFile ;
      private GeneXus.Programs.wallet.SdtEncryptedFile GXt_SdtEncryptedFile4 ;
   }

}
