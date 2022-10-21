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
   public class retbalanceonaddress : GXProcedure
   {
      public retbalanceonaddress( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public retbalanceonaddress( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_publicKeyText ,
                           string aP1_networkType ,
                           out long aP2_transactionsCount ,
                           out decimal aP3_totalBalance ,
                           out string aP4_error )
      {
         this.AV11publicKeyText = aP0_publicKeyText;
         this.AV10networkType = aP1_networkType;
         this.AV13transactionsCount = 0 ;
         this.AV12totalBalance = 0 ;
         this.AV8error = "" ;
         initialize();
         executePrivate();
         aP2_transactionsCount=this.AV13transactionsCount;
         aP3_totalBalance=this.AV12totalBalance;
         aP4_error=this.AV8error;
      }

      public string executeUdp( string aP0_publicKeyText ,
                                string aP1_networkType ,
                                out long aP2_transactionsCount ,
                                out decimal aP3_totalBalance )
      {
         execute(aP0_publicKeyText, aP1_networkType, out aP2_transactionsCount, out aP3_totalBalance, out aP4_error);
         return AV8error ;
      }

      public void executeSubmit( string aP0_publicKeyText ,
                                 string aP1_networkType ,
                                 out long aP2_transactionsCount ,
                                 out decimal aP3_totalBalance ,
                                 out string aP4_error )
      {
         retbalanceonaddress objretbalanceonaddress;
         objretbalanceonaddress = new retbalanceonaddress();
         objretbalanceonaddress.AV11publicKeyText = aP0_publicKeyText;
         objretbalanceonaddress.AV10networkType = aP1_networkType;
         objretbalanceonaddress.AV13transactionsCount = 0 ;
         objretbalanceonaddress.AV12totalBalance = 0 ;
         objretbalanceonaddress.AV8error = "" ;
         objretbalanceonaddress.context.SetSubmitInitialConfig(context);
         objretbalanceonaddress.initialize();
         Submit( executePrivateCatch,objretbalanceonaddress);
         aP2_transactionsCount=this.AV13transactionsCount;
         aP3_totalBalance=this.AV12totalBalance;
         aP4_error=this.AV8error;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((retbalanceonaddress)stateInfo).executePrivate();
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
         AV8error = "";
         /* User Code */
          decimal totalBalance = 0;
         /* User Code */
          QBitNinja.Client.QBitNinjaClient client;
         /* User Code */
          NBitcoin.BitcoinAddress netAddress;
         /* User Code */
          try
         /* User Code */
         		{
         if ( StringUtil.StrCmp(AV10networkType, "Main") == 0 )
         {
            /* User Code */
             netAddress = NBitcoin.BitcoinAddress.Create(AV11publicKeyText, NBitcoin.Network.Main);
            /* User Code */
             client = new QBitNinja.Client.QBitNinjaClient(NBitcoin.Network.Main);
         }
         else
         {
            /* User Code */
             netAddress = NBitcoin.BitcoinAddress.Create(AV11publicKeyText, NBitcoin.Network.TestNet);
            /* User Code */
             client = new QBitNinja.Client.QBitNinjaClient(NBitcoin.Network.TestNet);
         }
         /* User Code */
          var balance = client.GetBalance(netAddress, false).Result;
         /* User Code */
          AV13transactionsCount = balance.Operations.Count;
         /* User Code */
          for (int i = 0; i < balance.Operations.Count; i++)
         /* User Code */
          {
         /* User Code */
          totalBalance +=  balance.Operations[i].Amount.ToDecimal(NBitcoin.MoneyUnit.BTC);
         /* User Code */
          }
         /* User Code */
          AV12totalBalance = totalBalance;
         /* User Code */
         		}
         /* User Code */
         		catch (Exception ex)
         /* User Code */
         		{
         /* User Code */
         			AV8error = ex.Message.ToString();
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
         AV8error = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV13transactionsCount ;
      private decimal AV12totalBalance ;
      private string AV11publicKeyText ;
      private string AV10networkType ;
      private string AV8error ;
      private long aP2_transactionsCount ;
      private decimal aP3_totalBalance ;
      private string aP4_error ;
   }

}
