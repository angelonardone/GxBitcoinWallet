using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wallet {
   public class gxdomainconstants
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainconstants ()
      {
         domain["TempPassword"] = "Temp Password";
         domain["Wallet"] = "Wallet";
         domain["Key"] = "Key";
         domain["ExtendedKey"] = "Extended Key";
         domain["Wallets"] = "Wallet Directory";
         domain[".json"] = "Wallet File Extension";
         domain["*.json"] = "Wallet Directory Extension";
         domain["WalletAllLines"] = "Wallet All Lines";
         domain["*.note"] = "Notes Directory Extension";
         domain[".note"] = "Note File Extension";
         domain["Notes"] = "Notes";
         domain["Files"] = "Files";
         domain["*.enc"] = "Files Directory Extension";
         domain[".enc"] = "Files File Extension";
         domain["HistoryWithBalance"] = "History With Balance";
         domain["transactions.trn"] = "Transactions File";
         domain["AllKeys"] = "All Keys";
         domain["ReturnAddressess"] = "Return Addressess";
         domain["ReceiveAddressess"] = "Receive Addressess";
         domain["0.00001000"] = "Fee Used For Estimates";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["TempPassword"] = "TempPassword";
            domainMap["Wallet"] = "Wallet";
            domainMap["Key"] = "Key";
            domainMap["ExtendedKey"] = "ExtendedKey";
            domainMap["WalletDirectory"] = "Wallets";
            domainMap["WalletFileExtension"] = ".json";
            domainMap["WalletDirectoryExtension"] = "*.json";
            domainMap["WalletAllLines"] = "WalletAllLines";
            domainMap["NotesDirectoryExtension"] = "*.note";
            domainMap["NoteFileExtension"] = ".note";
            domainMap["Notes"] = "Notes";
            domainMap["Files"] = "Files";
            domainMap["FilesDirectoryExtension"] = "*.enc";
            domainMap["FilesFileExtension"] = ".enc";
            domainMap["HistoryWithBalance"] = "HistoryWithBalance";
            domainMap["TransactionsFile"] = "transactions.trn";
            domainMap["AllKeys"] = "AllKeys";
            domainMap["ReturnAddressess"] = "ReturnAddressess";
            domainMap["ReceiveAddressess"] = "ReceiveAddressess";
            domainMap["FeeUsedForEstimates"] = "0.00001000";
         }
         return (string)domainMap[key] ;
      }

   }

}
