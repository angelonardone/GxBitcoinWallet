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
   public class readjsonencfile : GXProcedure
   {
      public readjsonencfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public readjsonencfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_fileName ,
                           out string aP1_error ,
                           out string aP2_textClear )
      {
         this.AV17fileName = aP0_fileName;
         this.AV8error = "" ;
         this.AV11textClear = "" ;
         initialize();
         ExecuteImpl();
         aP1_error=this.AV8error;
         aP2_textClear=this.AV11textClear;
      }

      public string executeUdp( string aP0_fileName ,
                                out string aP1_error )
      {
         execute(aP0_fileName, out aP1_error, out aP2_textClear);
         return AV11textClear ;
      }

      public void executeSubmit( string aP0_fileName ,
                                 out string aP1_error ,
                                 out string aP2_textClear )
      {
         this.AV17fileName = aP0_fileName;
         this.AV8error = "" ;
         this.AV11textClear = "" ;
         SubmitImpl();
         aP1_error=this.AV8error;
         aP2_textClear=this.AV11textClear;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWallet1 = AV14wallet;
         new GeneXus.Programs.wallet.getwallet(context ).execute( out  GXt_SdtWallet1) ;
         AV14wallet = GXt_SdtWallet1;
         AV8error = "";
         if ( ( StringUtil.StrCmp(AV14wallet.gxTpr_Wallettype, "BrainWallet") == 0 ) || ( StringUtil.StrCmp(AV14wallet.gxTpr_Wallettype, "ImportedWIF") == 0 ) )
         {
            GXt_SdtKeyInfo2 = AV10keyInfo;
            new GeneXus.Programs.wallet.getkey(context ).execute( out  GXt_SdtKeyInfo2) ;
            AV10keyInfo = GXt_SdtKeyInfo2;
            AV15privateKey = AV10keyInfo.gxTpr_Privatekey;
         }
         else
         {
            GXt_SdtExtKeyInfo3 = AV16extKeyInfo;
            new GeneXus.Programs.wallet.getextkey(context ).execute( out  GXt_SdtExtKeyInfo3) ;
            AV16extKeyInfo = GXt_SdtExtKeyInfo3;
            AV15privateKey = AV16extKeyInfo.gxTpr_Privatekey;
         }
         GXt_boolean4 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean4) ;
         GXt_boolean5 = false;
         new GeneXus.Programs.wallet.isosunix(context ).execute( out  GXt_boolean5) ;
         AV13transactionsFile.Source = AV14wallet.gxTpr_Walletbasedirectory+(GXt_boolean5 ? "/" : "\\")+StringUtil.Trim( AV17fileName);
         if ( AV13transactionsFile.Exists() )
         {
            AV12textEnc = AV13transactionsFile.ReadAllText("");
            GXt_char6 = AV8error;
            new GeneXus.Programs.nbitcoin.eccdecrypt(context ).execute(  AV15privateKey,  AV12textEnc, out  AV11textClear, out  GXt_char6) ;
            AV8error = GXt_char6;
            if ( StringUtil.StrCmp(AV11textClear, "_empty_") == 0 )
            {
               AV11textClear = "";
            }
         }
         else
         {
            new GeneXus.Programs.wallet.savejsonencfile(context ).execute(  "transactions.trn",  "_empty_", out  AV8error) ;
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
         AV11textClear = "";
         AV14wallet = new GeneXus.Programs.wallet.SdtWallet(context);
         GXt_SdtWallet1 = new GeneXus.Programs.wallet.SdtWallet(context);
         AV10keyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         GXt_SdtKeyInfo2 = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         AV15privateKey = "";
         AV16extKeyInfo = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         GXt_SdtExtKeyInfo3 = new GeneXus.Programs.nbitcoin.SdtExtKeyInfo(context);
         AV13transactionsFile = new GxFile(context.GetPhysicalPath());
         AV12textEnc = "";
         GXt_char6 = "";
         /* GeneXus formulas. */
      }

      private string AV17fileName ;
      private string AV8error ;
      private string AV15privateKey ;
      private string GXt_char6 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private string AV11textClear ;
      private string AV12textEnc ;
      private string aP1_error ;
      private string aP2_textClear ;
      private GxFile AV13transactionsFile ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV10keyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo GXt_SdtKeyInfo2 ;
      private GeneXus.Programs.wallet.SdtWallet AV14wallet ;
      private GeneXus.Programs.wallet.SdtWallet GXt_SdtWallet1 ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo AV16extKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtExtKeyInfo GXt_SdtExtKeyInfo3 ;
   }

}
