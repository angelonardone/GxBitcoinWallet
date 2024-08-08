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
   public class readnote : GXProcedure
   {
      public readnote( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public readnote( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_noteFile_source ,
                           out GeneXus.Programs.wallet.SdtNote aP1_note )
      {
         this.AV12noteFile_source = aP0_noteFile_source;
         this.AV10note = new GeneXus.Programs.wallet.SdtNote(context) ;
         initialize();
         ExecuteImpl();
         aP1_note=this.AV10note;
      }

      public GeneXus.Programs.wallet.SdtNote executeUdp( string aP0_noteFile_source )
      {
         execute(aP0_noteFile_source, out aP1_note);
         return AV10note ;
      }

      public void executeSubmit( string aP0_noteFile_source ,
                                 out GeneXus.Programs.wallet.SdtNote aP1_note )
      {
         this.AV12noteFile_source = aP0_noteFile_source;
         this.AV10note = new GeneXus.Programs.wallet.SdtNote(context) ;
         SubmitImpl();
         aP1_note=this.AV10note;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11noteFile.Source = StringUtil.Trim( AV12noteFile_source);
         if ( AV11noteFile.Exists() )
         {
            if ( ! AV10note.FromJSonFile(AV11noteFile, AV9messages) )
            {
               GX_msglist.addItem("error: "+AV9messages.ToJSonString(false));
            }
         }
         else
         {
            GX_msglist.addItem("Note does not exist");
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
         AV10note = new GeneXus.Programs.wallet.SdtNote(context);
         AV11noteFile = new GxFile(context.GetPhysicalPath());
         AV9messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
      }

      private string AV12noteFile_source ;
      private GeneXus.Programs.wallet.SdtNote aP1_note ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9messages ;
      private GxFile AV11noteFile ;
      private GeneXus.Programs.wallet.SdtNote AV10note ;
   }

}
