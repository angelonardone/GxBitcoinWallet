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
   public class readallnotes : GXProcedure
   {
      public readallnotes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public readallnotes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wallet.SdtNote> aP0_notes )
      {
         this.AV13notes = new GXBaseCollection<GeneXus.Programs.wallet.SdtNote>( context, "Note", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_notes=this.AV13notes;
      }

      public GXBaseCollection<GeneXus.Programs.wallet.SdtNote> executeUdp( )
      {
         execute(out aP0_notes);
         return AV13notes ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wallet.SdtNote> aP0_notes )
      {
         readallnotes objreadallnotes;
         objreadallnotes = new readallnotes();
         objreadallnotes.AV13notes = new GXBaseCollection<GeneXus.Programs.wallet.SdtNote>( context, "Note", "GxBitcoinWallet") ;
         objreadallnotes.context.SetSubmitInitialConfig(context);
         objreadallnotes.initialize();
         Submit( executePrivateCatch,objreadallnotes);
         aP0_notes=this.AV13notes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((readallnotes)stateInfo).executePrivate();
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
         AV12noteDirectory.Source = AV11wallet.gxTpr_Walletbasedirectory+"Notes";
         if ( ! AV12noteDirectory.Exists() )
         {
            AV12noteDirectory.Create();
         }
         AV18GXV2 = 1;
         AV17GXV1 = AV12noteDirectory.GetFiles("*.note");
         while ( AV18GXV2 <= AV17GXV1.ItemCount )
         {
            AV8auxFile = AV17GXV1.Item(AV18GXV2);
            GXt_boolean2 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean2) ;
            GXt_boolean3 = false;
            new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean3) ;
            AV10fileName = AV8auxFile.GetPath() + (GXt_boolean3 ? "/" : "\\") + AV8auxFile.GetName();
            GXt_SdtNote4 = AV14note;
            new GeneXus.Programs.wallet.readnote(context ).execute(  AV10fileName, out  GXt_SdtNote4) ;
            AV14note = GXt_SdtNote4;
            AV14note.gxTpr_Notefilename = AV10fileName;
            AV13notes.Add(AV14note, 0);
            AV18GXV2 = (int)(AV18GXV2+1);
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
         AV13notes = new GXBaseCollection<GeneXus.Programs.wallet.SdtNote>( context, "Note", "GxBitcoinWallet");
         AV11wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV12noteDirectory = new GxDirectory(context.GetPhysicalPath());
         AV17GXV1 = new GxFileCollection();
         AV8auxFile = new GxFile(context.GetPhysicalPath());
         AV10fileName = "";
         AV14note = new GeneXus.Programs.wallet.SdtNote(context);
         GXt_SdtNote4 = new GeneXus.Programs.wallet.SdtNote(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV2 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean3 ;
      private string AV10fileName ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtNote> aP0_notes ;
      private GXBaseCollection<GeneXus.Programs.wallet.SdtNote> AV13notes ;
      private GxFile AV8auxFile ;
      private GxDirectory AV12noteDirectory ;
      private GxFileCollection AV17GXV1 ;
      private GeneXus.Programs.wallet.SdtWallet AV11wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.wallet.SdtNote AV14note ;
      private GeneXus.Programs.wallet.SdtNote GXt_SdtNote4 ;
   }

}
