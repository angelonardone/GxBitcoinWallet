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
   public class parse_serialized_extended_keyunittestdata : GXProcedure
   {
      public parse_serialized_extended_keyunittestdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public parse_serialized_extended_keyunittestdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT>( context, "parse_serialized_extended_keyUnitTestSDT", "GxBitcoinWallet") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> aP0_Gxm2rootcol )
      {
         parse_serialized_extended_keyunittestdata objparse_serialized_extended_keyunittestdata;
         objparse_serialized_extended_keyunittestdata = new parse_serialized_extended_keyunittestdata();
         objparse_serialized_extended_keyunittestdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT>( context, "parse_serialized_extended_keyUnitTestSDT", "GxBitcoinWallet") ;
         objparse_serialized_extended_keyunittestdata.context.SetSubmitInitialConfig(context);
         objparse_serialized_extended_keyunittestdata.initialize();
         Submit( executePrivateCatch,objparse_serialized_extended_keyunittestdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parse_serialized_extended_keyunittestdata)stateInfo).executePrivate();
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
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "1";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "xprv9s21ZrQH143K3jJ9HCQmAKPzGfDwGUDHfn8Jm7BFmtAizLdPaD9opjD3VDccfqyW4bKVvJya2M32NmT47s7uYM71PNWd1vQ6iBbhBRwHNin";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "xprv9s21ZrQH143K3jJ9HCQmAKPzGfDwGUDHfn8Jm7BFmtAizLdPaD9opjD3VDccfqyW4bKVvJya2M32NmT47s7uYM71PNWd1vQ6iBbhBRwHNin";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "Main";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "x";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "2";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "yprvABrGsX5C9janu2VG7ZCPNQVVSdNPD6CnateXYW599tYc3SScpsKNSnsBWRaCfkdRUESJfna8V1PaG44cqZXvLancFiD3bqDayufLZy1YDaw";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "xprv9s21ZrQH143K3jJ9HCQmAKPzGfDwGUDHfn8Jm7BFmtAizLdPaD9opjD3VDccfqyW4bKVvJya2M32NmT47s7uYM71PNWd1vQ6iBbhBRwHNin";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "Main";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "y";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "3";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "zprvAWgYBBk7JR8GkKgNwuz1aVazcbWq9iCHW1AkKty2XtvV6YFr5XUw4rXKXdXnffHLssZ7RGAgwfk89LgBZFww8pUD83uUBk35Fdiyxb9cqX5";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "xprv9s21ZrQH143K3jJ9HCQmAKPzGfDwGUDHfn8Jm7BFmtAizLdPaD9opjD3VDccfqyW4bKVvJya2M32NmT47s7uYM71PNWd1vQ6iBbhBRwHNin";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "Main";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "z";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "4";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "tprv8ZgxMBicQKsPeYXfwmGGKy1yane9VzFJ1L3RdXbiFrfCmwNUZaVZLUaVQPnGgDMpS2rGvQbLBhcpqczoF5TrMQNbv1ivgH89dHM7d7pMUCw";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "tprv8ZgxMBicQKsPeYXfwmGGKy1yane9VzFJ1L3RdXbiFrfCmwNUZaVZLUaVQPnGgDMpS2rGvQbLBhcpqczoF5TrMQNbv1ivgH89dHM7d7pMUCw";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "TestNet";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "x";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "5";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "uprv8tXDerPXZ1QsVqinn83tY47UkknbScEnvSZeQvVbds35q3BhpEf7xYEdRbjrg81jqfy5ftBteMyNiucMxmss9e4CnMRMGBwdu1Qm1mLUpEi";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "tprv8ZgxMBicQKsPeYXfwmGGKy1yane9VzFJ1L3RdXbiFrfCmwNUZaVZLUaVQPnGgDMpS2rGvQbLBhcpqczoF5TrMQNbv1ivgH89dHM7d7pMUCw";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "TestNet";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "y";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "6";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "vprv9DMUxX4ShgxMM8uucUqWk9Cyviw3PEEHqZ5sCKPV1sQxt8zw4tpgabtmSohSg2ffFK5tRMnT72KvcCDvgUHswsjoeh7mr6m8AjUQQLCE7pu";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "tprv8ZgxMBicQKsPeYXfwmGGKy1yane9VzFJ1L3RdXbiFrfCmwNUZaVZLUaVQPnGgDMpS2rGvQbLBhcpqczoF5TrMQNbv1ivgH89dHM7d7pMUCw";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "TestNet";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "z";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "7";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "vPrv9DMUxX4ShgxMM8uucUqWk9Cyviw3PEEHqZ5sCKPV1sQxt8zw4tpgabtmSohSg2ffFK5tRMnT72KvcCDvgUHswsjoeh7mr6m8AjUQQLCE7pu";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "Not recognized extended type";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "8";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "vprv9DMUxX4ShgxMM8uucUqWk9Cyviw3PEEHqZ5sCKt8zw4tpgabtmSohSg2ffFK5tRMnT72KvcCDvgUHswsjoeh7mr6m8AjUQQLCE7pu";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "TestNet";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "z";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "Invalid hash of the base 58 string";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "9";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "xpub661MyMwAqRbcEYS8w7XLSVeEsBXy79zSzH1J8vCdxAZningWLdN3zgtU6LBpB85b3D2yc8sfvZU521AAwdZafEz7mnzBBsz4wKY5fTtTQBm";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "Main";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "x";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "Invalid BitcoinExtPubKey";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "10";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "xpub661MyMwAqRbcEYS8w7XLSVeEsBXy79zSzH1J8vCdxAZningWLdN3zgtU6Txnt3siSujt9RCVYsx4qHZGc62TG4McvMGcAUjeuwZdduYEvFn";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "Main";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "x";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "Invalid BitcoinExtPubKey";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         Gxm2rootcol.Add(Gxm1parse_serialized_extended_keyunittestsdt, 0);
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Testcaseid = "11";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_In_extended_key = "vpub5UzmHJe4YPMzYL3MXiy4dvv5YPAGRU9iii8EHrfwLw2nfdMG9wVUfKi4pFeeuHbDhQqvdAh1gUZt9e6UbNfM8VrNaja2XsEd3MZfHRqDSSV";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedout_extended_key = "tpubD92vQsoaZ2QQWicSedXQG2STDSYpJ6dn6ZkyDCWrSrYSX7eRjUfh3thB6hecRbrJJbcSjhQ18u72cPpDRdLccQfsP1iBPDXqAmHMpcaQGJC";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgout_extended_key = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectednetworktype = "TestNet";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectedextendedkeytype = "z";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgextendedkeytype = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Expectederror = "";
         Gxm1parse_serialized_extended_keyunittestsdt.gxTpr_Msgerror = "";
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
         Gxm1parse_serialized_extended_keyunittestsdt = new GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT> Gxm2rootcol ;
      private GeneXus.Programs.nbitcoin.Sdtparse_serialized_extended_keyUnitTestSDT Gxm1parse_serialized_extended_keyunittestsdt ;
   }

}
