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
namespace GeneXus.Programs {
   public class areceivefromelectrum : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new areceivefromelectrum().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_key = new Guid()  ;
         string aP1_topic = new string(' ',0)  ;
         string aP2_message = new string(' ',0)  ;
         DateTime aP3_datetime = new DateTime()  ;
         if ( 0 < args.Length )
         {
            aP0_key=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_key=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_topic=((string)(args[1]));
         }
         else
         {
            aP1_topic="";
         }
         if ( 2 < args.Length )
         {
            aP2_message=((string)(args[2]));
         }
         else
         {
            aP2_message="";
         }
         if ( 3 < args.Length )
         {
            aP3_datetime=((DateTime)(context.localUtil.CToT( (string)(args[3]), 1)));
         }
         else
         {
            aP3_datetime=DateTime.MinValue;
         }
         execute(aP0_key, aP1_topic, aP2_message, aP3_datetime);
         return GX.GXRuntime.ExitCode ;
      }

      public areceivefromelectrum( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public areceivefromelectrum( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_key ,
                           string aP1_topic ,
                           string aP2_message ,
                           DateTime aP3_datetime )
      {
         this.AV12key = aP0_key;
         this.AV14topic = aP1_topic;
         this.AV11message = aP2_message;
         this.AV13datetime = aP3_datetime;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_key ,
                                 string aP1_topic ,
                                 string aP2_message ,
                                 DateTime aP3_datetime )
      {
         this.AV12key = aP0_key;
         this.AV14topic = aP1_topic;
         this.AV11message = aP2_message;
         this.AV13datetime = aP3_datetime;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16electrumResponse.FromJSonString(AV11message, null);
         if ( StringUtil.Len( AV16electrumResponse.gxTpr_Result) > 10 )
         {
            AV10notificationInfo.gxTpr_Id = AV12key.ToString();
            AV10notificationInfo.gxTpr_Message = AV11message;
            AV9ServerSocket.broadcast( AV10notificationInfo);
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
         AV16electrumResponse = new GeneXus.Programs.electrum.SdtelectrumResponse(context);
         AV10notificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV9ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         /* GeneXus formulas. */
      }

      private string AV14topic ;
      private DateTime AV13datetime ;
      private string AV11message ;
      private Guid AV12key ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV10notificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV9ServerSocket ;
      private GeneXus.Programs.electrum.SdtelectrumResponse AV16electrumResponse ;
   }

}
