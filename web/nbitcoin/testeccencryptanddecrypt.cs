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
namespace GeneXus.Programs.nbitcoin {
   public class testeccencryptanddecrypt : GXProcedure
   {
      public testeccencryptanddecrypt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public testeccencryptanddecrypt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_originalClearText ,
                           out bool aP1_isVerified )
      {
         this.AV14originalClearText = aP0_originalClearText;
         this.AV11isVerified = false ;
         initialize();
         executePrivate();
         aP1_isVerified=this.AV11isVerified;
      }

      public bool executeUdp( string aP0_originalClearText )
      {
         execute(aP0_originalClearText, out aP1_isVerified);
         return AV11isVerified ;
      }

      public void executeSubmit( string aP0_originalClearText ,
                                 out bool aP1_isVerified )
      {
         testeccencryptanddecrypt objtesteccencryptanddecrypt;
         objtesteccencryptanddecrypt = new testeccencryptanddecrypt();
         objtesteccencryptanddecrypt.AV14originalClearText = aP0_originalClearText;
         objtesteccencryptanddecrypt.AV11isVerified = false ;
         objtesteccencryptanddecrypt.context.SetSubmitInitialConfig(context);
         objtesteccencryptanddecrypt.initialize();
         Submit( executePrivateCatch,objtesteccencryptanddecrypt);
         aP1_isVerified=this.AV11isVerified;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((testeccencryptanddecrypt)stateInfo).executePrivate();
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
         AV12keyCreate.gxTpr_Createkeytype = 10;
         AV12keyCreate.gxTpr_Networktype = "Main";
         GXt_char1 = AV10error;
         new GeneXus.Programs.nbitcoin.createkey(context ).execute(  AV12keyCreate,  "", out  AV13destination, out  GXt_char1) ;
         AV10error = GXt_char1;
         GXt_char1 = AV10error;
         new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV13destination.gxTpr_Publickey,  AV14originalClearText, out  AV9cypherText, out  GXt_char1) ;
         AV10error = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10error)) )
         {
            GXt_char1 = AV10error;
            new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV13destination.gxTpr_Privatekey,  AV9cypherText, out  AV8clearText, out  GXt_char1) ;
            AV10error = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10error)) )
            {
               if ( StringUtil.StrCmp(StringUtil.Trim( AV14originalClearText), StringUtil.Trim( AV8clearText)) == 0 )
               {
                  AV11isVerified = true;
               }
               else
               {
                  AV11isVerified = false;
               }
            }
            else
            {
               AV11isVerified = false;
            }
         }
         else
         {
            AV11isVerified = false;
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
         AV12keyCreate = new GeneXus.Programs.nbitcoin.SdtKeyCreate(context);
         AV10error = "";
         AV13destination = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV9cypherText = "";
         GXt_char1 = "";
         AV8clearText = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV10error ;
      private string GXt_char1 ;
      private bool AV11isVerified ;
      private string AV14originalClearText ;
      private string AV9cypherText ;
      private string AV8clearText ;
      private bool aP1_isVerified ;
      private GeneXus.Programs.nbitcoin.SdtKeyCreate AV12keyCreate ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV13destination ;
   }

}
