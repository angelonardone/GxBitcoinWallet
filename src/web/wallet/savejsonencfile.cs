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
   public class savejsonencfile : GXProcedure
   {
      public savejsonencfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public savejsonencfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_fileName ,
                           string aP1_clearText ,
                           out string aP2_error )
      {
         this.AV18fileName = aP0_fileName;
         this.AV17clearText = aP1_clearText;
         this.AV8error = "" ;
         initialize();
         ExecuteImpl();
         aP2_error=this.AV8error;
      }

      public string executeUdp( string aP0_fileName ,
                                string aP1_clearText )
      {
         execute(aP0_fileName, aP1_clearText, out aP2_error);
         return AV8error ;
      }

      public void executeSubmit( string aP0_fileName ,
                                 string aP1_clearText ,
                                 out string aP2_error )
      {
         this.AV18fileName = aP0_fileName;
         this.AV17clearText = aP1_clearText;
         this.AV8error = "" ;
         SubmitImpl();
         aP2_error=this.AV8error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWallet1 = AV14wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV14wallet = GXt_SdtWallet1;
         if ( ( StringUtil.StrCmp(AV14wallet.gxTpr_Wallettype, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV14wallet.gxTpr_Wallettype, "ImportedWIF") == 0 ) )
         {
            GXt_SdtKeyInfo2 = AV10keyInfo;
            new GeneXus.Programs.wallet.getkey(context ).execute( out  GXt_SdtKeyInfo2) ;
            AV10keyInfo = GXt_SdtKeyInfo2;
            AV15publicKey = AV10keyInfo.gxTpr_Publickey;
         }
         else
         {
            GXt_SdtExtKeyInfo3 = AV16extKeyInfo;
            new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo3) ;
            AV16extKeyInfo = GXt_SdtExtKeyInfo3;
            AV15publicKey = AV16extKeyInfo.gxTpr_Publickey;
         }
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         GXt_boolean5 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
         AV13transactionsFile.Source = AV14wallet.gxTpr_Walletbasedirectory+(GXt_boolean5 ? "/" : "\\")+StringUtil.Trim( AV18fileName);
         GXt_char6 = AV8error;
         new GeneXus.Programs.nbitcoin.eccenctrypt(context ).execute(  AV15publicKey,  AV17clearText, out  AV12textEnc, out  GXt_char6) ;
         AV8error = GXt_char6;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8error)) )
         {
            if ( AV13transactionsFile.Exists() )
            {
               AV13transactionsFile.WriteAllText(AV12textEnc, "");
            }
            else
            {
               AV13transactionsFile.WriteAllText(AV12textEnc, "");
            }
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
         AV8error = "";
         AV14wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV10keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         GXt_SdtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV15publicKey = "";
         AV16extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtExtKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV13transactionsFile = new GxFile(context.GetPhysicalPath());
         GXt_char6 = "";
         AV12textEnc = "";
         /* GeneXus formulas. */
      }

      private string AV18fileName ;
      private string AV8error ;
      private string AV15publicKey ;
      private string GXt_char6 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private string AV17clearText ;
      private string AV12textEnc ;
      private string aP2_error ;
      private GxFile AV13transactionsFile ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV10keyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo GXt_SdtKeyInfo2 ;
      private GeneXus.Programs.wallet.SdtWallet AV14wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV16extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo3 ;
   }

}
