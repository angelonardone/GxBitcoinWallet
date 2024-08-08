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
namespace GeneXus.Programs.sudodb {
   public class unixtimetolocaldatetime : GXProcedure
   {
      public unixtimetolocaldatetime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("GeneXusUnanimo.UnanimoWeb", true);
      }

      public unixtimetolocaldatetime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_seconds ,
                           out DateTime aP1_localDateTime )
      {
         this.AV11seconds = aP0_seconds;
         this.AV8localDateTime = DateTime.MinValue ;
         initialize();
         ExecuteImpl();
         aP1_localDateTime=this.AV8localDateTime;
      }

      public DateTime executeUdp( long aP0_seconds )
      {
         execute(aP0_seconds, out aP1_localDateTime);
         return AV8localDateTime ;
      }

      public void executeSubmit( long aP0_seconds ,
                                 out DateTime aP1_localDateTime )
      {
         this.AV11seconds = aP0_seconds;
         this.AV8localDateTime = DateTime.MinValue ;
         SubmitImpl();
         aP1_localDateTime=this.AV8localDateTime;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* User Code */
          long miliseconds = AV11seconds;
         /* User Code */
          DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(miliseconds);
         /* User Code */
          DateTime dateTime = dateTimeOffset.UtcDateTime.ToLocalTime();
         /* User Code */
          AV8localDateTime = dateTime;
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
         AV8localDateTime = (DateTime)(DateTime.MinValue);
         /* GeneXus formulas. */
      }

      private long AV11seconds ;
      private DateTime AV8localDateTime ;
      private DateTime aP1_localDateTime ;
   }

}
