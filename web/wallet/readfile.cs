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
   public class readfile : GXProcedure
   {
      public readfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public readfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_file_source ,
                           out GeneXus.Programs.wallet.SdtEncryptedFile aP1_encryptedFile )
      {
         this.AV9file_source = aP0_file_source;
         this.AV8encryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context) ;
         initialize();
         executePrivate();
         aP1_encryptedFile=this.AV8encryptedFile;
      }

      public GeneXus.Programs.wallet.SdtEncryptedFile executeUdp( string aP0_file_source )
      {
         execute(aP0_file_source, out aP1_encryptedFile);
         return AV8encryptedFile ;
      }

      public void executeSubmit( string aP0_file_source ,
                                 out GeneXus.Programs.wallet.SdtEncryptedFile aP1_encryptedFile )
      {
         readfile objreadfile;
         objreadfile = new readfile();
         objreadfile.AV9file_source = aP0_file_source;
         objreadfile.AV8encryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context) ;
         objreadfile.context.SetSubmitInitialConfig(context);
         objreadfile.initialize();
         Submit( executePrivateCatch,objreadfile);
         aP1_encryptedFile=this.AV8encryptedFile;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((readfile)stateInfo).executePrivate();
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
         AV10fileFile.Source = StringUtil.Trim( AV9file_source);
         if ( AV10fileFile.Exists() )
         {
            if ( ! AV8encryptedFile.FromJSonFile(AV10fileFile, AV11messages) )
            {
               GX_msglist.addItem("error: "+AV11messages.ToJSonString(false));
            }
         }
         else
         {
            GX_msglist.addItem("File does not exist");
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
         AV8encryptedFile = new GeneXus.Programs.wallet.SdtEncryptedFile(context);
         AV10fileFile = new GxFile(context.GetPhysicalPath());
         AV11messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9file_source ;
      private GeneXus.Programs.wallet.SdtEncryptedFile aP1_encryptedFile ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11messages ;
      private GxFile AV10fileFile ;
      private GeneXus.Programs.wallet.SdtEncryptedFile AV8encryptedFile ;
   }

}
