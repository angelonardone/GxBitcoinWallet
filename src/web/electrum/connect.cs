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
namespace GeneXus.Programs.electrum {
   public class connect : GXProcedure
   {
      public connect( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public connect( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_error )
      {
         this.AV12error = "" ;
         initialize();
         ExecuteImpl();
         aP0_error=this.AV12error;
      }

      public string executeUdp( )
      {
         execute(out aP0_error);
         return AV12error ;
      }

      public void executeSubmit( out string aP0_error )
      {
         this.AV12error = "" ;
         SubmitImpl();
         aP0_error=this.AV12error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtConnection1 = AV20Connection;
         new GeneXus.Programs.electrum.getelectrumconnid(context ).execute( out  GXt_SdtConnection1) ;
         AV20Connection = GXt_SdtConnection1;
         if ( (Guid.Empty==AV20Connection.gxTpr_Connectionid) )
         {
            GXt_SdtConnectionParameters_ConnectionParametersItem2 = AV21walletConnParameter;
            new GeneXus.Programs.electrum.getelectrumconfigfornetworktype(context ).execute( out  GXt_SdtConnectionParameters_ConnectionParametersItem2) ;
            AV21walletConnParameter = GXt_SdtConnectionParameters_ConnectionParametersItem2;
            if ( ( StringUtil.StrCmp(AV21walletConnParameter.gxTpr_Connectiontype, "ws") == 0 ) && ! AV21walletConnParameter.gxTpr_Secure )
            {
               AV22wsUrl = "ws://" + StringUtil.Trim( AV21walletConnParameter.gxTpr_Hostname) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV21walletConnParameter.gxTpr_Port), 6, 0));
               AV17OperationResult = GxInternetLibWs.connect(AV22wsUrl, "receiveFromElectrum", AV21walletConnParameter.gxTpr_Timeoutmiliseconds);
            }
            else if ( ( StringUtil.StrCmp(AV21walletConnParameter.gxTpr_Connectiontype, "ws") == 0 ) && AV21walletConnParameter.gxTpr_Secure )
            {
               AV22wsUrl = "wss://" + StringUtil.Trim( AV21walletConnParameter.gxTpr_Hostname) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV21walletConnParameter.gxTpr_Port), 6, 0));
               AV17OperationResult = GxInternetLibWs.connect(AV22wsUrl, "receiveFromElectrum", AV21walletConnParameter.gxTpr_Timeoutmiliseconds);
            }
            else if ( StringUtil.StrCmp(AV21walletConnParameter.gxTpr_Connectiontype, "tcp") == 0 )
            {
               AV17OperationResult = GxInternetLibTcp.connect(StringUtil.Trim( AV21walletConnParameter.gxTpr_Hostname), AV21walletConnParameter.gxTpr_Port, "receiveFromElectrum", AV21walletConnParameter.gxTpr_Secure, AV21walletConnParameter.gxTpr_Timeoutmiliseconds);
            }
            else
            {
               AV12error = "We couldn't recognize the Connection Type on the Electrum config file";
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12error)) )
            {
               if ( AV17OperationResult.gxTpr_Success )
               {
                  AV20Connection.gxTpr_Connectionid = AV17OperationResult.gxTpr_Connectionid;
                  AV20Connection.gxTpr_Connectiontype = AV21walletConnParameter.gxTpr_Connectiontype;
                  new GeneXus.Programs.electrum.setelectrumconnid(context ).execute(  AV20Connection) ;
               }
               else
               {
                  AV12error = AV17OperationResult.gxTpr_Errormessage;
               }
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
         AV12error = "";
         AV20Connection = new GeneXus.Programs.electrum.SdtConnection(context);
         GXt_SdtConnection1 = new GeneXus.Programs.electrum.SdtConnection(context);
         AV21walletConnParameter = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context);
         GXt_SdtConnectionParameters_ConnectionParametersItem2 = new GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem(context);
         AV22wsUrl = "";
         AV17OperationResult = new GeneXus.Programs.gxinternetlib.SdtOperationResult(context);
         GxInternetLibWs = new GeneXus.Programs.gxinternetlib.SdtGxInternetLibWs(context);
         GxInternetLibTcp = new GeneXus.Programs.gxinternetlib.SdtGxInternetLibTcp(context);
         /* GeneXus formulas. */
      }

      private string AV12error ;
      private string AV22wsUrl ;
      private GeneXus.Programs.gxinternetlib.SdtGxInternetLibTcp GxInternetLibTcp ;
      private GeneXus.Programs.gxinternetlib.SdtGxInternetLibWs GxInternetLibWs ;
      private string aP0_error ;
      private GeneXus.Programs.gxinternetlib.SdtOperationResult AV17OperationResult ;
      private GeneXus.Programs.electrum.SdtConnection AV20Connection ;
      private GeneXus.Programs.electrum.SdtConnection GXt_SdtConnection1 ;
      private GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem AV21walletConnParameter ;
      private GeneXus.Programs.electrum.SdtConnectionParameters_ConnectionParametersItem GXt_SdtConnectionParameters_ConnectionParametersItem2 ;
   }

}
