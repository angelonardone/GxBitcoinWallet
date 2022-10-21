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
namespace GeneXus.Programs.nbitcoin.qbitninja {
   public class retnumtransonaddress : GXProcedure
   {
      public retnumtransonaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public retnumtransonaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.nbitcoin.SdtKeyInfo aP0_keyInfo ,
                           out long aP1_transactionsCount ,
                           out string aP2_error )
      {
         this.AV8keyInfo = aP0_keyInfo;
         this.AV10transactionsCount = 0 ;
         this.AV11error = "" ;
         initialize();
         executePrivate();
         aP1_transactionsCount=this.AV10transactionsCount;
         aP2_error=this.AV11error;
      }

      public string executeUdp( GeneXus.Programs.nbitcoin.SdtKeyInfo aP0_keyInfo ,
                                out long aP1_transactionsCount )
      {
         execute(aP0_keyInfo, out aP1_transactionsCount, out aP2_error);
         return AV11error ;
      }

      public void executeSubmit( GeneXus.Programs.nbitcoin.SdtKeyInfo aP0_keyInfo ,
                                 out long aP1_transactionsCount ,
                                 out string aP2_error )
      {
         retnumtransonaddress objretnumtransonaddress;
         objretnumtransonaddress = new retnumtransonaddress();
         objretnumtransonaddress.AV8keyInfo = aP0_keyInfo;
         objretnumtransonaddress.AV10transactionsCount = 0 ;
         objretnumtransonaddress.AV11error = "" ;
         objretnumtransonaddress.context.SetSubmitInitialConfig(context);
         objretnumtransonaddress.initialize();
         Submit( executePrivateCatch,objretnumtransonaddress);
         aP1_transactionsCount=this.AV10transactionsCount;
         aP2_error=this.AV11error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((retnumtransonaddress)stateInfo).executePrivate();
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
         /* User Code */
          AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>  {  if (args.Name.StartsWith("Newtonsoft.Json")) return System.Reflection.Assembly.LoadFrom(System.IO.Path.Combine(FileUtil.GetStartupDirectory(), "Newtonsoft.Json.dll"));
         /* User Code */
            else return null; };
         AV11error = "";
         AV9publicKeyText = StringUtil.Trim( AV8keyInfo.gxTpr_Address);
         /* User Code */
          try
         /* User Code */
         		{
         /* User Code */
          var mainNetAddress = NBitcoin.BitcoinAddress.Create(AV9publicKeyText, NBitcoin.Network.Main);
         /* User Code */
          var client = new QBitNinja.Client.QBitNinjaClient(NBitcoin.Network.Main);
         /* User Code */
          var balance = client.GetBalance(mainNetAddress, false).Result;
         /* User Code */
          AV10transactionsCount = balance.Operations.Count;
         /* User Code */
         		}
         /* User Code */
         		catch (Exception ex)
         /* User Code */
         		{
         /* User Code */
         			AV11error = ex.Message.ToString();
         /* User Code */
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
         AV11error = "";
         AV9publicKeyText = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV10transactionsCount ;
      private string AV11error ;
      private string AV9publicKeyText ;
      private long aP1_transactionsCount ;
      private string aP2_error ;
      private GeneXus.Programs.nbitcoin.SdtKeyInfo AV8keyInfo ;
   }

}
