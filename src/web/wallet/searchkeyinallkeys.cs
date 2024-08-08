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
   public class searchkeyinallkeys : GXProcedure
   {
      public searchkeyinallkeys( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public searchkeyinallkeys( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_address ,
                           GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                           out GeneXus.Programs.nbitcoin.SdtKeyInfo aP2_oneKeyInfo ,
                           out bool aP3_found )
      {
         this.AV10address = aP0_address;
         this.AV8allKeyInfo = aP1_allKeyInfo;
         this.AV9oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context) ;
         this.AV11found = false ;
         initialize();
         ExecuteImpl();
         aP2_oneKeyInfo=this.AV9oneKeyInfo;
         aP3_found=this.AV11found;
      }

      public bool executeUdp( string aP0_address ,
                              GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                              out GeneXus.Programs.nbitcoin.SdtKeyInfo aP2_oneKeyInfo )
      {
         execute(aP0_address, aP1_allKeyInfo, out aP2_oneKeyInfo, out aP3_found);
         return AV11found ;
      }

      public void executeSubmit( string aP0_address ,
                                 GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> aP1_allKeyInfo ,
                                 out GeneXus.Programs.nbitcoin.SdtKeyInfo aP2_oneKeyInfo ,
                                 out bool aP3_found )
      {
         this.AV10address = aP0_address;
         this.AV8allKeyInfo = aP1_allKeyInfo;
         this.AV9oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context) ;
         this.AV11found = false ;
         SubmitImpl();
         aP2_oneKeyInfo=this.AV9oneKeyInfo;
         aP3_found=this.AV11found;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11found = false;
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8allKeyInfo.Count )
         {
            AV9oneKeyInfo = ((GeneXus.Programs.nbitcoin.SdtKeyInfo)AV8allKeyInfo.Item(AV12GXV1));
            if ( StringUtil.StrCmp(StringUtil.Trim( AV9oneKeyInfo.gxTpr_Address), StringUtil.Trim( AV10address)) == 0 )
            {
               AV11found = true;
               if (true) break;
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV9oneKeyInfo = new GeneXus.Programs.nbitcoin.SdtKeyInfo(context);
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV10address ;
      private bool AV11found ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo aP2_oneKeyInfo ;
      private bool aP3_found ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.SdtKeyInfo> AV8allKeyInfo ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV9oneKeyInfo ;
   }

}
